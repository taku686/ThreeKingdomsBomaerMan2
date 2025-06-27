using System.Collections.Generic;
using Common.Data;
using Cysharp.Threading.Tasks;

/// <summary>
/// ステートマシン
/// </summary>
public class StateMachine<TOwner>
{
    /// <summary>
    /// ステートを表すクラス
    /// </summary>
    public abstract class State
    {
        /// <summary>
        /// このステートを管理しているステートマシン
        /// </summary>
        protected StateMachine<TOwner> StateMachine => stateMachine;

        internal StateMachine<TOwner> stateMachine;

        /// <summary>
        /// 遷移の一覧
        /// </summary>
        internal Dictionary<int, State> transitions = new Dictionary<int, State>();

        /// <summary>
        /// このステートのオーナー
        /// </summary>
        protected TOwner Owner => stateMachine._Owner;

        /// <summary>
        /// ステート開始
        /// </summary>
        internal void Enter(State prevState)
        {
            OnEnter(prevState);
        }

        internal async UniTask AsyncEnter(State prevState)
        {
            await OnAsyncEnter(prevState);
        }

        /// <summary>
        /// ステートを開始した時に呼ばれる
        /// </summary>
        protected virtual void OnEnter(State prevState)
        {
        }

        protected virtual async UniTask OnAsyncEnter(State prevState)
        {
        }

        /// <summary>
        /// ステート更新
        /// </summary>
        internal void Update()
        {
            OnUpdate();
        }

        /// <summary>
        /// 毎フレーム呼ばれる
        /// </summary>
        protected virtual void OnUpdate()
        {
        }

        internal void FixedUpdate()
        {
            OnFixedUpdate();
        }

        protected virtual void OnFixedUpdate()
        {
        }

        /// <summary>
        /// ステート終了
        /// </summary>
        internal void Exit(State nextState)
        {
            OnExit(nextState);
        }

        internal async UniTask OnAsyncExit(State nextState)
        {
        }

        /// <summary>
        /// ステートを終了した時に呼ばれる
        /// </summary>
        protected virtual void OnExit(State nextState)
        {
        }

        /// <summary>
        /// ステート終了
        /// </summary>
        internal void LateExit(State nextState)
        {
            OnLateExit(nextState);
        }

        /// <summary>
        /// ステートを終了した時に呼ばれる
        /// </summary>
        protected virtual void OnLateExit(State nextState)
        {
        }
    }

    /// <summary>
    /// どのステートからでも特定のステートへ遷移できるようにするための仮想ステート
    /// </summary>
    public sealed class AnyState : State
    {
    }

    /// <summary>
    /// このステートマシンのオーナー
    /// </summary>
    public TOwner _Owner { get; }

    /// <summary>
    /// 現在のステート
    /// </summary>
    public State _CurrentState { get; set; }

    public int _PreviousState { get; set; }

    // ステートリスト
    private readonly LinkedList<State> _states = new();

    /// <summary>
    /// ステートマシンを初期化する
    /// </summary>
    /// <param name="owner">ステートマシンのオーナー</param>
    public StateMachine(TOwner owner)
    {
        _Owner = owner;
    }

    /// <summary>
    /// ステートを追加する（ジェネリック版）
    /// </summary>
    public T Add<T>() where T : State, new()
    {
        var state = new T
        {
            stateMachine = this
        };
        _states.AddLast(state);
        return state;
    }

    /// <summary>
    /// 特定のステートを取得、なければ生成する
    /// </summary>
    public T GetOrAddState<T>() where T : State, new()
    {
        foreach (var state in _states)
        {
            if (state is T result)
            {
                return result;
            }
        }

        return Add<T>();
    }

    /// <summary>
    /// 遷移を定義する
    /// </summary>
    /// <param name="eventId">イベントID</param>
    public void AddTransition<TFrom, TTo>(int eventId)
        where TFrom : State, new()
        where TTo : State, new()
    {
        var from = GetOrAddState<TFrom>();
        if (from.transitions.ContainsKey(eventId))
        {
            // 同じイベントIDの遷移を定義済
            throw new System.ArgumentException(
                $"ステート'{nameof(TFrom)}'に対してイベントID'{eventId.ToString()}'の遷移は定義済です");
        }

        var to = GetOrAddState<TTo>();
        from.transitions.Add(eventId, to);
    }

    /// <summary>
    /// どのステートからでも特定のステートへ遷移できるイベントを追加する
    /// </summary>
    /// <param name="eventId">イベントID</param>
    public void AddAnyTransition<TTo>(int eventId) where TTo : State, new()
    {
        AddTransition<AnyState, TTo>(eventId);
    }

    /// <summary>
    /// ステートマシンの実行を開始する（ジェネリック版）
    /// </summary>
    public void Start<TFirst>() where TFirst : State, new()
    {
        Start(GetOrAddState<TFirst>());
    }

    /// <summary>
    /// ステートマシンの実行を開始する
    /// </summary>
    /// <param name="firstState">起動時のステート</param>
    /// <param name="param">パラメータ</param>
    private void Start(State firstState)
    {
        _CurrentState = firstState;
        _CurrentState.Enter(null);
        _CurrentState.AsyncEnter(null).Forget();
    }

    /// <summary>
    /// ステートを更新する
    /// </summary>
    public void Update()
    {
        _CurrentState.Update();
    }

    public void FixedUpdate()
    {
        _CurrentState.FixedUpdate();
    }

    /// <summary>
    /// イベントを発行する
    /// </summary>
    /// <param name="eventId">イベントID</param>
    /// <param name="prevEventId"></param>
    public void Dispatch(int eventId, int prevEventId = GameCommonData.InvalidNumber)
    {
        State to;
        if (!_CurrentState.transitions.TryGetValue(eventId, out to))
        {
            if (!GetOrAddState<AnyState>().transitions.TryGetValue(eventId, out to))
            {
                // イベントに対応する遷移が見つからなかった
                return;
            }
        }

        _PreviousState = prevEventId;

        Change(to).Forget();
    }

    /// <summary>
    /// ステートを変更する
    /// </summary>
    /// <param name="nextState">遷移先のステート</param>
    private async UniTask Change(State nextState)
    {
        _CurrentState.Exit(nextState);
        await _CurrentState.OnAsyncExit(nextState);
        nextState.Enter(_CurrentState);
        await nextState.AsyncEnter(_CurrentState);
        _CurrentState.LateExit(nextState);
        _CurrentState = nextState;
    }
}