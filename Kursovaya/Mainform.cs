using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kursovaya.EF;

namespace Kursovaya
{
    public partial class Mainform : Form
    {
        private string connectionString = "Data Source=LAPTOP-9NU3LM22\\SQLEXPRESS;Initial Catalog=movie_agregator;Integrated Security=True";
        private int userId;
        private ComboBox comboBoxMovies;
        public Mainform(int userId, string username, bool isPremium)
        {
            InitializeComponent();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchQuery))
            {
                MessageBox.Show("Введите название фильма для поиска", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SearchMovies(searchQuery);
        }

        private void SearchMovies(string searchQuery)
        {
            // Проверка входных данных
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                MessageBox.Show("Введите текст для поиска", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                using(var context = new MovieAgragatorContext())
                {
                    var films = context.FILMS.Where(f => f.title == searchQuery).ToList();
                    if(films.Count() == 0)
                    {
                        MessageBox.Show("Фильмы не найдены", "Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    dataGridViewResults.DataSource = films;
                    dataGridViewResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    /*
                    // Обработчик двойного клика
                    dataGridViewResults.CellDoubleClick += (s, ev) =>
                    {
                        if (ev.RowIndex >= 0)
                        {
                            int movieId = Convert.ToInt32(films[ev.RowIndex].movie_id);
                            MovieDetailsForm detailsForm = new MovieDetailsForm(movieId);
                            detailsForm.ShowDialog();
                        }
                    };
                    */

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        DataGridView dataGridView = new DataGridView
                        {
                            Dock = DockStyle.Fill,
                            DataSource = table,
                            ReadOnly = true,
                            AllowUserToAddRows = false,
                            AllowUserToDeleteRows = false
                        };

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
                        tableForm.WindowState = FormWindowState.Maximized;
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
                // Запрос для получения всех жанров
                string query = "SELECT genre_id, name FROM GENRES ORDER BY name";

                // Запрос для получения уже выбранных жанров пользователя
                string favoriteQuery = "SELECT genre_id FROM FAVORITE_GENRES WHERE user_id = @UserId";

                DataTable genresTable = new DataTable();
                List<int> favoriteGenres = new List<int>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Получаем все жанры
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(genresTable);
                    }

                    // Получаем избранные жанры пользователя
                    using (SqlCommand cmd = new SqlCommand(favoriteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                favoriteGenres.Add(reader.GetInt32(0));
                            }
                        }
                    }
                }

                if (genresTable.Rows.Count == 0)
                {
                    MessageBox.Show("В базе нет жанров", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Создаем форму для выбора жанров
                Form genresForm = new Form
                {
                    Text = "Выберите избранные жанры",
                    Size = new Size(300, 400),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false
                };

                FlowLayoutPanel panel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false
                };

                // Создаем чекбоксы для каждого жанра
                foreach (DataRow row in genresTable.Rows)
                {
                    int genreId = Convert.ToInt32(row["genre_id"]);
                    CheckBox chk = new CheckBox
                    {
                        Text = row["name"].ToString(),
                        Tag = genreId,
                        AutoSize = true,
                        Margin = new Padding(5),
                        Checked = favoriteGenres.Contains(genreId)
                    };

                    panel.Controls.Add(chk);
                }

                Button btnSave = new Button
                {
                    Text = "Сохранить",
                    Dock = DockStyle.Bottom,
                    Height = 40
                };

                btnSave.Click += (s, args) =>
                {
                    List<int> selectedGenres = new List<int>();
                    foreach (Control control in panel.Controls)
                    {
                        if (control is CheckBox chk && chk.Checked)
                        {
                            selectedGenres.Add((int)chk.Tag);
                        }
                    }

                    SaveSelectedGenres(selectedGenres);

                    MessageBox.Show("Избранные жанры сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    genresForm.Close();
                };

                genresForm.Controls.Add(panel);
                genresForm.Controls.Add(btnSave);
                genresForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке жанров: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void SaveSelectedGenres(List<int> selectedGenres)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Начинаем транзакцию для атомарности операций
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Удаляем старые избранные жанры пользователя
                        string deleteQuery = "DELETE FROM FAVORITE_GENRES WHERE user_id = @UserId";
                        using (SqlCommand cmd = new SqlCommand(deleteQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            cmd.ExecuteNonQuery();
                        }

                        // Добавляем новые избранные жанры, если они выбраны
                        if (selectedGenres.Count > 0)
                        {
                            string insertQuery = "INSERT INTO FAVORITE_GENRES (user_id, genre_id) VALUES (@UserId, @GenreId)";
                            foreach (int genreId in selectedGenres)
                            {
                                using (SqlCommand cmd = new SqlCommand(insertQuery, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@UserId", userId);
                                    cmd.Parameters.AddWithValue("@GenreId", genreId);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении жанров: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewResults_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ThrowException = false;
        }
    }
    
}