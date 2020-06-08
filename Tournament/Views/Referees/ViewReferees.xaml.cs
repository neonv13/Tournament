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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tournament.Models;
using Tournament.ViewModels;

namespace Tournament.Views.Referees
{
    /// <summary>
    /// Interaction logic for ViewReferees.xaml
    /// </summary>
    public partial class ViewReferees : Page
    {
        public RefereesViewModel RefereesViewModel { get; set; }
        public RefereeList RefereeList { get; set; }
        public ViewReferees(RefereesViewModel refereesViewModel, RefereeList refereeList)
        {
            RefereesViewModel = refereesViewModel;
            InitializeComponent();
            if (refereeList == null)
                RefereeListBox.ItemsSource = RefereesViewModel.Referees.List;
            else
                RefereeListBox.ItemsSource = RefereeList.List;
            
        }
        public void Refresh()
        {
            RefereeListBox.ItemsSource = null;
            RefereeListBox.ItemsSource = RefereesViewModel.Referees.List;
        }
    }
}
