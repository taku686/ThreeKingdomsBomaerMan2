using System;
using System.Globalization;
using Common.Data;
using Manager.DataManager;
using Repository;
using UnityEngine;
using Zenject;

public class SkillDetailViewModelUseCase : IDisposable
{
    private readonly SkillMasterDataRepository _skillMasterDataRepository;

    [Inject]
    public SkillDetailViewModelUseCase
    (
        SkillMasterDataRepository skillMasterDataRepository,
        UserDataRepository userDataRepository
    )
    {
        _skillMasterDataRepository = skillMasterDataRepository;
    }

    public SkillDetailPopup.ViewModel InAsTask(int skillId)
    {
        var skillData = _skillMasterDataRepository.GetSkillData(skillId);
        var explanation = TranslateExplanation(skillData);
        var interval = !Mathf.Approximately(skillData.Interval, GameCommonData.InvalidNumber) ? skillData.Interval.ToString(CultureInfo.InvariantCulture) + "秒" : "-";
        var effectTime = !Mathf.Approximately(skillData.EffectTime, GameCommonData.InvalidNumber) ? skillData.EffectTime.ToString(CultureInfo.InvariantCulture) + "秒" : "-";
        var range = !Mathf.Approximately(skillData.Range, GameCommonData.InvalidNumber) ? skillData.Range.ToString(CultureInfo.InvariantCulture) : "-";
        var skillTypeString = GameCommonData.TranslateStatusTypeToString(skillData.SkillType);
        var index = 0;
        var abnormalCondition = "";
        foreach (var abnormalConditionEnum in skillData.AbnormalConditionEnum)
        {
            abnormalCondition += GameCommonData.TranslateAbnormalConditionToString(abnormalConditionEnum);
            index++;
            if (index == skillData.AbnormalConditionEnum.Length)
            {
                break;
            }

            if (index > 0)
            {
                abnormalCondition += "、";
            }
        }


        return new SkillDetailPopup.ViewModel
        (
            skillData.Sprite,
            skillData.Name,
            explanation,
            interval,
            effectTime,
            range,
            skillTypeString,
            abnormalCondition
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