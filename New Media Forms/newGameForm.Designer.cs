
namespace New_Media_Forms
{
    partial class newGameForm
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
            this.newGamePlatformsLabel = new System.Windows.Forms.Label();
            this.newGameGenreLabel = new System.Windows.Forms.Label();
            this.newGameDeveloperLabel = new System.Windows.Forms.Label();
            this.newGameDeveloperTextBox = new System.Windows.Forms.TextBox();
            this.newGameTitleLabel = new System.Windows.Forms.Label();
            this.newGameTitleTextBox = new System.Windows.Forms.TextBox();
            this.addNewGameButton = new System.Windows.Forms.Button();
            this.gamePlatformListBox = new System.Windows.Forms.CheckedListBox();
            this.gameGenreListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // newGamePlatformsLabel
            // 
            this.newGamePlatformsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newGamePlatformsLabel.AutoSize = true;
            this.newGamePlatformsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGamePlatformsLabel.Location = new System.Drawing.Point(57, 354);
            this.newGamePlatformsLabel.Name = "newGamePlatformsLabel";
            this.newGamePlatformsLabel.Size = new System.Drawing.Size(169, 39);
            this.newGamePlatformsLabel.TabIndex = 33;
            this.newGamePlatformsLabel.Text = "Platforms:";
            this.newGamePlatformsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newGameGenreLabel
            // 
            this.newGameGenreLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newGameGenreLabel.AutoSize = true;
            this.newGameGenreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGameGenreLabel.Location = new System.Drawing.Point(106, 169);
            this.newGameGenreLabel.Name = "newGameGenreLabel";
            this.newGameGenreLabel.Size = new System.Drawing.Size(120, 39);
            this.newGameGenreLabel.TabIndex = 29;
            this.newGameGenreLabel.Text = "Genre:";
            this.newGameGenreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newGameDeveloperLabel
            // 
            this.newGameDeveloperLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newGameDeveloperLabel.AutoSize = true;
            this.newGameDeveloperLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGameDeveloperLabel.Location = new System.Drawing.Point(44, 99);
            this.newGameDeveloperLabel.Name = "newGameDeveloperLabel";
            this.newGameDeveloperLabel.Size = new System.Drawing.Size(182, 39);
            this.newGameDeveloperLabel.TabIndex = 27;
            this.newGameDeveloperLabel.Text = "Developer:";
            this.newGameDeveloperLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newGameDeveloperTextBox
            // 
            this.newGameDeveloperTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newGameDeveloperTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGameDeveloperTextBox.Location = new System.Drawing.Point(246, 99);
            this.newGameDeveloperTextBox.Name = "newGameDeveloperTextBox";
            this.newGameDeveloperTextBox.Size = new System.Drawing.Size(312, 45);
            this.newGameDeveloperTextBox.TabIndex = 26;
            // 
            // newGameTitleLabel
            // 
            this.newGameTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newGameTitleLabel.AutoSize = true;
            this.newGameTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGameTitleLabel.Location = new System.Drawing.Point(135, 29);
            this.newGameTitleLabel.Name = "newGameTitleLabel";
            this.newGameTitleLabel.Size = new System.Drawing.Size(91, 39);
            this.newGameTitleLabel.TabIndex = 25;
            this.newGameTitleLabel.Text = "Title:";
            this.newGameTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newGameTitleTextBox
            // 
            this.newGameTitleTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newGameTitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGameTitleTextBox.Location = new System.Drawing.Point(246, 29);
            this.newGameTitleTextBox.Name = "newGameTitleTextBox";
            this.newGameTitleTextBox.Size = new System.Drawing.Size(312, 45);
            this.newGameTitleTextBox.TabIndex = 24;
            // 
            // addNewGameButton
            // 
            this.addNewGameButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addNewGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewGameButton.Location = new System.Drawing.Point(246, 461);
            this.addNewGameButton.Name = "addNewGameButton";
            this.addNewGameButton.Size = new System.Drawing.Size(179, 61);
            this.addNewGameButton.TabIndex = 34;
            this.addNewGameButton.Text = "Add";
            this.addNewGameButton.UseVisualStyleBackColor = true;
            this.addNewGameButton.Click += new System.EventHandler(this.addNewGameButton_Click);
            // 
            // gamePlatformListBox
            // 
            this.gamePlatformListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gamePlatformListBox.FormattingEnabled = true;
            this.gamePlatformListBox.Items.AddRange(new object[] {
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
            this.gamePlatformListBox.Location = new System.Drawing.Point(246, 303);
            this.gamePlatformListBox.Name = "gamePlatformListBox";
            this.gamePlatformListBox.Size = new System.Drawing.Size(312, 140);
            this.gamePlatformListBox.TabIndex = 43;
            // 
            // gameGenreListBox
            // 
            this.gameGenreListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameGenreListBox.FormattingEnabled = true;
            this.gameGenreListBox.Items.AddRange(new object[] {
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
            this.gameGenreListBox.Location = new System.Drawing.Point(246, 169);
            this.gameGenreListBox.Name = "gameGenreListBox";
            this.gameGenreListBox.Size = new System.Drawing.Size(312, 123);
            this.gameGenreListBox.TabIndex = 44;
            // 
            // newGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 543);
            this.Controls.Add(this.gameGenreListBox);
            this.Controls.Add(this.gamePlatformListBox);
            this.Controls.Add(this.addNewGameButton);
            this.Controls.Add(this.newGamePlatformsLabel);
            this.Controls.Add(this.newGameGenreLabel);
            this.Controls.Add(this.newGameDeveloperLabel);
            this.Controls.Add(this.newGameDeveloperTextBox);
            this.Controls.Add(this.newGameTitleLabel);
            this.Controls.Add(this.newGameTitleTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "newGameForm";
            this.Text = "Add Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label newGamePlatformsLabel;
        private System.Windows.Forms.Label newGameGenreLabel;
        private System.Windows.Forms.Label newGameDeveloperLabel;
        private System.Windows.Forms.TextBox newGameDeveloperTextBox;
        private System.Windows.Forms.Label newGameTitleLabel;
        private System.Windows.Forms.TextBox newGameTitleTextBox;
        private System.Windows.Forms.Button addNewGameButton;
        private System.Windows.Forms.CheckedListBox gamePlatformListBox;
        private System.Windows.Forms.CheckedListBox gameGenreListBox;
    }
}