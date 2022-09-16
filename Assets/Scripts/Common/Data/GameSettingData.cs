namespace Common.Data
{
    public static class GameSettingData
    {
         public static float MoveThreshold = 0.01f;
         public static float TurnDuration = 0.1f;
    }

    public enum Direction
    {
        Forward,
        Back,
        Right,
        Left,
        None
    }
}