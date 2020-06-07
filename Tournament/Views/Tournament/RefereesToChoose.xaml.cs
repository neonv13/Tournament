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

namespace Tournament.Views.Tournament
{
    /// <summary>
    /// Interaction logic for RefereesToChoose.xaml
    /// </summary>
    public partial class RefereesToChoose : Page
    {
        public RefereesViewModel RefereesViewModel { get; set; }

        public RefereesToChoose(RefereesViewModel refereesViewModel)
        {
            RefereesViewModel = refereesViewModel;
            InitializeComponent();
            RefereesListBox.ItemsSource = RefereesViewModel.Referees.List;
        }
    }
}
