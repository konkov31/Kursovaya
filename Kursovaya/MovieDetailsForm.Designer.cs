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
            this.lblTitle.Location = new System.Drawing.Point(357, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(73, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Название";
            // 
            // txtDescription
            // 
            this.txtDescription.Enabled = false;
            this.txtDescription.Location = new System.Drawing.Point(361, 42);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(349, 75);
            this.txtDescription.TabIndex = 1;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(357, 158);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(88, 16);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "Год выпуска";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(357, 195);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(99, 16);
            this.lblDuration.TabIndex = 3;
            this.lblDuration.Text = "Длительность";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(357, 230);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(61, 16);
            this.lblRating.TabIndex = 4;
            this.lblRating.Text = "Рейтинг";
            // 
            // ptrboxPoster
            // 
            this.ptrboxPoster.Location = new System.Drawing.Point(92, 10);
            this.ptrboxPoster.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ptrboxPoster.Name = "ptrboxPoster";
            this.ptrboxPoster.Size = new System.Drawing.Size(240, 288);
            this.ptrboxPoster.TabIndex = 5;
            this.ptrboxPoster.TabStop = false;
            // 
            // btnShowPrevFilm
            // 
            this.btnShowPrevFilm.Location = new System.Drawing.Point(51, 330);
            this.btnShowPrevFilm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowPrevFilm.Name = "btnShowPrevFilm";
            this.btnShowPrevFilm.Size = new System.Drawing.Size(281, 54);
            this.btnShowPrevFilm.TabIndex = 6;
            this.btnShowPrevFilm.Text = "Предыдущий фильм";
            this.btnShowPrevFilm.UseVisualStyleBackColor = true;
            this.btnShowPrevFilm.Click += new System.EventHandler(this.btnShowPrevFilm_Click);
            // 
            // btnShowNextFilm
            // 
            this.btnShowNextFilm.Location = new System.Drawing.Point(423, 330);
            this.btnShowNextFilm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowNextFilm.Name = "btnShowNextFilm";
            this.btnShowNextFilm.Size = new System.Drawing.Size(286, 54);
            this.btnShowNextFilm.TabIndex = 7;
            this.btnShowNextFilm.Text = "Следующий фильм";
            this.btnShowNextFilm.UseVisualStyleBackColor = true;
            this.btnShowNextFilm.Click += new System.EventHandler(this.btnShowNextFilm_Click);
            // 
            // lblMovieId
            // 
            this.lblMovieId.AutoSize = true;
            this.lblMovieId.Location = new System.Drawing.Point(12, 10);
            this.lblMovieId.Name = "lblMovieId";
            this.lblMovieId.Size = new System.Drawing.Size(48, 16);
            this.lblMovieId.TabIndex = 8;
            this.lblMovieId.Text = "номер";
            // 
            // lblGenres
            // 
            this.lblGenres.AutoSize = true;
            this.lblGenres.Location = new System.Drawing.Point(361, 119);
            this.lblGenres.Name = "lblGenres";
            this.lblGenres.Size = new System.Drawing.Size(44, 16);
            this.lblGenres.TabIndex = 9;
            this.lblGenres.Text = "Жанр";
            // 
            // MovieDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 394);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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