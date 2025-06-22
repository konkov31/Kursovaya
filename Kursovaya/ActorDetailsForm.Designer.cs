namespace Kursovaya
{
    partial class ActorDetailsForm
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
            this.pictureBoxActor = new System.Windows.Forms.PictureBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.btnFilmography = new System.Windows.Forms.Button();
            this.btnShowNextActor = new System.Windows.Forms.Button();
            this.btnShowPrevActor = new System.Windows.Forms.Button();
            this.btnAwards = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxActor)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxActor
            // 
            this.pictureBoxActor.Location = new System.Drawing.Point(45, 37);
            this.pictureBoxActor.Name = "pictureBoxActor";
            this.pictureBoxActor.Size = new System.Drawing.Size(263, 312);
            this.pictureBoxActor.TabIndex = 0;
            this.pictureBoxActor.TabStop = false;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(358, 37);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(100, 20);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "Полное имя";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(358, 80);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(128, 20);
            this.lblBirthDate.TabIndex = 2;
            this.lblBirthDate.Text = "Дата рождения";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(358, 126);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(65, 20);
            this.lblCountry.TabIndex = 3;
            this.lblCountry.Text = "Страна";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(362, 172);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(45, 20);
            this.lblHeight.TabIndex = 4;
            this.lblHeight.Text = "Рост";
            // 
            // btnFilmography
            // 
            this.btnFilmography.Location = new System.Drawing.Point(362, 291);
            this.btnFilmography.Name = "btnFilmography";
            this.btnFilmography.Size = new System.Drawing.Size(248, 68);
            this.btnFilmography.TabIndex = 6;
            this.btnFilmography.Text = "Фильмография";
            this.btnFilmography.UseVisualStyleBackColor = true;
            this.btnFilmography.Click += new System.EventHandler(this.btnFilmography_Click);
            // 
            // btnShowNextActor
            // 
            this.btnShowNextActor.Location = new System.Drawing.Point(362, 374);
            this.btnShowNextActor.Name = "btnShowNextActor";
            this.btnShowNextActor.Size = new System.Drawing.Size(248, 63);
            this.btnShowNextActor.TabIndex = 7;
            this.btnShowNextActor.Text = "Следующий актер";
            this.btnShowNextActor.UseVisualStyleBackColor = true;
            this.btnShowNextActor.Click += new System.EventHandler(this.btnShowNextActor_Click_1);
            // 
            // btnShowPrevActor
            // 
            this.btnShowPrevActor.Location = new System.Drawing.Point(45, 374);
            this.btnShowPrevActor.Name = "btnShowPrevActor";
            this.btnShowPrevActor.Size = new System.Drawing.Size(263, 63);
            this.btnShowPrevActor.TabIndex = 8;
            this.btnShowPrevActor.Text = "Предыдущий актер";
            this.btnShowPrevActor.UseVisualStyleBackColor = true;
            this.btnShowPrevActor.Click += new System.EventHandler(this.btnShowPrevActor_Click);
            // 
            // btnAwards
            // 
            this.btnAwards.Location = new System.Drawing.Point(362, 213);
            this.btnAwards.Name = "btnAwards";
            this.btnAwards.Size = new System.Drawing.Size(248, 62);
            this.btnAwards.TabIndex = 9;
            this.btnAwards.Text = "Награды";
            this.btnAwards.UseVisualStyleBackColor = true;
            this.btnAwards.Click += new System.EventHandler(this.btnAwards_Click);
            // 
            // ActorDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 462);
            this.Controls.Add(this.btnAwards);
            this.Controls.Add(this.btnShowPrevActor);
            this.Controls.Add(this.btnShowNextActor);
            this.Controls.Add(this.btnFilmography);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.pictureBoxActor);
            this.Name = "ActorDetailsForm";
            this.Text = "Информация об актерах";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxActor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxActor;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Button btnFilmography;
        private System.Windows.Forms.Button btnShowNextActor;
        private System.Windows.Forms.Button btnShowPrevActor;
        private System.Windows.Forms.Button btnAwards;
    }
}