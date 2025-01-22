using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using MoreMountains.Tools;
using UniRx;

namespace Manager.BattleManager
{
    public partial class BattleCore
    {
        public class BattleResultState : StateMachine<BattleCore>.State
        {
            //順位に応じた報酬をもらう処理を行う
            //報酬もらった後はmainシーンに戻る

            private BattleResultView _BattleResultView => Owner.battleResultView;
            private CancellationTokenSource _cts;

            protected override void OnEnter(StateMachine<BattleCore>.State prevState)
            {
                Initialize();
                OnSubscribe();
            }

            protected override void OnExit(StateMachine<BattleCore>.State nextState)
            {
                Cancel();
                _BattleResultView.gameObject.SetActive(false);
            }

            private void Initialize()
            {
                _cts = new CancellationTokenSource();
                _BattleResultView.gameObject.SetActive(true);
            }

            private void OnSubscribe()
            {
                _BattleResultView.OkButtonObservable
                    .Subscribe(_ => { MMSceneLoadingManager.LoadScene(GameCommonData.TitleScene); })
                    .AddTo(_cts.Token);
            }

            private void Cancel()
            {
                if (_cts == null)
                {
                    return;
                }

                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
            }
        }
    }
}