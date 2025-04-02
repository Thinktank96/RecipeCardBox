using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RecipeProgram
{//had to make recipe class public because of the recipe editor constructor.
    public class Recipe
    {
        public string DEFAULT_FILEPATH = "unnamed_recipe";
        public string DEFAULT_NAME = "Unnamed Recipe";
        public string DEFAULT_INSTRUCTIONS = "No instructions provided.";
        public string DEFAULT_FILE_TEXT = @"Name: [ ]

Tags: [ ]

Ingredients:
[ ] 

Instructions: 
[]";

        public string filePath { get; set; } 
        public string name { get; private set; }
        public List<string> tags { get; private set; }
        //public List<string> ingredients { get; private set; }
        public List<Ingredient> ingredients { get; private set; }
        public string instructions { get; private set; }

        public Recipe(string FILE, string NAME, List<string> TAGS, List<string> INGREDIENTS, string INSTRUCTIONS)
        {
            filePath = FILE;
            name = NAME;
            tags = TAGS;
            ingredients = new List<Ingredient>();
            foreach (string i in INGREDIENTS)
            {
                try
                {
                    ingredients.Add(ToIngredient(i));
                }
                catch(Exception e)
                {
                    MessageBox.Show(NAME + ": " + e.Message);
                }
            }
            instructions = INSTRUCTIONS;
        }
        public Recipe(string FILE, string NAME, List<string> TAGS, List<string> INGREDIENTS)
        {
            filePath = FILE;
            name = NAME;
            tags = TAGS;
            ingredients = new List<Ingredient>();
            foreach (string i in INGREDIENTS)
            {
                try
                {
                    ingredients.Add(ToIngredient(i));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            instructions = DEFAULT_INSTRUCTIONS;
        }
        public Recipe(string FILE, string NAME, List<string> INGREDIENTS, string INSTRUCTIONS)
        {
            filePath = FILE;
            name = NAME;
            tags = new List<string>();
            ingredients = new List<Ingredient>();
            foreach (string i in INGREDIENTS)
            {
                try
                {
                    ingredients.Add(ToIngredient(i));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            instructions = INSTRUCTIONS;
        }
        public Recipe(string FILE, List<string> TAGS, List<string> INGREDIENTS, string INSTRUCTIONS)
        {
            filePath = FILE;
            name = DEFAULT_NAME;
            tags = TAGS;
            ingredients = new List<Ingredient>();
            foreach (string i in INGREDIENTS)
            {
                try
                {
                    ingredients.Add(ToIngredient(i));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            instructions = INSTRUCTIONS;
        }

        public Recipe(string FILE, string NAME, List<string> INGREDIENTS)
        {
            filePath = FILE;
            name = NAME;
            tags = new List<string>();
            ingredients = new List<Ingredient>();
            foreach (string i in INGREDIENTS)
            {
                try
                {
                    ingredients.Add(ToIngredient(i));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            instructions = DEFAULT_INSTRUCTIONS;
        }
        public Recipe(string FILE, List<string> INGREDIENTS)
        {
            filePath = FILE;
            name = DEFAULT_NAME;
            tags = new List<string>();
            ingredients = new List<Ingredient>();
            foreach (string i in INGREDIENTS)
            {
                try
                {
                    ingredients.Add(ToIngredient(i));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            instructions = DEFAULT_INSTRUCTIONS;
        }
        public Recipe()
        {
            filePath = DEFAULT_FILEPATH;
            name = DEFAULT_NAME;
            tags = new List<string>();
            ingredients = new List<Ingredient>();
            instructions = DEFAULT_INSTRUCTIONS;
        }

        public void SetName(string n)
        {
            name = n;
        }
        public void SetTags(List<string> t)
        {
            tags = t;
        }
        public void AddTag(string t)
        {
            // if tag text contains brackets already, don't add any, if it doesn't have any, add them.
            tags.Add((t.Contains("[") && t.Contains("]") ? t : "[" + t + "]"));
        }

        public void RemoveTag(int t) // I'm using index just on the off chance there are multiples of an ingredient and you wanted a specific one removed.
        {
            tags.RemoveAt(t);
        }
        // Just some more options
        public void RemoveTag(string t)
        {
            tags.Remove((t.Contains("[") && t.Contains("]") ? t : "[" + t + "]"));
        }

        public void SetIngredients(List<Ingredient> i)
        {
            ingredients = i;
        }

        public void AddIngredient(Ingredient i)
        {
            ingredients.Add(i);
        }

        public void RemoveIngredient(Ingredient i)
        {
            ingredients.Remove(i);
        }

        public void SetInstruction(string i)
        {
            instructions = i;
        }

        public override string ToString()
        {
            // I spent all this time figuring out literal string interpolation and I forgot why I needed it to not just read from the file. 
            return ($@"Name: [{name}]

Tags: [{String.Join(", ", tags)}]

Ingredients:
[{String.Join("\n", ingredients)}] 

Instructions: 
[{instructions}]");
        }

        public string NameToFileName()
        {
            Regex safeChars = new Regex(@"(\B\W)*");
            return ("recipe_" + (safeChars.Replace(name, String.Empty)).Replace(" ", "_").ToLower() + ".txt");
        }

        public Ingredient ToIngredient(string i)
        {

            string quantityPattern = @"^\s*\d*\s*(?:\d*\/\d*)*"; // that little asterisk on the end is very important, it allows for that subexpression to not be present and still catch the digits
            var quantityMatch = Regex.Match(i, quantityPattern);
            string quantityValue = "NAN";

            string measurementPattern = @"\w*(\.+)";
            var measurementMatch = Regex.Match(i, measurementPattern);
            string measurementValue = String.Empty;

            string fullName;

            if (quantityMatch.Success)
            {
                quantityValue = quantityMatch.Value;
                i = Regex.Replace(i, quantityPattern, String.Empty); // turns out I never needed a delegate, for some reason I just complained the first time.
            }

            if (measurementMatch.Success)
            {
                measurementValue = measurementMatch.Value;
                i = Regex.Replace(i, measurementPattern, String.Empty);
            }

            fullName = i.Trim(); // now that we've removed the quantity and measurement values, we can just send anything left to the 'name' field of ingredient, with trimming just in case.

            Ingredient ingredient = new Ingredient(quantityValue, measurementValue, fullName);
            return ingredient;

        }

    }
}
