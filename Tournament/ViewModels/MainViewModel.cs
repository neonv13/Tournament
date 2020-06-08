using System;
using System.Collections.Generic;
using System.Text;
using Tournament.Views;
using Tournament.Views.Referees;

namespace Tournament.ViewModels
{
    class MainViewModel
    {
        public TeamViewModel TeamViewModel { get; set; }
        public PlayersViewModel PlayersViewModel { get; set; }
        public RefereesViewModel RefereesViewModel { get; set; }
        public TournamentViewModel TournamentViewModel { get; set; }
        public TournamentView TournamentView { get; set; }
        public TeamsView TeamsView { get ; set; }
        public PlayersView PlayersView { get; set; }
        public RefereeView RefereeView { get; set; }
        public MainViewModel()
        {
            TeamViewModel = new TeamViewModel();
            PlayersViewModel = new PlayersViewModel();
            RefereesViewModel = new RefereesViewModel();
            TournamentViewModel = new TournamentViewModel();
            TournamentView = new TournamentView(TournamentViewModel, PlayersViewModel, TeamViewModel, RefereesViewModel);
            TeamsView = new TeamsView(TeamViewModel, PlayersViewModel);
            PlayersView = new PlayersView(PlayersViewModel);
            RefereeView = new RefereeView(RefereesViewModel);
        }
        public void SaveAll() 
        {
            PlayersViewModel.SavePlayersViewModel();
            TeamViewModel.SaveTeamViewModel();
            RefereesViewModel.SaveRefereesViewModel();
            TournamentViewModel.SaveViewModel();
        }
        public void LoadAll() 
        {
            PlayersViewModel.LoadPlayersViewModel();
            TeamViewModel.LoadTeamViewModel();
            RefereesViewModel.LoadRefereesViewModel();
            TournamentViewModel.LoadViewModel();
        }
    }
}
