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

namespace Tournament.Views.Referees
{
    /// <summary>
    /// Interaction logic for RefereeView.xaml
    /// </summary>
    public partial class RefereeView : Page
    {
        public RefereeView()
        {
            InitializeComponent();
        }
        private void Button_Click_AddReferee(object sender, RoutedEventArgs e)
        {
            Referees.Content = new AddReferee();
        }
        private void Button_Click_RemoveReferee(object sender, RoutedEventArgs e)
        {
            Referees.Content = new RemoveReferee();
        }
        private void Button_Click_ViewReferees(object sender, RoutedEventArgs e)
        {
            Referees.Content = new ViewReferees();
        }
    }
}
