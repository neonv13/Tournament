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
            try
            {
                PlayersViewModel.SavePlayersViewModel();
            }
            catch (Exception)
            {
                throw new Exception("File playersList.xml not found");
            }
            try
            {
                TeamViewModel.SaveTeamViewModel();
            }
            catch (Exception)
            {
                throw new Exception("File teamsList.xml not found");
            }
            try
            {
                RefereesViewModel.SaveRefereesViewModel();
            }
            catch (Exception)
            {
                throw new Exception("File refereesList.xml not found");
            }
            try
            {
                TournamentViewModel.SaveViewModel();
            }
            catch (Exception)
            {
                throw new Exception("File tournamentsList.xml not found");
            }
        }
        public void LoadAll() 
        {
            try
            {
                PlayersViewModel.LoadPlayersViewModel();
                PlayersView.ViewPlayers.Refresh();
            }
            catch (Exception)
            {
                throw new Exception("File playersList.xml not found");
            }
            try
            {
                TeamViewModel.LoadTeamViewModel();
                TeamsView.ViewTeams.Refresh();
            }
            catch (Exception)
            {
                throw new Exception("File teamsList.xml not found");
            }
            try
            {
                RefereesViewModel.LoadRefereesViewModel();
                RefereeView.ViewReferees.Refresh();
            }
            catch (Exception)
            {
                throw new Exception("File refereesList.xml not found");
            }
            try
            {
                TournamentViewModel.LoadViewModel();
                TournamentView.Refresh();
            }
            catch (Exception)
            {
                throw new Exception("File tournamentsList.xml not found");
            }
        }
    }
}
