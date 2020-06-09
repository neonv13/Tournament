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
        public ViewReferees(RefereesViewModel refereesViewModel)
        {
            RefereesViewModel = refereesViewModel;
            RefereeList = RefereesViewModel.Referees;
            InitializeComponent();
            RefereeListBox.ItemsSource = RefereeList.List;
            
        }
        public ViewReferees( RefereeList refereeList) 
        {
            RefereeList = refereeList;
            InitializeComponent();
            RefereeListBox.ItemsSource = RefereeList.List;
        }

        public void Refresh()
        {
            RefereeListBox.ItemsSource = null;
            RefereeListBox.ItemsSource = RefereeList.List;
        }
    }
}
