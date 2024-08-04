using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using MoreMountains.Tools;
using UniRx;
using State = StateMachine<Manager.BattleManager.BattleCore>.State;

namespace Manager.BattleManager
{
    public partial class BattleCore
    {
        public class BattleResultState : StateMachine<BattleCore>.State
        {
            //順位に応じた報酬をもらう処理を行う
            //報酬もらった後はmainシーンに戻る

            private BattleResultView battleResultView;
            private CancellationTokenSource cts;

            protected override void OnEnter(StateMachine<BattleCore>.State prevState)
            {
                Initialize();
                OnSubscribe();
            }

            protected override void OnExit(StateMachine<BattleCore>.State nextState)
            {
                Cancel();
                battleResultView.gameObject.SetActive(false);
            }

            private void Initialize()
            {
                cts = new CancellationTokenSource();
                battleResultView = Owner.battleResultView;
                battleResultView.gameObject.SetActive(true);
            }

            private void OnSubscribe()
            {
                battleResultView.OkButtonObservable
                    .Subscribe(_ => { MMSceneLoadingManager.LoadScene(GameCommonData.TitleScene); })
                    .AddTo(cts.Token);
            }

            private void Cancel()
            {
                if (cts == null)
                {
                    return;
                }

                cts.Cancel();
                cts.Dispose();
                cts = null;
            }
        }
    }
}