
namespace New_Media_Forms
{
    partial class newBookForm
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
            this.newBookTitleTextBox = new System.Windows.Forms.TextBox();
            this.newBookTitleLabel = new System.Windows.Forms.Label();
            this.newBookAuthorLabel = new System.Windows.Forms.Label();
            this.newBookAuthorTextBox = new System.Windows.Forms.TextBox();
            this.newBookGenreLabel = new System.Windows.Forms.Label();
            this.addNewBookButton = new System.Windows.Forms.Button();
            this.bookGenreListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // newBookTitleTextBox
            // 
            this.newBookTitleTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newBookTitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newBookTitleTextBox.Location = new System.Drawing.Point(240, 94);
            this.newBookTitleTextBox.Name = "newBookTitleTextBox";
            this.newBookTitleTextBox.Size = new System.Drawing.Size(312, 45);
            this.newBookTitleTextBox.TabIndex = 0;
            // 
            // newBookTitleLabel
            // 
            this.newBookTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newBookTitleLabel.AutoSize = true;
            this.newBookTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newBookTitleLabel.Location = new System.Drawing.Point(129, 94);
            this.newBookTitleLabel.Name = "newBookTitleLabel";
            this.newBookTitleLabel.Size = new System.Drawing.Size(91, 39);
            this.newBookTitleLabel.TabIndex = 1;
            this.newBookTitleLabel.Text = "Title:";
            this.newBookTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newBookAuthorLabel
            // 
            this.newBookAuthorLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newBookAuthorLabel.AutoSize = true;
            this.newBookAuthorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newBookAuthorLabel.Location = new System.Drawing.Point(94, 168);
            this.newBookAuthorLabel.Name = "newBookAuthorLabel";
            this.newBookAuthorLabel.Size = new System.Drawing.Size(126, 39);
            this.newBookAuthorLabel.TabIndex = 3;
            this.newBookAuthorLabel.Text = "Author:";
            this.newBookAuthorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newBookAuthorTextBox
            // 
            this.newBookAuthorTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newBookAuthorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newBookAuthorTextBox.Location = new System.Drawing.Point(240, 168);
            this.newBookAuthorTextBox.Name = "newBookAuthorTextBox";
            this.newBookAuthorTextBox.Size = new System.Drawing.Size(312, 45);
            this.newBookAuthorTextBox.TabIndex = 2;
            // 
            // newBookGenreLabel
            // 
            this.newBookGenreLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newBookGenreLabel.AutoSize = true;
            this.newBookGenreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newBookGenreLabel.Location = new System.Drawing.Point(100, 294);
            this.newBookGenreLabel.Name = "newBookGenreLabel";
            this.newBookGenreLabel.Size = new System.Drawing.Size(120, 39);
            this.newBookGenreLabel.TabIndex = 5;
            this.newBookGenreLabel.Text = "Genre:";
            this.newBookGenreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addNewBookButton
            // 
            this.addNewBookButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addNewBookButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewBookButton.Location = new System.Drawing.Point(240, 470);
            this.addNewBookButton.Name = "addNewBookButton";
            this.addNewBookButton.Size = new System.Drawing.Size(179, 61);
            this.addNewBookButton.TabIndex = 8;
            this.addNewBookButton.Text = "Add";
            this.addNewBookButton.UseVisualStyleBackColor = true;
            this.addNewBookButton.Click += new System.EventHandler(this.addNewBookButton_Click);
            // 
            // bookGenreListBox
            // 
            this.bookGenreListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bookGenreListBox.FormattingEnabled = true;
            this.bookGenreListBox.Items.AddRange(new object[] {
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
            this.bookGenreListBox.Location = new System.Drawing.Point(240, 243);
            this.bookGenreListBox.Name = "bookGenreListBox";
            this.bookGenreListBox.Size = new System.Drawing.Size(312, 208);
            this.bookGenreListBox.TabIndex = 9;
            // 
            // newBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 543);
            this.Controls.Add(this.bookGenreListBox);
            this.Controls.Add(this.addNewBookButton);
            this.Controls.Add(this.newBookGenreLabel);
            this.Controls.Add(this.newBookAuthorLabel);
            this.Controls.Add(this.newBookAuthorTextBox);
            this.Controls.Add(this.newBookTitleLabel);
            this.Controls.Add(this.newBookTitleTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "newBookForm";
            this.Text = "Add Book";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox newBookTitleTextBox;
        private System.Windows.Forms.Label newBookTitleLabel;
        private System.Windows.Forms.Label newBookAuthorLabel;
        private System.Windows.Forms.TextBox newBookAuthorTextBox;
        private System.Windows.Forms.Label newBookGenreLabel;
        private System.Windows.Forms.Button addNewBookButton;
        private System.Windows.Forms.CheckedListBox bookGenreListBox;
    }
}