using System;
using Common.Data;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class TeamGridView : MonoBehaviour
{
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private TextMeshProUGUI _characterNameText;
    [SerializeField] private Image _typeImage;
    [SerializeField] private Image _characterImage;
    [SerializeField] private TeamStatusGridView _statusGridView;
    [SerializeField] private Button _changeButton;
    [SerializeField] private Button _noSelectButton;
    [SerializeField] private GameObject _noSelectObject;
    [SerializeField] private GameObject _selectObject;
    private int _index;

    public IObservable<(int, Button)> _ChangeButton
        => _changeButton.OnClickAsObservable()
            .Select(_ => (_index, _changeButton));

    public IObservable<(int, Button)> _NoSelectButton
        => _noSelectButton.OnClickAsObservable()
            .Select(_ => (_index, _noSelectButton));

    public void ApplyViewModel(ViewModel viewModel)
    {
        _index = viewModel._Index;
        var characterData = viewModel._CharacterData;
        if (characterData == null)
        {
            _noSelectObject.SetActive(true);
            _selectObject.SetActive(false);
            return;
        }

        _backgroundImage.sprite = characterData.ColorSprite;
        _characterNameText.text = characterData.Name;
        _typeImage.sprite = viewModel._TypeSprite;
        _characterImage.sprite = characterData.SelfPortraitSprite;
        _statusGridView.ApplyViewModel(viewModel._StatusGridViewViewModel);
    }

    public class ViewModel
    {
        public int _Index { get; }
        public CharacterData _CharacterData { get; }
        public Sprite _TypeSprite { get; }
        public Color _TypeColor { get; }
        public TeamStatusGridView.ViewModel _StatusGridViewViewModel { get; }

        public ViewModel
        (
            int index,
            CharacterData characterData,
            Sprite typeSprite,
            Color typeColor,
            TeamStatusGridView.ViewModel statusGridViewViewModel
        )
        {
            _Index = index;
            _CharacterData = characterData;
            _TypeSprite = typeSprite;
            _TypeColor = typeColor;
            _StatusGridViewViewModel = statusGridViewViewModel;
        }
    }
}