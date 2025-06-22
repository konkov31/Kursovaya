namespace Kursovaya
{
    partial class Mainform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.lblTest = new System.Windows.Forms.Label();
            this.btn_topfilms = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRecomendations = new System.Windows.Forms.Button();
            this.btnGoToMovie = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnActorsList = new System.Windows.Forms.Button();
            this.btnSelectGenres = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUserActivity = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTest
            // 
            this.lblTest.Location = new System.Drawing.Point(0, 0);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(100, 23);
            this.lblTest.TabIndex = 0;
            // 
            // btn_topfilms
            // 
            this.btn_topfilms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_topfilms.Location = new System.Drawing.Point(82, 99);
            this.btn_topfilms.Name = "btn_topfilms";
            this.btn_topfilms.Size = new System.Drawing.Size(177, 82);
            this.btn_topfilms.TabIndex = 1;
            this.btn_topfilms.Text = "Топ лучших фильмов";
            this.btn_topfilms.UseVisualStyleBackColor = false;
            this.btn_topfilms.Click += new System.EventHandler(this.btn_topfilms_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Рекомендуемое:";
            // 
            // btnRecomendations
            // 
            this.btnRecomendations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRecomendations.Location = new System.Drawing.Point(83, 187);
            this.btnRecomendations.Name = "btnRecomendations";
            this.btnRecomendations.Size = new System.Drawing.Size(176, 68);
            this.btnRecomendations.TabIndex = 4;
            this.btnRecomendations.Text = "Получить рекомендации";
            this.btnRecomendations.UseVisualStyleBackColor = false;
            this.btnRecomendations.Click += new System.EventHandler(this.btnRecomendations_Click);
            // 
            // btnGoToMovie
            // 
            this.btnGoToMovie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnGoToMovie.Location = new System.Drawing.Point(437, 98);
            this.btnGoToMovie.Name = "btnGoToMovie";
            this.btnGoToMovie.Size = new System.Drawing.Size(149, 82);
            this.btnGoToMovie.TabIndex = 5;
            this.btnGoToMovie.Text = "Посмотреть фильмы";
            this.btnGoToMovie.UseVisualStyleBackColor = false;
            this.btnGoToMovie.Click += new System.EventHandler(this.btnGoToMovie_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.Location = new System.Drawing.Point(61, 372);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(240, 43);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "Войти в другой аккаунт";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnActorsList
            // 
            this.btnActorsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnActorsList.Location = new System.Drawing.Point(437, 186);
            this.btnActorsList.Name = "btnActorsList";
            this.btnActorsList.Size = new System.Drawing.Size(149, 69);
            this.btnActorsList.TabIndex = 10;
            this.btnActorsList.Text = "Все актеры";
            this.btnActorsList.UseVisualStyleBackColor = false;
            this.btnActorsList.Click += new System.EventHandler(this.btnActorsList_Click);
            // 
            // btnSelectGenres
            // 
            this.btnSelectGenres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSelectGenres.Location = new System.Drawing.Point(437, 265);
            this.btnSelectGenres.Name = "btnSelectGenres";
            this.btnSelectGenres.Size = new System.Drawing.Size(149, 68);
            this.btnSelectGenres.TabIndex = 12;
            this.btnSelectGenres.Text = "Все жанры";
            this.btnSelectGenres.UseVisualStyleBackColor = false;
            this.btnSelectGenres.Click += new System.EventHandler(this.btnSelectGenres_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(390, 371);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(240, 44);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Выйти";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(385, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Найдите что-то новое для себя";
            // 
            // btnUserActivity
            // 
            this.btnUserActivity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnUserActivity.Location = new System.Drawing.Point(83, 265);
            this.btnUserActivity.Name = "btnUserActivity";
            this.btnUserActivity.Size = new System.Drawing.Size(176, 68);
            this.btnUserActivity.TabIndex = 15;
            this.btnUserActivity.Text = "Самые активные пользователи";
            this.btnUserActivity.UseVisualStyleBackColor = false;
            this.btnUserActivity.Click += new System.EventHandler(this.btnUserActivity_Click);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(696, 449);
            this.Controls.Add(this.btnUserActivity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSelectGenres);
            this.Controls.Add(this.btnActorsList);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnGoToMovie);
            this.Controls.Add(this.btnRecomendations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_topfilms);
            this.Controls.Add(this.lblTest);
            this.Name = "Mainform";
            this.Text = "Поиск фильмов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Button btn_topfilms;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRecomendations;
        private System.Windows.Forms.Button btnGoToMovie;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnActorsList;
        private System.Windows.Forms.Button btnSelectGenres;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUserActivity;
    }
}