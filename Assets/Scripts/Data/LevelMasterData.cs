using System;

public class LevelMasterData : IDisposable
{
    public int Level;
    public float StatusRate;
    public bool IsSkillOneActive;
    public bool IsSkillTwoActive;
    public bool IsPassiveSkillOneActive;
    public bool IsPassiveSkillTwoActive;
    public bool IsPenetrationBombActive;
    public bool IsDangerBombActive;
    public int NeedCoin;

    public void Dispose()
    {
    }
}