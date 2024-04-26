using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RELaba6Sem2.Models
{
    public class Movie:INotifyPropertyChanged
    {
        public string _title;
        public string _genre;
        public int _year;
        public double _rating;
        public string _prodname;
        public string Title 
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Genre
        {
            get { return _genre; }
            set
            {
                _genre = value;
                OnPropertyChanged("Genre");
            }
        }
        public int Year
        {
            get { return _year; }
            set
            {
                _year = value;
                OnPropertyChanged("Year");
            }
        }
        
        public string ProducerName 
        {
            get { return _prodname; }
            set { _prodname = value;
                OnPropertyChanged("ProducerName");
            }
        }
        public double Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                OnPropertyChanged("Rating");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Movie(string title, string genre, int year, double rating, string prodname)
        {
            _title=title;
            _genre=genre;
            _year=year;

            _rating=rating;
            this._prodname=prodname;
        }
    }
}
