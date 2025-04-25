using System;
using System.Collections.Generic;
using Common.Data;
using Manager.DataManager;
using Zenject;

namespace UI.Title
{
    public class TeamEditViewModelUseCase : IDisposable
    {
        private readonly TeamGridViewModelUseCase _teamGridViewModelUseCase;
        private readonly CharacterMasterDataRepository _characterMasterDataRepository;
        private readonly UserDataRepository _userDataRepository;
        private readonly List<TeamGridView.ViewModel> _teamGridViewModels = new();

        [Inject]
        public TeamEditViewModelUseCase
        (
            TeamGridViewModelUseCase teamGridViewModelUseCase,
            CharacterMasterDataRepository characterMasterDataRepository,
            UserDataRepository userDataRepository
        )
        {
            _teamGridViewModelUseCase = teamGridViewModelUseCase;
            _characterMasterDataRepository = characterMasterDataRepository;
            _userDataRepository = userDataRepository;
        }


        public TeamEditView.ViewModel InAsTask()
        {
            _teamGridViewModels.Clear();
            var teamMembers = _userDataRepository.GetTeamMembers();
            for (var i = 0; i < GameCommonData.TeamMemberCount; i++)
            {
                var characterId = teamMembers[i];
                var characterData = _characterMasterDataRepository.GetCharacterData(characterId);
                var viewModel = _teamGridViewModelUseCase.InAsTask(characterData, i);
                _teamGridViewModels.Add(viewModel);
            }

            return new TeamEditView.ViewModel(_teamGridViewModels.ToArray());
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}