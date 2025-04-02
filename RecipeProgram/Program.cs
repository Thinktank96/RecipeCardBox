#define INDEV

/* This is by far the biggest project I have included in this portfolio, and I will be up front and say that it is not complete.
 * 
 * It was conceived as a project for showing off what I could do, and it still does that very well.
 * 
 * I moved on from this as I got bored of it, and began working on other projects, but intended to come back and finish it before I started looking for a job
 * I apologize for the largely uncommented and less than perfect state of this software, but it still shows off my skills and approach to problem solving very well I think.
 * 
 * I'll summarize the functionality of the program here, and if whoever is reading this would like more clarification, I would be happy to, the best of my recollection, 
 * go over and explain in detail anything you might have questions about.
 * 
 * So without further ado:
 *------------------------
 *About this software
 *------------------------
 *
 * This program, obstenibly named "Recipe Box" was envisioned as a sort of proof-of-concept for what a program that lets you store
 * your recipes digitally, as easy to read and access .txt files that you can email to people, and edit using the software, but does't
 * require the software to do either.
 * 
 * The idea is that you would manually transcribe your recipe cards using the interface of this software, which formats it as a person would,
 * making it very simple to just email the file to yourself, or others, for storage in a cloud storage of some sort (I actually have used this for that purpose personally)
 * 
 * I originally intended this to have email functionality, but stopped work on the project before implementing it, though I do intend to resume work and eventually
 * include that feature.
 *
 *
 *------------------------
 *How this software works
 *------------------------
 *
 * You may be asking yourself, "How do I use this software?"
 * Well it's ideally, quite simple.
 * 
 * After starting the program, you are presented with several options.
 * You can either create a new recipe, which will be covered later, or:
 *     1. open existing ones.
 *        I've included a handful of real recipes that you can access by first clicking the drop down labeled "Folder Select".
 *        
 *        From there, you can select folders pertaining to different types of recipes like Desserts or Breakfast, etc.
 *        
 *        I recommend selecting "All Recipes" and going from there but you can poke around any of them as you wish.
 *        
 *        Now that you have selected a fold, you can select a specific recipe to view from the "Recipe Select" dropdown.
 *        
 *        Upon selecting a recipe from the list, it will now be displayed in the panel to right.
 *        
 *        You might have noticed the two separate search options located at the top and middle-ish area to the left of the recipe panel.
 *        The one of the top will let you search for recipes based purely on their names, while the "advanced search will let you search by
 *        tags, which you can assign to each recipe. The standard search is straigh-forward enough, so I will only explain how to use the 
 *        "Advanced search" option.
 *        
 *        Once you have clicked the button, a window will appear with all the tags present in all the recipes in the current folder you have selected,
 *        this is why I recommend selecting the "All Recipes" folder.
 *        
 *        From here you can click once on a tag to set it as desired, and it will return any recipe with that tag.
 *        
 *        If you select more than one tag it will only return recipes with both of those tags, not all recipes with either.
 *        
 *        If you click an already selected tag again, it will now exclude any recipe that contains those tags, indicated by a black square instead of a checkmark.
 *        This also works so that if you want specific recipes that contain, dairy, for instance, but not eggs, you can allow dairy but block eggs and it will bring
 *        up only the recipes that include dairy but not eggs.
 *        
 *    2. Creating and Editing Recipes.
 *        If you want to edit a recipe that you have open, you can select the edit button, which will bring up a new window.
 *        
 *        Here you are presented with a cadre of options for changing every bit of the recipe. 
 *        
 *        First, you can change the name, of the recipe, not super exciting but it's important.
 *        
 *        Next, if you want to add the recipe to another folder, or to one in the first place, simply click the drop down or slick the new folder button
 *        and save your changes to add the recipe to the specified folder, it now is contained in that folder, as well as any others you might have added it to 
 *        (these are not duplicates, they are links to the master file)
 *        
 *        Moving down from there, we have the "Auto-convert" option, I recommend leaving this on, as it allows the program to correctly change measurements
 *        if you double, half, or otherwise change the amount of required ingredients later.
 *        
 *        below that, you have the ingredients, and at the bottom, you have the fields pertaining to them, namely "Quantity", "Measurement", and "Ingredient Name"
 *        these fields allow you to enter the amount, measurment, and name/short description of the ingredient.
 *        once you have filled each field out (with the expection of measurement, if you have something like "1 egg") you can hit the plus button to add
 *        that ingredient to the list. At the moment, there is no way to edit an ingredient on the list, but if you select one, you can make a new entry with the changed information
 *        and then delete the old one. I must have forgotten to add that functionality because I don't think it would be hard.
 *        
 *        Finally, we have the coolest part of this whole thing, you can hit the buttons that pertain to what amount you want to change the measurements of the ingredients.
 *        for instance, if you want to half the batch, or double it, you can hit the appropriate button, and it will perform the operation on all the ingredients, even changing
 *        their measurement designation appropriately (though sometimes when halfing or thirding an amount it will display an odd fractional amount on account of the way
 *        measurements aren't really layed out logically so you can have some pretty big distances between designations when going backwards) 
 *        
 *        The rest of the editor is pretty straight forward, you can add or remove tags (braces are added automatically, no need to include them) and just fill out, or edit the instructions as needed.
 *        
 *        if you want to make an altered copy of a recipe, use "Save as", otherwise save your changes when you are done with them and they will be reflected in the main recipe panel.
 *        
 *        
 * And that's pretty much the whole thing, There are some really neat things going on under the hood, like how I use Regex to parse the files
 * or how I handle fractions and converting measurements but I don't have the time to write them all out here, right now anyway, which I apologize for.
 * You can contact me in regards for explanation on any of those things, and maybe I'll do another write-up explaining them if you'd like me to.
 *     
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace RecipeProgram
{
    // I place the measurements in an equivelant relationship based on the smallest measurement, a drop.
    public class Unit
    {
        public Unit(string name, int drops)
        {
            Name = name;
            Drops = drops;
        }
        public string Name { get; private set; }
        public int Drops { get; private set; }

        public static bool ContainsUnit(Unit[] units, string unitName)
        {
            foreach(Unit unit in units)
            {
                if (unit.Name == unitName)
                {
                    return true;
                }
            }
            return false;
        }

        public static double ValueAtUnitName(Unit[] units, string name)
        {
            for (int i = 0; i < units.Length; i++)
            {
                if (units[i].Name == name)
                {
                    return (double)units[i].Drops;
                }
            }
            throw new Exception("No unit with name " + name + " was found.");
        }

    }

    static class Program
    {

        // I had to make this a public staic object so I could access a public function I included in the form.
        public static MainForm mainForm;

#if INDEV
        public const string ROOT_DIR_PATH = @"..\..\recipes\";
#else
        //public const string ROOT_DIR_PATH = @"\recipes\";
        public static string ROOT_DIR_PATH = AppDomain.CurrentDomain.BaseDirectory + @"recipes\"; // this is better. otherwise it creates a folder in C:\ which is less portable.
#endif

        public static Dictionary<string, Recipe> recipes = new Dictionary<string, Recipe>();
        public static Dictionary<string, DirectoryInfo> folders = new Dictionary<string, DirectoryInfo>();
        public static RecipeReader reader = new RecipeReader(ROOT_DIR_PATH);
        public static Recipe activeRecipe;
        public static DirectoryInfo rootDirectory;
        public static DirectoryInfo activeDirectory;
        public static Ingredient activeIngredient;
        //public static string[] measurements = {
        //    "",
        //    "dsh.",
        //    "drp.",
        //    "tsp.",
        //    "tbsp.",
        //    "c.",
        //    "pnt.",
        //    "qrt."
        //};
        public static Unit[] measurements = {
            new Unit("",             0),      
            new Unit("drp.",         1),
            new Unit("dsh.",         3),
            new Unit("tsp.",        60),
            new Unit("tbsp.",      180),
            new Unit("c.",        2880),
            new Unit("qrt.",     11520)
        };
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [DllImport("UxTheme.Dll", EntryPoint = "#65", CharSet = CharSet.Unicode)]
        public static extern int SetSystemVisualStyle(string pszFilename, string pszColor, string pszSize, int dwReserved);



        [STAThread]
        static void Main()
        {
            rootDirectory = new DirectoryInfo(ROOT_DIR_PATH);
            if(!rootDirectory.Exists)
            {
                Directory.CreateDirectory(ROOT_DIR_PATH);
            }

            folders = reader.LoadDirectories();

            Application.EnableVisualStyles();
            SetSystemVisualStyle(@"C:\WINDOWS\resources\Themes\aero\aero.msstyles", "Flat", "NormalSize", 0);
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new MainForm();
            Application.Run(mainForm);
            
        }
    }
}
