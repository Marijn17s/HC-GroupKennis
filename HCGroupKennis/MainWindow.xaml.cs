using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();

            // Fill the comboboxes with the filter options.
            MainGroupComboBox.ItemsSource = Enum.GetValues(typeof(Groups.MainGroupType));
            SubGroupComboBox.ItemsSource = Enum.GetValues(typeof(Groups.SubGroupType));
            
            // Only fill the datagrid with all items for the first time.
            CvDataGrid.ItemsSource = AllCvItems;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region Fields

        private readonly List<CvItem> AllCvItems = new List<CvItem>()
        {
            new CvItem("testNaam", Groups.MainGroupType.Backend, Groups.SubGroupType.Miscellaneous, 2020, 8.5),
        };

        private List<CvItem> FilteredCvItems = new List<CvItem>();

        #endregion

        #region Properties
        
        private Groups.MainGroupType selectedMainGroup;
        internal Groups.MainGroupType SelectedMainGroup {
            get => selectedMainGroup;
            set
            {
                selectedMainGroup = value;
                OnPropertyChanged();
            }
        }

        private Groups.SubGroupType selectedSubGroup;
        internal Groups.SubGroupType SelectedSubGroup {
            get => selectedSubGroup;
            set
            {
                selectedSubGroup = value;
                OnPropertyChanged();
            }
        }

        #endregion

        private void GroupsFilter_DropDownClosed(object? sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ResetMainGroupFilter_OnClick(object sender, RoutedEventArgs e)
        {
            MainGroupComboBox.SelectedIndex = -1;
            ApplyFilters();
        }

        private void ResetSubGroupFilter_OnClick(object sender, RoutedEventArgs e)
        {
            SubGroupComboBox.SelectedIndex = -1;
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            if (MainGroupComboBox?.SelectedItem is not null)
                SelectedMainGroup = (Groups.MainGroupType)Enum.Parse(typeof(Groups.MainGroupType), MainGroupComboBox?.SelectedItem.ToString());
            if (SubGroupComboBox?.SelectedItem is not null)
                SelectedSubGroup = (Groups.SubGroupType)Enum.Parse(typeof(Groups.SubGroupType), SubGroupComboBox?.SelectedItem.ToString());
            Debug.WriteLine($"MainGroup: {SelectedMainGroup}, SubGroup: {SelectedSubGroup}");
            if (MainGroupComboBox is null || SubGroupComboBox is null || AllCvItems is null || FilteredCvItems is null)
                return;
            // No filters applied
            if (MainGroupComboBox.SelectedIndex == -1 && SubGroupComboBox.SelectedIndex == -1)
                FilteredCvItems = AllCvItems;
            // Only MainGroup filter applied
            else if (MainGroupComboBox.SelectedIndex != -1 && SubGroupComboBox.SelectedIndex == -1)
                FilteredCvItems = AllCvItems.Where(item => item.MainGroup == SelectedMainGroup).ToList();
            // Only SubGroup filter applied
            else if (MainGroupComboBox.SelectedIndex == -1 && SubGroupComboBox.SelectedIndex != -1)
                FilteredCvItems = AllCvItems.Where(item => item.SubGroup == SelectedSubGroup).ToList();
            // Both filters applied
            else if (MainGroupComboBox.SelectedIndex != -1 && SubGroupComboBox.SelectedIndex != -1)
                FilteredCvItems = AllCvItems.Where(item => item.MainGroup == SelectedMainGroup)
                    .Where(item => item.SubGroup == SelectedSubGroup).ToList();
            CvDataGrid.ItemsSource = FilteredCvItems;
            return;
        }
    }
}
