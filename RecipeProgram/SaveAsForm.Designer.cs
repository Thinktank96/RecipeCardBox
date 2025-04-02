namespace RecipeProgram
{
    partial class SaveAsForm
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
            this.FolderSelectCombo = new System.Windows.Forms.ComboBox();
            this.NewFolderButton = new System.Windows.Forms.Button();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FolderSelectCombo
            // 
            this.FolderSelectCombo.FormattingEnabled = true;
            this.FolderSelectCombo.Location = new System.Drawing.Point(12, 55);
            this.FolderSelectCombo.Name = "FolderSelectCombo";
            this.FolderSelectCombo.Size = new System.Drawing.Size(161, 21);
            this.FolderSelectCombo.TabIndex = 18;
            this.FolderSelectCombo.Text = "Folder Select";
            this.FolderSelectCombo.DropDown += new System.EventHandler(this.FolderSelectCombo_DropDown);
            this.FolderSelectCombo.SelectedIndexChanged += new System.EventHandler(this.FolderSelectCombo_SelectedIndexChanged);
            // 
            // NewFolderButton
            // 
            this.NewFolderButton.Location = new System.Drawing.Point(179, 53);
            this.NewFolderButton.Name = "NewFolderButton";
            this.NewFolderButton.Size = new System.Drawing.Size(74, 23);
            this.NewFolderButton.TabIndex = 17;
            this.NewFolderButton.Text = "New Folder";
            this.NewFolderButton.UseVisualStyleBackColor = true;
            this.NewFolderButton.Click += new System.EventHandler(this.NewFolderButton_Click);
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(12, 29);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(241, 20);
            this.NameBox.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "New recipe name";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(12, 82);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(241, 23);
            this.SaveButton.TabIndex = 21;
            this.SaveButton.Text = "Save as";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SaveAsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 120);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.FolderSelectCombo);
            this.Controls.Add(this.NewFolderButton);
            this.Name = "SaveAsForm";
            this.Text = "SaveAsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FolderSelectCombo;
        private System.Windows.Forms.Button NewFolderButton;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveButton;
    }
}