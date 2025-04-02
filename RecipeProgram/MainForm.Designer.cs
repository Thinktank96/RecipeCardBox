namespace RecipeProgram
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.RecipeDisplayText = new System.Windows.Forms.RichTextBox();
            this.RecipeSelectCombo = new System.Windows.Forms.ComboBox();
            this.EditButton = new System.Windows.Forms.Button();
            this.NewFolderButton = new System.Windows.Forms.Button();
            this.NewRecipeButton = new System.Windows.Forms.Button();
            this.FolderSelectCombo = new System.Windows.Forms.ComboBox();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusStripInfoLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.DeleteFolderButton = new System.Windows.Forms.Button();
            this.DeleteRecipeButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AdvancedSearchButton = new System.Windows.Forms.Button();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // RecipeDisplayText
            // 
            this.RecipeDisplayText.Location = new System.Drawing.Point(176, 12);
            this.RecipeDisplayText.Name = "RecipeDisplayText";
            this.RecipeDisplayText.ReadOnly = true;
            this.RecipeDisplayText.Size = new System.Drawing.Size(612, 413);
            this.RecipeDisplayText.TabIndex = 0;
            this.RecipeDisplayText.Text = "";
            // 
            // RecipeSelectCombo
            // 
            this.RecipeSelectCombo.FormattingEnabled = true;
            this.RecipeSelectCombo.Location = new System.Drawing.Point(12, 109);
            this.RecipeSelectCombo.Name = "RecipeSelectCombo";
            this.RecipeSelectCombo.Size = new System.Drawing.Size(158, 21);
            this.RecipeSelectCombo.TabIndex = 1;
            this.RecipeSelectCombo.Text = "Recipe Select";
            this.RecipeSelectCombo.SelectedIndexChanged += new System.EventHandler(this.RecipeSelectCombo_SelectedIndexChanged);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(99, 133);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(71, 23);
            this.EditButton.TabIndex = 2;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // NewFolderButton
            // 
            this.NewFolderButton.Location = new System.Drawing.Point(12, 76);
            this.NewFolderButton.Name = "NewFolderButton";
            this.NewFolderButton.Size = new System.Drawing.Size(75, 23);
            this.NewFolderButton.TabIndex = 4;
            this.NewFolderButton.Text = "New Folder";
            this.NewFolderButton.UseVisualStyleBackColor = true;
            this.NewFolderButton.Click += new System.EventHandler(this.NewFolderButton_Click);
            // 
            // NewRecipeButton
            // 
            this.NewRecipeButton.Location = new System.Drawing.Point(12, 133);
            this.NewRecipeButton.Name = "NewRecipeButton";
            this.NewRecipeButton.Size = new System.Drawing.Size(75, 23);
            this.NewRecipeButton.TabIndex = 15;
            this.NewRecipeButton.Text = "New";
            this.NewRecipeButton.UseVisualStyleBackColor = true;
            this.NewRecipeButton.Click += new System.EventHandler(this.NewRecipeButton_Click);
            // 
            // FolderSelectCombo
            // 
            this.FolderSelectCombo.FormattingEnabled = true;
            this.FolderSelectCombo.Location = new System.Drawing.Point(12, 49);
            this.FolderSelectCombo.Name = "FolderSelectCombo";
            this.FolderSelectCombo.Size = new System.Drawing.Size(158, 21);
            this.FolderSelectCombo.TabIndex = 16;
            this.FolderSelectCombo.Text = "Folder Select";
            this.FolderSelectCombo.DropDown += new System.EventHandler(this.FolderSelectCombo_DropDown);
            this.FolderSelectCombo.SelectedIndexChanged += new System.EventHandler(this.FolderSelectCombo_SelectedIndexChanged);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusStripInfoLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 428);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(800, 22);
            this.StatusStrip.TabIndex = 17;
            // 
            // StatusStripInfoLabel
            // 
            this.StatusStripInfoLabel.Name = "StatusStripInfoLabel";
            this.StatusStripInfoLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // DeleteFolderButton
            // 
            this.DeleteFolderButton.Location = new System.Drawing.Point(99, 76);
            this.DeleteFolderButton.Name = "DeleteFolderButton";
            this.DeleteFolderButton.Size = new System.Drawing.Size(71, 23);
            this.DeleteFolderButton.TabIndex = 18;
            this.DeleteFolderButton.Text = "Delete";
            this.DeleteFolderButton.UseVisualStyleBackColor = true;
            this.DeleteFolderButton.Click += new System.EventHandler(this.DeleteFolderButton_Click);
            // 
            // DeleteRecipeButton
            // 
            this.DeleteRecipeButton.Location = new System.Drawing.Point(12, 162);
            this.DeleteRecipeButton.Name = "DeleteRecipeButton";
            this.DeleteRecipeButton.Size = new System.Drawing.Size(158, 23);
            this.DeleteRecipeButton.TabIndex = 19;
            this.DeleteRecipeButton.Text = "Delete";
            this.DeleteRecipeButton.UseVisualStyleBackColor = true;
            this.DeleteRecipeButton.Click += new System.EventHandler(this.DeleteRecipeButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(12, 23);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(158, 20);
            this.SearchTextBox.TabIndex = 20;
            this.SearchTextBox.Click += new System.EventHandler(this.SearchTextBox_Click);
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Search Recipes";
            // 
            // AdvancedSearchButton
            // 
            this.AdvancedSearchButton.Location = new System.Drawing.Point(29, 248);
            this.AdvancedSearchButton.Name = "AdvancedSearchButton";
            this.AdvancedSearchButton.Size = new System.Drawing.Size(110, 23);
            this.AdvancedSearchButton.TabIndex = 22;
            this.AdvancedSearchButton.Text = "Advanced Search";
            this.AdvancedSearchButton.UseVisualStyleBackColor = true;
            this.AdvancedSearchButton.Click += new System.EventHandler(this.AdvancedSearchButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AdvancedSearchButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.DeleteRecipeButton);
            this.Controls.Add(this.DeleteFolderButton);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.FolderSelectCombo);
            this.Controls.Add(this.NewRecipeButton);
            this.Controls.Add(this.NewFolderButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.RecipeSelectCombo);
            this.Controls.Add(this.RecipeDisplayText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Recipe Box";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RecipeDisplayText;
        private System.Windows.Forms.ComboBox RecipeSelectCombo;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button NewFolderButton;
        private System.Windows.Forms.Button NewRecipeButton;
        private System.Windows.Forms.ComboBox FolderSelectCombo;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusStripInfoLabel;
        private System.Windows.Forms.Button DeleteFolderButton;
        private System.Windows.Forms.Button DeleteRecipeButton;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AdvancedSearchButton;
    }
}

