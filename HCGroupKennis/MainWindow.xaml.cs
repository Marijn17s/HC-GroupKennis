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
        private Groups.SubGroupType SelectedSubGroup;
        private static CvItem test = new("testNaam", Groups.MainGroupType.Miscellaneous, Groups.SubGroupType.Miscellaneous, new DateTime(2020), 8.5);
        private readonly List<CvItem> AllCvItems = new List<CvItem>()
        {
            test
        };
        private List<CvItem> FilteredCvItems = new List<CvItem>();

        public MainWindow()
        {
            InitializeComponent();
            MainGroupComboBox.ItemsSource = Enum.GetValues(typeof(Groups.MainGroupType));
            SubGroupComboBox.ItemsSource = Enum.GetValues(typeof(Groups.SubGroupType));
        }

        private void GroupsFilter_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //FilteredCvItems = AllCvItems;
            if (MainGroupComboBox is null || SubGroupComboBox is null || AllCvItems is null || FilteredCvItems is null)
                return;
            // Only MainGroup filter applied
            if (MainGroupComboBox.SelectedIndex != 0 && SubGroupComboBox.SelectedIndex == 0)
            {
                FilteredCvItems = AllCvItems.Where(item => item.MainGroup == SelectedMainGroup).ToList();
                return;
            }
            // Only SubGroup filter applied
            else if (MainGroupComboBox.SelectedIndex == 0 && SubGroupComboBox.SelectedIndex != 0)
            {
                FilteredCvItems = AllCvItems.Where(item => item.SubGroup == SelectedSubGroup).ToList();
                return;
            }
            // Both filters applied
            else if (MainGroupComboBox.SelectedIndex != 0 && SubGroupComboBox.SelectedIndex != 0)
            {
                FilteredCvItems = AllCvItems.Where(item => item.MainGroup == SelectedMainGroup)
                    .Where(item => item.SubGroup == SelectedSubGroup).ToList();
                return;
            }
            // No filters applied
            return;
        }
    }
}
