using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Kursovaya
{
    public partial class LoginForm : Form
    {
        // Строка подключения к базе данных
        private string connectionString = "Data Source=LAPTOP-9NU3LM22\\SQLEXPRESS;Initial Catalog=movie_agregator;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public LoginForm()
        {
            InitializeComponent();
            this.FormClosing += LoginForm_FormClosing; // Обработчик закрытия формы
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Если форма входа закрывается, завершаем приложение
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Валидация ввода
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Введите имя пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Пароль должен содержать минимум 8 символа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT user_id, username, is_premium 
                                    FROM USERS 
                                    WHERE username = @Username AND user_password = @Password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                int userId = reader.GetInt32(0);
                                string dbUsername = reader.GetString(1);
                                bool isPremium = reader.GetBoolean(2);

                                this.Hide(); 

                                Mainform mainForm = new Mainform(userId, dbUsername, isPremium);
                                mainForm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин или пароль", "Ошибка входа",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtPassword.SelectAll();
                                txtPassword.Focus();
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Ошибка базы данных: {sqlEx.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            string username = txtRegUsername.Text.Trim();
            string email = txtRegEmail.Text.Trim();
            string password = txtRegPassword.Text;
            string confirmPassword = txtRegConfirmPassword.Text;

            // Валидация данных
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Введите имя пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRegUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                MessageBox.Show("Введите корректный email", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRegEmail.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRegPassword.Focus();
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Пароль должен содержать минимум 8 символов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRegPassword.Focus();
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRegConfirmPassword.Focus();
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Проверка на существующего пользователя
                    string checkUserQuery = "SELECT COUNT(*) FROM USERS WHERE username = @Username OR email = @Email";
                    using (SqlCommand checkCmd = new SqlCommand(checkUserQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", username);
                        checkCmd.Parameters.AddWithValue("@Email", email);

                        int userCount = (int)checkCmd.ExecuteScalar();
                        if (userCount > 0)
                        {
                            MessageBox.Show("Пользователь с таким именем или email уже существует", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Регистрация нового пользователя
                    string insertQuery = @"INSERT INTO USERS (username, email, user_password, registration_date, is_premium)
                                 VALUES (@Username, @Email, @Password, @RegDate, 0)";

                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@Username", username);
                        insertCmd.Parameters.AddWithValue("@Email", email);
                        insertCmd.Parameters.AddWithValue("@Password", password);
                        insertCmd.Parameters.AddWithValue("@RegDate", DateTime.Now);

                        int rowsAffected = insertCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Регистрация прошла успешно!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Очищаем поля после успешной регистрации
                            txtRegUsername.Text = "";
                            txtRegEmail.Text = "";
                            txtRegPassword.Text = "";
                            txtRegConfirmPassword.Text = "";
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Ошибка базы данных: {sqlEx.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}