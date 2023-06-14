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
            new CvItem("Zelfstandig gestart met plugins maken in Lua", Groups.MainGroupType.Fullstack, Groups.SubGroupType.Overig, 2018),
            new CvItem("Geëxperimenteerd met Adobe Photoshop", Groups.MainGroupType.Design, Groups.SubGroupType.Photoshop, 2019),
            new CvItem("Zelfstandig gestart met C# in WinForms", Groups.MainGroupType.Fullstack, Groups.SubGroupType.CSharp, 2020),
            new CvItem("Zelfstandig gestart met Adobe After Effects", Groups.MainGroupType.Design, Groups.SubGroupType.AfterEffects, 2020),
            new CvItem("Begonnen met eigen project in C# WinForms", Groups.MainGroupType.Fullstack, Groups.SubGroupType.CSharp, 2021),
            new CvItem("Eigen website opgezet", Groups.MainGroupType.Fullstack, Groups.SubGroupType.Web, 2021),
            new CvItem("Geëperimenteerd met Adobe Premiere Pro", Groups.MainGroupType.Design, Groups.SubGroupType.PremierePro, 2021),
            new CvItem("Op school gestart met HTML, CSS, Javascript", Groups.MainGroupType.Frontend, Groups.SubGroupType.Web, 2021),
            new CvItem("Op school gestart met basis C# in WPF", Groups.MainGroupType.Frontend, Groups.SubGroupType.CSharp, 2021),
            new CvItem("Geleerd responsive designs te maken in WPF", Groups.MainGroupType.Frontend, Groups.SubGroupType.CSharp, 2021),
            new CvItem("Geleerd responsive designs te maken in HTML, CSS", Groups.MainGroupType.Frontend, Groups.SubGroupType.Web, 2021),
            new CvItem("Op school gestart met MySQL", Groups.MainGroupType.Overig, Groups.SubGroupType.DatabaseBeheer, 2021),
            new CvItem("Op school gestart met PHP", Groups.MainGroupType.Backend, Groups.SubGroupType.Php, 2022),
            new CvItem("Op school gestart met CRUD applicaties in C#", Groups.MainGroupType.Backend, Groups.SubGroupType.CSharp, 2022),
            new CvItem("Op school gestart met CRUD applicaties in PHP", Groups.MainGroupType.Backend, Groups.SubGroupType.Php, 2022),
            new CvItem("Op school basis van Linux geleerd", Groups.MainGroupType.Overig, Groups.SubGroupType.Overig, 2022),
            new CvItem("Op school geleerd Unit tests te maken in C#", Groups.MainGroupType.Overig, Groups.SubGroupType.CSharp, 2022),
            new CvItem("Op school geleerd Unit tests te maken in Laravel", Groups.MainGroupType.Overig, Groups.SubGroupType.Laravel, 2022),
            new CvItem("Op school geleerd Feature tests te maken in Laravel", Groups.MainGroupType.Overig, Groups.SubGroupType.Laravel, 2022),
            new CvItem("Conditional operators in C#", Groups.MainGroupType.Backend, Groups.SubGroupType.CSharp, 2022),
            new CvItem("DLL's importeren en gebruiken in C#", Groups.MainGroupType.Backend, Groups.SubGroupType.CSharp, 2022),
            new CvItem("Inheritance in C#", Groups.MainGroupType.Backend, Groups.SubGroupType.CSharp, 2022),
            new CvItem("Polymorfisme in C#", Groups.MainGroupType.Backend, Groups.SubGroupType.CSharp, 2022),
            new CvItem("Geëxperimenteerd met C++", Groups.MainGroupType.Backend, Groups.SubGroupType.Overig, 2022),
            new CvItem("Eigen project update geautomatiseerd tijdens dat de applicatie draait", Groups.MainGroupType.Backend, Groups.SubGroupType.CSharp, 2022),
            new CvItem("Op school gestart met Laravel Framework (PHP)", Groups.MainGroupType.Fullstack, Groups.SubGroupType.CSharp, 2022),
            new CvItem("Op school gestart met API's maken in Laravel", Groups.MainGroupType.Backend, Groups.SubGroupType.Laravel, 2022),
            new CvItem("Op school gestart met CRUD door middel van een API in Laravel", Groups.MainGroupType.Backend, Groups.SubGroupType.Laravel, 2022),
            new CvItem("Op school frontend gemaakt om API te leren gebruiken", Groups.MainGroupType.Frontend, Groups.SubGroupType.Web, 2023),
            new CvItem("Op school geleerd API semi-live te zetten op virtuele machine", Groups.MainGroupType.Frontend, Groups.SubGroupType.Web, 2023),
            new CvItem("Op school gestart met beschermde API's in Laravel", Groups.MainGroupType.Backend, Groups.SubGroupType.Laravel, 2023),
            new CvItem("Beschermde API gemaakt voor eigen website in Laravel", Groups.MainGroupType.Backend, Groups.SubGroupType.Laravel, 2023),
            new CvItem("Op school gestart met het Flutter Framework", Groups.MainGroupType.Fullstack, Groups.SubGroupType.Flutter, 2023),
            new CvItem("Op school gestart met Wordpress", Groups.MainGroupType.Fullstack, Groups.SubGroupType.Web, 2023),
            new CvItem("Zelfstandig gestart met Adobe Lightroom", Groups.MainGroupType.Design, Groups.SubGroupType.Lightroom, 2023),
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

        #region EventHandlers

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

        #region Validation

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

        #endregion

        private void ResetYearFilter_OnClick(object sender, RoutedEventArgs e)
        {
            // Reset all filters by year.
            YearTextBox.Text = string.Empty;
            YearFilter = 0;
            ApplyFilters();
        }

        #endregion
    }
}
