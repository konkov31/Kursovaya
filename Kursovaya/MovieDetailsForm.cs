using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string connectionString = "Data Source=LAPTOP-9NU3LM22\\SQLEXPRESS;Initial Catalog=movie_agregator;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            string query = @"SELECT title, description, release_year, duration, imdb_rating, poster_url
                            FROM Films 
                            WHERE movie_id = @MovieId";

            string genresQuery = @"SELECT g.name 
                     FROM GENRES g
                     INNER JOIN MOVIE_GENRES mg ON g.genre_id = mg.genre_id
                     WHERE mg.movie_id = @MovieId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MovieId", _movieId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblMovieId.Text = "Номер:" + _movieId.ToString();
                            lblTitle.Text = reader["Title"].ToString();
                            txtDescription.Text = reader["Description"].ToString();
                            lblYear.Text = "Год выпуска: " + reader["Release_Year"].ToString();
                            lblDuration.Text = "Длительность: " + reader["Duration"].ToString() + " мин";
                            lblRating.Text = "Рейтинг: " + reader["imdb_rating"].ToString() + "/10";

                            if (reader["poster_url"] != DBNull.Value)
                            {
                                string imageUrl = reader["poster_url"].ToString();
                                LoadPosterImage(imageUrl);
                            }
                        }
                    }

                    SqlCommand genresCommand = new SqlCommand(genresQuery, connection);
                    genresCommand.Parameters.AddWithValue("@MovieId", _movieId);

                    List<string> genres = new List<string>();
                    using (SqlDataReader reader = genresCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            genres.Add(reader["name"].ToString());
                        }
                    }

                    if (genres.Count > 0)
                    {
                        lblGenres.Text = "Жанры: " + string.Join(", ", genres);
                    }
                    else
                    {
                        lblGenres.Text = "Жанры не указаны";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }


        private async void LoadPosterImage(string imageUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Добавляем User-Agent, так как некоторые серверы требуют его
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");

                    using (var response = await client.GetAsync(imageUrl))
                    {
                        response.EnsureSuccessStatusCode();

                        using (Stream stream = await response.Content.ReadAsStreamAsync())
                        {
                            // Создаем копию потока для безопасной работы
                            using (MemoryStream ms = new MemoryStream())
                            {
                                await stream.CopyToAsync(ms);
                                ms.Position = 0;

                                // Загружаем изображение с масштабированием
                                using (var originalImage = Image.FromStream(ms))
                                {
                                    // Масштабируем изображение под размер PictureBox
                                    var scaledImage = ScaleImageToFit(originalImage, ptrboxPoster.Width, ptrboxPoster.Height);

                                    // Очищаем предыдущее изображение (если было)
                                    if (ptrboxPoster.Image != null)
                                    {
                                        var oldImage = ptrboxPoster.Image;
                                        ptrboxPoster.Image = null;
                                        oldImage.Dispose();
                                    }

                                    ptrboxPoster.Image = scaledImage;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки постера: {ex.Message}");
            }
        }

        private Image ScaleImageToFit(Image image, int targetWidth, int targetHeight)
        {
            // Рассчитываем соотношение сторон
            double ratioX = (double)targetWidth / image.Width;
            double ratioY = (double)targetHeight / image.Height;
            double ratio = Math.Min(ratioX, ratioY);

            // Новые размеры с сохранением пропорций
            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            // Создаем новое изображение
            Bitmap newImage = new Bitmap(newWidth, newHeight);

            // Используем высококачественное масштабирование
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
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

