using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Tournament.Models;
using Tournament.ViewModels;

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
        private void Button_Click_RemoveReferee(object sender, RoutedEventArgs e)
        {
            bool IsNameValid;
            bool IsSurameValid;
            bool IsRefereeValid;
            bool IsIDValid;
            string name = NameTextBox.Text;
            string surname = SurnameTextBox.Text;
            int id;

            if(IDTextBox.Text != string.Empty)
            {
                id = int.Parse(IDTextBox.Text);

                if (id >= 0)
                {
                    IsIDValid = true;
                }
                else
                {
                    Error( "Please enter corect ID");
                    return;
                }

            }
            else
            {
                Error( "Please enter ID");
                return;
            }
            Referee referee = RefereesViewModel.Referees.FindByID(id);
            

            
            if (name != string.Empty)
                IsNameValid = true;
            else
            {
                Error( "Please enter the Name");
                return;
            }

            if (surname != string.Empty)
                IsSurameValid = true;
            else
            {
                Error("Please enter the Surname");
                return;

            }

            if (referee != null)
            {
                IsRefereeValid = true;
            }
            else
            {
                Error("There is no such referee in the database");
                return;

            }

            if (IsNameValid && IsRefereeValid && IsSurameValid && IsIDValid && referee.Name == name && referee.Surname == surname)
            {
                RefereesViewModel.Referees.Remove(id);
                ViewReferees.Refresh();
                NavigationService.Navigate(ViewReferees);
                Error("Succesfully removed Referee");
            }
            else
            {
                Error( "There is no such referee in the database");
                return;
            }
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            ViewReferees.Refresh();
            NavigationService.Navigate(ViewReferees);
        }
        private void Error(string text)
        {
            ErrorWindow errorSurnameWindow = new ErrorWindow() { Width = 400 };
            errorSurnameWindow.ErrorContent.Text = text;
            errorSurnameWindow.Show();
        }
    }
}
