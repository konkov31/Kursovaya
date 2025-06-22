using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya
{
    public partial class Mainform : Form
    {
        private string connectionString = "Data Source=LAPTOP-9NU3LM22\\SQLEXPRESS;Initial Catalog=movie_agregator;Integrated Security=True";
        private int userId;
        private ComboBox comboBoxMovies;

        private int _currentUserId;

       
       
       

        private int GetCurrentUserId()
        {
            return _currentUserId;
        }

        public Mainform(int userId, string username, bool isPremium)
        {
            InitializeComponent();
            _currentUserId = userId;
            this.FormClosing += Mainform_FormClosing;
            this.Controls.Add(comboBoxMovies);

            void Mainform_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    Application.Exit();
                }
            }

            var lblTest = new Label
            {
                Text = $"Добро пожаловать, {username}!",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopCenter
            };
            this.Controls.Add(lblTest);


        }

       
        private void btn_topfilms_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-9NU3LM22\\SQLEXPRESS;Initial Catalog=movie_agregator;Integrated Security=True";

            string query = "SELECT * FROM HighRatedMovies";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    // Создаем новую форму для отображения таблицы
                    Form tableForm = new Form();
                    tableForm.AutoSize = true;
                    DataGridView dataGridView = new DataGridView
                    {
                        Dock = DockStyle.Fill,
                        DataSource = table,
                        ReadOnly = true,
                        AllowUserToAddRows = false,
                        AllowUserToDeleteRows = false
                    };
                    dataGridView.AutoSize = true;

                    dataGridView.CellContentClick += (s, ev) =>
                    {
                        // Проверяем, что клик был по ячейке в столбце с названием фильма
                        // Замените "НазваниеСтолбца" на фактическое название столбца с именами фильмов
                        if (ev.ColumnIndex == dataGridView.Columns["title"].Index && ev.RowIndex >= 0)
                        {
                            // Получаем ID фильма или другие данные, которые нужно передать в MovieDetailsForm
                            // Предполагаем, что в таблице есть столбец с ID фильма
                            int movieId = Convert.ToInt32(dataGridView.Rows[ev.RowIndex].Cells["movie_id"].Value);

                            // Создаем и показываем форму с деталями фильма
                            MovieDetailsForm detailsForm = new MovieDetailsForm(movieId);
                            detailsForm.ShowDialog();
                        }
                    };

                    tableForm.Controls.Add(dataGridView);
                    tableForm.StartPosition = FormStartPosition.CenterScreen;
                    tableForm.WindowState = FormWindowState.Normal;
                    tableForm.Text = "Популярные фильмы";

                    tableForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGoToMovie_Click(object sender, EventArgs e)
        {
            MovieDetailsForm detailsForm = new MovieDetailsForm(1);
            detailsForm.Show();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();

            LoginForm loginingForm = new LoginForm();
            loginingForm.Show();
        }

        private void btnActorsList_Click(object sender, EventArgs e)
        {
            try
            {
                // Запрос для получения списка актеров (персон с актерскими ролями)
                string query = @"
                    SELECT DISTINCT p.person_id, p.full_name
                    FROM PERSONS p
                    JOIN FILM_POSITIONS fp ON p.person_id = fp.person_id
                    WHERE fp.position_type = 'actor'
                    ORDER BY p.full_name";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("В базе нет актеров");
                        return;
                    }

                    // Создаем форму для отображения списка актеров
                    Form actorsListForm = new Form
                    {
                        Text = "Список актеров",
                        Size = new Size(400, 500),
                        StartPosition = FormStartPosition.CenterParent
                    };

                    ListBox listBox = new ListBox
                    {
                        Dock = DockStyle.Fill,
                        DataSource = dt,
                        DisplayMember = "full_name",
                        ValueMember = "person_id",
                        Font = new Font("Microsoft Sans Serif", 12)
                    };

                    listBox.DoubleClick += (s, args) =>
                    {
                        if (listBox.SelectedValue != null)
                        {
                            int selectedActorId = Convert.ToInt32(listBox.SelectedValue);
                            ActorDetailsForm actorDetailForm = new ActorDetailsForm(selectedActorId);
                            actorDetailForm.ShowDialog();
                            actorsListForm.Close();
                        }
                    };

                    actorsListForm.Controls.Add(listBox);
                    actorsListForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке списка актеров: " + ex.Message);
            }
        }

        void btnSelectGenres_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем все жанры
                DataTable genresTable = GetAllGenres();

                // Получаем текущие избранные жанры пользователя
                List<int> favoriteGenres = GetUserFavoriteGenres(userId);

                if (genresTable.Rows.Count == 0)
                {
                    MessageBox.Show("В базе нет жанров", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Создаем форму для выбора жанров
                var genresForm = new Form
                {
                    Text = "Выберите избранные жанры",
                    Size = new Size(300, 400),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false
                };

                var panel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false
                };

                // Добавляем чекбоксы для каждого жанра
                foreach (DataRow row in genresTable.Rows)
                {
                    int genreId = Convert.ToInt32(row["genre_id"]);
                    panel.Controls.Add(new CheckBox
                    {
                        Text = row["name"].ToString(),
                        Tag = genreId,
                        AutoSize = true,
                        Margin = new Padding(5),
                        Checked = favoriteGenres.Contains(genreId)
                    });
                }

                var btnSave = new Button { Text = "Сохранить", Dock = DockStyle.Bottom, Height = 40 };
                btnSave.Click += (s, args) => SaveUsingAddFavoriteGenre(panel, genresForm);

                genresForm.Controls.Add(panel);
                genresForm.Controls.Add(btnSave);
                genresForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetAllGenres()
        {
            var dt = new DataTable();
            using (var connection = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("SELECT genre_id, name FROM GENRES ORDER BY name", connection))
            {
                connection.Open();
                dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }

        private List<int> GetUserFavoriteGenres(int userId)
        {
            var genres = new List<int>();
            using (var connection = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("SELECT genre_id FROM FAVORITE_GENRES WHERE user_id = @user_id", connection))
            {
                cmd.Parameters.AddWithValue("@user_id", userId);
                connection.Open();

                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        genres.Add(reader.GetInt32(0));
            }
            return genres;
        }

        private void SaveUsingAddFavoriteGenre(FlowLayoutPanel panel, Form form)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (var chk in panel.Controls.OfType<CheckBox>().Where(c => c.Checked))
                    {
                        using (var cmd = new SqlCommand("AddFavoriteGenre", connection))
                        {
                            if (chk.Tag == null || !int.TryParse(chk.Tag.ToString(), out int genreId))
                            {
                                MessageBox.Show($"Ошибка: неверный genre_id для жанра '{chk.Text}'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                continue;
                            }

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@user_id", userId);
                            cmd.Parameters.AddWithValue("@genre_id", (int)chk.Tag);
                            Console.WriteLine($"Удаляем жанры для user_id = {userId}");
                            Console.WriteLine($"Добавляем жанр: genre_id = {chk.Text}");

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                // Логируем, но не останавливаем процесс
                                Debug.WriteLine($"Ошибка при добавлении жанра {chk.Text}: {ex.Message}");
                            }
                        }
                    }
                    MessageBox.Show("Избранные жанры обновлены!", "Успех",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);

                    form.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUserActivity_Click(object sender, EventArgs e)
        {
            try
            {
                // Загружаем данные из представления
                DataTable viewData = LoadViewData("UserReviewsSummary"); // Замените на имя вашего VIEW

                if (viewData.Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для отображения.", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Создаем форму для отображения данных
                Form viewForm = new Form()
                {
                    Text = "Данные из представления",
                    Size = new Size(600, 400),
                    StartPosition = FormStartPosition.CenterParent
                };

                // Создаем DataGridView для вывода данных
                DataGridView dataGridView = new DataGridView()
                {
                    Dock = DockStyle.Fill,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    DataSource = viewData,
                    ReadOnly = true // Только для просмотра
                };

                viewForm.Controls.Add(dataGridView);
                viewForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable LoadViewData(string viewName)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT * FROM {viewName}"; // Или конкретные столбцы
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return dataTable;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Запрос подтверждения перед выходом
            DialogResult result = MessageBox.Show(
                "Вы действительно хотите выйти?",
                "Подтверждение выхода",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Корректное завершение приложения
            }
        }

        private void btnRecomendations_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Получаем ID текущего пользователя (предполагаем, что он авторизован)
                int currentUserId = _currentUserId;

                if (currentUserId == 0)
                {
                    MessageBox.Show("Пожалуйста, войдите в систему для получения рекомендаций",
                                  "Рекомендации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 2. Получаем рекомендации из БД
                DataTable recommendations = GetPersonalizedRecommendations(currentUserId);

                if (recommendations.Rows.Count == 0)
                {
                    MessageBox.Show("Не удалось найти рекомендации. Пожалуйста, укажите ваши любимые жанры.",
                                  "Рекомендации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 3. Создаем форму для отображения рекомендаций
                var recommendationsForm = new Form
                {
                    Text = "Персонализированные рекомендации",
                    Size = new Size(900, 600),
                    StartPosition = FormStartPosition.CenterParent
                };

                // 4. Настраиваем DataGridView
                var dgv = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    DataSource = recommendations,
                    ReadOnly = true,
                    AllowUserToAddRows = false
                };

                // Настраиваем столбцы
                dgv.Columns["title"].HeaderText = "Название";
                dgv.Columns["release_year"].HeaderText = "Год";
                dgv.Columns["imdb_rating"].HeaderText = "Рейтинг IMDb";
                dgv.Columns["duration"].HeaderText = "Длительность (мин)";
                dgv.Columns["age_rating"].HeaderText = "Возрастной рейтинг";
                dgv.Columns["platforms"].HeaderText = "Доступно на";

                
                dgv.Columns["movie_id"].Visible = false;

              
                var detailsColumn = new DataGridViewButtonColumn
                {
                    Text = "Подробнее",
                    UseColumnTextForButtonValue = true,
                    HeaderText = "Действия"
                };
                dgv.Columns.Add(detailsColumn);

               
                dgv.CellContentClick += (s, args) =>
                {
                    if (args.ColumnIndex == detailsColumn.Index && args.RowIndex >= 0)
                    {
                        int movieId = Convert.ToInt32(dgv.Rows[args.RowIndex].Cells["movie_id"].Value);
                        ShowMovieDetails(movieId);
                    }
                };
              
                recommendationsForm.Controls.Add(dgv);
                recommendationsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении рекомендаций: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowMovieDetails(int movieId)
        {
            try
            {
                // Создаем экземпляр вашей существующей формы
                var detailsForm = new MovieDetailsForm(movieId); // Предполагается, что форма принимает movieId в конструкторе

                detailsForm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке информации о фильме: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetPersonalizedRecommendations(int userId)
        {
            DataTable recommendations = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT TOP 20 
                f.movie_id,
                f.title,
                f.release_year,
                f.duration,
                f.imdb_rating,
                f.age_rating,
                STRING_AGG(p.name, ', ') AS platforms
            FROM FILMS f
            INNER JOIN MOVIE_GENRES mg ON f.movie_id = mg.movie_id
            INNER JOIN FAVORITE_GENRES fg ON mg.genre_id = fg.genre_id AND fg.user_id = @userId
            LEFT JOIN MOVIE_AVAILABILITY ma ON f.movie_id = ma.movie_id
            LEFT JOIN PLATFORMS p ON ma.platform_id = p.platform_id
            WHERE f.imdb_rating >= 7.0
            GROUP BY f.movie_id, f.title, f.release_year, f.duration, f.imdb_rating, f.age_rating
            ORDER BY f.imdb_rating DESC, f.release_year DESC";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);

                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(recommendations);
            }

            return recommendations;
        }
    }
    
}