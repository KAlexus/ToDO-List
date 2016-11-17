using System.Windows.Controls;

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
    }
}
