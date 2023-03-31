using Manager.DataManager;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class MissionState : State
        {
            private MissionDataManager _missionDataManager;

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            private void Initialize()
            {
                _missionDataManager = Owner._missionDataManager;
            }
        }
    }
}