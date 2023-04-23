
namespace Media_Search_Result_Forms
{
    partial class movieSearchResultForm
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
            this.movieDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.movieDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // movieDataGridView
            // 
            this.movieDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.movieDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.movieDataGridView.Location = new System.Drawing.Point(12, 12);
            this.movieDataGridView.Name = "movieDataGridView";
            this.movieDataGridView.RowHeadersWidth = 51;
            this.movieDataGridView.RowTemplate.Height = 24;
            this.movieDataGridView.Size = new System.Drawing.Size(1054, 459);
            this.movieDataGridView.TabIndex = 0;
            // 
            // movieSearchResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 483);
            this.Controls.Add(this.movieDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "movieSearchResultForm";
            this.Text = "movieSearchResultForm";
            this.Load += new System.EventHandler(this.movieSearchResultForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.movieDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView movieDataGridView;
    }
}