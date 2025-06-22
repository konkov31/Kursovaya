namespace Kursovaya
{
    partial class MovieDetailsForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.ptrboxPoster = new System.Windows.Forms.PictureBox();
            this.btnShowPrevFilm = new System.Windows.Forms.Button();
            this.btnShowNextFilm = new System.Windows.Forms.Button();
            this.lblMovieId = new System.Windows.Forms.Label();
            this.lblGenres = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptrboxPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(402, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(83, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Название";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(406, 53);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(392, 80);
            this.txtDescription.TabIndex = 1;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(402, 197);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(103, 20);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "Год выпуска";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(402, 244);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(121, 20);
            this.lblDuration.TabIndex = 3;
            this.lblDuration.Text = "Длительность";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(402, 288);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(71, 20);
            this.lblRating.TabIndex = 4;
            this.lblRating.Text = "Рейтинг";
            // 
            // ptrboxPoster
            // 
            this.ptrboxPoster.Location = new System.Drawing.Point(103, 13);
            this.ptrboxPoster.Name = "ptrboxPoster";
            this.ptrboxPoster.Size = new System.Drawing.Size(270, 360);
            this.ptrboxPoster.TabIndex = 5;
            this.ptrboxPoster.TabStop = false;
            // 
            // btnShowPrevFilm
            // 
            this.btnShowPrevFilm.Location = new System.Drawing.Point(57, 412);
            this.btnShowPrevFilm.Name = "btnShowPrevFilm";
            this.btnShowPrevFilm.Size = new System.Drawing.Size(316, 67);
            this.btnShowPrevFilm.TabIndex = 6;
            this.btnShowPrevFilm.Text = "Предыдущий фильм";
            this.btnShowPrevFilm.UseVisualStyleBackColor = true;
            this.btnShowPrevFilm.Click += new System.EventHandler(this.btnShowPrevFilm_Click);
            // 
            // btnShowNextFilm
            // 
            this.btnShowNextFilm.Location = new System.Drawing.Point(476, 412);
            this.btnShowNextFilm.Name = "btnShowNextFilm";
            this.btnShowNextFilm.Size = new System.Drawing.Size(322, 67);
            this.btnShowNextFilm.TabIndex = 7;
            this.btnShowNextFilm.Text = "Следующий фильм";
            this.btnShowNextFilm.UseVisualStyleBackColor = true;
            this.btnShowNextFilm.Click += new System.EventHandler(this.btnShowNextFilm_Click);
            // 
            // lblMovieId
            // 
            this.lblMovieId.AutoSize = true;
            this.lblMovieId.Location = new System.Drawing.Point(13, 13);
            this.lblMovieId.Name = "lblMovieId";
            this.lblMovieId.Size = new System.Drawing.Size(56, 20);
            this.lblMovieId.TabIndex = 8;
            this.lblMovieId.Text = "номер";
            // 
            // lblGenres
            // 
            this.lblGenres.AutoSize = true;
            this.lblGenres.Location = new System.Drawing.Point(406, 149);
            this.lblGenres.Name = "lblGenres";
            this.lblGenres.Size = new System.Drawing.Size(49, 20);
            this.lblGenres.TabIndex = 9;
            this.lblGenres.Text = "Жанр";
            // 
            // MovieDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(831, 492);
            this.Controls.Add(this.lblGenres);
            this.Controls.Add(this.lblMovieId);
            this.Controls.Add(this.btnShowNextFilm);
            this.Controls.Add(this.btnShowPrevFilm);
            this.Controls.Add(this.ptrboxPoster);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblTitle);
            this.Name = "MovieDetailsForm";
            this.Text = "информация";
            ((System.ComponentModel.ISupportInitialize)(this.ptrboxPoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.PictureBox ptrboxPoster;
        private System.Windows.Forms.Button btnShowPrevFilm;
        private System.Windows.Forms.Button btnShowNextFilm;
        private System.Windows.Forms.Label lblMovieId;
        private System.Windows.Forms.Label lblGenres;
    }
}