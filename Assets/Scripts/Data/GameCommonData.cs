using UnityEngine;

namespace Common.Data
{
    public static class GameCommonData
    {
        public static readonly int CharacterPrice = 200;
        public static readonly float MoveThreshold = 0.6f;
        public static readonly float RotateThreshold = 0.01f;
        public static readonly float TurnDuration = 0.3f;
        public static readonly float InputBombInterval = 0.05f;
        public static readonly string TitleID = "92AF5";
        public static readonly string JoystickName = "JoyStickMove";
        public static readonly string PlayerTag = "Player";
        public static readonly string BombTag = "Bomb";
        public static readonly string BombEffectTag = "BombEffect";
        public static readonly string ObstacleLayer = "Obstacles";
        public static readonly string UserKey = "User";
        public static readonly string VirtualCurrencyKey = "vc";
        public static readonly string PriceKey = "price";
        public static readonly string BombLayer = "Bomb";
        public static readonly string GemKey = "MS";
        public static readonly string CoinKey = "CO";
        public static readonly string RealMoneyKey = "RM";
        public static readonly string GachaShopKey = "GachaStore";
        public static readonly string MainShopKey = "MainShop";
        public static readonly string ConsumableClassKey = "Consumable";
        public static readonly string BundleClassKey = "Bundle";
        public static readonly string CharacterClassKey = "Character";
        public static readonly string CharacterGachaItemKey = "bundle01";
        public static readonly string ThousandCoinItemKey = "coin1000";
        public static readonly string FiveThousandCoinItemKey = "coin5000";
        public static readonly string TwelveThousandCoinItemKey = "coin12000";
        public static readonly string TwentyGemItemKey = "gem20";
        public static readonly string HundredGemKey = "gem100";
        public static readonly string TwoHundredGemKey = "gem200";
        public static readonly int ThousandCoinItemPrice = 100;
        public static readonly int FiveThousandCoinItemPrice = 480;
        public static readonly int TwelveThousandCoinItemPrice = 980;
        public static readonly int TwentyGemItemPrice = 100;
        public static readonly int HundredGemItemPrice = 480;
        public static readonly int TwoHundredGemItemPrice = 980;
        public static readonly string CharacterMasterKey = "CharacterMaster";
        public static readonly int SkillOneHashKey = Animator.StringToHash("Attack");
        public static readonly int SkillTwoHashKey = Animator.StringToHash("Passive");
        public static readonly int ActiveHashKey = Animator.StringToHash("Active");
        public static readonly string SkillOneKey = "Base Layer.Attack";
        public static readonly string SkillTwoKey = "Base Layer.Passive";
        public static readonly string GameID = "5089859";
        public static readonly string RewardAdsKey = "ca-app-pub-3940256099942544/1033173712";
        public static readonly string PlacementName = "testReward";
        public static string CharacterDataPath = "Data/Character/";
        public static string UserDataPath = "Data/UserData/UserData";
        public static readonly string CharacterSpritePath = "Sprites/Character/";
        public static readonly string CharacterColorPath = "Sprites/CharacterColor/";
        public static readonly string CharacterPrefabPath = "Prefabs/Character/";
        public static string BattleReadyGridPrefabPath = "Prefabs/UI/BattleReadyGrid";
        public static readonly float CloseDuration = 0.5f;
        public static readonly float OpenDuration = 1.0f;
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

    public enum Team
    {
        Gi,
        Go,
        Syoku,
        Other
    }
}