using System.Collections.Generic;
using Common.Data;
using UnityEngine;
using UnityEngine.UI;

public class TeamEditView : ViewBase
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _decideButton;
    [SerializeField] private TeamGridView _teamGridView;
    [SerializeField] private Transform _teamGridParent;
    private readonly List<TeamGridView> _teamGridViews = new();
    public Button _BackButton => _backButton;
    public Button _DecideButton => _decideButton;

    public void ApplyViewModel(ViewModel viewModel)
    {
        foreach (var teamGridView in _teamGridViews)
        {
            Destroy(teamGridView.gameObject);
        }

        _teamGridViews.Clear();
        for (var i = 0; i < GameCommonData.MaxTeamMember; i++)
        {
            var teamGridView = Instantiate(_teamGridView, _teamGridParent);
            teamGridView.ApplyViewModel(viewModel._TeamGridViewModels[i]);
            _teamGridViews.Add(teamGridView);
        }
    }

    public List<TeamGridView> GetTeamGridViews()
    {
        return _teamGridViews;
    }

    public class ViewModel
    {
        public TeamGridView.ViewModel[] _TeamGridViewModels { get; }

        public ViewModel(TeamGridView.ViewModel[] teamGridViewModels)
        {
            _TeamGridViewModels = teamGridViewModels;
        }
    }
}