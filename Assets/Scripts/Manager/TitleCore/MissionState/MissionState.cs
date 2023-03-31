using System.Collections.Generic;
using Assets.Scripts.Common.Data;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using UI.Common;
using UnityEngine;
using UnityEngine.UI;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class MissionState : State
        {
            private const string CanGet = "Get";
            private const string InProgress = "In Progress";
            private const string ProgressBarText = " <#b3bedb>/ 100";
            private MissionDataManager _missionDataManager;
            private UserDataManager _userDataManager;
            private CatalogDataManager _catalogDataManager;
            private MainView _mainView;
            private MissionView _missionView;
            private UIAnimation _uiAnimation;
            private Sprite _coinSprite;
            private Sprite _gemSprite;
            private readonly List<MissionGrid> _missionGrids = new();


            protected override void OnEnter(State prevState)
            {
                Initialize().Forget();
            }

            protected override void OnExit(State nextState)
            {
                DestroyMissionGrids();
            }


            private async UniTask Initialize()
            {
                _missionDataManager = Owner._missionDataManager;
                _userDataManager = Owner._userDataManager;
                _catalogDataManager = Owner._catalogDataManager;
                _mainView = Owner.mainView;
                _missionView = Owner.missionView;
                _uiAnimation = Owner._uiAnimation;
                await GenerateMissionGrid();
                Owner.DisableTitleGameObject();
                OpenMissionPanel().Forget();
            }

            private async UniTask OpenMissionPanel()
            {
                var panel = _mainView.MissionGameObject.transform;
                panel.localScale = Vector3.zero;
                panel.gameObject.SetActive(true);
                await _uiAnimation.Open(panel, GameCommonData.OpenDuration);
            }

            private async UniTask GenerateMissionGrid()
            {
                var coinSprite = await Resources.LoadAsync<Sprite>(GameCommonData.VirtualCurrencySpritePath + "coin");
                _coinSprite = (Sprite)coinSprite;
                var gemSprite = await Resources.LoadAsync<Sprite>(GameCommonData.VirtualCurrencySpritePath + "gem");
                _gemSprite = (Sprite)gemSprite;
                var missionProgressDatum = _userDataManager.GetMissionProgressDatum();
                foreach (var data in missionProgressDatum)
                {
                    var missionData = _missionDataManager.GetMissionData(data.Key);
                    var rewardData = _catalogDataManager.GetAddVirtualCurrencyItemData(missionData.rewardId);
                    var missionGrid = Instantiate(_missionView.missionGrid, _missionView.gridParent);
                    _missionGrids.Add(missionGrid);
                    missionGrid.progressSlider.maxValue = GameCommonData.MaxMissionProgress;
                    missionGrid.progressSlider.value = data.Value;
                    missionGrid.progressText.text = data.Value + ProgressBarText;
                    missionGrid.missionText.text = missionData.explanation;
                    missionGrid.buttonText.text = data.Value >= GameCommonData.MaxMissionProgress ? CanGet : InProgress;
                    missionGrid.getButton.enabled = data.Value >= GameCommonData.MaxMissionProgress;
                    if (rewardData == null)
                    {
                        continue;
                    }

                    missionGrid.rewardText.text = rewardData.price.ToString("D");
                    missionGrid.rewardImage.sprite = rewardData.vc == GameCommonData.CoinKey ? _coinSprite : _gemSprite;
                }
            }

            private void DestroyMissionGrids()
            {
                foreach (var missionGrid in _missionGrids)
                {
                    Destroy(missionGrid);
                }

                _missionGrids.Clear();
            }
        }
    }
}