using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Common.Data;
using Manager.DataManager;
using Repository;
using UI.Common;
using Zenject;

namespace UI.Title
{
    public class TeamGridViewModelUseCase
    {
        private readonly UserDataRepository _userDataRepository;
        private readonly CharacterTypeSpriteManager _characterTypeSpriteManager;
        private readonly TeamStatusGridViewModelUseCase _teamStatusGridViewModelUseCase;
        private readonly CharacterMasterDataRepository _characterMasterDataRepository;
        private readonly ApplyStatusSkillUseCase _applyStatusSkillUseCase;

        [Inject]
        public TeamGridViewModelUseCase
        (
            UserDataRepository userDataRepository,
            CharacterTypeSpriteManager characterTypeSpriteManager,
            TeamStatusGridViewModelUseCase teamStatusGridViewModelUseCase,
            CharacterMasterDataRepository characterMasterDataRepository,
            ApplyStatusSkillUseCase applyStatusSkillUseCase
        )
        {
            _userDataRepository = userDataRepository;
            _characterTypeSpriteManager = characterTypeSpriteManager;
            _teamStatusGridViewModelUseCase = teamStatusGridViewModelUseCase;
            _characterMasterDataRepository = characterMasterDataRepository;
            _applyStatusSkillUseCase = applyStatusSkillUseCase;
        }

        public TeamGridView.ViewModel InAsTask(CharacterData characterData, int index)
        {
            if (characterData == null)
            {
                return new TeamGridView.ViewModel
                (
                    index,
                    null,
                    null,
                    default,
                    null
                );
            }

            var characterDataClone = characterData.Clone();
            characterDataClone = ApplyStatusSkill(characterDataClone);
            var (typeSprite, typeColor) = _characterTypeSpriteManager.GetCharacterTypeData(characterDataClone.Type);
            //todo 後で修正する
            var statusGridViewModel = _teamStatusGridViewModelUseCase.InAsTask(StatusType.Hp, characterDataClone.Hp);

            return new TeamGridView.ViewModel
            (
                index,
                characterDataClone,
                typeSprite,
                typeColor,
                statusGridViewModel
            );
        }

        private CharacterData ApplyStatusSkill(CharacterData characterData)
        {
            var characterId = characterData.Id;
            var equippedWeaponData = _userDataRepository.GetEquippedWeaponData(characterId);
            var hpAppliedLevel = _applyStatusSkillUseCase.ApplyLevelStatus(characterId, StatusType.Hp);
            var attackAppliedLevel = _applyStatusSkillUseCase.ApplyLevelStatus(characterId, StatusType.Attack);
            var defenseAppliedLevel = _applyStatusSkillUseCase.ApplyLevelStatus(characterId, StatusType.Defense);
            var speedAppliedLevel = _applyStatusSkillUseCase.ApplyLevelStatus(characterId, StatusType.Speed);
            var bombAppliedLevel = _applyStatusSkillUseCase.ApplyLevelStatus(characterId, StatusType.BombLimit);
            var fireAppliedLevel = _applyStatusSkillUseCase.ApplyLevelStatus(characterId, StatusType.FireRange);
            var resistanceAppliedLevel = _applyStatusSkillUseCase.ApplyLevelStatus(characterId, StatusType.Resistance);

            foreach (var statusSkill in equippedWeaponData.StatusSkillMasterDatum)
            {
                hpAppliedLevel += _applyStatusSkillUseCase.GetStatusSkillValue(statusSkill.Id, StatusType.Hp);
                attackAppliedLevel += _applyStatusSkillUseCase.GetStatusSkillValue(statusSkill.Id, StatusType.Attack);
                defenseAppliedLevel += _applyStatusSkillUseCase.GetStatusSkillValue(statusSkill.Id, StatusType.Defense);
                speedAppliedLevel += _applyStatusSkillUseCase.GetStatusSkillValue(statusSkill.Id, StatusType.Speed);
                bombAppliedLevel += _applyStatusSkillUseCase.GetStatusSkillValue(statusSkill.Id, StatusType.BombLimit);
                fireAppliedLevel += _applyStatusSkillUseCase.GetStatusSkillValue(statusSkill.Id, StatusType.FireRange);
                resistanceAppliedLevel += _applyStatusSkillUseCase.GetStatusSkillValue(statusSkill.Id, StatusType.Resistance);
            }

            characterData.Hp = hpAppliedLevel;
            characterData.Attack = attackAppliedLevel;
            characterData.Defense = defenseAppliedLevel;
            characterData.Speed = speedAppliedLevel;
            characterData.BombLimit = bombAppliedLevel;
            characterData.FireRange = fireAppliedLevel;
            characterData.Resistance = resistanceAppliedLevel;

            return characterData;
        }
    }
}