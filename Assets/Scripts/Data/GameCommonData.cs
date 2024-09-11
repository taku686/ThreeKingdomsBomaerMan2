using System;
using UnityEngine;

namespace Common.Data
{
    public static class GameCommonData
    {
        public const int CharacterPrice = 200;
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
        public const string IdleTag = "Idle";
        public const string AttackTag = "Attack";
        public const string PerformanceTag = "Performance";
        public const string PassiveTag = "Passive";
        public const string ObstacleLayer = "Obstacles";
        public const string ExplosionLayer = "Explosion";
        public const string BombLayer = "Bomb";
        public const string UserKey = "User";
        public const string GemKey = "MS";
        public const string CoinKey = "CO";
        public const string TicketKey = "TK";
        public const string GachaShopKey = "GachaStore";
        public const string ConsumableClassKey = "Consumable";
        public const string CharacterClassKey = "Character";
        public const string LoginBonusClassKey = "Consumable";
        public const string CharacterGachaItemKey = "bundle01";
        public const string ThousandCoinItemKey = "coin1000";
        public const string FiveThousandCoinItemKey = "coin5000";
        public const string TwelveThousandCoinItemKey = "coin12000";
        public const string TwentyGemItemKey = "gem20";
        public const string HundredGemItemKey = "gem100";
        public const string TwoHundredGemItemKey = "gem200";
        public const string LoginBonusNotificationItemKey = "LoginBonusNotification";
        public const string LevelItemKey = "level";
        public const string LoginBonusItemKey = "day";
        public static readonly int NormalHashKey = Animator.StringToHash("Normal");
        public static readonly int SpecialHashKey = Animator.StringToHash("Special");
        public static readonly int ActiveHashKey = Animator.StringToHash("Active");
        public static readonly int PerformanceHashKey = Animator.StringToHash("Performance");
        public const string NormalKey = "Base Layer.Normal";
        public const string SpecialKey = "Base Layer.Special";
        public const string GameID = "5089859";
        public const string RewardAdsKey = "ca-app-pub-3759795642939239/2878540700";
        public const string PlacementName = "testReward";
        public const string CharacterSpritePath = "Sprites/Character/";
        public const string CharacterColorPath = "Sprites/CharacterColor/";
        public const string CharacterPrefabPath = "Prefabs/Character/";
        public const string WeaponEffectPrefabPath = "Prefabs/WeaponEffect/Effect";
        public const string StagePrefabPath = "Prefabs/Stage/";
        public const string SkillSpritePath = "Sprites/Skill/";
        public const string WeaponSpritePath = "Sprites/Weapon/";
        public const string WeaponPrefabPath = "Prefabs/Weapon/";
        public const string VirtualCurrencySpritePath = "Sprites/VirtualCurrency/";
        public const string LevelText = "Lv.";
        public const string TitleScene = "Title";
        public const string BattleScene = "Battle";
        public const float CloseDuration = 0.5f;
        public const float OpenDuration = 1.0f;
        public const int ThreeMilliSecondsBeforeExplosion = 3000;
        public const int MaxCharacterLevel = 10;
        public const int MinCharacterLevel = 0;
        public const int MaxMissionCount = 3;
        public const int MaxMissionProgress = 100;
        public const int BattleCountActionId = 0;
        public const int LevelUpActionId = 1;
        public const int CharacterBattleActionId = 2;
        public const int ExceptionMissionProgress = 999;
        public const int NetworkErrorCode = Int32.MaxValue;
        public const float FadeOutTime = 0.8f;
        public const int BattleTime = 180;
        public const int DefaultWeaponId = 71;
        public const int StatusSkillReleaseLevel = 3;
        public const int NormalSkillReleaseLevel = 7;
        public const int SpecialSkillReleaseLevel = 10;

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

        public static Vector3 GetPlayerDirection(float rotation)
        {
            switch (rotation)
            {
                case -180:
                    return Vector3.back;
                case 0:
                    return Vector3.forward;
                case -90:
                    return Vector3.left;
                case 90:
                    return Vector3.right;
                default:
                    return Vector3.zero;
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

    public enum WeaponType
    {
        Spear = 0,
        Hammer = 1,
        Sword = 2,
        Knife = 3,
        Fan = 4,
        Bow = 5,
        Shield = 6,
        Axe = 7,
        Staff = 8,
    }

    public enum AttributeType
    {
        Fire = 0,
        Water = 1,
        Wind = 2,
        Earth = 3,
        Light = 4,
        Dark = 5,
        Poison = 6,
        None = 100
    }

    public enum SkillType
    {
        Status,
        Normal,
        Special
    }

    public enum AnimationStateType
    {
        Idle,
        Performance,
        Normal,
        Special
    }

    public enum StatusType
    {
        Hp = 0,
        Attack = 1,
        Speed = 2,
        BombLimit = 3,
        FireRange = 4,
    }

    public enum SkillEffectType
    {
        Hp = 0,
        Attack = 1,
        Speed = 2,
        BombLimit = 3,
        FireRange = 4,
        Heal = 5,
        ContinuousHeal = 6,
        Barrier = 7,
        PerfectBarrier = 8,
        Reborn = 9,
        SlowTime = 10,
        ProhibitedSkill = 11,
        Paralysis = 12,
        Confusion = 13,
        Illusion = 14,
        Jump = 15,
        Dash = 16,
        WallThrough = 17,
        WallDestruction = 18,
        Teleport = 19,
        Kick = 20,
        Transparent = 21,
        Clairvoyance = 22,
        LinerArrangement = 23,
        CircleArrangement = 24,
        ArrowArrangement = 25,
        Meteor = 26,
        BombDestruction = 27,
        BombBlowOff = 28,
        EnemyBlowOff = 29,
        BlastReflection = 30,
        SkillBarrier = 31,
        Frozen = 32,
        RewardCoin = 33,
        RewardGem = 34,
        PenetrationBomb = 35,
        DiffusionBomb = 36,
        FullPowerBomb = 37,
        ParalysisBomb = 38,
        ConfusionBomb = 39,
        PoisonBomb = 40,
        IceBomb = 41,
        GoldenBomb = 42,
        ChaseBomb = 43,
        RotateBomb = 44,
        GenerateWall = 45,
        CantMoveTrap = 46,
        PoisonTrap = 47,
        GenerateBombAlly = 48,
        BombDestructionShot = 49,
        BombBlowOffShot = 50,
        EnemyBlowOffShot = 51,
        AllStatusBuff = 52,
        HpBuff = 53,
        AttackBuff = 54,
        SpeedBuff = 55,
        BombLimitBuff = 56,
        FireRangeBuff = 57,
        AllStatusDebuff = 58,
        HpDebuff = 59,
        AttackDebuff = 60,
        SpeedDebuff = 61,
        BombLimitDebuff = 62,
        FireRangeDebuff = 63,
        PoisonShot = 64,
        IceShot = 65,
        ParalysisShot = 66,
        ConfusionShot = 67,
        Poison = 68,
        RandomDebuff = 69,
        FastMove = 70,
        BombThrough = 71,
        BlackHole = 72,
        Summon = 73,
        Fear = 74,
        GodPower = 75,
        None = 999
    }
}