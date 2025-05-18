using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UI.Common;
using UI.Common.Popup;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Title
{
    public class AbnormalConditionPopup : PopupBase
    {
        [SerializeField] private Transform _abnormalConditionParent;
        [SerializeField] private AbnormalConditionGrid _abnormalConditionGrid;
        [SerializeField] private Button _closeButton;
        [Inject] private UIAnimation _uiAnimation;
        private readonly List<AbnormalConditionGrid> _abnormalConditionGrids = new();
        private Action<bool> _setActivePanelAction;
        private IObservable<Unit> _onClickCancel;
        public IObservable<Unit> _OnClickButton => _onClickCancel;

        public async UniTask Open(ViewModel viewModel)
        {
            ApplyViewModel(viewModel);
            _onClickCancel = _closeButton
                .OnClickAsObservable()
                .Take(1)
                .SelectMany(_ => OnClickButtonAnimation(_closeButton).ToObservable())
                .SelectMany(_ => Close().ToObservable())
                .Select(_ => Unit.Default);

            await base.Open(null);
        }

        private async UniTask OnClickButtonAnimation(Button button)
        {
            await _uiAnimation.ClickScaleColor(button.gameObject).ToUniTask();
        }

        private void ApplyViewModel(ViewModel viewModel)
        {
            gameObject.SetActive(true);
            foreach (var abnormalConditionGrid in _abnormalConditionGrids)
            {
                Destroy(abnormalConditionGrid.gameObject);
            }

            _abnormalConditionGrids.Clear();


            foreach (var abnormalConditionGridViewModel in viewModel._AbnormalConditionGridViewModels)
            {
                var abnormalConditionGridObj = Instantiate(_abnormalConditionGrid, _abnormalConditionParent);
                var abnormalConditionGrid = abnormalConditionGridObj.GetComponent<AbnormalConditionGrid>();
                abnormalConditionGrid.ApplyViewModel(abnormalConditionGridViewModel);
                _abnormalConditionGrids.Add(abnormalConditionGrid);
            }

            _abnormalConditionParent.position = new Vector3(0, 0, 0);
        }

        public class ViewModel
        {
            public AbnormalConditionGrid.ViewModel[] _AbnormalConditionGridViewModels { get; }

            public ViewModel
            (
                AbnormalConditionGrid.ViewModel[] abnormalConditionGridViewModels
            )
            {
                _AbnormalConditionGridViewModels = abnormalConditionGridViewModels;
            }
        }

        public class Factory : PlaceholderFactory<AbnormalConditionPopup>
        {
        }
    }
}