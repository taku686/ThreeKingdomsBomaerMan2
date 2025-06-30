using System;
using Common.Data;
using Player.Common;
using UnityEngine;

namespace UseCase
{
    public class HpCalculateUseCase : IDisposable
    {
        private const int DeadHp = 0;

        public static void InAsTask
        (
            PlayerCore.PlayerStatusInfo playerStatusInfo,
            int damage,
            Action deadAction = null
        )
        {
            var tuple = playerStatusInfo._Hp.Value;
            var maxHp = Mathf.FloorToInt(TranslateStatusInBattleUseCase.Translate(StatusType.Hp, tuple.Item1));
            var hp = Mathf.FloorToInt(TranslateStatusInBattleUseCase.Translate(StatusType.Hp, tuple.Item2));
            hp -= damage;
            hp = Mathf.Clamp(hp, DeadHp, maxHp);
            playerStatusInfo._Hp.Value = (maxHp, hp);
            if (hp <= DeadHp)
            {
                deadAction?.Invoke();
            }
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}