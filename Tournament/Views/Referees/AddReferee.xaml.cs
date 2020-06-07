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

namespace Tournament.Views.Referees
{
    /// <summary>
    /// Interaction logic for AddReferee.xaml
    /// </summary>
    public partial class AddReferee : Page
    {
        public RefereesViewModel RefereesViewModel { get; set; }
        public ViewReferees ViewReferees { get; set; }
        public AddReferee(RefereesViewModel refereesViewModel, ViewReferees viewReferees)
        {
            RefereesViewModel = refereesViewModel;
            ViewReferees = viewReferees;
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RefereesViewModel refereesViewModel = new RefereesViewModel();
            string name = NameTextBox.Text;
            string surname = SurnameTextBox.Text;
            refereesViewModel.Referees.AddReferee(new Referee(name, surname, refereesViewModel.Referees.RefereesList));
            refereesViewModel.SaveRefereesViewModel();
            NavigationService.Navigate(ViewReferees);
        }
    }
}
