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

namespace Tournament.Views.Tournament.TourWindow
{
    /// <summary>
    /// Interaction logic for TourInfo.xaml
    /// </summary>
    public partial class TourInfo : Page
    {
        public Tournaments Tournaments { get; set; }

        public TourInfo(Tournaments tournaments)
        {
            Tournaments = tournaments;
            InitializeComponent();
        }
        
    }
}
