using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Kursovaya.EF;

namespace Kursovaya
{
    public partial class MovieDetailsForm : Form
    {
        private int _movieId;
        public MovieDetailsForm(int movie_id)
        {
            InitializeComponent();
            _movieId = movie_id;
            LoadMovieDetails();
        }

        private void LoadMovieDetails()
        {


            try
            {
                using(var context = new MovieAgragatorContext())
                {
                    var moviesFound = context.FILMS.Where(m => m.movie_id == _movieId);
                    if(moviesFound.Count() == 0)
                    {
                        throw new Exception("Фильм не существет");
                    }
                    var movie = moviesFound.First();
                    lblMovieId.Text = "Номер:" + _movieId.ToString();
                    lblTitle.Text = movie.title;
                    txtDescription.Text = movie.description.ToString();
                    lblYear.Text = "Год выпуска" + movie.release_year.ToString();
                    lblDuration.Text = "Длительность: " + movie.duration.ToString() + " мин";
                    lblRating.Text = "Рейтинг: " + movie.imdb_rating.ToString() + "/10";
                    
                    var genres = context.FILMS_GANRES.Where(m => m.movie_id == _movieId).Select(m => m.name).ToList();
                    if (genres.Count > 0)
                    {
                        lblGenres.Text = "Жанры: " + string.Join(", ", genres);
                    }
                    else
                    {
                        lblGenres.Text = "Жанры не указаны";
                    }

                    if (movie.poster_url != null)
                    {
                        string imageUrl = movie.poster_url;
                        Image img = DownloadImageSync(imageUrl);
                        ptrboxPoster.Image = img;
                        ptrboxPoster.SizeMode = PictureBoxSizeMode.StretchImage;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        public Image DownloadImageSync(string imageUrl)
        {
            using (WebClient client = new WebClient())
            {
                byte[] data = client.DownloadData(imageUrl);
                using (MemoryStream mem = new MemoryStream(data))
                {
                    return Image.FromStream(mem);
                }
            }
        }

        private void btnShowPrevFilm_Click(object sender, EventArgs e)
        {
            {
                _movieId = _movieId - 1;
                LoadMovieDetails();
            };
            this.Controls.Add(btnShowPrevFilm);
        }

        private void btnShowNextFilm_Click(object sender, EventArgs e)
        {
            {
                _movieId = _movieId + 1;
                LoadMovieDetails();
            };
            this.Controls.Add(btnShowNextFilm);
        }
    }


}

