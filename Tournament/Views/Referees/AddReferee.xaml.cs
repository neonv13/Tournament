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

        private void Button_Click_AddReferee(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string surname = SurnameTextBox.Text;
            bool IsNameValid;
            bool IsSurameValid;
            if (name != string.Empty)
                IsNameValid = true;
            else
            {
                ErrorWindow errorNameWindow = new ErrorWindow();
                errorNameWindow.ErrorContent.Text = "Please enter the Name";
                errorNameWindow.Show();
                return;
            }
            if (surname != string.Empty)
                IsSurameValid = true;
            else
            {
                ErrorWindow errorSurnameWindow = new ErrorWindow();
                errorSurnameWindow.ErrorContent.Text = "Please enter the Surname";
                errorSurnameWindow.Show();
                return;
            }
            if (IsNameValid && IsSurameValid)
            {
                RefereesViewModel.Referees.Add(new Referee() { Name = name, Surname = surname, ID = -1 });
                ViewReferees.Refresh();
                NavigationService.Navigate(ViewReferees);
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.ErrorContent.Text = "Succesfully added Referee";
                errorWindow.Show();
            }
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            ViewReferees.Refresh();
            NavigationService.Navigate(ViewReferees);
        }
    }
}
