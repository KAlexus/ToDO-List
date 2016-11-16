using System;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;

namespace ToDO
{
    /// <summary>
    /// Interaction logic for Entry.xaml
    /// </summary>
    public partial class EntryAdd : Page
    {
        public EntryAdd()
        {
            InitializeComponent();
            DataContext = new EntryAddViewModel();
        }
    }
}
