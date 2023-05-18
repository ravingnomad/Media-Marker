
namespace Media_Edit_Forms
{
    partial class MovieEditForm
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
            this.movieEditGenreListBox = new System.Windows.Forms.CheckedListBox();
            this.movieEditSaveButton = new System.Windows.Forms.Button();
            this.movieEditGenreLabel = new System.Windows.Forms.Label();
            this.movieEditDirectorLabel = new System.Windows.Forms.Label();
            this.movieEditDirectorTextBox = new System.Windows.Forms.TextBox();
            this.movieEditTitleLabel = new System.Windows.Forms.Label();
            this.movieEditTitleTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // movieEditGenreListBox
            // 
            this.movieEditGenreListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.movieEditGenreListBox.FormattingEnabled = true;
            this.movieEditGenreListBox.Items.AddRange(new object[] {
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
            this.movieEditGenreListBox.Location = new System.Drawing.Point(247, 165);
            this.movieEditGenreListBox.Name = "movieEditGenreListBox";
            this.movieEditGenreListBox.Size = new System.Drawing.Size(312, 259);
            this.movieEditGenreListBox.TabIndex = 35;
            // 
            // movieEditSaveButton
            // 
            this.movieEditSaveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.movieEditSaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movieEditSaveButton.Location = new System.Drawing.Point(247, 454);
            this.movieEditSaveButton.Name = "movieEditSaveButton";
            this.movieEditSaveButton.Size = new System.Drawing.Size(179, 61);
            this.movieEditSaveButton.TabIndex = 34;
            this.movieEditSaveButton.Text = "Save";
            this.movieEditSaveButton.UseVisualStyleBackColor = true;
            this.movieEditSaveButton.Click += new System.EventHandler(this.movieEditSaveButton_Click);
            // 
            // movieEditGenreLabel
            // 
            this.movieEditGenreLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.movieEditGenreLabel.AutoSize = true;
            this.movieEditGenreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movieEditGenreLabel.Location = new System.Drawing.Point(104, 273);
            this.movieEditGenreLabel.Name = "movieEditGenreLabel";
            this.movieEditGenreLabel.Size = new System.Drawing.Size(120, 39);
            this.movieEditGenreLabel.TabIndex = 33;
            this.movieEditGenreLabel.Text = "Genre:";
            this.movieEditGenreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // movieEditDirectorLabel
            // 
            this.movieEditDirectorLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.movieEditDirectorLabel.AutoSize = true;
            this.movieEditDirectorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movieEditDirectorLabel.Location = new System.Drawing.Point(84, 97);
            this.movieEditDirectorLabel.Name = "movieEditDirectorLabel";
            this.movieEditDirectorLabel.Size = new System.Drawing.Size(145, 39);
            this.movieEditDirectorLabel.TabIndex = 32;
            this.movieEditDirectorLabel.Text = "Director:";
            this.movieEditDirectorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // movieEditDirectorTextBox
            // 
            this.movieEditDirectorTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.movieEditDirectorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movieEditDirectorTextBox.Location = new System.Drawing.Point(247, 97);
            this.movieEditDirectorTextBox.Name = "movieEditDirectorTextBox";
            this.movieEditDirectorTextBox.Size = new System.Drawing.Size(312, 45);
            this.movieEditDirectorTextBox.TabIndex = 31;
            // 
            // movieEditTitleLabel
            // 
            this.movieEditTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.movieEditTitleLabel.AutoSize = true;
            this.movieEditTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movieEditTitleLabel.Location = new System.Drawing.Point(136, 27);
            this.movieEditTitleLabel.Name = "movieEditTitleLabel";
            this.movieEditTitleLabel.Size = new System.Drawing.Size(91, 39);
            this.movieEditTitleLabel.TabIndex = 30;
            this.movieEditTitleLabel.Text = "Title:";
            this.movieEditTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // movieEditTitleTextBox
            // 
            this.movieEditTitleTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.movieEditTitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movieEditTitleTextBox.Location = new System.Drawing.Point(247, 27);
            this.movieEditTitleTextBox.Name = "movieEditTitleTextBox";
            this.movieEditTitleTextBox.Size = new System.Drawing.Size(312, 45);
            this.movieEditTitleTextBox.TabIndex = 29;
            // 
            // movieEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 543);
            this.Controls.Add(this.movieEditGenreListBox);
            this.Controls.Add(this.movieEditSaveButton);
            this.Controls.Add(this.movieEditGenreLabel);
            this.Controls.Add(this.movieEditDirectorLabel);
            this.Controls.Add(this.movieEditDirectorTextBox);
            this.Controls.Add(this.movieEditTitleLabel);
            this.Controls.Add(this.movieEditTitleTextBox);
            this.Name = "movieEditForm";
            this.Text = "movieEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox movieEditGenreListBox;
        private System.Windows.Forms.Button movieEditSaveButton;
        private System.Windows.Forms.Label movieEditGenreLabel;
        private System.Windows.Forms.Label movieEditDirectorLabel;
        private System.Windows.Forms.TextBox movieEditDirectorTextBox;
        private System.Windows.Forms.Label movieEditTitleLabel;
        private System.Windows.Forms.TextBox movieEditTitleTextBox;
    }
}