using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace RecipeProgram
{
    class RecipeReader
    {
        public string rootDirectory { get; private set; }
        public string allDirectory { get; private set; }

        // I moved this to Program.cs, it's more accessible there.
        //public FileInfo activeFile { get; private set; }
        //public DirectoryInfo activeDirectory { get; private set; }

        public const string ALL_DIR = "_all";
        public RecipeReader()
        {
            // I'm omitting, but not removing this for now.
            //rootDirectory = Program.ROOT_DIR_PATH; 
            rootDirectory = @"recipes\"; // this way the recipes can always be read from wherever they are located, instead of absolute paths.
            allDirectory = rootDirectory + ALL_DIR + @"\"; 
        }
        public RecipeReader(string ROOT)
        {
            rootDirectory = ROOT;
            allDirectory = rootDirectory + ALL_DIR + @"\";
        }

        // Because of how we load the recipes, I'm going to store each link as a separate text within the target folder.
        public Dictionary<string, Recipe> LoadRecipes(string dir)
        {
            Dictionary<string, Recipe> recipes = new Dictionary<string, Recipe>();
            DirectoryInfo d = new DirectoryInfo(dir);

            foreach(var file in d.GetFiles("*.txt"))
            {
                if (d.Name == ALL_DIR)
                {
                    Recipe r = ReadRecipe(file, true);
                    try
                    {
                        recipes.Add(r.name, r);
                    }
                    catch
                    {
                        MessageBox.Show("The actual recipe file itself cannot be read.");
                    }
                }
                else
                {
                    Recipe r = ReadRecipe(file);
                    try
                    {
                        recipes.Add(r.name, r); // this was still making the process stop so I told the IDE to stop breaking on it and let my own code handle it, might be necessary for testers too.
                    }
                    catch
                    {
                        MessageBox.Show("Recipe returned null because the program couldn't find the linked file.");
                    }
                }


            }

            return recipes;
        }

        public Dictionary<string, DirectoryInfo> LoadDirectories(string dirPath)
        {
            Dictionary<string, DirectoryInfo> dirs = new Dictionary<string, DirectoryInfo>();
            DirectoryInfo rootDir = new DirectoryInfo(dirPath);

            // we create the all recipe directory if it doesn't exist;
            if (rootDir.GetDirectories(ALL_DIR).Length == 0)
            {
                Program.rootDirectory.CreateSubdirectory(ALL_DIR);
            }

            foreach(var dir in rootDir.GetDirectories("*"))
            {   
                if(dir.Name == ALL_DIR)
                {
                    dirs.Add("All Recipes", dir);
                }
                else
                {
                    dirs.Add(dir.Name, dir);
                }

            }
            return dirs;
        }

        public Dictionary<string, Recipe> LoadRecipes()
        {
            return LoadRecipes(rootDirectory);
        }

        public Dictionary<string, DirectoryInfo> LoadDirectories()
        {
            return LoadDirectories(rootDirectory);
        }

        public Recipe ReadRecipe(FileInfo file, bool isOriginal = false) // I'm going to assume we're not trying to read the original files because most of the time we aren't
        {
            string name = string.Empty;
            List<string> tags = new List<string>();
            List<string> ingredients = new List<string>();
            string instructions = string.Empty;

            string content;

            try
            {
                string path;

                // If we have flagged this file as not the original file, then we read the text from the link file and save it as path
                // otherwise, we just get the full path to the file and save it to path. the contents are read in the same way regardless.
                if (!isOriginal)
                {
                    path = File.ReadAllText(file.FullName); // I'm putting too much faith in this, I'll update this with Regex to scan for specifically what I want later.

                }
                else
                {
                    path = file.FullName.ToString();
                }

                content = File.ReadAllText(path);

                string namePattern = @"(?<=\w*Name:\s*\[)([^\]]*)[^\]]";
                Match nameMatch = Regex.Match(content, namePattern);

                if (nameMatch.Success)
                {
                    name = nameMatch.Value;
                }
                else
                {
                    name = "No name found";
                }

                string tagPattern = @"(?<=\w*Tags:\s*\[)([^\.]*)(?<=\]*)[$\]](?=])";
                Match tagMatch = Regex.Match(content, tagPattern);

                if (tagMatch.Success)
                {
                    tags = Regex.Split(tagMatch.Value, ", ").ToList();
                }

                string ingredientPattern = @"(?<=\w*Ingredients:\s*\r\n\[)[^\]]*[^\]]";
                Match ingredientMatch = Regex.Match(content, ingredientPattern);

                if (ingredientMatch.Success)
                {
                    ingredients = Regex.Split(ingredientMatch.Value, @"\n").ToList();
                }
                else
                {
                    //ingredients.Add("The Void");
                }

                string instructionsPattern = @"(?<=\w*Instructions:\s*\r\n\[)[^\]]*[^\]]";
                Match instructionsMatch = Regex.Match(content, instructionsPattern);

                if (instructionsMatch.Success)
                {
                    instructions = instructionsMatch.Value;
                }

            }
            catch
            {
                //throw new IOException("File could not be read.");
                if (!isOriginal)
                {
                    File.Delete(file.FullName); // remove the now useless link file that links to a nonexistant file.
                }

                //MessageBox.Show("File could not be read, the Original file may be missing."); // we'll handle this error when it's called instead.
                return null; // I'm not sure this is a wise solution to keep the program from halting if it can't read a file but it's what I'm going with now.
            }

            Recipe recipe = new Recipe(file.FullName.ToString(), name, tags, ingredients, instructions);
            return recipe;
        }


        public void WriteRecipe(Recipe recipe, bool inFolder = false)
        {
            //will need to account for renaming of recipe, could cause confusion.
            if (recipe.filePath == recipe.DEFAULT_FILEPATH && recipe.name != recipe.DEFAULT_NAME)
            {
                recipe.filePath = (allDirectory + recipe.NameToFileName());
                File.WriteAllText(recipe.filePath, recipe.ToString());
                if (Program.activeDirectory.Name != ALL_DIR)
                {
                    MakeLink(Program.activeDirectory, allDirectory, recipe.NameToFileName());
                }

                return; // breaking out of function because filename isn't working right,and we don't need to parse 
            }
            else if (recipe.filePath == recipe.DEFAULT_FILEPATH && recipe.name == recipe.DEFAULT_FILEPATH)
            {
                //hrow new MissingFieldException("Cannot save file, missing filename. please give the recipe a name first.");
                Program.mainForm.StatusStripInfoLabel_ShowMessage("Cannot save file, missing filename. please give the recipe a name first.");
            }

            //string content;

            try
            {
                /*
                content = File.ReadAllText(recipe.filePath);

                string namePattern = @"(?<=\w*Name:\s*\[)([^\]]*)[^\]]";
                Match nameMatch = Regex.Match(content, namePattern);

                if (nameMatch.Success)
                {
                    content = content.Remove(nameMatch.Index, nameMatch.Length );
                    content = content.Insert(nameMatch.Index, recipe.name);
                }

                string tagPattern = @"(?<=\w*Tags:\s*\[)([^\.]*)(?<=\]*)[^\]]]";
                Match tagMatch = Regex.Match(content, tagPattern);

                if (tagMatch.Success)
                {
                    content = content.Remove(tagMatch.Index, tagMatch.Length);
                    content = content.Insert(tagMatch.Index, String.Join(", ", recipe.tags));
                }

                string ingredientPattern = @"(?<=\w*Ingredients:\s*\r\n\[)[^\]]*[^\]]";
                Match ingredientMatch = Regex.Match(content, ingredientPattern);

                if (ingredientMatch.Success)
                {
                    content = content.Remove(ingredientMatch.Index, ingredientMatch.Length);
                    content = content.Insert(ingredientMatch.Index, String.Join("\n", recipe.ingredients));
                }

                string instructionsPattern = @"(?<=\w*Instructions:\s*\r\n\[)[^\]]*[^\]]";
                Match instructionsMatch = Regex.Match(content, instructionsPattern);

                if (ingredientMatch.Success)
                {
                    content = content.Remove(instructionsMatch.Index, instructionsMatch.Length);
                    content = content.Insert(instructionsMatch.Index, recipe.instructions);
                }

                // We always write the data itself to the main folder where all the recipes are actually stored.
                File.WriteAllText(recipe.filePath, content);

                // if the active directory isn't the same as that main folder, we make a file containing a link and place it in the active directory.
                if (Program.activeDirectory.Name != ALL_DIR)
                {
                    MakeLink(Program.activeDirectory, allDirectory, recipe.NameToFileName());
                }*/

                // We always write the data itself to the main folder where all the recipes are actually stored.
                // I made this always update the filename to whatever the name of the file has been changed to.
                // aside from allowing for renaming of files, it also allows us to save a copy of a file under a different name.
                recipe.filePath = (allDirectory + recipe.NameToFileName()); 
                File.WriteAllText(recipe.filePath, recipe.ToString());

                // if the active directory isn't the same as that main folder, we make a file containing a link and place it in the active directory.
                if (Program.activeDirectory.Name != ALL_DIR)
                {
                    MakeLink(Program.activeDirectory, allDirectory, recipe.NameToFileName());
                }
            }
            catch(Exception e)
            {
                //MessageBox.Show(e.Message);
                //MessageBox.Show(recipe.filePath);
                //throw new IOException(recipe.filePath + " could not write file.");
                Program.mainForm.StatusStripInfoLabel_ShowMessage("Could not write to " + recipe.filePath);
            }
        }

        public void MakeLink(DirectoryInfo dir, string path, string fileName)
        {
            // We take the active directory information, the full path to the original file, and the filename of the original file.
            // then we write a file and fill it with a filepath for use in opening the original file.
            File.WriteAllText(dir.FullName + @"\"+ fileName, path + fileName);
        }

    }
}
