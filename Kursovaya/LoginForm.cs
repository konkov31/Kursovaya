using System;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using Kursovaya.EF;


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
              
                using (var context = new MovieAgragatorContext())
                {
                var userFound = context.USERS.Where(u => u.username == username && u.user_password == password).ToList();
                if(userFound.Count() == 0)
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.SelectAll();
                        txtPassword.Focus();
                    }

                    var User = userFound.First();

                    int userId = User.user_id;
                    string dbUsername = User.username;
                    bool isPremium = Convert.ToBoolean(User.is_premium);
                    this.Hide(); 
                    Mainform mainForm = new Mainform(userId, dbUsername, isPremium);
                    mainForm.Show();
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
                using(var context = new MovieAgragatorContext())
                {
                    var usernameField = new SqlParameter("@Username", username);
                    var emailField = new SqlParameter("@Email", email);
                    var passwordField = new SqlParameter("@Password", password);

                    context.Database.ExecuteSqlCommand("exec RegisterUser @Username, @Email, @Password", usernameField, emailField, passwordField);
                }

                txtRegUsername.Text = "";
                txtRegEmail.Text = "";
                txtRegPassword.Text = "";
                txtRegConfirmPassword.Text = "";

                MessageBox.Show("Регистрация прошла успешно!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException sqlEx)
            {
                
                switch (sqlEx.Number)
                {
                    case 50000:
                        MessageBox.Show($"Пользователь с таким логином уже есть", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}