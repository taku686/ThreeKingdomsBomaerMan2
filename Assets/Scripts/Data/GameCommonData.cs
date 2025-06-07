using UnityEngine;

namespace Common.Data
{
    public static class GameCommonData
    {
        public const int CharacterPrice = 200;
        public const int WeaponBuyPrice = 100;
        public const float TurnDuration = 0.3f;
        public const float InputBombInterval = 0.05f;
        public const float CharacterChangeInterval = 5f;
        public const float DashInterval = 0.5f;
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
        public const string BombLayer = "Bomb";
        public const string PlayerLayer = "Player";
        public const string EnemyLayer = "Enemies";
        public const string UserKey = "User";
        public const string GemKey = "MS";
        public const string CoinKey = "CO";
        public const string TicketKey = "TK";
        public const string GachaShopKey = "GachaStore";
        public const string ConsumableClassKey = "Consumable";
        public const string CharacterClassKey = "Character";
        public const string LoginBonusClassKey = "Consumable";
        public const string CharacterGachaItemKey = "bundle01";
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
        public static readonly int KickHashKey = Animator.StringToHash("Kick");
        public static readonly int JumpHashKey = Animator.StringToHash("Jump");
        public static readonly int DashHashKey = Animator.StringToHash("Dash");
        public static readonly int BuffHashKey = Animator.StringToHash("Buff");
        public static readonly int DeadHashKey = Animator.StringToHash("Dead");
        public static readonly int SlashHashKey = Animator.StringToHash("Slash");
        public static readonly int PerformanceHashKey = Animator.StringToHash("Performance");
        public const string NormalKey = "Base Layer.Normal";
        public const string SpecialKey = "Base Layer.Special";
        public const string KickKey = "Base Layer.Kick";
        public const string JumpKey = "Base Layer.Jump";
        public const string DashKey = "Base Layer.Dash";
        public const string BuffKey = "Base Layer.Buff";
        public const string DeadKey = "Base Layer.Dead";
        public const string SlashKey = "Base Layer.Slash";
        public const string SpeedhParameterName = "speedh";
        public const string SpeedvParameterName = "speedv";
        public const string NormalParameterName = "Normal";
        public const string SpecialParameterName = "Special";
        public const string KickParameterName = "Kick";
        public const string JumpParameterName = "Jump";
        public const string DashParameterName = "Dash";
        public const string BuffParameterName = "Buff";
        public const string DeadParameterName = "Dead";
        public const string SlashParameterName = "Slash";
        public const string CharacterSpritePath = "Sprites/Character/";
        public const string UserIconSpritePath = "Sprites/UserIcon/";
        public const string SkillIconSpritePath = "Sprites/Skill/";
        public const string CharacterColorPath = "Sprites/CharacterColor/";
        public const string CharacterPrefabPath = "Prefabs/Character/";
        public const string PlayerCorePath = "Prefabs/Character/PlayerCore";
        public const string StagePrefabPath = "Prefabs/Stage/";
        public const string WeaponPrefabPath = "Prefabs/Weapon/";
        public const string RewardSpritePath = "Sprites/Reward/";
        public const string MissionActionPath = "Sprites/MissionAction/";
        public static readonly string _SortWeaponDataPath = Application.persistentDataPath + "/weaponSortData.json";
        public static readonly string _WeaponCautionDataPath = Application.persistentDataPath + "/weaponCautionData.json";
        public const string LevelText = "Lv.";
        public const string TitleScene = "Title";
        public const string BattleScene = "Battle";
        public const float CloseDuration = 0.5f;
        public const float OpenDuration = 1.0f;
        public const int ThreeMilliSecondsBeforeExplosion = 3000;
        public const int MaxCharacterLevel = 10;
        public const int MinCharacterLevel = 1;
        public const int MaxMissionCount = 20;
        public const int NetworkErrorCode = int.MaxValue;
        public const int BattleTime = 180;
        public const int DefaultWeaponId = 0;
        public const int NormalSkillReleaseLevel = 3;
        public const int SpecialSkillReleaseLevel = 5;
        public const int InvalidNumber = -9999;
        public const int MaxTeamMember = 3;
        public const string Item1000CoinKey = "1000_coin";
        public const string Item5000CoinKey = "5000_coin";
        public const string Item12000CoinKey = "12000_coin";
        public const string Item20GemKey = "20_gem";
        public const string Item100GemKey = "100_gem";
        public const string Item200GemKey = "200_gem";

        public static class Terms
        {
            public const string AddGemPopupTile = "ジェムの数が足りません";
            public const string AddGemPopupExplanation = "ジェムの数が足りません。\nジェムを追加しますか？";
            public const string InvalidData = "無効なデータです。";
            public const string NorHaveWeapon = "所持していない武器です。";
            public const string ErrorAddVirtualCurrency = "仮想通貨の追加に失敗しました。";
            public const string ErrorUpdateUserData = "ユーザーデータの更新に失敗しました。";
            public const string AddGemPopupOk = "追加";
            public const string AddGemPopupCancel = "キャンセル";
            public const string PurchaseCharacterPopupTitle = "キャラクターを購入しますか？";
            public const string PurchaseCharacterPopupExplanation = "200ジェムを消費して \nキャラクターを購入しますか？";
            public const string PurchaseCharacterPopupOk = "購入";
            public const string PurchaseCharacterPopupCancel = "キャンセル";
        }

        public static int GetWeaponSellPrice(int rare)
        {
            return rare switch
            {
                1 => (int)WeaponPriceByRarity.One,
                2 => (int)WeaponPriceByRarity.Two,
                3 => (int)WeaponPriceByRarity.Three,
                4 => (int)WeaponPriceByRarity.Four,
                5 => (int)WeaponPriceByRarity.Five,
                _ => 0
            };
        }

        public enum RewardType
        {
            Coin = 0,
            Gem = 1,
            Weapon = 2,
            Character = 3,
            Consumable = 4,
            TreasureBox = 5,
            None = 999
        }

        public enum MissionType
        {
            LevelUp = 0,
            BattleCount = 1,
            WonCount = 2,
            KillCount = 3,
            DamageAmount = 4,
            Gacha = 5,
            None = 999
        }

        public static MissionType TranslateMissionType(MissionActionId actionId)
        {
            return actionId switch
            {
                MissionActionId.LevelUp => MissionType.LevelUp,
                MissionActionId.CharacterLevelUp => MissionType.LevelUp,
                MissionActionId.BattleCount => MissionType.BattleCount,
                MissionActionId.CharacterBattleCount => MissionType.BattleCount,
                MissionActionId.WeaponBattleCount => MissionType.BattleCount,
                MissionActionId.FirstWonCount => MissionType.WonCount,
                MissionActionId.CharacterFirstWonCount => MissionType.WonCount,
                MissionActionId.WeaponFirstWonCount => MissionType.WonCount,
                MissionActionId.KillCount => MissionType.KillCount,
                MissionActionId.CharacterKillCount => MissionType.KillCount,
                MissionActionId.WeaponKillCount => MissionType.KillCount,
                MissionActionId.DamageAmount => MissionType.DamageAmount,
                MissionActionId.CharacterDamageAmount => MissionType.DamageAmount,
                MissionActionId.WeaponDamageAmount => MissionType.DamageAmount,
                MissionActionId.GachaCount => MissionType.Gacha,
                MissionActionId.WeaponGachaCount => MissionType.Gacha,
                _ => MissionType.None
            };
        }

        public enum MissionActionId
        {
            LevelUp = 0,
            CharacterLevelUp = 1,
            BattleCount = 2,
            CharacterBattleCount = 3,
            WeaponBattleCount = 4,
            FirstWonCount = 5,
            CharacterFirstWonCount = 6,
            WeaponFirstWonCount = 7,
            KillCount = 8,
            CharacterKillCount = 9,
            WeaponKillCount = 10,
            DamageAmount = 11,
            CharacterDamageAmount = 12,
            WeaponDamageAmount = 13,
            GachaCount = 14,
            WeaponGachaCount = 15
        }

        public static bool IsMissionsUsingCharacter(int missionActionId)
        {
            return missionActionId switch
            {
                (int)MissionActionId.CharacterLevelUp => true,
                (int)MissionActionId.CharacterBattleCount => true,
                (int)MissionActionId.CharacterFirstWonCount => true,
                (int)MissionActionId.CharacterKillCount => true,
                (int)MissionActionId.CharacterDamageAmount => true,
                _ => false
            };
        }

        public static bool IsMissionsUsingWeapon(int missionActionId)
        {
            return missionActionId switch
            {
                (int)MissionActionId.WeaponBattleCount => true,
                (int)MissionActionId.WeaponFirstWonCount => true,
                (int)MissionActionId.WeaponKillCount => true,
                (int)MissionActionId.WeaponDamageAmount => true,
                _ => false
            };
        }

        private enum WeaponPriceByRarity
        {
            One = 50,
            Two = 100,
            Three = 150,
            Four = 200,
            Five = 300
        }

        public static CharacterColor GetCharacterColor(string color)
        {
            return color switch
            {
                "Red" => CharacterColor.Red,
                "Blue" => CharacterColor.Blue,
                "Green" => CharacterColor.Green,
                "Purple" => CharacterColor.Purple,
                "Yellow" => CharacterColor.Yellow,
                _ => CharacterColor.Red
            };
        }

        public static Vector3 GetPlayerDirection(float rotation)
        {
            return rotation switch
            {
                -180 => Vector3.back,
                0 => Vector3.forward,
                -90 => Vector3.left,
                90 => Vector3.right,
                _ => Vector3.zero
            };
        }

        public static Vector3 DirectionToVector3(MoveDirection moveDirection)
        {
            return moveDirection switch
            {
                MoveDirection.Forward => Vector3.forward,
                MoveDirection.Back => Vector3.back,
                MoveDirection.Left => Vector3.left,
                MoveDirection.Right => Vector3.right,
                _ => Vector3.zero
            };
        }

        public static Color GetWeaponColor(int characterId)
        {
            return characterId switch
            {
                0 => Color.green,
                1 => Color.red,
                2 => new Color(0, 7, 255),
                3 => Color.green,
                4 => Color.red,
                5 => new Color(116, 0, 255),
                6 => Color.blue,
                7 => new Color(91, 2193, 255),
                8 => new Color(139, 255, 0),
                9 => new Color(108, 0, 255),
                10 => new Color(255, 100, 0),
                11 => new Color(0, 205, 255),
                12 => new Color(94, 94, 183),
                13 => new Color(255, 0, 140),
                14 => new Color(154, 0, 255),
                15 => Color.blue,
                16 => Color.green,
                17 => new Color(121, 0, 255),
                18 => new Color(0, 124, 255),
                19 => new Color(255, 29, 0),
                20 => Color.green,
                21 => new Color(130, 0, 8),
                _ => Color.black
            };
        }

        public static LoginBonusStatus GetLoginBonusStatus(int index)
        {
            return index switch
            {
                0 => LoginBonusStatus.Disable,
                1 => LoginBonusStatus.CanReceive,
                2 => LoginBonusStatus.Received,
                _ => LoginBonusStatus.Exception
            };
        }

        public static string TranslateStatusTypeToString(StatusType statusType)
        {
            return statusType switch
            {
                StatusType.Hp => "HP",
                StatusType.Attack => "攻撃力",
                StatusType.Speed => "スピード",
                StatusType.BombLimit => "ボム数",
                StatusType.FireRange => "火力",
                StatusType.Defense => "防御力",
                StatusType.Resistance => "精神力",
                StatusType.None => "Level",
                _ => "-"
            };
        }

        public static string TranslateStatusTypeToString(SkillType skillType)
        {
            return skillType switch
            {
                SkillType.Status => "ステータス",
                SkillType.Active => "アクティブ",
                SkillType.Passive => "パッシブ",
                _ => "-"
            };
        }

        public static string TranslateAbnormalConditionToString(AbnormalCondition abnormalCondition)
        {
            return abnormalCondition switch
            {
                AbnormalCondition.Paralysis => "麻痺",
                AbnormalCondition.Poison => "毒",
                AbnormalCondition.Frozen => "氷",
                AbnormalCondition.Confusion => "混乱",
                AbnormalCondition.NockBack => "ノックバック",
                AbnormalCondition.Charm => "魅惑",
                AbnormalCondition.Miasma => "瘴気",
                AbnormalCondition.Darkness => "暗黒",
                AbnormalCondition.Sealed => "封印",
                AbnormalCondition.LifeSteal => "吸血",
                AbnormalCondition.Curse => "呪い",
                AbnormalCondition.HellFire => "業火",
                AbnormalCondition.Fear => "恐怖",
                AbnormalCondition.TimeStop => "時止め",
                AbnormalCondition.Apraxia => "行動不能",
                AbnormalCondition.SoakingWet => "水濡れ",
                AbnormalCondition.Burning => "灼熱",
                AbnormalCondition.None => "なし",
                _ => "-"
            };
        }
    }


    public enum MoveDirection
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

    public enum Gender
    {
        Male,
        Female
    }

    public enum BombType
    {
        Normal = 0,
        Penetration = 1,
        Diffusion = 2,
        Paralysis = 3,
        Poison = 4,
        Frozen = 5,
        Confusion = 6,
        Sealed = 7,
        GreatFire = 9,
        LifeSteal = 10,
        Holy = 11,
        Apraxia = 12,
        Burning = 13,
        Charm = 14,
        Curse = 15,
        Darkness = 16,
        Fear = 17,
        HellFire = 18,
        Miasma = 19,
        ParalyzingThunder = 20,
        SoakingWet = 21,
        TimeStop = 22,
        None = 999
    }

    public enum AbnormalCondition
    {
        Paralysis = 0,
        Poison = 1,
        Frozen = 2,
        Confusion = 3,
        NockBack = 4,
        Charm = 5,
        Miasma = 6,
        Darkness = 7,
        Sealed = 8,
        LifeSteal = 9,
        Curse = 10,
        HellFire = 11,
        Fear = 12,
        TimeStop = 13,
        Apraxia = 14,
        SoakingWet = 15,
        Burning = 16,
        ParalyzingThunder = 17,
        All = 99,
        None = 999
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
        BigSword = 9,
        Crow = 10,
        Katana = 11,
        Scythe = 12,
        Lance = 13,
        None = 999,
    }

    public enum SkillType
    {
        Status,
        Active,
        Passive,
    }

    public enum NumberRequirementType
    {
        Character = 0,
        CharacterType = 1,
        AnyTeam = 2,
        Weapon = 3,
        HpRate = 4,
        BattleRank = 5,
        AllTeam = 6,
        None = 999
    }

    public enum BoolRequirementType
    {
        Buff = 0,
        Debuff = 1,
        AbnormalCondition = 2,
        ReceiveDamage = 3,
        None = 999
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
        Defense = 5,
        Resistance = 6,
        None = 999
    }

    public enum SkillDirection
    {
        Forward = 0,
        Back = 1,
        Left = 2,
        Right = 3,
        ForwardBack = 4,
        LeftRight = 5,
        All = 6,
        Random = 7,
        Specified = 8,
        Everywhere = 9,
        None = 999
    }

    public enum SkillActionType
    {
        Heal = 5,
        ContinuousHeal = 6,
        Barrier = 7,
        PerfectBarrier = 8,
        Reborn = 9,
        SlowTime = 10,
        ProhibitedSkill = 11,
        Jump = 15,
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
        AllBuff = 52,
        HpBuff = 53,
        AttackBuff = 54,
        SpeedBuff = 55,
        BombLimitBuff = 56,
        FireRangeBuff = 57,
        AllDebuff = 58,
        HpDebuff = 59,
        AttackDebuff = 60,
        SpeedDebuff = 61,
        BombLimitDebuff = 62,
        FireRangeDebuff = 63,
        RandomDebuff = 69,
        FastMove = 70,
        BombThrough = 71,
        BlackHole = 72,
        Summon = 73,
        GodPower = 75,
        ResistanceBuff = 78,
        DefenseBuff = 79,
        Slash = 80,
        Shot = 83,
        Resistance = 84,
        Bomb = 85,
        Dash = 86,
        DashAttack = 87,
        FlyingSlash = 88,
        Impact = 89,
        JumpSmash = 90,
        SlashSpin = 91,
        ThrowEdge = 92,
        None = 999
    }
}