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

namespace RecipeProgram
{
    public partial class RecipeEditor : Form
    {
        public RecipeEditor()
        {
            InitializeComponent();
        }
        public RecipeEditor(Recipe recipe, bool isNew)
        {
            InitializeComponent();

            NameBox.Text = recipe.name;
            foreach(Unit unit in Program.measurements)
            {
                MeasurementComboBox.Items.Add(unit.Name);
            }
            //MeasurementComboBox.Items.AddRange(Program.measurements); // bring in our list of measurements, this is likely eventually be read in from a file, but not here.
            //TagBox.Text = String.Join(", ", recipe.tags);
            foreach(string tag in recipe.tags)
            {
                TagListBox.Items.Add(tag);
            }
            //IngredientBox.Text = String.Join("\n", recipe.ingredients);
            foreach(Ingredient ingredient in recipe.ingredients)
            {
                IngredientListBox.Items.Add(ingredient); // this might need to be cast as a string, and then dealt with later when it comes to adding it.
            }
            InstructionsBox.Text = recipe.instructions;

            if (isNew)
            {
                SaveAsRecipeButton.Enabled = false;
            }
        }

        //private void RecipeEditor_Load(object sender, EventArgs e, string recipeName)
        //{
        //    Program.recipes.TryGetValue(recipeName, out Program.activeRecipe);
        //    Recipe recipe = Program.activeRecipe;
        //    NameBox.Text = recipe.name;
        //    TagBox.Text = String.Join(", ", recipe.tags);
        //    IngredientBox.Text = String.Join("\n", recipe.ingredients);
        //    InstructionsBox.Text = recipe.instructions;
        //}

        // I need an overloaded version of this function so the designer.cs file won't complain. it just intilizes the window with a blank recipe file.
        private void RecipeEditor_Load(object sender, EventArgs e)
        {
            //Recipe recipe = new Recipe();
            //NameBox.Text = recipe.name;
            //TagBox.Text = String.Join(", ", recipe.tags);
            //IngredientBox.Text = String.Join("\n", recipe.ingredients);
            //InstructionsBox.Text = recipe.instructions;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (NameBox.TextLength != 0)
            {
                Recipe recipe = Program.activeRecipe;

                recipe.SetName(NameBox.Text);
                //recipe.SetTags(new List<string>(Regex.Split(TagBox.Text, ", ")).ToList<string>());
                //recipe.SetIngredients(ObjColToList(TagListBox.Items)); // previous version
                recipe.SetTags(new List<string>(TagListBox.Items.Cast<string>())); // I don't remember figuring this out
                //recipe.SetIngredients(new List<string>(Regex.Split(IngredientBox.Text, "\n")).ToList<string>());
                //recipe.SetIngredients(ObjColToList(IngredientListBox.Items)); // I thought listboxes used lists...like in the name, but they don't, so I wrote that function.
                recipe.SetIngredients(new List<Ingredient>(IngredientListBox.Items.Cast<Ingredient>())); // but it let's me eliminate a custom function I wrote so there's that.
                recipe.SetInstruction(InstructionsBox.Text);
                try
                {
                    Program.reader.WriteRecipe(recipe);
                    Program.mainForm.StatusStripInfoLabel_ShowMessage("Changes saved...");

                    NameBox.Clear();
                    //TagBox.Clear();
                    //IngredientBox.Clear();
                    InstructionsBox.Clear();
                }
                catch (Exception ee)
                {
                    Program.mainForm.StatusStripInfoLabel_ShowMessage(ee.Message); // now I can do this! :D
                    //MessageBox.Show(ee.Message);
                }
                Program.mainForm.RecipeDisplayText_ShowMessage(recipe.ToString());
                this.FindForm().Hide();
            }
        }

        private void IngredientInputButton_Click(object sender, EventArgs e)
        {
            AddIngredient();
        }

        private void IngredientRemoveButton_Click(object sender, EventArgs e)
        {
            //string recipeName = (string)RecipeSelectCombo.SelectedItem;
            //Recipe recipe = Program.activeRecipe;

            //Program.activeRecipe.RemoveIngredient(IngredientInputBox.Text);
            try
            {
                Program.activeRecipe.RemoveIngredient((Ingredient)IngredientListBox.SelectedItem);
                IngredientListBox.Items.Remove(IngredientListBox.SelectedItem);
                //IngredientBox.Text = String.Join("\r\n", Program.activeRecipe.ingredients);
            }
            catch
            {
                MessageBox.Show("No ingredient selected, please select an ingredient before attempting to remove one.");
            }

        }

        private void TagAddButton_Click(object sender, EventArgs e)
        {
            AddTag();
        }

        private void TagRemoveButton_Click(object sender, EventArgs e)
        {
            //string recipeName = (string)RecipeSelectCombo.SelectedItem;
            //Recipe recipe;
            //Program.recipes.TryGetValue(recipeName, out recipe);
            try
            {
                Program.activeRecipe.RemoveTag((string)TagListBox.SelectedItem);
                TagListBox.Items.Remove(TagListBox.SelectedItem);
            }
            catch
            {
                MessageBox.Show("No ingredient selected, please select an ingredient before attempting to remove one.");
            }

            //TagBox.Text = String.Join(", ", Program.activeRecipe.tags);
        }

        private void SaveAsRecipeButton_Click(object sender, EventArgs e)
        {
            Recipe recipe = Program.activeRecipe;

            //recipe.SetName(NameBox.Text);
            //recipe.SetTags(new List<string>(Regex.Split(TagBox.Text, ", ")).ToList<string>());
            recipe.SetTags(new List<string>(TagListBox.Items.Cast<string>()));
            //recipe.SetIngredients(new List<string>(Regex.Split(IngredientBox.Text, "\n")).ToList<string>());
            // I have to use my own function to convert Ingredient types because Linq won't take them.
            //recipe.SetIngredients(ObjColToList(IngredientListBox.Items));
            // apparently past me thought I couldn't do this with linq, but current me, not knowing I thought it impossible, did it with linq.
            recipe.SetIngredients(new List<Ingredient>(IngredientListBox.Items.Cast<Ingredient>())); 
            recipe.SetInstruction(InstructionsBox.Text);

            SaveAsForm saveAsForm = new SaveAsForm();
            saveAsForm.ShowDialog();
            this.FindForm().Hide();

        }

        private void NewFolderButton_Click(object sender, EventArgs e)
        {
            NewFolderForm newFolderForm = new NewFolderForm();
            newFolderForm.ShowDialog();
        }

        private void FolderSelectCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dirName = (string)FolderSelectCombo.SelectedItem;
            Program.folders.TryGetValue(dirName, out Program.activeDirectory);
        }

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

        //why did I need to do this???????????
        //private List<string> ObjColToList(System.Windows.Forms.ListBox.ObjectCollection objCol)
        //{
        //    List<string> list = new List<string>();
        //    foreach(string s in objCol)
        //    {
        //        list.Add(s);
        //    }
        //    return list;
        //}

        //private List<string> ObjColToList(System.Windows.Forms.ListBox.ObjectCollection objCol)
        //{
        //    List<string> list = new List<string>();
        //    foreach (object o in objCol)
        //    {
        //        list.Add(o.ToString()); // this should allow me to store my objects as whatever and retrieve their values using ToString()
        //    }
        //    return list;
        //}

        private List<Ingredient> ObjColToList(System.Windows.Forms.ListBox.ObjectCollection objCol)
        {
            List<Ingredient> list = new List<Ingredient>();
            foreach (object o in objCol)
            {
                list.Add((Ingredient) o);
            }
            return list;
        }

        private void TagInputTextBox_KeyPress(object sender, KeyPressEventArgs e) 
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (!String.IsNullOrEmpty(TagInputTextBox.Text) && !Program.activeRecipe.tags.Contains(TagInputTextBox.Text))
                {
                    AddTag();
                }
                TagInputTextBox.Clear();
                e.Handled = true;
            }
        }

        // This will be removed and the functionality placed in a unifying function.
        private void IngredientInputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Return)
            //{
            //    if (!String.IsNullOrEmpty(IngredientInputBox.Text) && !Program.activeRecipe.ingredients.Contains(IngredientInputBox.Text))
            //    {
            //        Program.activeRecipe.AddIngredient(IngredientInputBox.Text);
            //        IngredientListBox.Items.Add(IngredientInputBox.Text);
            //    }
            //    IngredientInputBox.Clear();
            //    e.Handled = true;
            //}
        }

        private void IngredientListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // can't cast it, I thought it stored the object but apparantly it doesn't, there's a way to do it, but I'm tired.
            try
            {
                
                Program.activeIngredient = (Ingredient) IngredientListBox.SelectedItem;
                QuantityTextBox.Text = Program.activeIngredient.quantity;
                //MeasurementTextBox.Text = Program.activeIngredient.measurement; // I'll need to make this change the dropdown option to match.
                if (MeasurementComboBox.Items.Contains(Program.activeIngredient.measurement))
                {
                    MeasurementComboBox.Text = Program.activeIngredient.measurement;
                }
                IngredientNameTextBox.Text = Program.activeIngredient.name;
            }
            catch
            {
                //MessageBox.Show(IngredientListBox.SelectedItem.GetType().ToString());
                //MessageBox.Show(IngredientListBox.SelectedItem.ToString());
            }
        }

        private void IngredientInputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClearIngredientSelectionButton_Click(object sender, EventArgs e)
        {
            IngredientListBox.ClearSelected();
            //QuantityTextBox.Clear();
            //MeasurementTextBox.Clear();
            //IngredientNameTextBox.Clear();
        }

        private void DoubleQuantityButton_Click(object sender, EventArgs e)
        {
            DoOperateOnQuantity(2.0);
        }

        private void HalfQuantityButton_Click(object sender, EventArgs e)
        {
            DoOperateOnQuantity(.5);
        }

        private void ThirdQuantityButton_Click(object sender, EventArgs e)
        {
            double num = (1.0 / 3.0);
            DoOperateOnQuantity(num);
        }

        private void TripleQuantityButton_Click(object sender, EventArgs e)
        {
            DoOperateOnQuantity(3.0);
        }

        private void IngredientNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                AddIngredient();
                e.Handled = true;
            }
        }

        public void AddIngredient()
        {
            if (!String.IsNullOrEmpty(QuantityTextBox.Text) && !String.IsNullOrEmpty(MeasurementComboBox.Text) && !String.IsNullOrEmpty(IngredientNameTextBox.Text) && MeasurementComboBox.Items.Contains(MeasurementComboBox.Text))
            {
                //Program.activeIngredient = new Ingredient(QuantityTextBox.Text, MeasurementTextBox.Text, IngredientNameTextBox.Text);
                Program.activeIngredient = new Ingredient(QuantityTextBox.Text, (string)MeasurementComboBox.Text, IngredientNameTextBox.Text);

                //might need to make this not use toString()
                if (!Program.activeRecipe.ingredients.Contains(Program.activeIngredient))
                {
                    // So fun fact, when you call this function, it just uses the ToString() function for the object to display text, if there is an override, it will use that
                    // It would be nice if it said that somewhere, but I am glad I added an override to this.
                    IngredientListBox.Items.Add(Program.activeIngredient);
                    QuantityTextBox.Clear();
                    MeasurementComboBox.Text = String.Empty;
                    MeasurementComboBox.SelectedItem = null;
                    IngredientNameTextBox.Clear();
                    IngredientListBox.SelectedItem = null;
                }
                else if (!Program.activeRecipe.ingredients.Contains(Program.activeIngredient) && IngredientListBox.SelectedItem != Program.activeIngredient)
                {
                    int index = IngredientListBox.SelectedIndex;
                    IngredientListBox.Items.Insert(IngredientListBox.SelectedIndex, Program.activeIngredient);
                    IngredientListBox.Items.RemoveAt(IngredientListBox.SelectedIndex);
                    IngredientListBox.SelectedIndex = index;
                    QuantityTextBox.Clear();
                    IngredientNameTextBox.Clear();
                    IngredientListBox.SelectedItem = null;
                }
                else if (Program.activeRecipe.ingredients.Contains(Program.activeIngredient) && IngredientListBox.SelectedItem == Program.activeIngredient)
                {
                    IngredientListBox.SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("You already added that ingredient! If you want to increase the amount or change a measurement, select it from the list.");
                }
            }
            else if (!String.IsNullOrEmpty(QuantityTextBox.Text) && String.IsNullOrEmpty(MeasurementComboBox.Text) && !String.IsNullOrEmpty(IngredientNameTextBox.Text) && MeasurementComboBox.Items.Contains(MeasurementComboBox.Text)) // might not need this contain check
            {
                Program.activeIngredient = new Ingredient(QuantityTextBox.Text, string.Empty, IngredientNameTextBox.Text);


                //might need to make this not use toString()
                if (!Program.activeRecipe.ingredients.Contains(Program.activeIngredient) && IngredientListBox.SelectedItem == null)
                {
                    IngredientListBox.Items.Add(Program.activeIngredient);
                    QuantityTextBox.Clear();
                    IngredientNameTextBox.Clear();
                    IngredientListBox.SelectedItem = null;
                }
                else if (!Program.activeRecipe.ingredients.Contains(Program.activeIngredient) && IngredientListBox.SelectedItem != Program.activeIngredient)
                {
                    int index = IngredientListBox.SelectedIndex;
                    IngredientListBox.Items.Insert(IngredientListBox.SelectedIndex, Program.activeIngredient);
                    IngredientListBox.Items.RemoveAt(IngredientListBox.SelectedIndex);
                    IngredientListBox.SelectedIndex = index;
                    QuantityTextBox.Clear();
                    IngredientNameTextBox.Clear();
                    IngredientListBox.SelectedItem = null;
                }
                else if (Program.activeRecipe.ingredients.Contains(Program.activeIngredient) && IngredientListBox.SelectedItem == Program.activeIngredient)
                {
                    IngredientListBox.SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("You already added that ingredient! If you want to increase the amount or change a measurement, select it from the list.");
                }
            }
            else if (!MeasurementComboBox.Items.Contains(MeasurementComboBox.Text))
            {
                MessageBox.Show(MeasurementComboBox.Text + " is not contained in the list of measurements, please try selecting one instead.");
            }
            else
            {
                MessageBox.Show("You must fill out at least the quantity and name fields before trying to add an ingredient!");
            }
        }

        public void AddTag()
        {
            //recipe recipe = Program.activeRecipe;
            TagInputTextBox.Text = TagInputTextBox.Text.ToLower().Trim();
            TagInputTextBox.Text = TagInputTextBox.Text.Replace("[", string.Empty); // \0 is the unicode null char, because there it's a Char.empty.
            TagInputTextBox.Text = TagInputTextBox.Text.Replace("]", string.Empty);
            TagInputTextBox.Text = "[" + TagInputTextBox.Text + "]";
            //TagInputTextBox.Text = (TagInputTextBox.Text.Contains("[") && TagInputTextBox.Text.Contains("]") ? TagInputTextBox.Text : "[" + TagInputTextBox.Text + "]");
            if (!String.IsNullOrEmpty(TagInputTextBox.Text) && !Program.activeRecipe.tags.Contains(TagInputTextBox.Text))
            {
                Program.activeRecipe.AddTag(TagInputTextBox.Text);
                // I'm just taking the code from recipe's addtag function, it's ultimately more efficient than grabbing the list of tags and refreshing the list box.
                TagListBox.Items.Add(TagInputTextBox.Text);
                TagInputTextBox.Clear();
            }
            else
            {
                MessageBox.Show("You cannot have duplicate tags.");
                TagInputTextBox.Clear();
            }
            //add another strip info label to the editor so we can gently notify the user they are dumb.
        }

        public void DoOperateOnQuantity(double multiplier)
        {
            if (IngredientListBox.SelectedItem != null && IngredientListBox.SelectedItem == Program.activeIngredient)
            {
                string fraction = Program.activeIngredient.OperateOnQuantity(Program.activeIngredient.quantity, multiplier);
                int index = IngredientListBox.SelectedIndex;
                Program.activeIngredient.SetQuantity(fraction);

                if (AutoConvertCheckBox.Checked)
                {
                    Ingredient.ConvertMeasurement(
                            Program.measurements,
                            (int)Program.activeIngredient.ToDrops(
                                Program.measurements,
                                Program.activeIngredient.ParseFraction(
                                    Program.activeIngredient.quantity
                                ),
                                Program.activeIngredient.measurement
                            ),
                            ref Program.activeIngredient
                    );
                }
                IngredientListBox.Items.Insert(IngredientListBox.SelectedIndex, Program.activeIngredient);
                IngredientListBox.Items.RemoveAt(IngredientListBox.SelectedIndex);
                IngredientListBox.SelectedIndex = index;
                QuantityTextBox.Text = fraction;
            }
            else if (IngredientListBox.SelectedItem == null)
            {
                ListBox tmp = new ListBox();

                for(int i = 0; i < IngredientListBox.Items.Count; i++)
                {
                    Ingredient tempIngredient = (Ingredient)IngredientListBox.Items[i]; // This is necessary becuase it won't let me access the item and it's functions without assigning it.
                    string fraction = tempIngredient.OperateOnQuantity(tempIngredient.quantity, multiplier);
                    tempIngredient.SetQuantity(fraction);

                    //IngredientListBox.SelectedIndex = i;

                    if (AutoConvertCheckBox.Checked)
                    {
                        Ingredient.ConvertMeasurement(
                            Program.measurements,
                            (int)tempIngredient.ToDrops(
                                Program.measurements,
                                tempIngredient.ParseFraction(
                                    tempIngredient.quantity
                                ),
                                tempIngredient.measurement
                            ),
                            ref tempIngredient
                        );
                    }

                    //IngredientListBox.SelectedItem = tempIngredient; // just assigning the selected item to temp to make sure all my bases are covered

                    tmp.Items.Add(tempIngredient);
                }

                IngredientListBox.Items.Clear();

                foreach (Ingredient item in tmp.Items)
                {
                    IngredientListBox.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("No Recipe Selected or quantity entered");
            }
        }

        private void AutoConvertCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoConvertCheckBox.Checked)
            {
                DoOperateOnQuantity(1); // just a quick and dirty way to auto convert measurements if the box was previously unchecked, using a pre-existing function.
            }
        }
    }
}
