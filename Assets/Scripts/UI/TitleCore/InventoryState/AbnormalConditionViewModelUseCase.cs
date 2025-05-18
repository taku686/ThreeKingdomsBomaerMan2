using System;
using System.Collections.Generic;
using Common.Data;
using Repository;
using Zenject;

namespace UI.Title
{
    public class AbnormalConditionViewModelUseCase : IDisposable
    {
        private readonly AbnormalConditionMasterDataRepository _abnormalConditionMasterDataRepository;
        private readonly AbnormalConditionSpriteRepository _abnormalConditionSpriteRepository;

        [Inject]
        public AbnormalConditionViewModelUseCase
        (
            AbnormalConditionMasterDataRepository abnormalConditionMasterDataRepository,
            AbnormalConditionSpriteRepository abnormalConditionSpriteRepository
        )
        {
            _abnormalConditionMasterDataRepository = abnormalConditionMasterDataRepository;
            _abnormalConditionSpriteRepository = abnormalConditionSpriteRepository;
        }


        public AbnormalConditionPopup.ViewModel InAsTask()
        {
            var viewModels = new List<AbnormalConditionGrid.ViewModel>();
            foreach (var value in Enum.GetValues(typeof(AbnormalCondition)))
            {
                if (value is AbnormalCondition.All or AbnormalCondition.None)
                {
                    continue;
                }

                var abnormalCondition = (AbnormalCondition)value;
                var masterData = _abnormalConditionMasterDataRepository.GetAbnormalConditionMasterData(abnormalCondition);
                var sprite = _abnormalConditionSpriteRepository.GetAbnormalConditionSprite(abnormalCondition);
                var name = masterData.Name;
                var explanation = masterData.Explanation;
                var viewModel = new AbnormalConditionGrid.ViewModel(sprite, name, explanation);
                viewModels.Add(viewModel);
            }

            var abnormalConditionViewModel = new AbnormalConditionPopup.ViewModel(viewModels.ToArray());

            return abnormalConditionViewModel;
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}