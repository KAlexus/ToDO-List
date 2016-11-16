using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using System.Windows.Navigation;
using System.Windows;
using System.Windows.Controls.Primitives;
using MaterialDesignThemes.Wpf;
using static ToDO.MainWindow;

namespace ToDO
{
    class EntriesListViewModel : INotifyPropertyChanged
    {
        private ToDoEntries _selectedEntry;
        public ObservableCollection<ToDoEntries> Entries { get; set; }

        private ToDoCommand _addCommand;
        private ToDoCommand _editCommand;
        private ToDoCommand _removeCommand;
        private ToDoCommand _exitCommand;


        public EntriesListViewModel()
        {
            Entries = db.ToDoEntries.Local;
        }

        public ToDoCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new ToDoCommand(obj =>
                {
                    Navigation.Navigate(new System.Uri("EntryAdd.xaml", UriKind.RelativeOrAbsolute));
                }));
            }
        }
        public ToDoCommand EditCommand
        {
            get
            {
                return _editCommand ?? (_editCommand = new ToDoCommand(obj =>
                       {
                           Entry = SelectedEntry;
                           Navigation.Navigate(new System.Uri("EntryEdit.xaml", UriKind.RelativeOrAbsolute));
                       },
                       (obj) => SelectedEntry != null));
            }
        }
        public ToDoCommand RemoveCommand
        {
            get
            {
                return _removeCommand ?? (_removeCommand = new ToDoCommand(obj =>
                {
                    Entry = SelectedEntry;
                    ToDoEntries updateEntry = db.ToDoEntries.Find(SelectedEntry.Id);
                    if (updateEntry != null)
                    {
                        //MainWindow.db.Entry(updateEntry).State = EntityState.Deleted;
                        db.ToDoEntries.Remove(updateEntry);
                        db.SaveChanges();
                    }
                    
                },
                       (obj) => SelectedEntry != null));
            }
        }
       
        public ToDoCommand ExitCommand
        {
            get
            {
                return _exitCommand ?? (_exitCommand = new ToDoCommand(obj =>
                {
                    Application.Current.Shutdown();
                }));
            }
        }

        public ToDoEntries SelectedEntry
        {
            get
            {
                return _selectedEntry;
            }
            set
            {
                Entry = value;
                _selectedEntry = value;

                OnPropertyChanged("SelectedEntry");
            }
        }

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
