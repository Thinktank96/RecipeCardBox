using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace RecipeProgram
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            StatusStripInfoLabel_ShowMessage("Hello :)");

            foreach (var folder in Program.folders)
            {
                if (!FolderSelectCombo.Items.Contains(folder))
                {
                    FolderSelectCombo.Items.Add(folder.Key);
                }
            }

            EditButton.Enabled = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown)
                return;

            DialogResult result = MessageBox.Show(
               "Are you sure you want to quit?",
               "Quit - Confirm",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else
            {
                // do any cleanup here.
            }
        }

        // When the user makes a recipe selection in the recipe combo box,
        // we store the name of the item as a string so we can search a dictionary
        // containing the contents of the current directory. We then send the recipe object
        // to the Program class by way of 'activeRecipe' so we can access it's functions globally.
        // We also update the various editing text boxes with copies of the data.
        private void RecipeSelectCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Recipe recipe;
            Program.recipes.TryGetValue((string)RecipeSelectCombo.SelectedItem, out recipe);
            DisplayRecipe(recipe);
        }


        // The function below is in use, but not necessary, though it may be of use later.
        private void NewFolderButton_Click(object sender, EventArgs e)
        {
            NewFolderForm newFolderForm = new NewFolderForm();
            newFolderForm.ShowDialog();
        }


        // The two functions below are more placeholders than anything, you can disregard them.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //RecipeDisplayText.Text = NameBox.Text;
        }

        private void IngredientBox_TextChanged(object sender, EventArgs e)
        {

        }


        // If the user wants to create a new recipe, this function will 
        // create a new recipe object and populate only the edting boxes with
        // it's contents, allowing the user to fill out the fields as they want.
        private void NewRecipeButton_Click(object sender, EventArgs e)
        {
            Program.activeRecipe = new Recipe();
            //Recipe recipe = Program.activeRecipe;

            RecipeEditor recipeEditor = new RecipeEditor(Program.activeRecipe, true);
            recipeEditor.ShowDialog();

            DirectoryInfo directory = Program.activeDirectory;
            Program.recipes.Clear();
            RecipeSelectCombo.Items.Clear();
            Program.recipes = Program.reader.LoadRecipes(directory.FullName);
            foreach (var recipe in Program.recipes)
            {
                if (!RecipeSelectCombo.Items.Contains(recipe))
                {
                    RecipeSelectCombo.Items.Add(recipe.Key);
                }
            }
            //foreach (KeyValuePair<string, Recipe> recipe in Program.recipes)
            //{
            //    if (!RecipeSelectCombo.Items.Contains(recipe.Value))
            //    {
            //        RecipeSelectCombo.Items.Add(recipe.Value);
            //    }
            //}
        }


        // In order to view recipes, a user must first select a folder.
        // This function reads the dictionary of folders, matching it
        // to the name of the selected item in the combobox and them loads
        // the recipes from that folder into their own dictionary for use
        // in another combobox, making sure to clear it out in the event of
        // a changed folder.
        private void FolderSelectCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dirName = (string)FolderSelectCombo.SelectedItem;
            Program.folders.TryGetValue(dirName, out Program.activeDirectory);
            DirectoryInfo directory = Program.activeDirectory;
            Program.recipes.Clear();
            RecipeSelectCombo.Items.Clear();
            Program.recipes = Program.reader.LoadRecipes(directory.FullName);
            foreach (var recipe in Program.recipes)
            {
                if (!RecipeSelectCombo.Items.Contains(recipe))
                {
                    RecipeSelectCombo.Items.Add(recipe.Key);
                }
            }
            StatusStripInfoLabel.Text = RecipeSelectCombo.Items.Count + " recipes loaded.";
        }

        // We update the list of folders when we click the drop down, in the event the user added one.
        private void FolderSelectCombo_DropDown(object sender, EventArgs e)
        {
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

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            RecipeEditor recipeEditor = new RecipeEditor(Program.activeRecipe, false);
            recipeEditor.ShowDialog();
        }


        // PUBLICLY AVAILABLE FUNCTIONS
        //==============================================
        //Now we can call this function from any other class and can use it to display error messages or status messages.
        //I may switch this functionality to a little message bar later.
        public void RecipeDisplayText_ShowMessage(string message)
        {
            RecipeDisplayText.Text = message;
        }

        public void StatusStripInfoLabel_ShowMessage(string message)
        {
            StatusStripInfoLabel.Text = message;
        }

        private void LoadRecipes()
        {

        }

        public void UpdateSearchResults(List<Recipe> recipes)
        {
            if (recipes.Count > 0)
            {
                RecipeSelectCombo.Items.Clear();
                //RecipeSelectCombo.Items.AddRange(recipes.ToArray());
                var names = new List<string>();

                foreach (var entry in recipes)
                    names.Add(entry.name);

                RecipeSelectCombo.Items.AddRange(names.ToArray());

                StatusStripInfoLabel.Text = "Search returned " + RecipeSelectCombo.Items.Count + " recipes.";
            }
            else
            {
                RecipeSelectCombo.Items.Clear();
                // consider placing this snippet in a function so it can be called from the two places it's used instead.
                foreach (var recipe in Program.recipes)
                {
                    if (!RecipeSelectCombo.Items.Contains(recipe))
                    {
                        RecipeSelectCombo.Items.Add(recipe.Key);
                    }
                }
                StatusStripInfoLabel.Text = RecipeSelectCombo.Items.Count + " recipes loaded.";
            }
        }

        public void DisplayRecipe(Recipe recipe)
        {
            Program.recipes.TryGetValue(recipe.name, out Program.activeRecipe);

            RecipeDisplayText.Text = recipe.ToString();
            EditButton.Enabled = true;
        }

        //==============================================

        private void DeleteFolderButton_Click(object sender, EventArgs e)
        {
            if(Program.activeDirectory.Name != RecipeReader.ALL_DIR) // this isn't the name
            {
                //GET THE HELL OUTTA HERE!
                
                Program.activeDirectory.Delete(true);

                FolderSelectCombo.Text = "All Recipes";

                //reset active directory to all.
                Program.folders.TryGetValue(Program.reader.allDirectory, out Program.activeDirectory);
            }
            else
            {
                MessageBox.Show("You a big dummy! You can't delete that!");
            }
        }

        private void DeleteRecipeButton_Click(object sender, EventArgs e)
        {
            // Not gonna do anything with this yet, I'll need a more robust way to tell if there is an active recipe or not for disabling the edit button.
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            List<Recipe> recipeMatches = new List<Recipe>();
            //if (SearchTextBox.TextLength > 0)
            //{
            //    RecipeSelectCombo.Items.Clear();
            //    foreach (var recipe in Program.recipes)
            //    {
            //        if (recipe.Key.ToLower().Contains(SearchTextBox.Text)) // cast the keys to lowercase so we don't have to so specific.
            //        {
            //            RecipeSelectCombo.Items.Add(recipe.Key);
            //        }
            //    }
            //    StatusStripInfoLabel.Text = "Search returned " + RecipeSelectCombo.Items.Count + " recipes."; 
            //}
            if (SearchTextBox.TextLength > 0)
            {
                    RecipeSelectCombo.Items.Clear();
                    foreach (Recipe recipe in Program.recipes.Values)
                    {
                        if (recipe.name.ToLower().Contains(SearchTextBox.Text)) // cast the keys to lowercase so we don't have to so specific.
                        {
                            recipeMatches.Add(recipe);
                        }
                    }
                    UpdateSearchResults(recipeMatches);
                    //StatusStripInfoLabel.Text = "Search returned " + RecipeSelectCombo.Items.Count + " recipes.";
            }
            else
            {
                RecipeSelectCombo.Items.Clear();
                // consider placing this snippet in a function so it can be called from the two places it's used instead.
                foreach (var recipe in Program.recipes)
                {
                    if (!RecipeSelectCombo.Items.Contains(recipe))
                    {
                        RecipeSelectCombo.Items.Add(recipe.Key);
                    }
                }
                StatusStripInfoLabel.Text = RecipeSelectCombo.Items.Count + " recipes loaded.";
            }
        }

        private void SearchTextBox_Click(object sender, EventArgs e)
        {
            RecipeSelectCombo.Items.Clear();
            //RecipeSelectCombo.SelectedItem = String.Empty;
            RecipeSelectCombo.Text = String.Empty;
            RecipeDisplayText.Clear();
        }

        private void AdvancedSearchButton_Click(object sender, EventArgs e)
        {
            AdvancedSearch advancedSearch = new AdvancedSearch();
            advancedSearch.Show();
        }
    }
}
