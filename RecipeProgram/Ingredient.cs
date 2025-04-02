using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace RecipeProgram
{

    public class Ingredient
    {
        // I have split up quantity into three fields, these will not be displayed separately, and decVal will not be displayed at all.
        public string quantity { get; private set; }

        public string measurement { get; private set; }

        public string name { get; private set; }


        public Ingredient(string QUANTITY, string MEASUREMENT, string NAME)
        {
            // In order of appearance
            
            if (ParseFraction(QUANTITY) != 0.0) // maybe we should consider not checking if measurement is one we have, just for flexibility.
            {
                //if(Program.measurements.Contains(MEASUREMENT))
                if (Unit.ContainsUnit(Program.measurements, MEASUREMENT))
                {
                    quantity = QUANTITY;
                    measurement = MEASUREMENT;
                    name = NAME;
                }
                else
                {
                    throw new ArgumentException(MEASUREMENT + " of " + NAME + " is not contained in our list of accepted measurements.");
                }
            }
            else
            {
                throw new ArgumentException(QUANTITY + " of " + NAME + " is not a valid numeric value.");
            }
        }

        public void SetQuantity(string qty)
        {
            quantity = qty;
        }

        public void SetMeasurement(string msrmnt)
        {
            measurement = msrmnt;
        }

        public void SetName(string n)
        {
            name = n;
        }

        public string OperateOnQuantity(string quantity, double modifier)
        {
            //int wholeParts;
            //string fractionalPart;
            string affectedQuantity;
            double value = ParseFraction(quantity);

            value *= modifier; // this should work, but if you're getting unexpected values returned, this is where you should check.

            
            affectedQuantity = DecimalToFraction(value);

            return affectedQuantity;
    }

        public static string DecimalToFraction(double dec)
        {
            int n = 1;
            double d = 1.0;
            bool resolved = false;

            while (!resolved)
            {
                d = Math.Abs(n) / dec; // made this absolute because there were cases where it was going negative, of course these cases it was also hanging so maybe I should use that to abort.
                if(d % 1 != 0)
                {
                    n++;
                }
                else
                {
                    resolved = true;
                }
                
            }
            if (n >= d)
            {
                // this should handle improper fractions
                // I'm not sure if I need to let it use it's double or float version of d or cast it, I'll leave it alone for now and test.
                // It was leaving 0 if it fit nicely so i used a ternary operation and made sure to reformat the remander fraction.
                // I tacked on a cast to int for the whole number value since I the fractional amount is represented right next to it.
                return ((int)(n / d) + (n % d == 0 ? string.Empty : " " + n % d + "/" + (int)d));
            }
            else
            {
                return (n + "/" + (int)d);
            }

        }

        public double ParseFraction(string fract)
        {
            // grab any number of digits at the beginning
            string wholePattern = @"^\s*\d*\s*(?!\d*\/\d*)";
            // grab any number of digits split by a / at the end
            string fractionPattern = @"\d*\s*\/\d*\s*$";
            string[] numDenom;
            double dec = 0.0;

            Match wholeMatch = Regex.Match(fract, wholePattern);
            Match fractionMatch = Regex.Match(fract, fractionPattern);


            // if we match for whole numbers, we should add them to the fraction as well, so we can operate on it.
            if(wholeMatch.Success && fractionMatch.Success)
            {
                dec += int.Parse(wholeMatch.Value);
                numDenom = fractionMatch.Value.Split('/');
                dec += float.Parse(numDenom[0]) / float.Parse(numDenom[1]);
            }
            else if (!fractionMatch.Success && wholeMatch.Success)
            {
                dec = int.Parse(wholeMatch.Value);
            }
            else if (!wholeMatch.Success && fractionMatch.Success)
            {
                numDenom = fractionMatch.Value.Split('/');
                dec = float.Parse(numDenom[0]) / float.Parse(numDenom[1]);
            }

            // since a fraction would never evaluate to zero, we can safely return zero in the event that we couldn't match a fraction in the string.
            // potentially, I would actually remove this code from ingredient and run it from a function in recipe editor that I use to check if I would need to parse something.
            return dec;
        }

        public double ToDrops(Unit[] units, double decQuantity, string measurement)
        {
            int dropMultiplier = (int)Unit.ValueAtUnitName(units, measurement); // I don't know why I typed the function for double, I'll probably change that but I don't want to risk anything breaking right now
            double dropValue = decQuantity * dropMultiplier;
            return dropValue;
        }

        public static void ConvertMeasurement(Unit[] units, int nDrops, ref Ingredient ingredient)
        {
            //for (int i = units.Length - 1; i >= 0; i--)
            //{
            //    double value = (double)nDrops / units[i].Drops;
            //    double upperValue;
            //    if (i < units.Length - 1) { upperValue = (double)nDrops / (units[i + 1].Drops); }
            //    else { upperValue = 0; }
                
            //    if (value >= 1 && upperValue < 1) // this is still going to always prefer the larger measurement unless I add a flag or something to tell it to treat it differently if descending.
            //    {
            //        string ending = "";

            //        //if (value != 1.0)
            //            //ending = (units[i].Name == "Dash" ? "es" : "s");

            //        string fractVal = DecimalToFraction(value);

            //        ingredient.SetMeasurement(units[i].Name);
            //        ingredient.SetQuantity(fractVal);

            //        //Console.WriteLine(
            //        //   "{0} drop{1} => {2} {3}{4}",
            //        //   nDrops, nDrops == 1 ? "" : "s",
            //        //   fractVal, units[i].Name, ending
            //        //);

            //        break;
            //    }
            //}

            for(int i = units.Length - 2; i > 2; i--)
            {
                if (nDrops >= units[i].Drops && nDrops < units[i+1].Drops)
                {
                    double value = (double)nDrops / units[i].Drops;
                    string fractVal = DecimalToFraction(value);
                    ingredient.SetMeasurement(units[i].Name);
                    ingredient.SetQuantity(fractVal);
                    break;
                }
                else if (nDrops >= units[i+1].Drops && i == units.Length - 2)
                {
                    double value = (double)nDrops / units[i+1].Drops;
                    string fractVal = DecimalToFraction(value);
                    ingredient.SetMeasurement(units[i+1].Name);
                    ingredient.SetQuantity(fractVal);
                    break;
                }
            }
        }

        public override string ToString()
        {
            return (quantity + " " + measurement + " " + name);
        }
    }
}
