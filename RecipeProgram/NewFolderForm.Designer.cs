namespace RecipeProgram
{
    partial class NewFolderForm
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
            this.FolderNameBox = new System.Windows.Forms.TextBox();
            this.CreateFolderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FolderNameBox
            // 
            this.FolderNameBox.Location = new System.Drawing.Point(12, 12);
            this.FolderNameBox.Name = "FolderNameBox";
            this.FolderNameBox.Size = new System.Drawing.Size(382, 20);
            this.FolderNameBox.TabIndex = 0;
            this.FolderNameBox.TextChanged += new System.EventHandler(this.FolderNameBox_TextChanged);
            this.FolderNameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FolderNameBox_KeyPress);
            // 
            // CreateFolderButton
            // 
            this.CreateFolderButton.Location = new System.Drawing.Point(12, 38);
            this.CreateFolderButton.Name = "CreateFolderButton";
            this.CreateFolderButton.Size = new System.Drawing.Size(382, 23);
            this.CreateFolderButton.TabIndex = 1;
            this.CreateFolderButton.Text = "Create Folder";
            this.CreateFolderButton.UseVisualStyleBackColor = true;
            this.CreateFolderButton.Click += new System.EventHandler(this.CreateFolderButton_Click);
            this.CreateFolderButton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CreateFolderButton_KeyPress);
            // 
            // NewFolderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 71);
            this.Controls.Add(this.CreateFolderButton);
            this.Controls.Add(this.FolderNameBox);
            this.Name = "NewFolderForm";
            this.Text = "Create New Folder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FolderNameBox;
        private System.Windows.Forms.Button CreateFolderButton;
    }
}