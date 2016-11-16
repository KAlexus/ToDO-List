using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ToDO
{
    public enum EntryPriority { Low, Standart, High}

    public class ToDoEntries : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _title;
        private string _dateCreation;
        private string _priority;
        private string _description;
        private string _dateEnd;
        private string _location;
        private int _done;

        public int Id { get; set; }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        public string DateCreation
        {
            get { return _dateCreation; }
            set
            {
                _dateCreation = value;
                OnPropertyChanged("DateCreation");
            }
        }
        public string Priority
        {
            get { return _priority; }
            set
            {
                _priority = value;
                OnPropertyChanged("Priority");
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }
        public string DateEnd
        {
            get { return _dateEnd; }
            set
            {
                _dateEnd = value;
                OnPropertyChanged("DateEnd");
            }
        }
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged("Location");
            }
        }
        public int Done
        {
            get { return _done; }
            set
            {
                _done = value;
                OnPropertyChanged("Done");
            }
        }

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Title" :
                        if (_title.Length==0)
                        {
                            error = "Title is empty";
                        }
                        else if (_title.Length > 100)
                        {
                            error = "Title is too long. Max - 100 symbols";
                        }
                        break;
                    case "Description":
                        if (_description.Length == 0)
                        {
                            error = "Description is empty";
                        }
                        else if (_description.Length > 255)
                        {
                            error = "Description is too long. Max - 256 symbols";
                        }
                        break;
                }
                return error;
            }
        }

        public override string ToString()
        {
            return "Entry: "+ "Creation Date-" + DateCreation + ",Title-" +Title+", Description-"+Description+", Priority-"+Priority+", End Data-"+DateEnd+", Location-"+Location+", Done-"+Done;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        
    }
}
