using UnityEngine;

namespace Common.Data
{
    public static class GameCommonData
    {
        public const int CharacterPrice = 200;
        public const float MoveThreshold = 0.6f;
        public const float RotateThreshold = 0.01f;
        public const float TurnDuration = 0.3f;
        public const float InputBombInterval = 0.05f;
        public const string TitleID = "92AF5";
        public const string JoystickName = "JoyStickMove";
        public const string PlayerTag = "Player";
        public const string BombTag = "Bomb";
        public const string BombEffectTag = "BombEffect";
        public const string BreakingWallTag = "BreakingWall";
        public const string WeaponTag = "Weapon";
        public const string ObstacleLayer = "Obstacles";
        public const string ExplosionLayer = "Explosion";
        public const string UserKey = "User";
        public const string VirtualCurrencyKey = "vc";
        public const string PriceKey = "price";
        public const string BombLayer = "Bomb";
        public const string GemKey = "MS";
        public const string CoinKey = "CO";
        public const string RealMoneyKey = "RM";
        public const string GachaShopKey = "GachaStore";
        public const string MainShopKey = "MainShop";
        public const string ConsumableClassKey = "Consumable";
        public const string BundleClassKey = "Bundle";
        public const string CharacterClassKey = "Character";
        public const string CharacterGachaItemKey = "bundle01";
        public const string ThousandCoinItemKey = "coin1000";
        public const string FiveThousandCoinItemKey = "coin5000";
        public const string TwelveThousandCoinItemKey = "coin12000";
        public const string TwentyGemItemKey = "gem20";
        public const string HundredGemKey = "gem100";
        public const string TwoHundredGemKey = "gem200";
        public const string CharacterMasterKey = "CharacterMaster";
        public const string CharacterLevelMasterKey = "CharacterLevelMaster";
        public static readonly int SkillOneHashKey = Animator.StringToHash("Attack");
        public static readonly int SkillTwoHashKey = Animator.StringToHash("Passive");
        public static readonly int ActiveHashKey = Animator.StringToHash("Active");
        public const string SkillOneKey = "Base Layer.Attack";
        public const string SkillTwoKey = "Base Layer.Passive";
        public const string GameID = "5089859";
        public const string RewardAdsKey = "ca-app-pub-3759795642939239/2878540700";
        public const string PlacementName = "testReward";
        public const string CharacterSpritePath = "Sprites/Character/";
        public const string CharacterColorPath = "Sprites/CharacterColor/";
        public const string CharacterPrefabPath = "Prefabs/Character/";
        public const string SkillSpritePath = "Sprites/Skill/";
        public const float CloseDuration = 0.5f;
        public const float OpenDuration = 1.0f;
        public const int ThreeMilliSecondsBeforeExplosion = 3000;
        public const int MaxCharacterLevel = 10;
        public const int MinCharacterLevel = 0;

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