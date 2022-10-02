namespace Common.Data
{
    public static class GameSettingData
    {
        public static float MoveThreshold = 0.01f;
        public static float TurnDuration = 0.1f;
        public static string TitleID = "92AF5";
    }

    public enum Direction
    {
        Forward,
        Back,
        Right,
        Left,
        None
    }

    public enum CharacterName
    {
        Bacho,
        Ryuubi,
        Sousou,
        Sonsaku,
        Syokatsuryou,
        Shibasyou,
        Syuuyu,
        Tyouun,
        Ryofu,
        Ganryou
    }

    public enum CharacterColor
    {
        Blue,
        Green,
        Purple,
        Red,
        Yellow
    }

    public enum PlayerIndex
    {
        Player1,
        Player2,
        Player3,
        Player4,
    }

    public enum SceneIndex
    {
        Title,
        BattleScene
    }
}