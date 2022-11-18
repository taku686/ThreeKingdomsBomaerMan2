namespace Common.Data
{
    public class GameSettingData
    {
        public static float MoveThreshold = 0.6f;
        public static float RotateThreshold = 0.01f;
        public static float TurnDuration = 0.1f;
        public static string TitleID = "92AF5";
        public static string JoystickName = "JoyStickMove";
        public static float ThreeSecondsBeforeExplosion = 3f;

        public static CharacterColor GetCharacterColor(string color)
        {
            switch (color)
            {
                case "Red":
                    return CharacterColor.Red;
                case "Blue":
                    return CharacterColor.Blue;
                case "Green":
                    return CharacterColor.Green;
                case "Purple":
                    return CharacterColor.Purple;
                case "Yellow":
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

    public enum BombType
    {
        Normal,
        Penetration,
        Danger
    }
}