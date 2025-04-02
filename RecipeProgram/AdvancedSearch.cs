using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeProgram
{
    public partial class AdvancedSearch : Form
    {
        List<CheckBox> selections;
        List<Recipe> recipes = new List<Recipe>();
        List<string> tags = new List<string>();
        List<string> includedTags = new List<string>();
        List<string> excludedTags = new List<string>();
        public AdvancedSearch()
        {
            InitializeComponent();
            //TestCheckListBox();
            //TestListBox();
            //TestFlowLayout();
            //selections = FetchSelections(); // this should only be called when you hit the search button.
            //selections[0].CheckState;
            foreach (Recipe recipe in Program.recipes.Values)
            {
                //recipes.Add(recipe);
                foreach (string tag in recipe.tags)
                {
                    if (!tags.Contains(tag))
                    {
                        tags.Add(tag);
                    }
                }

            }
            PopulateFlowLayout();
        }


        public void TestFlowLayout()
        {
            for (int i = 0; i < 100; i++)
            {
                CheckBox chck = new CheckBox();
                chck.ThreeState = true;
                chck.Text = "test " + i;

                flowLayoutPanel1.Controls.Add(chck);
            }
        }
        public void PopulateFlowLayout()
        {
            foreach (string tag in tags)
            {
                CheckBox chck = new CheckBox();
                chck.ThreeState = true;
                chck.Text = tag;

                flowLayoutPanel1.Controls.Add(chck);
            }
        }

        private List<string> GetList(CheckState theState)
        {
            var theList = new List<string>();

            foreach (var item in flowLayoutPanel1.Controls)
            {
                if (item is CheckBox)
                {
                    CheckBox cb = (CheckBox)item;

                    if (cb.CheckState == theState)
                        theList.Add(cb.Text);
                }
            }

            return (theList);
        }

        public List<string> GetIncluded()
        {
            return (GetList(CheckState.Checked));
        }

        public List<string> GetExcluded()
        {
            return (GetList(CheckState.Indeterminate));
        }


        public List<CheckBox> FetchSelections()
        {
            List<CheckBox> chcks = new List<CheckBox>();
            foreach (CheckBox chck in chcks)
            {
                chcks.Add(chck);
            }
            return chcks;
        }

        private void IncludeAllButton_Click(object sender, EventArgs e)
        {
            foreach (CheckBox box in flowLayoutPanel1.Controls)
            {
                box.CheckState = CheckState.Checked;
            }
        }

        private void DeselectAllButton_Click(object sender, EventArgs e)
        {
            foreach (CheckBox box in flowLayoutPanel1.Controls)
            {
                box.CheckState = CheckState.Unchecked;
            }
        }

        private void ExcludeAllButton_Click(object sender, EventArgs e)
        {
            foreach (CheckBox box in flowLayoutPanel1.Controls)
            {
                box.CheckState = CheckState.Indeterminate;
            }
        }

#if false
        private void SearchButton_Click(object sender, EventArgs e)
        {
            Program.mainForm.UpdateSearchResults(recipes);
            foreach(Recipe recipe in Program.recipes.Values)
            {
                foreach (string goodTag in includedTags)
                {
                    foreach(string badtag in excludedTags)
                    {
                        if (recipe.tags.Contains(goodTag) && recipe.tags.Contains(badtag))
                        {
                            continue;
                        }
                        recipes.Add(recipe);
                    }
                }
                //for (int i = 0, j = 0; i < includedTags.Count && j < excludedTags.Count; i++, j++)
                //{
                //    if (recipe.tags.Contains(includedTags[i]) && !recipe.tags.Contains(excludedTags[j]))
                //    {
                //        recipes.Add(recipe);
                //    }
                //}
            }
            Program.mainForm.UpdateSearchResults(recipes);
        }
#endif

        private void SearchButton_Click(object sender, EventArgs e)
        {
            var iList = GetIncluded();
            var eList = GetExcluded();

            recipes.Clear();
            Program.mainForm.UpdateSearchResults(recipes);

            foreach (Recipe recipe in Program.recipes.Values)
            {
                // Must include all tags from 'iList' and none from 'eList'

                bool foundAll = true;

                foreach (string goodTag in iList)
                {
                    if (!recipe.tags.Contains(goodTag))
                    {
                        foundAll = false;
                        break;
                    }
                }

                if (foundAll)
                {
                    bool missingAll = true;

                    foreach (string badTag in eList)
                    {
                        if (recipe.tags.Contains(badTag))
                        {
                            missingAll = false;
                            break;
                        }
                    }

                    if (missingAll)
                    {
                        recipes.Add(recipe);
                    }
                }
            }

            Program.mainForm.UpdateSearchResults(recipes);
            AdvancedSearchResultsListBox.Items.Clear();
            foreach(Recipe recipe in recipes)
            {
                AdvancedSearchResultsListBox.Items.Add(recipe);
            }

        }

        private void AdvancedSearchResultsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.mainForm.DisplayRecipe((Recipe)AdvancedSearchResultsListBox.SelectedItem);
            Program.mainForm.Activate();
        }
    }
}


