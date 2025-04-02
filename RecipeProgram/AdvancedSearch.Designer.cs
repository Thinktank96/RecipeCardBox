namespace RecipeProgram
{
    partial class AdvancedSearch
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.DeselectAllButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.AdvancedSearchStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.AdvancedSearchResultsListBox = new System.Windows.Forms.ListBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 34);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(242, 362);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // DeselectAllButton
            // 
            this.DeselectAllButton.Location = new System.Drawing.Point(12, 5);
            this.DeselectAllButton.Name = "DeselectAllButton";
            this.DeselectAllButton.Size = new System.Drawing.Size(75, 23);
            this.DeselectAllButton.TabIndex = 5;
            this.DeselectAllButton.Text = "Deselect All";
            this.DeselectAllButton.UseVisualStyleBackColor = true;
            this.DeselectAllButton.Click += new System.EventHandler(this.DeselectAllButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(12, 402);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(242, 23);
            this.SearchButton.TabIndex = 7;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AdvancedSearchStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(526, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // AdvancedSearchStripStatusLabel1
            // 
            this.AdvancedSearchStripStatusLabel1.Name = "AdvancedSearchStripStatusLabel1";
            this.AdvancedSearchStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // AdvancedSearchResultsListBox
            // 
            this.AdvancedSearchResultsListBox.FormattingEnabled = true;
            this.AdvancedSearchResultsListBox.Location = new System.Drawing.Point(260, 34);
            this.AdvancedSearchResultsListBox.Name = "AdvancedSearchResultsListBox";
            this.AdvancedSearchResultsListBox.Size = new System.Drawing.Size(254, 381);
            this.AdvancedSearchResultsListBox.TabIndex = 9;
            this.AdvancedSearchResultsListBox.SelectedIndexChanged += new System.EventHandler(this.AdvancedSearchResultsListBox_SelectedIndexChanged);
            // 
            // AdvancedSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 450);
            this.Controls.Add(this.AdvancedSearchResultsListBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.DeselectAllButton);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "AdvancedSearch";
            this.Text = "AdvancedSearch";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button DeselectAllButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel AdvancedSearchStripStatusLabel1;
        private System.Windows.Forms.ListBox AdvancedSearchResultsListBox;
    }
}