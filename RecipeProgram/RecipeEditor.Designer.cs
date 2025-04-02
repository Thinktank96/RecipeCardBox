namespace RecipeProgram
{
    partial class RecipeEditor
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
            this.SaveAsRecipeButton = new System.Windows.Forms.Button();
            this.IngredientRemoveButton = new System.Windows.Forms.Button();
            this.IngredientInputButton = new System.Windows.Forms.Button();
            this.TagAddButton = new System.Windows.Forms.Button();
            this.TagInputTextBox = new System.Windows.Forms.TextBox();
            this.TagRemoveButton = new System.Windows.Forms.Button();
            this.InstructionsBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LabelName = new System.Windows.Forms.Label();
            this.LabelIngredients = new System.Windows.Forms.Label();
            this.LabelTags = new System.Windows.Forms.Label();
            this.LabelInstructions = new System.Windows.Forms.Label();
            this.IngredientListBox = new System.Windows.Forms.ListBox();
            this.FolderSelectCombo = new System.Windows.Forms.ComboBox();
            this.NewFolderButton = new System.Windows.Forms.Button();
            this.TagListBox = new System.Windows.Forms.ListBox();
            this.QuantityTextBox = new System.Windows.Forms.TextBox();
            this.IngredientNameTextBox = new System.Windows.Forms.TextBox();
            this.QuantityLabel = new System.Windows.Forms.Label();
            this.MeasurementLabel = new System.Windows.Forms.Label();
            this.IngredientNameLabel = new System.Windows.Forms.Label();
            this.ClearIngredientSelectionButton = new System.Windows.Forms.Button();
            this.HalfMeasureButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ThirdQuantityButton = new System.Windows.Forms.Button();
            this.TripleQuantityButton = new System.Windows.Forms.Button();
            this.MeasurementComboBox = new System.Windows.Forms.ComboBox();
            this.AutoConvertCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // SaveAsRecipeButton
            // 
            this.SaveAsRecipeButton.Location = new System.Drawing.Point(632, 39);
            this.SaveAsRecipeButton.Name = "SaveAsRecipeButton";
            this.SaveAsRecipeButton.Size = new System.Drawing.Size(68, 23);
            this.SaveAsRecipeButton.TabIndex = 8;
            this.SaveAsRecipeButton.Text = "Save as";
            this.SaveAsRecipeButton.UseVisualStyleBackColor = true;
            this.SaveAsRecipeButton.Click += new System.EventHandler(this.SaveAsRecipeButton_Click);
            // 
            // IngredientRemoveButton
            // 
            this.IngredientRemoveButton.Location = new System.Drawing.Point(249, 380);
            this.IngredientRemoveButton.Name = "IngredientRemoveButton";
            this.IngredientRemoveButton.Size = new System.Drawing.Size(23, 23);
            this.IngredientRemoveButton.TabIndex = 26;
            this.IngredientRemoveButton.Text = "-";
            this.IngredientRemoveButton.UseVisualStyleBackColor = true;
            this.IngredientRemoveButton.Click += new System.EventHandler(this.IngredientRemoveButton_Click);
            // 
            // IngredientInputButton
            // 
            this.IngredientInputButton.Location = new System.Drawing.Point(220, 380);
            this.IngredientInputButton.Name = "IngredientInputButton";
            this.IngredientInputButton.Size = new System.Drawing.Size(23, 23);
            this.IngredientInputButton.TabIndex = 24;
            this.IngredientInputButton.Text = "+";
            this.IngredientInputButton.UseVisualStyleBackColor = true;
            this.IngredientInputButton.Click += new System.EventHandler(this.IngredientInputButton_Click);
            // 
            // TagAddButton
            // 
            this.TagAddButton.Location = new System.Drawing.Point(381, 380);
            this.TagAddButton.Name = "TagAddButton";
            this.TagAddButton.Size = new System.Drawing.Size(23, 23);
            this.TagAddButton.TabIndex = 23;
            this.TagAddButton.Text = "+";
            this.TagAddButton.UseVisualStyleBackColor = true;
            this.TagAddButton.Click += new System.EventHandler(this.TagAddButton_Click);
            // 
            // TagInputTextBox
            // 
            this.TagInputTextBox.Location = new System.Drawing.Point(278, 354);
            this.TagInputTextBox.Name = "TagInputTextBox";
            this.TagInputTextBox.Size = new System.Drawing.Size(157, 20);
            this.TagInputTextBox.TabIndex = 3;
            this.TagInputTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TagInputTextBox_KeyPress);
            // 
            // TagRemoveButton
            // 
            this.TagRemoveButton.Location = new System.Drawing.Point(410, 380);
            this.TagRemoveButton.Name = "TagRemoveButton";
            this.TagRemoveButton.Size = new System.Drawing.Size(23, 23);
            this.TagRemoveButton.TabIndex = 21;
            this.TagRemoveButton.Text = "-";
            this.TagRemoveButton.UseVisualStyleBackColor = true;
            this.TagRemoveButton.Click += new System.EventHandler(this.TagRemoveButton_Click);
            // 
            // InstructionsBox
            // 
            this.InstructionsBox.Location = new System.Drawing.Point(441, 111);
            this.InstructionsBox.Multiline = true;
            this.InstructionsBox.Name = "InstructionsBox";
            this.InstructionsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InstructionsBox.Size = new System.Drawing.Size(258, 238);
            this.InstructionsBox.TabIndex = 4;
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(12, 42);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(423, 20);
            this.NameBox.TabIndex = 5;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(543, 39);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(71, 23);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(12, 13);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(35, 13);
            this.LabelName.TabIndex = 28;
            this.LabelName.Text = "Name";
            // 
            // LabelIngredients
            // 
            this.LabelIngredients.AutoSize = true;
            this.LabelIngredients.Location = new System.Drawing.Point(12, 95);
            this.LabelIngredients.Name = "LabelIngredients";
            this.LabelIngredients.Size = new System.Drawing.Size(59, 13);
            this.LabelIngredients.TabIndex = 29;
            this.LabelIngredients.Text = "Ingredients";
            // 
            // LabelTags
            // 
            this.LabelTags.AutoSize = true;
            this.LabelTags.Location = new System.Drawing.Point(275, 95);
            this.LabelTags.Name = "LabelTags";
            this.LabelTags.Size = new System.Drawing.Size(31, 13);
            this.LabelTags.TabIndex = 30;
            this.LabelTags.Text = "Tags";
            // 
            // LabelInstructions
            // 
            this.LabelInstructions.AutoSize = true;
            this.LabelInstructions.Location = new System.Drawing.Point(438, 95);
            this.LabelInstructions.Name = "LabelInstructions";
            this.LabelInstructions.Size = new System.Drawing.Size(61, 13);
            this.LabelInstructions.TabIndex = 31;
            this.LabelInstructions.Text = "Instructions";
            // 
            // IngredientListBox
            // 
            this.IngredientListBox.FormattingEnabled = true;
            this.IngredientListBox.Location = new System.Drawing.Point(12, 111);
            this.IngredientListBox.Name = "IngredientListBox";
            this.IngredientListBox.Size = new System.Drawing.Size(260, 212);
            this.IngredientListBox.TabIndex = 32;
            this.IngredientListBox.SelectedIndexChanged += new System.EventHandler(this.IngredientListBox_SelectedIndexChanged);
            // 
            // FolderSelectCombo
            // 
            this.FolderSelectCombo.FormattingEnabled = true;
            this.FolderSelectCombo.Location = new System.Drawing.Point(12, 68);
            this.FolderSelectCombo.Name = "FolderSelectCombo";
            this.FolderSelectCombo.Size = new System.Drawing.Size(343, 21);
            this.FolderSelectCombo.TabIndex = 6;
            this.FolderSelectCombo.Text = "Folder Select";
            this.FolderSelectCombo.DropDown += new System.EventHandler(this.FolderSelectCombo_DropDown);
            this.FolderSelectCombo.SelectedIndexChanged += new System.EventHandler(this.FolderSelectCombo_SelectedIndexChanged);
            // 
            // NewFolderButton
            // 
            this.NewFolderButton.Location = new System.Drawing.Point(361, 66);
            this.NewFolderButton.Name = "NewFolderButton";
            this.NewFolderButton.Size = new System.Drawing.Size(74, 23);
            this.NewFolderButton.TabIndex = 33;
            this.NewFolderButton.Text = "New Folder";
            this.NewFolderButton.UseVisualStyleBackColor = true;
            this.NewFolderButton.Click += new System.EventHandler(this.NewFolderButton_Click);
            // 
            // TagListBox
            // 
            this.TagListBox.FormattingEnabled = true;
            this.TagListBox.Location = new System.Drawing.Point(278, 111);
            this.TagListBox.Name = "TagListBox";
            this.TagListBox.Size = new System.Drawing.Size(155, 238);
            this.TagListBox.TabIndex = 35;
            // 
            // QuantityTextBox
            // 
            this.QuantityTextBox.Location = new System.Drawing.Point(12, 354);
            this.QuantityTextBox.Name = "QuantityTextBox";
            this.QuantityTextBox.Size = new System.Drawing.Size(59, 20);
            this.QuantityTextBox.TabIndex = 0;
            // 
            // IngredientNameTextBox
            // 
            this.IngredientNameTextBox.Location = new System.Drawing.Point(142, 354);
            this.IngredientNameTextBox.Name = "IngredientNameTextBox";
            this.IngredientNameTextBox.Size = new System.Drawing.Size(130, 20);
            this.IngredientNameTextBox.TabIndex = 2;
            this.IngredientNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IngredientNameTextBox_KeyPress);
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.AutoSize = true;
            this.QuantityLabel.Location = new System.Drawing.Point(12, 336);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(46, 13);
            this.QuantityLabel.TabIndex = 39;
            this.QuantityLabel.Text = "Quantity";
            // 
            // MeasurementLabel
            // 
            this.MeasurementLabel.AutoSize = true;
            this.MeasurementLabel.Location = new System.Drawing.Point(77, 338);
            this.MeasurementLabel.Name = "MeasurementLabel";
            this.MeasurementLabel.Size = new System.Drawing.Size(71, 13);
            this.MeasurementLabel.TabIndex = 40;
            this.MeasurementLabel.Text = "Measurement";
            // 
            // IngredientNameLabel
            // 
            this.IngredientNameLabel.AutoSize = true;
            this.IngredientNameLabel.Location = new System.Drawing.Point(154, 339);
            this.IngredientNameLabel.Name = "IngredientNameLabel";
            this.IngredientNameLabel.Size = new System.Drawing.Size(85, 13);
            this.IngredientNameLabel.TabIndex = 41;
            this.IngredientNameLabel.Text = "Ingredient Name";
            // 
            // ClearIngredientSelectionButton
            // 
            this.ClearIngredientSelectionButton.Location = new System.Drawing.Point(211, 90);
            this.ClearIngredientSelectionButton.Name = "ClearIngredientSelectionButton";
            this.ClearIngredientSelectionButton.Size = new System.Drawing.Size(61, 23);
            this.ClearIngredientSelectionButton.TabIndex = 42;
            this.ClearIngredientSelectionButton.Text = "De-select";
            this.ClearIngredientSelectionButton.UseVisualStyleBackColor = true;
            this.ClearIngredientSelectionButton.Click += new System.EventHandler(this.ClearIngredientSelectionButton_Click);
            // 
            // HalfMeasureButton
            // 
            this.HalfMeasureButton.Location = new System.Drawing.Point(12, 380);
            this.HalfMeasureButton.Name = "HalfMeasureButton";
            this.HalfMeasureButton.Size = new System.Drawing.Size(32, 23);
            this.HalfMeasureButton.TabIndex = 43;
            this.HalfMeasureButton.Text = "1/2";
            this.HalfMeasureButton.UseVisualStyleBackColor = true;
            this.HalfMeasureButton.Click += new System.EventHandler(this.HalfQuantityButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(50, 380);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 23);
            this.button3.TabIndex = 44;
            this.button3.Text = "x2";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.DoubleQuantityButton_Click);
            // 
            // ThirdQuantityButton
            // 
            this.ThirdQuantityButton.Location = new System.Drawing.Point(88, 380);
            this.ThirdQuantityButton.Name = "ThirdQuantityButton";
            this.ThirdQuantityButton.Size = new System.Drawing.Size(32, 23);
            this.ThirdQuantityButton.TabIndex = 45;
            this.ThirdQuantityButton.Text = "1/3";
            this.ThirdQuantityButton.UseVisualStyleBackColor = true;
            this.ThirdQuantityButton.Click += new System.EventHandler(this.ThirdQuantityButton_Click);
            // 
            // TripleQuantityButton
            // 
            this.TripleQuantityButton.Location = new System.Drawing.Point(126, 380);
            this.TripleQuantityButton.Name = "TripleQuantityButton";
            this.TripleQuantityButton.Size = new System.Drawing.Size(32, 23);
            this.TripleQuantityButton.TabIndex = 46;
            this.TripleQuantityButton.Text = "x3";
            this.TripleQuantityButton.UseVisualStyleBackColor = true;
            this.TripleQuantityButton.Click += new System.EventHandler(this.TripleQuantityButton_Click);
            // 
            // MeasurementComboBox
            // 
            this.MeasurementComboBox.FormattingEnabled = true;
            this.MeasurementComboBox.Location = new System.Drawing.Point(78, 353);
            this.MeasurementComboBox.Name = "MeasurementComboBox";
            this.MeasurementComboBox.Size = new System.Drawing.Size(58, 21);
            this.MeasurementComboBox.TabIndex = 1;
            // 
            // AutoConvertCheckBox
            // 
            this.AutoConvertCheckBox.AutoSize = true;
            this.AutoConvertCheckBox.Checked = true;
            this.AutoConvertCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoConvertCheckBox.Location = new System.Drawing.Point(125, 94);
            this.AutoConvertCheckBox.Name = "AutoConvertCheckBox";
            this.AutoConvertCheckBox.Size = new System.Drawing.Size(88, 17);
            this.AutoConvertCheckBox.TabIndex = 47;
            this.AutoConvertCheckBox.Text = "Auto-Convert";
            this.AutoConvertCheckBox.UseVisualStyleBackColor = true;
            this.AutoConvertCheckBox.CheckedChanged += new System.EventHandler(this.AutoConvertCheckBox_CheckedChanged);
            // 
            // RecipeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 410);
            this.Controls.Add(this.AutoConvertCheckBox);
            this.Controls.Add(this.MeasurementComboBox);
            this.Controls.Add(this.TripleQuantityButton);
            this.Controls.Add(this.ThirdQuantityButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.HalfMeasureButton);
            this.Controls.Add(this.ClearIngredientSelectionButton);
            this.Controls.Add(this.IngredientNameLabel);
            this.Controls.Add(this.MeasurementLabel);
            this.Controls.Add(this.QuantityLabel);
            this.Controls.Add(this.IngredientNameTextBox);
            this.Controls.Add(this.QuantityTextBox);
            this.Controls.Add(this.TagListBox);
            this.Controls.Add(this.FolderSelectCombo);
            this.Controls.Add(this.NewFolderButton);
            this.Controls.Add(this.IngredientListBox);
            this.Controls.Add(this.LabelInstructions);
            this.Controls.Add(this.LabelTags);
            this.Controls.Add(this.LabelIngredients);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.SaveAsRecipeButton);
            this.Controls.Add(this.IngredientRemoveButton);
            this.Controls.Add(this.IngredientInputButton);
            this.Controls.Add(this.TagAddButton);
            this.Controls.Add(this.TagInputTextBox);
            this.Controls.Add(this.TagRemoveButton);
            this.Controls.Add(this.InstructionsBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.SaveButton);
            this.Name = "RecipeEditor";
            this.Text = "RecipeEditor";
            this.Load += new System.EventHandler(this.RecipeEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveAsRecipeButton;
        private System.Windows.Forms.Button IngredientRemoveButton;
        private System.Windows.Forms.Button IngredientInputButton;
        private System.Windows.Forms.Button TagAddButton;
        private System.Windows.Forms.TextBox TagInputTextBox;
        private System.Windows.Forms.Button TagRemoveButton;
        private System.Windows.Forms.TextBox InstructionsBox;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.Label LabelIngredients;
        private System.Windows.Forms.Label LabelTags;
        private System.Windows.Forms.Label LabelInstructions;
        private System.Windows.Forms.ListBox IngredientListBox;
        private System.Windows.Forms.ComboBox FolderSelectCombo;
        private System.Windows.Forms.Button NewFolderButton;
        private System.Windows.Forms.ListBox TagListBox;
        private System.Windows.Forms.TextBox QuantityTextBox;
        private System.Windows.Forms.TextBox IngredientNameTextBox;
        private System.Windows.Forms.Label QuantityLabel;
        private System.Windows.Forms.Label MeasurementLabel;
        private System.Windows.Forms.Label IngredientNameLabel;
        private System.Windows.Forms.Button ClearIngredientSelectionButton;
        private System.Windows.Forms.Button HalfMeasureButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button ThirdQuantityButton;
        private System.Windows.Forms.Button TripleQuantityButton;
        private System.Windows.Forms.ComboBox MeasurementComboBox;
        private System.Windows.Forms.CheckBox AutoConvertCheckBox;
    }
}