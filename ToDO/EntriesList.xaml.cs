using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using MaterialDesignThemes.Wpf;

namespace ToDO
{
    /// <summary>
    /// Interaction logic for EntriesList.xaml
    /// </summary>
    public partial class EntriesList : Page
    {
        public EntriesList()
        {
            InitializeComponent();
            DataContext = new EntriesListViewModel();
        }

        private void ButtonView_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Navigation.Navigate(new System.Uri("EntryEdit.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
