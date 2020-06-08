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
            int id = int.Parse(IDTextBox.Text);
            string name = NameTextBox.Text;
            string surname = SurnameTextBox.Text;
            Referee referee = RefereesViewModel.Referees.FindByID(id);
            bool IsNameValid;
            bool IsSurameValid;
            bool IsRefereeValid;
            bool IsIDValid;
            if (id >= 0)
            {
                IsIDValid = true;
            }
            else 
            {
                ErrorWindow errorNameWindow = new ErrorWindow();
                errorNameWindow.ErrorContent.Text = "Please enter the ID";
                errorNameWindow.Show();
                return;
            }
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

            if (referee != null)
            {
                IsRefereeValid = true;
            }
            else
            {
                ErrorWindow errorSurnameWindow = new ErrorWindow() { Width = Width + 200 };
                errorSurnameWindow.ErrorContent.Text = "There is no such referee in the database";
                errorSurnameWindow.Show();
                return;

            }

            if (IsNameValid && IsRefereeValid && IsSurameValid && IsIDValid)
            {
                RefereesViewModel.Referees.Remove(id);
                ViewReferees.Refresh();
                NavigationService.Navigate(ViewReferees);
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.ErrorContent.Text = "Succesfully removed Referee";
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
