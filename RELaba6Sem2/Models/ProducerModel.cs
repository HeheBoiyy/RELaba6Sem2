using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RELaba6Sem2.Models
{
    public class Producer:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string _name;
        public int _yearstart;
        public int _yearend;
        public double _rating;
        public int _moviecount;
        public string ProducerName
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("ProducerName");
            }
        }
        public int StartDate
        {
            get { return _yearstart; }
            set
            {
                _yearstart = value;
                OnPropertyChanged("StartDate");
            }
        }

        public int EndDate
        {
            get { return _yearend; }
            set
            {
                _yearend = value;
                OnPropertyChanged("EndDate");
            }
        }

        public double AverageRating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                OnPropertyChanged("AverageRating");
            }
        }

        public int MovieCount
        {
            get { return _moviecount; }
            set
            {
                _moviecount = value;
                OnPropertyChanged("MovieCount");
            }
        }
    }
}
