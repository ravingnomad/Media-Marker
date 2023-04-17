
namespace Media_Edit_Forms
{
    partial class bookEditForm
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
            this.bookEditGenreListBox = new System.Windows.Forms.CheckedListBox();
            this.bookEditSaveButton = new System.Windows.Forms.Button();
            this.bookEditGenreLabel = new System.Windows.Forms.Label();
            this.bookEditAuthorLabel = new System.Windows.Forms.Label();
            this.bookEditAuthorTextBox = new System.Windows.Forms.TextBox();
            this.bookEditTitleLabel = new System.Windows.Forms.Label();
            this.bookEditTitleTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bookEditGenreListBox
            // 
            this.bookEditGenreListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bookEditGenreListBox.FormattingEnabled = true;
            this.bookEditGenreListBox.Items.AddRange(new object[] {
            "Action",
            "Adventure",
            "Biographical",
            "Comedy",
            "Comic",
            "Detective Fiction",
            "Educational",
            "Fantasy",
            "Historical Fiction",
            "History",
            "Horror",
            "Manga",
            "Mystery",
            "Non Fiction",
            "Philosophy",
            "Romance",
            "Science Fiction",
            "Short Story",
            "Tragedy"});
            this.bookEditGenreListBox.Location = new System.Drawing.Point(238, 158);
            this.bookEditGenreListBox.Name = "bookEditGenreListBox";
            this.bookEditGenreListBox.Size = new System.Drawing.Size(312, 276);
            this.bookEditGenreListBox.TabIndex = 16;
            // 
            // bookEditSaveButton
            // 
            this.bookEditSaveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bookEditSaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookEditSaveButton.Location = new System.Drawing.Point(238, 453);
            this.bookEditSaveButton.Name = "bookEditSaveButton";
            this.bookEditSaveButton.Size = new System.Drawing.Size(179, 61);
            this.bookEditSaveButton.TabIndex = 15;
            this.bookEditSaveButton.Text = "Save";
            this.bookEditSaveButton.UseVisualStyleBackColor = true;
            this.bookEditSaveButton.Click += new System.EventHandler(this.bookEditSaveButton_Click);
            // 
            // bookEditGenreLabel
            // 
            this.bookEditGenreLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bookEditGenreLabel.AutoSize = true;
            this.bookEditGenreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookEditGenreLabel.Location = new System.Drawing.Point(98, 277);
            this.bookEditGenreLabel.Name = "bookEditGenreLabel";
            this.bookEditGenreLabel.Size = new System.Drawing.Size(120, 39);
            this.bookEditGenreLabel.TabIndex = 14;
            this.bookEditGenreLabel.Text = "Genre:";
            this.bookEditGenreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bookEditAuthorLabel
            // 
            this.bookEditAuthorLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bookEditAuthorLabel.AutoSize = true;
            this.bookEditAuthorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookEditAuthorLabel.Location = new System.Drawing.Point(92, 102);
            this.bookEditAuthorLabel.Name = "bookEditAuthorLabel";
            this.bookEditAuthorLabel.Size = new System.Drawing.Size(126, 39);
            this.bookEditAuthorLabel.TabIndex = 13;
            this.bookEditAuthorLabel.Text = "Author:";
            this.bookEditAuthorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bookEditAuthorTextBox
            // 
            this.bookEditAuthorTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bookEditAuthorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookEditAuthorTextBox.Location = new System.Drawing.Point(238, 102);
            this.bookEditAuthorTextBox.Name = "bookEditAuthorTextBox";
            this.bookEditAuthorTextBox.Size = new System.Drawing.Size(312, 45);
            this.bookEditAuthorTextBox.TabIndex = 12;
            // 
            // bookEditTitleLabel
            // 
            this.bookEditTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bookEditTitleLabel.AutoSize = true;
            this.bookEditTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookEditTitleLabel.Location = new System.Drawing.Point(127, 28);
            this.bookEditTitleLabel.Name = "bookEditTitleLabel";
            this.bookEditTitleLabel.Size = new System.Drawing.Size(91, 39);
            this.bookEditTitleLabel.TabIndex = 11;
            this.bookEditTitleLabel.Text = "Title:";
            this.bookEditTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bookEditTitleTextBox
            // 
            this.bookEditTitleTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bookEditTitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookEditTitleTextBox.Location = new System.Drawing.Point(238, 28);
            this.bookEditTitleTextBox.Name = "bookEditTitleTextBox";
            this.bookEditTitleTextBox.Size = new System.Drawing.Size(312, 45);
            this.bookEditTitleTextBox.TabIndex = 10;
            // 
            // bookEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 543);
            this.Controls.Add(this.bookEditGenreListBox);
            this.Controls.Add(this.bookEditSaveButton);
            this.Controls.Add(this.bookEditGenreLabel);
            this.Controls.Add(this.bookEditAuthorLabel);
            this.Controls.Add(this.bookEditAuthorTextBox);
            this.Controls.Add(this.bookEditTitleLabel);
            this.Controls.Add(this.bookEditTitleTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "bookEditForm";
            this.Text = "bookEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox bookEditGenreListBox;
        private System.Windows.Forms.Button bookEditSaveButton;
        private System.Windows.Forms.Label bookEditGenreLabel;
        private System.Windows.Forms.Label bookEditAuthorLabel;
        private System.Windows.Forms.TextBox bookEditAuthorTextBox;
        private System.Windows.Forms.Label bookEditTitleLabel;
        private System.Windows.Forms.TextBox bookEditTitleTextBox;
    }
}