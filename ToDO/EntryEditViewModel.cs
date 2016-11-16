using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using static ToDO.MainWindow;

namespace ToDO
{
    public class EntryEditViewModel : INotifyPropertyChanged
    {
        private ToDoEntries _currentEntry;

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
                           ToDoEntries updateEntry = db.ToDoEntries.Find(Entry.Id);
                           if (updateEntry != null)
                           {
                               updateEntry.Title = _currentEntry.Title;
                               updateEntry.Description = _currentEntry.Description;
                               updateEntry.Priority = _currentEntry.Priority;
                               updateEntry.DateEnd = _currentEntry.DateEnd;
                               updateEntry.Location = _currentEntry.Location;
                               updateEntry.DateCreation = _currentEntry.DateCreation;
                               updateEntry.Done = _currentEntry.Done;

                               //MainWindow.db.Entry(updateEntry).State = EntityState.Modified;
                               db.SaveChanges();

                           }
                           
                           Navigation.GoBack();
                       }));
            }
        }

        public ToDoCommand BackCommand
        {
            get
            {
                return _entryBackCommand ?? (_entryBackCommand = new ToDoCommand(obj =>
                {
                    Navigation.GoBack();
                }));
            }
        }

        public EntryEditViewModel()
        {
            _currentEntry = Entry;

            Title = _currentEntry.Title;
            Description = _currentEntry.Description;
            PriorityIndex = 1;
            DateEnd = DateTime.ParseExact(_currentEntry.DateEnd, "dd/MM/yyyy", null);
            //DateEnd = DateTime.ParseExact(_currentEntry.DateEnd, "MM/dd/yyyy", null);
            Location = _currentEntry.Location;
        }

        private bool ValidateEntry()
        {

            if (Title == null || (Title.Length == 0 && Title.Length > 255)) return false;
            if (Description==null || (Description.Length == 0)) return false;

                _currentEntry = new ToDoEntries
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
