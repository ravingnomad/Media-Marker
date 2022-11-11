
namespace Possessed_Media_Forms
{
    partial class newPossessedBookForm
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
            this.newPossessedBookTitleTextBox = new System.Windows.Forms.TextBox();
            this.newPossessedBookTitleLabel = new System.Windows.Forms.Label();
            this.newPossessedBookAuthorLabel = new System.Windows.Forms.Label();
            this.newPossessedBookAuthorTextBox = new System.Windows.Forms.TextBox();
            this.newPossessedBookGenreLabel = new System.Windows.Forms.Label();
            this.newPossessedBookGenreTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // newPossessedBookTitleTextBox
            // 
            this.newPossessedBookTitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPossessedBookTitleTextBox.Location = new System.Drawing.Point(319, 109);
            this.newPossessedBookTitleTextBox.Name = "newPossessedBookTitleTextBox";
            this.newPossessedBookTitleTextBox.Size = new System.Drawing.Size(255, 45);
            this.newPossessedBookTitleTextBox.TabIndex = 0;
            // 
            // newPossessedBookTitleLabel
            // 
            this.newPossessedBookTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPossessedBookTitleLabel.Location = new System.Drawing.Point(183, 109);
            this.newPossessedBookTitleLabel.Name = "newPossessedBookTitleLabel";
            this.newPossessedBookTitleLabel.Size = new System.Drawing.Size(130, 46);
            this.newPossessedBookTitleLabel.TabIndex = 1;
            this.newPossessedBookTitleLabel.Text = "Title:";
            this.newPossessedBookTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newPossessedBookAuthorLabel
            // 
            this.newPossessedBookAuthorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPossessedBookAuthorLabel.Location = new System.Drawing.Point(183, 191);
            this.newPossessedBookAuthorLabel.Name = "newPossessedBookAuthorLabel";
            this.newPossessedBookAuthorLabel.Size = new System.Drawing.Size(130, 46);
            this.newPossessedBookAuthorLabel.TabIndex = 3;
            this.newPossessedBookAuthorLabel.Text = "Author:";
            this.newPossessedBookAuthorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newPossessedBookAuthorTextBox
            // 
            this.newPossessedBookAuthorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPossessedBookAuthorTextBox.Location = new System.Drawing.Point(319, 191);
            this.newPossessedBookAuthorTextBox.Name = "newPossessedBookAuthorTextBox";
            this.newPossessedBookAuthorTextBox.Size = new System.Drawing.Size(255, 45);
            this.newPossessedBookAuthorTextBox.TabIndex = 2;
            // 
            // newPossessedBookGenreLabel
            // 
            this.newPossessedBookGenreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPossessedBookGenreLabel.Location = new System.Drawing.Point(183, 273);
            this.newPossessedBookGenreLabel.Name = "newPossessedBookGenreLabel";
            this.newPossessedBookGenreLabel.Size = new System.Drawing.Size(130, 46);
            this.newPossessedBookGenreLabel.TabIndex = 5;
            this.newPossessedBookGenreLabel.Text = "Genre:";
            this.newPossessedBookGenreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newPossessedBookGenreTextBox
            // 
            this.newPossessedBookGenreTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPossessedBookGenreTextBox.Location = new System.Drawing.Point(319, 273);
            this.newPossessedBookGenreTextBox.Name = "newPossessedBookGenreTextBox";
            this.newPossessedBookGenreTextBox.Size = new System.Drawing.Size(255, 45);
            this.newPossessedBookGenreTextBox.TabIndex = 4;
            // 
            // newPossessedBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.newPossessedBookGenreLabel);
            this.Controls.Add(this.newPossessedBookGenreTextBox);
            this.Controls.Add(this.newPossessedBookAuthorLabel);
            this.Controls.Add(this.newPossessedBookAuthorTextBox);
            this.Controls.Add(this.newPossessedBookTitleLabel);
            this.Controls.Add(this.newPossessedBookTitleTextBox);
            this.Name = "newPossessedBookForm";
            this.Text = "Add New Possessed Book";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox newPossessedBookTitleTextBox;
        private System.Windows.Forms.Label newPossessedBookTitleLabel;
        private System.Windows.Forms.Label newPossessedBookAuthorLabel;
        private System.Windows.Forms.TextBox newPossessedBookAuthorTextBox;
        private System.Windows.Forms.Label newPossessedBookGenreLabel;
        private System.Windows.Forms.TextBox newPossessedBookGenreTextBox;
    }
}