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
            this.lblTest = new System.Windows.Forms.Label();
            this.btn_topfilms = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnfavgenfilms = new System.Windows.Forms.Button();
            this.btnGoToMovie = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnActorsList = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSelectGenres = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTest
            // 
            this.lblTest.Location = new System.Drawing.Point(0, 0);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(89, 18);
            this.lblTest.TabIndex = 0;
            // 
            // btn_topfilms
            // 
            this.btn_topfilms.Location = new System.Drawing.Point(11, 79);
            this.btn_topfilms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_topfilms.Name = "btn_topfilms";
            this.btn_topfilms.Size = new System.Drawing.Size(157, 66);
            this.btn_topfilms.TabIndex = 1;
            this.btn_topfilms.Text = "Топ лучших фильмов";
            this.btn_topfilms.UseVisualStyleBackColor = true;
            this.btn_topfilms.Click += new System.EventHandler(this.btn_topfilms_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Рекомендуемое:";
            // 
            // btnfavgenfilms
            // 
            this.btnfavgenfilms.Location = new System.Drawing.Point(12, 150);
            this.btnfavgenfilms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnfavgenfilms.Name = "btnfavgenfilms";
            this.btnfavgenfilms.Size = new System.Drawing.Size(156, 55);
            this.btnfavgenfilms.TabIndex = 4;
            this.btnfavgenfilms.Text = "Фильмы ваших любимых жанров";
            this.btnfavgenfilms.UseVisualStyleBackColor = true;
            // 
            // btnGoToMovie
            // 
            this.btnGoToMovie.Location = new System.Drawing.Point(264, 79);
            this.btnGoToMovie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGoToMovie.Name = "btnGoToMovie";
            this.btnGoToMovie.Size = new System.Drawing.Size(132, 66);
            this.btnGoToMovie.TabIndex = 5;
            this.btnGoToMovie.Text = "Посмотреть фильмы";
            this.btnGoToMovie.UseVisualStyleBackColor = true;
            this.btnGoToMovie.Click += new System.EventHandler(this.btnGoToMovie_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(476, 79);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(145, 22);
            this.txtSearch.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(626, 74);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 26);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridViewResults
            // 
            this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResults.Location = new System.Drawing.Point(476, 105);
            this.dataGridViewResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.RowHeadersWidth = 62;
            this.dataGridViewResults.RowTemplate.Height = 28;
            this.dataGridViewResults.Size = new System.Drawing.Size(213, 162);
            this.dataGridViewResults.TabIndex = 8;
            this.dataGridViewResults.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewResults_DataError);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(476, 40);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(213, 34);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "Войти в другой аккаунт";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnActorsList
            // 
            this.btnActorsList.Location = new System.Drawing.Point(264, 150);
            this.btnActorsList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActorsList.Name = "btnActorsList";
            this.btnActorsList.Size = new System.Drawing.Size(132, 55);
            this.btnActorsList.TabIndex = 10;
            this.btnActorsList.Text = "Все актеры";
            this.btnActorsList.UseVisualStyleBackColor = true;
            this.btnActorsList.Click += new System.EventHandler(this.btnActorsList_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(264, 210);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 57);
            this.button2.TabIndex = 11;
            this.button2.Text = "Все режиссеры";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnSelectGenres
            // 
            this.btnSelectGenres.Location = new System.Drawing.Point(264, 272);
            this.btnSelectGenres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectGenres.Name = "btnSelectGenres";
            this.btnSelectGenres.Size = new System.Drawing.Size(132, 54);
            this.btnSelectGenres.TabIndex = 12;
            this.btnSelectGenres.Text = "Все жанры";
            this.btnSelectGenres.UseVisualStyleBackColor = true;
            this.btnSelectGenres.Click += new System.EventHandler(this.btnSelectGenres_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(476, 282);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(213, 35);
            this.button4.TabIndex = 13;
            this.button4.Text = "Редактировать";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 359);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnSelectGenres);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnActorsList);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.dataGridViewResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnGoToMovie);
            this.Controls.Add(this.btnfavgenfilms);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_topfilms);
            this.Controls.Add(this.lblTest);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Mainform";
            this.Text = "Mainform";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Button btn_topfilms;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnfavgenfilms;
        private System.Windows.Forms.Button btnGoToMovie;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnActorsList;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSelectGenres;
        private System.Windows.Forms.Button button4;
    }
}