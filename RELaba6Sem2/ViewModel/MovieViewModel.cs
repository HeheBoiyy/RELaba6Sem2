using RELaba5Sem2.src;
using RELaba6Sem2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;

namespace RELaba6Sem2.ViewModels
{
    public class MovieViewModel
    {
        MainWindow mv = (MainWindow)Application.Current.MainWindow;
        public ObservableCollection<Producer> producers {get;set;}
        ObservableCollection<Movie> FilteredMovies { get;set;}
        public Movie SelectedItem { get; set; }
        public RelayCommand AddMovie => new RelayCommand(execute => _addMovie(mv.NameText.Text, mv.GenresCombo.SelectedItem.ToString(), TryParce(mv.YearText.Text),TryParceDouble(mv.RatingText.Text),mv.ProducerNameText.Text));
        public RelayCommand DeleteMovie => new RelayCommand(execute => _deleteMovie(SelectedItem));
        public RelayCommand ShowAllMovies => new RelayCommand(execute => _showAllMovies());
        public RelayCommand FilterByGenre => new RelayCommand(execute => _filterbygenre(mv.GenreBoxFilter.SelectedItem.ToString()));
        public RelayCommand FilterByDate => new RelayCommand(execute => _filterbydate(TryParce(mv.FromYear.Text),TryParce(mv.ToYear.Text)));
        public RelayCommand FilterByAscending => new RelayCommand(execute => _filterbyascending());
        public RelayCommand FilterByDescending => new RelayCommand(execute => _filterbydescending());
        public RelayCommand CreateProdList => new RelayCommand(execute => _prodlist());
        public ObservableCollection<Movie> Movies {get; set; }
        
        public MovieViewModel()
        {
            Movies = new ObservableCollection<Movie>()
            {
            new Movie("Oppenheimer","Хоррор",2023,9.9,"Кристофер Н."),
            new Movie("Кунгфу Панда","Мультфильм",2024,8.3,"Марк О.")
            };

            mv.GenresCombo.Items.Add("Хоррор");
            mv.GenresCombo.Items.Add("Фэнтези");
            mv.GenresCombo.Items.Add("Сайфай");
            mv.GenresCombo.Items.Add("Документальный");
            mv.GenresCombo.Items.Add("Драмма");
            mv.GenresCombo.Items.Add("Мультфильм");

            mv.GenreBoxFilter.Items.Add("Хоррор");
            mv.GenreBoxFilter.Items.Add("Фэнтези");
            mv.GenreBoxFilter.Items.Add("Сайфай");
            mv.GenreBoxFilter.Items.Add("Документальный");
            mv.GenreBoxFilter.Items.Add("Драмма");
            mv.GenreBoxFilter.Items.Add("Мультфильм");
        }
        public void _addMovie(string name, string genre, int year, double raiting, string prodname)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(genre) || string.IsNullOrEmpty(prodname) || year==0 || raiting == 0 )
            {
                MessageBox.Show("Какое либо из полей пустое/или неправильный формат данных");
            }
            else
            {
                Movies.Add(new Movie(name, genre, year, raiting, prodname));
            }
        }

        public void _deleteMovie(Movie movie) 
        {
            Movies.Remove(movie);
        }
        public int TryParce(string aboba)
        {
            try
            {
                Convert.ToInt64(aboba);
            }
            catch
            {
                return 0;
            }
            return Convert.ToInt32(aboba);
        }
        public double TryParceDouble(string aboba)
        {
            try
            {
                Convert.ToDouble(aboba);
            }
            catch
            {
                return 0;
            }
            return Convert.ToDouble(aboba);
        }
        public void _showAllMovies()
        {
            mv.MainList.ItemsSource = Movies;
        }

        public void _filterbygenre(string filter)
        {
            FilteredMovies = new ObservableCollection<Movie>(Movies.Where(x => x.Genre == filter).ToList());
            if (FilteredMovies.Count == 0)
            {
                MessageBox.Show("По данному фильтру ничего не найдено:((");
                mv.MainList.ItemsSource = Movies;
            }
            else
            {
                mv.MainList.ItemsSource = FilteredMovies;
            }
        }

        public void _filterbydate(int start,int end)
        {
            FilteredMovies = new ObservableCollection<Movie>(Movies.Where(movie => movie.Year >= start && movie.Year <= end).ToList());
            if (FilteredMovies.Count == 0)
            {
                MessageBox.Show("По данному фильтру ничего не найдено:((");
                mv.MainList.ItemsSource= Movies;
            }
            else
            {
                mv.MainList.ItemsSource = FilteredMovies;
            }
        }

        public void _filterbyascending()
        {
            FilteredMovies = new ObservableCollection<Movie>(Movies.OrderBy(x =>x.Rating).ToList());
            if (FilteredMovies.Count == 0)
            {
                MessageBox.Show("По данному фильтру ничего не найдено:((");
                mv.MainList.ItemsSource = Movies;
            }
            else
            {
                mv.MainList.ItemsSource = FilteredMovies;
            }
        }
        
        public void _filterbydescending()
        {
            FilteredMovies = new ObservableCollection<Movie>(Movies.OrderByDescending(x => x.Rating).ToList());
            if (FilteredMovies.Count == 0)
            {
                MessageBox.Show("По данному фильтру ничего не найдено:((");
                mv.MainList.ItemsSource = Movies;
            }
            else
            {
                mv.MainList.ItemsSource = FilteredMovies;
            }
        }
        public void _prodlist()
        {
            producers = new ObservableCollection<Producer>(Movies
            .GroupBy(movie => movie.ProducerName)
            .Select(group => new Producer
            {
                ProducerName = group.Key,
                MovieCount = group.Count(),
                AverageRating = group.Average(movie => movie.Rating),
                StartDate = group.Min(movie => movie.Year),
                EndDate = group.Max(movie => movie.Year)
            })
            .ToList());
            mv.ProdList.ItemsSource= producers;
        }
    }
}
