using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HCGroupKennis.Classes;

namespace HCGroupKennis
{
    public partial class MainWindow : Window
    {
        private Groups.MainGroupType SelectedMainGroup;

        public MainWindow()
        {
            InitializeComponent();
            MainGroupComboBox.ItemsSource = Enum.GetValues(typeof(Groups.MainGroupType));
            SubGroupComboBox.ItemsSource = Enum.GetValues(typeof(Groups.SubGroupType));
        }
    }
}
