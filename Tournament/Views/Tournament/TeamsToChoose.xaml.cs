using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tournament.ViewModels;

namespace Tournament.Views.Tournament
{
    /// <summary>
    /// Interaction logic for TeamsToChoose.xaml
    /// </summary>
    public partial class TeamsToChoose : Page
    {
        public TeamViewModel TeamViewModel { get; set; }
        public TeamsToChoose(TeamViewModel teamViewModel)
        {
            TeamViewModel = teamViewModel;
            InitializeComponent();
            TeamsListBox.ItemsSource = TeamViewModel.Teams.TeamsList;
        }
    }
}
