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
            new CvItem("test1", Groups.MainGroupType.Backend, Groups.SubGroupType.Miscellaneous, 2020, 8.5),
            new CvItem("test1(2)", Groups.MainGroupType.Backend, Groups.SubGroupType.Miscellaneous, 2019, 8.5),
            new CvItem("test2", Groups.MainGroupType.Frontend, Groups.SubGroupType.CSharp, 2020, 7.5),
            new CvItem("test3", Groups.MainGroupType.Backend, Groups.SubGroupType.CSharp, 2020, 9.5),
            new CvItem("test4", Groups.MainGroupType.Design, Groups.SubGroupType.Photoshop, 2020, 6.5),
            new CvItem("test5", Groups.MainGroupType.Design, Groups.SubGroupType.AfterEffects, 2020, 6.5),
            new CvItem("test6", Groups.MainGroupType.Design, Groups.SubGroupType.PremierePro, 2020, 6.5),
            new CvItem("test7", Groups.MainGroupType.Design, Groups.SubGroupType.Lightroom, 2020, 8.0),
            new CvItem("test8", Groups.MainGroupType.Miscellaneous, Groups.SubGroupType.MySql, 2020, 8.0),
            new CvItem("test9", Groups.MainGroupType.Frontend, Groups.SubGroupType.Css, 2020, 8.0),
            new CvItem("test10", Groups.MainGroupType.Frontend, Groups.SubGroupType.Javascript, 2019, 8.0),
            new CvItem("test11", Groups.MainGroupType.Frontend, Groups.SubGroupType.Html, 2019, 8.0),
            new CvItem("test10", Groups.MainGroupType.Frontend, Groups.SubGroupType.Php, 2020, 8.0),
        };

        private List<CvItem> FilteredCvItems = new List<CvItem>();

        #endregion

        #region Properties

        private int YearFilter { get; set; }

        private Groups.MainGroupType selectedMainGroup;
        internal Groups.MainGroupType SelectedMainGroup {
            get => selectedMainGroup;
            set => selectedMainGroup = value;
        }

        private Groups.SubGroupType selectedSubGroup;
        internal Groups.SubGroupType SelectedSubGroup {
            get => selectedSubGroup;
            set => selectedSubGroup = value;
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
            if (MainGroupComboBox is null || SubGroupComboBox is null || AllCvItems is null || FilteredCvItems is null)
                return;

            // No filters applied
            if (MainGroupComboBox.SelectedIndex == -1 && SubGroupComboBox.SelectedIndex == -1 && YearFilter.ToString().Length != 4)
                FilteredCvItems = AllCvItems;

            // Only Year filter applied
            if (MainGroupComboBox.SelectedIndex == -1 && SubGroupComboBox.SelectedIndex == -1 && YearFilter.ToString().Length == 4)
                FilteredCvItems = AllCvItems
                    .Where(item => item.Year.Equals(YearFilter)).ToList();

            // Only MainGroup filter applied
            else if (MainGroupComboBox.SelectedIndex != -1 && SubGroupComboBox.SelectedIndex == -1 && YearFilter.ToString().Length != 4)
                FilteredCvItems = AllCvItems
                    .Where(item => item.MainGroup == SelectedMainGroup).ToList();

            // MainGroup and Year filter applied
            else if (MainGroupComboBox.SelectedIndex != -1 && SubGroupComboBox.SelectedIndex == -1 && YearFilter.ToString().Length == 4)
                FilteredCvItems = AllCvItems
                    .Where(item => item.MainGroup == SelectedMainGroup)
                    .Where(item => item.Year.Equals(YearFilter)).ToList();

            // Only SubGroup filter applied
            else if (MainGroupComboBox.SelectedIndex == -1 && SubGroupComboBox.SelectedIndex != -1 && YearFilter.ToString().Length != 4)
                FilteredCvItems = AllCvItems
                    .Where(item => item.SubGroup == SelectedSubGroup).ToList();

            // SubGroup and Year filter applied
            else if (MainGroupComboBox.SelectedIndex == -1 && SubGroupComboBox.SelectedIndex != -1 && YearFilter.ToString().Length == 4)
                FilteredCvItems = AllCvItems
                    .Where(item => item.SubGroup == SelectedSubGroup)
                    .Where(item => item.Year.Equals(YearFilter)).ToList();

            // MainGroup and SubGroup filters applied
            else if (MainGroupComboBox.SelectedIndex != -1 && SubGroupComboBox.SelectedIndex != -1 && YearFilter.ToString().Length != 4)
                FilteredCvItems = AllCvItems
                    .Where(item => item.MainGroup == SelectedMainGroup)
                    .Where(item => item.SubGroup == SelectedSubGroup).ToList();

            // MainGroup, SubGroup and Year filters applied
            else if (MainGroupComboBox.SelectedIndex != -1 && SubGroupComboBox.SelectedIndex != -1 && YearFilter.ToString().Length == 4)
                FilteredCvItems = AllCvItems
                    .Where(item => item.MainGroup == SelectedMainGroup)
                    .Where(item => item.SubGroup == SelectedSubGroup)
                    .Where(item => item.Year.Equals(YearFilter)).ToList();

            // Fill the DataGrid with only the filtered items.
            CvDataGrid.ItemsSource = FilteredCvItems;

            return;
        }

        private void YearFilter_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            // Make sure the textbox is not empty and has 4 characters.
            if (YearTextBox is null || YearTextBox.Text.Equals(string.Empty))
                return;
            YearFilter = int.Parse(YearTextBox.Text);
            ApplyFilters();
        }

        private void YearTextBox_PreviewTextInput(object? sender, TextCompositionEventArgs e)
        {
            // Make sure there are only numbers in the textbox.
            e.Handled = e.Text is null || !e.Text.All(char.IsDigit);
        }

        private void YearTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Make sure there are no spaces in the textbox.
            e.Handled = e.Key == Key.Space;
        }

        private void HandleCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Disable pasting invalid characters into the textbox.
            if (e.Command == ApplicationCommands.Paste) {
                e.CanExecute = false;
                e.Handled = true;
            }
        }

        private void ResetYearFilter_OnClick(object sender, RoutedEventArgs e)
        {
            // Reset all filters by year.
            YearTextBox.Text = string.Empty;
            YearFilter = 0;
            ApplyFilters();
        }
    }
}
