
namespace New_Media_Forms
{
    partial class newMovieForm
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
            this.newMovieGenreLabel = new System.Windows.Forms.Label();
            this.newMovieDirectorLabel = new System.Windows.Forms.Label();
            this.newMovieDirectorTextBox = new System.Windows.Forms.TextBox();
            this.newMovieTitleLabel = new System.Windows.Forms.Label();
            this.newMovieTitleTextBox = new System.Windows.Forms.TextBox();
            this.addNewMovieButton = new System.Windows.Forms.Button();
            this.newMovieGenreListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // newMovieGenreLabel
            // 
            this.newMovieGenreLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newMovieGenreLabel.AutoSize = true;
            this.newMovieGenreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newMovieGenreLabel.Location = new System.Drawing.Point(103, 271);
            this.newMovieGenreLabel.Name = "newMovieGenreLabel";
            this.newMovieGenreLabel.Size = new System.Drawing.Size(120, 39);
            this.newMovieGenreLabel.TabIndex = 11;
            this.newMovieGenreLabel.Text = "Genre:";
            this.newMovieGenreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newMovieDirectorLabel
            // 
            this.newMovieDirectorLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newMovieDirectorLabel.AutoSize = true;
            this.newMovieDirectorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newMovieDirectorLabel.Location = new System.Drawing.Point(83, 95);
            this.newMovieDirectorLabel.Name = "newMovieDirectorLabel";
            this.newMovieDirectorLabel.Size = new System.Drawing.Size(145, 39);
            this.newMovieDirectorLabel.TabIndex = 9;
            this.newMovieDirectorLabel.Text = "Director:";
            this.newMovieDirectorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newMovieDirectorTextBox
            // 
            this.newMovieDirectorTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newMovieDirectorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newMovieDirectorTextBox.Location = new System.Drawing.Point(246, 95);
            this.newMovieDirectorTextBox.Name = "newMovieDirectorTextBox";
            this.newMovieDirectorTextBox.Size = new System.Drawing.Size(312, 45);
            this.newMovieDirectorTextBox.TabIndex = 8;
            // 
            // newMovieTitleLabel
            // 
            this.newMovieTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newMovieTitleLabel.AutoSize = true;
            this.newMovieTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newMovieTitleLabel.Location = new System.Drawing.Point(135, 25);
            this.newMovieTitleLabel.Name = "newMovieTitleLabel";
            this.newMovieTitleLabel.Size = new System.Drawing.Size(91, 39);
            this.newMovieTitleLabel.TabIndex = 7;
            this.newMovieTitleLabel.Text = "Title:";
            this.newMovieTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newMovieTitleTextBox
            // 
            this.newMovieTitleTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newMovieTitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newMovieTitleTextBox.Location = new System.Drawing.Point(246, 25);
            this.newMovieTitleTextBox.Name = "newMovieTitleTextBox";
            this.newMovieTitleTextBox.Size = new System.Drawing.Size(312, 45);
            this.newMovieTitleTextBox.TabIndex = 6;
            // 
            // addNewMovieButton
            // 
            this.addNewMovieButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addNewMovieButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewMovieButton.Location = new System.Drawing.Point(246, 452);
            this.addNewMovieButton.Name = "addNewMovieButton";
            this.addNewMovieButton.Size = new System.Drawing.Size(179, 61);
            this.addNewMovieButton.TabIndex = 27;
            this.addNewMovieButton.Text = "Add";
            this.addNewMovieButton.UseVisualStyleBackColor = true;
            this.addNewMovieButton.Click += new System.EventHandler(this.addNewMovieButton_Click);
            // 
            // newMovieGenreListBox
            // 
            this.newMovieGenreListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newMovieGenreListBox.FormattingEnabled = true;
            this.newMovieGenreListBox.Items.AddRange(new object[] {
            "Action",
            "Animation",
            "Biographical",
            "Comedy",
            "Documentary",
            "Drama",
            "Fantasy",
            "Historical Fiction",
            "Horror",
            "Musical",
            "Mystery",
            "Romance",
            "Science Fiction",
            "Thriller",
            "Western"});
            this.newMovieGenreListBox.Location = new System.Drawing.Point(246, 163);
            this.newMovieGenreListBox.Name = "newMovieGenreListBox";
            this.newMovieGenreListBox.Size = new System.Drawing.Size(312, 259);
            this.newMovieGenreListBox.TabIndex = 28;
            // 
            // newMovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 543);
            this.Controls.Add(this.newMovieGenreListBox);
            this.Controls.Add(this.addNewMovieButton);
            this.Controls.Add(this.newMovieGenreLabel);
            this.Controls.Add(this.newMovieDirectorLabel);
            this.Controls.Add(this.newMovieDirectorTextBox);
            this.Controls.Add(this.newMovieTitleLabel);
            this.Controls.Add(this.newMovieTitleTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "newMovieForm";
            this.Text = "Add Movie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label newMovieGenreLabel;
        private System.Windows.Forms.Label newMovieDirectorLabel;
        private System.Windows.Forms.TextBox newMovieDirectorTextBox;
        private System.Windows.Forms.Label newMovieTitleLabel;
        private System.Windows.Forms.TextBox newMovieTitleTextBox;
        private System.Windows.Forms.Button addNewMovieButton;
        private System.Windows.Forms.CheckedListBox newMovieGenreListBox;
    }
}