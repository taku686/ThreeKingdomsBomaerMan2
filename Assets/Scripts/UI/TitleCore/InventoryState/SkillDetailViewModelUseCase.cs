using System;
using System.Globalization;
using Common.Data;
using Repository;
using Zenject;

public class SkillDetailViewModelUseCase : IDisposable
{
    private readonly WeaponMasterDataRepository _weaponMasterDataRepository;

    [Inject]
    public SkillDetailViewModelUseCase
    (
        WeaponMasterDataRepository weaponMasterDataRepository,
        UserDataRepository userDataRepository
    )
    {
        _weaponMasterDataRepository = weaponMasterDataRepository;
    }

    public SkillDetailPopup.ViewModel InAsTask(int weaponId, int skillType)
    {
        var weaponData = _weaponMasterDataRepository.GetWeaponData(weaponId);
        var skillData = weaponData.GetSkillData(skillType);
        var explanation = TranslateExplanation(skillData);
        return new SkillDetailPopup.ViewModel
        (
            skillData.Sprite,
            skillData.Name,
            explanation
        );
    }

    private static string TranslateExplanation(SkillMasterData skillMasterData)
    {
        var explanation = skillMasterData.Explanation;
        explanation = explanation.Replace("hppl", skillMasterData.HpPlu.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("atkpl", skillMasterData.AttackPlu.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("defpl", skillMasterData.DefensePlu.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("spdpl", skillMasterData.SpeedPlu.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("respl", skillMasterData.ResistancePlu.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("bompl", skillMasterData.BombPlu.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("firpl", skillMasterData.FirePlu.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("dmgpl", skillMasterData.DamagePlu.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("coipl", skillMasterData.CoinPlu.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("gempl", skillMasterData.GemPlu.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("skpl", skillMasterData.SkillPlu.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("hpml", skillMasterData.HpMul.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("atkml", skillMasterData.AttackMul.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("defml", skillMasterData.DefenseMul.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("spdml", skillMasterData.SpeedMul.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("resml", skillMasterData.ResistanceMul.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("bomml", skillMasterData.BombMul.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("firml", skillMasterData.FireMul.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("dmgml", skillMasterData.DamageMul.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("coiml", skillMasterData.CoinMul.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("gemml", skillMasterData.GemMul.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("skml", skillMasterData.SkillMul.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("ran", skillMasterData.Range.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("inv", skillMasterData.Interval.ToString(CultureInfo.InvariantCulture));
        explanation = explanation.Replace("et", skillMasterData.EffectTime.ToString(CultureInfo.InvariantCulture));

        return explanation;
    }

    public void Dispose()
    {
        // TODO マネージリソースをここで解放します
    }
}