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

namespace Tournament.Views.Referees
{
    /// <summary>
    /// Interaction logic for RefereeView.xaml
    /// </summary>
    public partial class RefereeView : Page
    {
        public RefereesViewModel RefereesViewModel { get; set; }
        public ViewReferees ViewReferees { get; set; }
        public RefereeView(RefereesViewModel refereesViewModel)
        {
            RefereesViewModel = refereesViewModel;
            ViewReferees = new ViewReferees(RefereesViewModel);
            InitializeComponent();
            Referees.Content = ViewReferees;
        }
        private void Button_Click_AddReferee(object sender, RoutedEventArgs e)
        {
            Referees.Content = new AddReferee(RefereesViewModel,ViewReferees);
        }
        private void Button_Click_RemoveReferee(object sender, RoutedEventArgs e)
        {
            Referees.Content = new RemoveReferee(RefereesViewModel, ViewReferees);
        }
        private void Button_Click_ViewReferees(object sender, RoutedEventArgs e)
        {
            ViewReferees.Refresh();
            Referees.Content = ViewReferees;

        }
    }
}
