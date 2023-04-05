using System;
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
        public const string ChatGptApiKey = "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";
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
        public const string GachaShopKey = "GachaStore";
        public const string MainShopKey = "MainShop";
        public const string ConsumableClassKey = "Consumable";
        public const string BundleClassKey = "Bundle";
        public const string CharacterClassKey = "Character";
        public const string LevelClassKey = "Level";
        public const string LoginBonusClassKey = "Consumable";
        public const string CharacterGachaItemKey = "bundle01";
        public const string ThousandCoinItemKey = "coin1000";
        public const string FiveThousandCoinItemKey = "coin5000";
        public const string TwelveThousandCoinItemKey = "coin12000";
        public const string TwentyGemItemKey = "gem20";
        public const string HundredGemItemKey = "gem100";
        public const string TwoHundredGemItemKey = "gem200";
        public const string LevelItemKey = "level";
        public const string LoginBonusItemKey = "day";
        public const string CharacterMasterKey = "CharacterMaster";
        public const string CharacterLevelMasterKey = "CharacterLevelMaster";
        public const string MissionMasterKey = "MissionMaster";
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
        public const string WeaponEffectPrefabPath = "Prefabs/WeaponEffect/Effect";
        public const string StagePrefabPath = "Prefabs/Stage/";
        public const string SkillSpritePath = "Sprites/Skill/";
        public const string VirtualCurrencySpritePath = "Sprites/VirtualCurrency/";
        public const string LevelText = "Lv.";
        public const float CloseDuration = 0.5f;
        public const float OpenDuration = 1.0f;
        public const float ClickIntervalDuration = 0.2f;
        public const int ThreeMilliSecondsBeforeExplosion = 3000;
        public const int MaxCharacterLevel = 10;
        public const int MinCharacterLevel = 0;
        public const int MaxMissionCount = 3;
        public const int MaxMissionProgress = 100;
        public const int BattleCountActionId = 0;
        public const int LevelUpActionId = 1;
        public const int CharacterBattleActionId = 2;
        public const int ExceptionMissionProgress = 999;
        public const int ExceptionCharacterId = 999;
        public const int NetworkErrorCode = Int32.MaxValue;
        public const int CharacterLimit = 40;

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

        public static Color GetWeaponColor(int characterId)
        {
            switch (characterId)
            {
                case 0:
                    return Color.green;
                case 1:
                    return Color.red;
                case 2:
                    return new Color(0, 7, 255);
                case 3:
                    return Color.green;
                case 4:
                    return Color.red;
                case 5:
                    return new Color(116, 0, 255);
                case 6:
                    return Color.blue;
                case 7:
                    return new Color(91, 2193, 255);
                case 8:
                    return new Color(139, 255, 0);
                case 9:
                    return new Color(108, 0, 255);
                case 10:
                    return new Color(255, 100, 0);
                case 11:
                    return new Color(0, 205, 255);
                case 12:
                    return new Color(94, 94, 183);
                case 13:
                    return new Color(255, 0, 140);
                case 14:
                    return new Color(154, 0, 255);
                case 15:
                    return Color.blue;
                case 16:
                    return Color.green;
                case 17:
                    return new Color(121, 0, 255);
                case 18:
                    return new Color(0, 124, 255);
                case 19:
                    return new Color(255, 29, 0);
                case 20:
                    return Color.green;
                case 21:
                    return new Color(130, 0, 8);
                default:
                    return Color.black;
            }
        }

        public static LoginBonusStatus GetLoginBonusStatus(int index)
        {
            switch (index)
            {
                case 0:
                    return LoginBonusStatus.Disable;
                case 1:
                    return LoginBonusStatus.CanReceive;
                case 2:
                    return LoginBonusStatus.Received;
                default:
                    return LoginBonusStatus.Exception;
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

    public enum LoginBonusStatus
    {
        Disable,
        CanReceive,
        Received,
        Exception
    }
}