using System;
using Cysharp.Threading.Tasks;
using UI.Title;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace PUROPORO
{
    /// <summary>
    /// Loot Box Demo.
    ///
    /// The demo showcases yet another usage for the chest in games.
    /// This demo debuts the loot box event, which is a common occurrence in mobile games.
    ///
    /// This class is used to manage events, update the UI, draw cards, and spawn cards,
    /// among other things.
    ///
    /// The database, which is made possible by the use of ScriptableObjects,
    /// has a list of the various cards. For more information about these,
    /// please check https://docs.unity3d.com/Manual/class-ScriptableObject.html
    /// </summary>
    public class UILootBoxSystemDemo : MonoBehaviour
    {
        private LootBoxState m_State;
        private int m_TotalRange;

        [Header("LootBox")] [SerializeField] private LootBoxDemo _lootBoxPrefab;
        [SerializeField] private Transform _lootBoxParent;

        [Header("UI Elements")] [SerializeField]
        private CardCounter m_Counter;

        [SerializeField] private GameObject m_TextYouGot;
        [SerializeField] private Text m_TextPressContinue;
        private int m_Count;

        [Header("Cards")] [SerializeField] private AnimateAToBUi m_CardAnimator;
        [SerializeField] private CardUI m_CardUI;
        [SerializeField] private GameObject m_CardUiGo;

        [SerializeField] private RectTransform m_AchievedCardsUI;

        // [SerializeField] private SOCardsDB m_CardsDB; // ScriptableObject
        [SerializeField] private Button _button;

        [SerializeField] private Sprite[] _frameImages;

        //private ProbabilityRange[] m_ProbabilityRange;
        private CardUI[] m_CardUIs = new CardUI[0];

        //private int[] m_AchievedCards;
        private RewardDataUseCase.RewardData[] _rewardDatum;

        private LootBoxDemo _lootBox;
        public IObservable<LootBoxState> _OnClickAsObservable => _button.OnClickAsObservable().Select(_ => OnClick());

        public async void Initialize(RewardDataUseCase.RewardData[] rewardDatum)
        {
            _lootBox = Instantiate(_lootBoxPrefab, _lootBoxParent);
            _lootBox.Initialize();
            m_State = LootBoxState.Starting;
            m_CardAnimator = GetComponent<AnimateAToBUi>();
            m_TotalRange = 0;
            _rewardDatum = rewardDatum;
            m_TextYouGot.SetActive(false);
            m_TextPressContinue.gameObject.SetActive(true);
            m_TextPressContinue.text = "Press to Open";
            await UniTask.Delay(1000);
            SpawnChest();
        }

        [Obsolete]
        public LootBoxState OnClick()
        {
            switch (m_State)
            {
                case LootBoxState.Opening:
                    SpawnCard();
                    return m_State;
                case LootBoxState.Resulting:
                    m_State = LootBoxState.Ending;
                    if (m_CardUIs.Length > 0)
                    {
                        foreach (var t in m_CardUIs)
                            Destroy(t.gameObject);
                    }

                    Destroy(_lootBox.gameObject);
                    _lootBox = null;
                    return m_State;
                case LootBoxState.Waiting:
                    ShowResult();
                    return m_State;
                default:
                    return m_State;
            }
        }

        /// <summary>
        /// Spawn a new chest and reset a UI for the new opening event.
        /// </summary>
        [System.Obsolete]
        private void SpawnChest()
        {
            m_Count = _rewardDatum.Length;

            if (m_Count == 6 || m_Count == 3)
                m_AchievedCardsUI.GetComponent<GridLayoutGroup>().constraintCount = 3;
            else if (m_Count == 8 || m_Count == 4)
                m_AchievedCardsUI.GetComponent<GridLayoutGroup>().constraintCount = 4;
            else
                m_AchievedCardsUI.GetComponent<GridLayoutGroup>().constraintCount = 5;

            _lootBox.ChestDrop();

            m_Counter.gameObject.SetActive(true);
            m_Counter.UpdateCounter(_rewardDatum.Length);

            m_State = LootBoxState.Opening;
        }

        /// <summary>
        /// Spawn a new card at random from the database and display it with animations.
        /// The function contains a simple lottery method that draws cards according to probabilities.
        /// The card probabilities are calculated in the Start function.
        /// The function also gives the command to stop drawing when the cards run out of the chest.
        /// </summary>
        [Obsolete]
        private void SpawnCard()
        {
            if (m_State != LootBoxState.Opening) return;

            var rewardData = _rewardDatum[m_Count - 1];
            var frameSprite = _frameImages[rewardData._Rarity - 1];
            m_CardUI.SetCard(frameSprite, rewardData._Icon, rewardData._Name);
            _lootBox.SetRarityColor(rewardData._Color);

            _lootBox.ChestQuickOpens();
            m_CardAnimator.StartAnimation(0);
            m_Count--;
            m_Counter.UpdateCounter(m_Count);
            if (m_Count <= 0)
            {
                m_State = LootBoxState.Waiting;
            }
        }

        private void ShowResult()
        {
            _lootBox.ChestEmpty();
            m_TextPressContinue.gameObject.SetActive(true);
            m_TextPressContinue.text = "Press to Back";
            ShowEnding();
        }

        /// <summary>
        /// When all the cards have been drawn you better call this function.
        /// The function disposes of the empty chest and displays all the drawn cards in (a) row(s).
        /// </summary>
        private void ShowEnding()
        {
            // if (m_State != LootBoxState.Resulting) return;

            _lootBox.ChestDisappear();
            m_CardAnimator.ResetAnimation();

            m_CardUIs = new CardUI[_rewardDatum.Length];
            var index = 0;

            foreach (var rewardData in _rewardDatum)
            {
                GameObject go = Instantiate(m_CardUiGo, m_AchievedCardsUI);
                var frameSprite = _frameImages[rewardData._Rarity - 1];
                go.GetComponent<CardUI>().SetCard(frameSprite, rewardData._Icon, rewardData._Name);
                m_CardUIs[index] = go.GetComponent<CardUI>();
                index++;
            }

            for (int i = 0; i < m_CardUIs.Length; i++)
                m_CardUIs[i].GetComponent<AnimateScale>().StartAnimation((m_CardUIs.Length - i) * 0.1f);

            m_Counter.gameObject.SetActive(false);

            m_TextYouGot.SetActive(true);
            m_TextPressContinue.gameObject.SetActive(true);
            m_State = LootBoxState.Resulting;
        }
    }

    public enum Rarity
    {
        Common = 40,
        Uncommon = 30,
        Rare = 20,
        Epic = 10,
        Legendary = 5
    }

    public enum LootBoxState
    {
        Starting,
        Opening,
        Resulting,
        Ending,
        Waiting
    }
}