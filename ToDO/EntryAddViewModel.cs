using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace ToDO
{
    public class EntryAddViewModel : INotifyPropertyChanged
    {
        private ToDoEntries _newEntry;
#pragma warning disable CS0169 // The field 'EntryAddViewModel._currentEntry' is never used
        private ToDoEntries _currentEntry;
#pragma warning restore CS0169 // The field 'EntryAddViewModel._currentEntry' is never used

        public string Title { get; set; }
        public string Description { get; set; }
        public ComboBoxItem Priority { get; set; }
        public int PriorityIndex { get; set; }
        public DateTime DateEnd { get; set; }
        public string Location { get; set; }

        private ToDoCommand _entryAddCommand;
        private ToDoCommand _entryBackCommand;

        public ToDoCommand AddEntryCommand
        {
            get
            {
                return _entryAddCommand ?? (_entryAddCommand = new ToDoCommand(obj =>
                       {
                           if (!ValidateEntry()) return;
                           MainWindow.db.ToDoEntries.Add(_newEntry);
                           MainWindow.db.SaveChanges();
                           MainWindow.Navigation.GoBack();
                       }));
            }
        }

        public ToDoCommand BackCommand
        {
            get
            {
                return _entryBackCommand ?? (_entryBackCommand = new ToDoCommand(obj =>
                {
                    MainWindow.Navigation.GoBack();
                }));
            }
        }
        public EntryAddViewModel()
        {
            this.DateEnd = DateTime.Now;
            this.PriorityIndex = 1;
        }


        private bool ValidateEntry()
        {

            if (Title == null || (Title.Length == 0 && Title.Length > 255)) return false;
            if (Description==null || (Description.Length == 0)) return false;

                _newEntry = new ToDoEntries
            {
                Title = this.Title,
                Description = this.Description,
                Priority = Priority?.Content.ToString() ?? "Standart",
                DateCreation = DateTime.Now.ToString("dd/MM/yyyy"),
                DateEnd = this.DateEnd.ToString("dd/MM/yyyy"),
                Location = this.Location
            };

            return true;
        }

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
