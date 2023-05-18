
namespace Media_Edit_Forms
{
    partial class GameEditForm
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
            this.gameEditGenreListBox = new System.Windows.Forms.CheckedListBox();
            this.gameEditPlatformListBox = new System.Windows.Forms.CheckedListBox();
            this.gameEditSaveButton = new System.Windows.Forms.Button();
            this.gameEditPlatformsLabel = new System.Windows.Forms.Label();
            this.gameEditGenreLabel = new System.Windows.Forms.Label();
            this.gameEditDeveloperLabel = new System.Windows.Forms.Label();
            this.gameEditDeveloperTextBox = new System.Windows.Forms.TextBox();
            this.gameEditTitleLabel = new System.Windows.Forms.Label();
            this.gameEditTitleTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // gameEditGenreListBox
            // 
            this.gameEditGenreListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameEditGenreListBox.FormattingEnabled = true;
            this.gameEditGenreListBox.Items.AddRange(new object[] {
            "Action",
            "Adventure",
            "Beat-em-Up",
            "Fantasy",
            "Fighting",
            "FPS",
            "Flight Sim",
            "Hack-and-Slash",
            "Horror",
            "JRPG",
            "Mecha",
            "Platforming",
            "Puzzle",
            "RPG",
            "Science Fiction",
            "Stealth",
            "Strategy",
            "Survival",
            "Third-Person Shooter",
            "Turn-Based RPG"});
            this.gameEditGenreListBox.Location = new System.Drawing.Point(266, 165);
            this.gameEditGenreListBox.Name = "gameEditGenreListBox";
            this.gameEditGenreListBox.Size = new System.Drawing.Size(312, 123);
            this.gameEditGenreListBox.TabIndex = 53;
            // 
            // gameEditPlatformListBox
            // 
            this.gameEditPlatformListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameEditPlatformListBox.FormattingEnabled = true;
            this.gameEditPlatformListBox.Items.AddRange(new object[] {
            "3DS",
            "DS",
            "GBA",
            "GBC",
            "NES",
            "SNES",
            "Switch",
            "PS One",
            "PS Vita",
            "PS2",
            "PS3",
            "PSP",
            "X-Box",
            "X-Box 360",
            "PC"});
            this.gameEditPlatformListBox.Location = new System.Drawing.Point(266, 299);
            this.gameEditPlatformListBox.Name = "gameEditPlatformListBox";
            this.gameEditPlatformListBox.Size = new System.Drawing.Size(312, 140);
            this.gameEditPlatformListBox.TabIndex = 52;
            // 
            // gameEditSaveButton
            // 
            this.gameEditSaveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameEditSaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameEditSaveButton.Location = new System.Drawing.Point(266, 457);
            this.gameEditSaveButton.Name = "gameEditSaveButton";
            this.gameEditSaveButton.Size = new System.Drawing.Size(179, 61);
            this.gameEditSaveButton.TabIndex = 51;
            this.gameEditSaveButton.Text = "Save";
            this.gameEditSaveButton.UseVisualStyleBackColor = true;
            this.gameEditSaveButton.Click += new System.EventHandler(this.gameEditSaveButton_Click);
            // 
            // gameEditPlatformsLabel
            // 
            this.gameEditPlatformsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameEditPlatformsLabel.AutoSize = true;
            this.gameEditPlatformsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameEditPlatformsLabel.Location = new System.Drawing.Point(77, 350);
            this.gameEditPlatformsLabel.Name = "gameEditPlatformsLabel";
            this.gameEditPlatformsLabel.Size = new System.Drawing.Size(169, 39);
            this.gameEditPlatformsLabel.TabIndex = 50;
            this.gameEditPlatformsLabel.Text = "Platforms:";
            this.gameEditPlatformsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameEditGenreLabel
            // 
            this.gameEditGenreLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameEditGenreLabel.AutoSize = true;
            this.gameEditGenreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameEditGenreLabel.Location = new System.Drawing.Point(126, 165);
            this.gameEditGenreLabel.Name = "gameEditGenreLabel";
            this.gameEditGenreLabel.Size = new System.Drawing.Size(120, 39);
            this.gameEditGenreLabel.TabIndex = 49;
            this.gameEditGenreLabel.Text = "Genre:";
            this.gameEditGenreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameEditDeveloperLabel
            // 
            this.gameEditDeveloperLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameEditDeveloperLabel.AutoSize = true;
            this.gameEditDeveloperLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameEditDeveloperLabel.Location = new System.Drawing.Point(64, 95);
            this.gameEditDeveloperLabel.Name = "gameEditDeveloperLabel";
            this.gameEditDeveloperLabel.Size = new System.Drawing.Size(182, 39);
            this.gameEditDeveloperLabel.TabIndex = 48;
            this.gameEditDeveloperLabel.Text = "Developer:";
            this.gameEditDeveloperLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameEditDeveloperTextBox
            // 
            this.gameEditDeveloperTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameEditDeveloperTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameEditDeveloperTextBox.Location = new System.Drawing.Point(266, 95);
            this.gameEditDeveloperTextBox.Name = "gameEditDeveloperTextBox";
            this.gameEditDeveloperTextBox.Size = new System.Drawing.Size(312, 45);
            this.gameEditDeveloperTextBox.TabIndex = 47;
            // 
            // gameEditTitleLabel
            // 
            this.gameEditTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameEditTitleLabel.AutoSize = true;
            this.gameEditTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameEditTitleLabel.Location = new System.Drawing.Point(155, 25);
            this.gameEditTitleLabel.Name = "gameEditTitleLabel";
            this.gameEditTitleLabel.Size = new System.Drawing.Size(91, 39);
            this.gameEditTitleLabel.TabIndex = 46;
            this.gameEditTitleLabel.Text = "Title:";
            this.gameEditTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameEditTitleTextBox
            // 
            this.gameEditTitleTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameEditTitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameEditTitleTextBox.Location = new System.Drawing.Point(266, 25);
            this.gameEditTitleTextBox.Name = "gameEditTitleTextBox";
            this.gameEditTitleTextBox.Size = new System.Drawing.Size(312, 45);
            this.gameEditTitleTextBox.TabIndex = 45;
            // 
            // gameEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 543);
            this.Controls.Add(this.gameEditGenreListBox);
            this.Controls.Add(this.gameEditPlatformListBox);
            this.Controls.Add(this.gameEditSaveButton);
            this.Controls.Add(this.gameEditPlatformsLabel);
            this.Controls.Add(this.gameEditGenreLabel);
            this.Controls.Add(this.gameEditDeveloperLabel);
            this.Controls.Add(this.gameEditDeveloperTextBox);
            this.Controls.Add(this.gameEditTitleLabel);
            this.Controls.Add(this.gameEditTitleTextBox);
            this.Name = "gameEditForm";
            this.Text = "gameEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox gameEditGenreListBox;
        private System.Windows.Forms.CheckedListBox gameEditPlatformListBox;
        private System.Windows.Forms.Button gameEditSaveButton;
        private System.Windows.Forms.Label gameEditPlatformsLabel;
        private System.Windows.Forms.Label gameEditGenreLabel;
        private System.Windows.Forms.Label gameEditDeveloperLabel;
        private System.Windows.Forms.TextBox gameEditDeveloperTextBox;
        private System.Windows.Forms.Label gameEditTitleLabel;
        private System.Windows.Forms.TextBox gameEditTitleTextBox;
    }
}