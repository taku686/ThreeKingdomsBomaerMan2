namespace Common.Data
{
    public static class GameSettingData
    {
        public static float MoveThreshold = 0.01f;
        public static float TurnDuration = 0.1f;
        public static string TitleID = "92AF5";

        public static CharacterColor GetCharacterColor(string color)
        {
            switch (color)
            {
                case nameof(CharacterColor.Red):
                    return CharacterColor.Red;
                case nameof(CharacterColor.Blue):
                    return CharacterColor.Blue;
                case nameof(CharacterColor.Green):
                    return CharacterColor.Green;
                case nameof(CharacterColor.Purple):
                    return CharacterColor.Purple;
                case nameof(CharacterColor.Yellow):
                    return CharacterColor.Yellow;
                default:
                    return CharacterColor.Red;
            }
        }
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
        Ganryou,
        Kanu,
        Kaouen
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

    public enum Gender
    {
        Male,
        Female
    }
}