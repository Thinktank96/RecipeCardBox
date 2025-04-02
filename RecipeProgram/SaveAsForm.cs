using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace RecipeProgram
{
    public partial class SaveAsForm : Form
    {
        public SaveAsForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (NameBox.TextLength != 0)
            {
                Recipe recipe = Program.activeRecipe;

                // since we never changed the original name, we can check to make sure the user isn't over-writing the original, 
                // even if they changed it in the recipe editor text field.
                if (NameBox.Text != recipe.name) 
                {
                    recipe.SetName(NameBox.Text); // This is the only thing we are changing in this form.
                }


                try
                {
                    // It's not saving right now for some reason.
                    Program.reader.WriteRecipe(recipe);
                    Program.mainForm.StatusStripInfoLabel_ShowMessage("Changes saved...");

                    NameBox.Clear();
                }
                catch (Exception ee)
                {
                    Program.mainForm.StatusStripInfoLabel_ShowMessage(ee.Message); // now I can do this! :D
                    //MessageBox.Show(ee.Message);
                }
                Program.mainForm.RecipeDisplayText_ShowMessage(recipe.ToString());
                this.Close();
            }
        }

        private void NewFolderButton_Click(object sender, EventArgs e)
        {
            NewFolderForm newFolderForm = new NewFolderForm();
            newFolderForm.ShowDialog();
        }

        private void FolderSelectCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // I thought about reverting the active folder to the original after hitting save, 
            // but seeing how I send the new file back to the Recipe display, I think that would make it more confusing.
            string dirName = (string)FolderSelectCombo.SelectedItem;
            Program.folders.TryGetValue(dirName, out Program.activeDirectory);
        }

        private void FolderSelectCombo_DropDown(object sender, EventArgs e)
        {
            // I'm leaving in the rescanning of the folders because I gave the user the option to make a new folder for the new recipe so I need to update the list.
            FolderSelectCombo.Items.Clear();
            Program.folders = Program.reader.LoadDirectories(Program.rootDirectory.FullName);
            foreach (var folder in Program.folders)
            {
                if (!FolderSelectCombo.Items.Contains(folder))
                {
                    FolderSelectCombo.Items.Add(folder.Key);
                }
            }
        }
    }
}
