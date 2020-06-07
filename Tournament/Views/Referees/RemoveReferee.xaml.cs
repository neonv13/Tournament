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
using Tournament.Models;
using Tournament.ViewModels;
using Tournament.Views.Players;

namespace Tournament.Views.Referees
{
    /// <summary>
    /// Interaction logic for RemoveReferee.xaml
    /// </summary>
    public partial class RemoveReferee : Page
    {
        public RefereesViewModel RefereesViewModel { get; set; }
        public ViewReferees ViewReferees { get; set; }
        public RemoveReferee(RefereesViewModel refereesViewModel, ViewReferees viewReferees)
        {
            RefereesViewModel = refereesViewModel;
            ViewReferees = viewReferees;
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RefereesViewModel refereesViewModel = new RefereesViewModel();
            int id = int.Parse(IDTextBox.Text);
            string name = NameTextBox.Text;
            string surname = SurnameTextBox.Text;
            Referee referee = refereesViewModel.Referees.FindByID(id);
            if (referee != null && referee.Name == name && referee.Surname == surname)
            {                     
                refereesViewModel.Referees.Remove(id);
                refereesViewModel.SaveRefereesViewModel();
            }
            NavigationService.Navigate(ViewReferees);
        }
    }
}
