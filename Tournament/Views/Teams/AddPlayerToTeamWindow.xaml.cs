using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tournament.Models;
using Tournament.ViewModels;

namespace Tournament.Views.Teams
{
    /// <summary>
    /// Interaction logic for AddPlayerToTeamWindow.xaml
    /// </summary>
    public partial class AddPlayerToTeamWindow : Window
    {
        public TeamViewModel TeamViewModel { get; set; }
        public Team Team{ get; set; }
        public TeamWindow TeamWindow { get; set; }

        public AddPlayerToTeamWindow(Team team, TeamWindow teamWindow, TeamViewModel teamViewModel)
        {
            TeamWindow = teamWindow;
            TeamViewModel = teamViewModel;
            Team = team;
            InitializeComponent();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            PlayersViewModel playersViewModel = new PlayersViewModel();
            
            int id = int.Parse(IDText.Text);
            string name = NameText.Text;
            string surname = SurnameText.Text;
            Player player = playersViewModel.Players.FindPlayerByID(id);
            if (player != null &&  player.Name == name && player.Surname == surname)
            {
                if (!Team.IsInTeam(id))
                {
                    Team.AddPlayer(player);
                    TeamWindow.Refresh();
                    TeamViewModel.SaveTeamViewModel();
                    this.Close();
                }
                else
                {
                    ErrorWindow errorWindow = new ErrorWindow
                    {
                        Height = 300,
                        Width = 500
                    };
                    errorWindow.ErrorContent.Text = "This player is already in this team";
                    errorWindow.Show();
                }
            }
            else
            {
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.Show();
            }
        }

       
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
