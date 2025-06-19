using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya
{
    public partial class ActorDetailsForm : Form
    {
        private int currentActorId;
        public ActorDetailsForm(int actorId)
        {
            InitializeComponent();
            currentActorId = actorId;
            LoadActorData();
        }

        private void LoadActorData()
        {           
                string connectionString = "data source=laptop\\sqlexpress;initial catalog=Delivery;integrated security=True;encrypt=False;trustservercertificate=True;MultipleActiveResultSets=True;";
                // Загрузка основной информации об актере
                string actorQuery = @"
                    SELECT full_name, birth_date, country, height, photo_url, imdb_link 
                    FROM PERSONS 
                    WHERE person_id = @actorId";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand(actorQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@actorId", currentActorId);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    lblFullName.Text = reader["full_name"].ToString();
                                    lblBirthDate.Text = Convert.ToDateTime(reader["birth_date"]).ToString("dd.MM.yyyy");
                                    lblCountry.Text = reader["country"].ToString();
                                    lblHeight.Text = reader["height"].ToString() + " см";

                                    // Загрузка фото, если есть
                                    if (reader["photo_url"] != DBNull.Value)
                                    {
                                        pictureBoxActor.Load(reader["photo_url"].ToString());
                                    }
                                }
                            }
                        }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
            }
        }

        

        private void btnFilmography_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=laptop\\\\sqlexpress;initial catalog=Delivery;integrated security=True;encrypt=False;trustservercertificate=True;MultipleActiveResultSets=True;\"";
            string filmographyQuery = @"
                SELECT f.title, f.release_year, fp.character_name, 
                       CASE WHEN fp.is_lead_role = 1 THEN 'Главная' ELSE 'Второстепенная' END AS role_type
                FROM FILM_POSITIONS fp
                JOIN FILMS f ON fp.movie_id = f.movie_id
                WHERE fp.person_id = @actorId AND fp.position_type = 'actor'
                ORDER BY f.release_year DESC";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand(filmographyQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@actorId", currentActorId);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                FilmographyForm filmographyForm = new FilmographyForm(dt);
                filmographyForm.ShowDialog();
            }
        }

        public class FilmographyForm : Form
        {
            public FilmographyForm(DataTable filmographyData)
            {
                this.Text = "Фильмография";
                this.Size = new Size(600, 400);

                DataGridView dgv = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    DataSource = filmographyData,
                    ReadOnly = true,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                };

                this.Controls.Add(dgv);
            }
        }

        private void btnShowPrevActor_Click(object sender, EventArgs e)
        {
            currentActorId -= 1;
            LoadActorData();
        }

        private void btnShowNextActor_Click_1(object sender, EventArgs e)
        {
            currentActorId += 1;
            LoadActorData();
        }

        private void btnAwards_Click(object sender, EventArgs e)
        {
            if (currentActorId <= 0)
            {
                MessageBox.Show("Не выбран актер.");
                return;
            }

            string connectionString = "data source=laptop\\sqlexpress;initial catalog=Delivery;integrated security=True;encrypt=False;trustservercertificate=True;MultipleActiveResultSets=True;";
            string awardsQuery = @"
        SELECT 
            ISNULL(n.name, 'Нет данных') AS name,
            ISNULL(n.category, 'Нет данных') AS category,
            ISNULL(n.description, 'Нет описания') AS  description,
            ISNULL(f.title, 'Не указан') AS movie_title
        FROM NOMINATIONS n
        LEFT JOIN AWARDINGS a ON n.nomination_id = a.nomination_id
        LEFT JOIN FILMS f ON a.movie_id = f.movie_id
        WHERE n.participant_id = @actorId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(awardsQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@actorId", currentActorId);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }

                    if (dt == null || dt.Rows.Count == 0)
                    {
                        MessageBox.Show("У актера нет наград.");
                        return;
                    }

                    new AwardsForm(dt).ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}\n\nПодробности:\n{ex.StackTrace}",
                               "Ошибка",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        public class AwardsForm : Form
        {
            public AwardsForm(DataTable awardsData)
            {
                this.Text = "Награды актера";
                this.Size = new Size(600, 400);

                DataGridView dgv = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    DataSource = awardsData,
                    ReadOnly = true,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    AllowUserToAddRows = false,
                    RowHeadersVisible = false
                };

                // Format the columns for better display
                dgv.Columns["name"].HeaderText = "Награда";
                dgv.Columns["category"].HeaderText = "Категория";
                dgv.Columns["description"].HeaderText = "Описание";
                

                this.Controls.Add(dgv);
            }
        }
    }
}
