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
using Tournament.Views.Players;

namespace Tournament.Views.Referees
{
    /// <summary>
    /// Interaction logic for RemoveReferee.xaml
    /// </summary>
    public partial class RemoveReferee : Page
    {
        public RemoveReferee()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RefereesViewModel refereesViewModel = new RefereesViewModel();
            int id = int.Parse(IDTextBox.Text);
            string name = NameTextBox.Text;
            string surname = SurnameTextBox.Text;
            if (refereesViewModel.Referees.FindRefereeByID(id).Name == name && refereesViewModel.Referees.FindRefereeByID(id).Surname == surname)
            {                     
                refereesViewModel.Referees.RemoveReferee(id);
                refereesViewModel.Referees.SaveRefereeList("refereesList.txt");
            }
            NavigationService.Navigate(new ViewPlayers());
        }
    }
}
