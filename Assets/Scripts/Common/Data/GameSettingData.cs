using UnityEngine;

namespace Common.Data
{
    public static class GameSettingData
    {
        public static readonly float MoveThreshold = 0.6f;
        public static readonly float RotateThreshold = 0.01f;
        public static readonly float TurnDuration = 0.1f;
        public static readonly string TitleID = "92AF5";
        public static readonly string JoystickName = "JoyStickMove";
        public static readonly string PlayerTag = "Player";
        public static readonly string BombEffectTag = "BombEffect";
        public static readonly string ObstacleLayer = "Obstacles";
        public static readonly string UserKey = "User";
        public static readonly string BombLayer = "Bomb";
        public static readonly string DiamondKey = "MS";
        public static readonly string CoinKey = "CO";
        
        public static readonly int ThreeMilliSecondsBeforeExplosion = 3000;

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

        public static Vector3 DirectionToVector3(Direction direction)
        {
            switch (direction)
            {
                case Direction.Forward:
                    return Vector3.forward;
                case Direction.Back:
                    return Vector3.back;
                case Direction.Left:
                    return Vector3.left;
                case Direction.Right:
                    return Vector3.right;
                default:
                    return Vector3.zero;
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
        Error,
        Normal,
        Penetration,
        Danger
    }
}