using System;

public class AbnormalConditionMasterData : IDisposable
{
    public int Id;
    public string Name;
    public string Explanation;

    public void Dispose()
    {
        // TODO マネージリソースをここで解放します
    }
}
