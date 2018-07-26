using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CaseConverterMVVM.Models
{
    public class TextConverter
    {
        //Regex comparators
        static private Regex alphanumeric = new Regex(@"^[a-zA-Z]+[0-9a-zA-Z ]*");
        static private Regex space = new Regex(@"[\s]"); //actually any whitespace, not just space
        static private Regex allWhiteSpace = new Regex(@"^[\s]+$");
        static private Regex capitals = new Regex(@"[A-Z]");
        static private Regex startsCapital = new Regex(@"^[A-Z]");

        //Conversion functions called by ViewModel
        public static string ConvertSpacedToPascal(string spaced)
        {
            spaced = spaced.Trim();
            //First validate for appropriate alphanumeric spaced input
            if (!(alphanumeric.IsMatch(spaced)))
                return "Invalid space-separated input. Input must be " +
                    "alphanumeric and spaces only and begin with an alpha character.";
            //Separate space-delimited text and return pascal-formatted string
            return PascalCase(Parse(spaced, space));
        }
        public static string ConvertPascalToSpaced(string pascal)
        {
            pascal = pascal.Trim();
            //First validate for appropriate alphanumeric pascal-case input
            if (!(alphanumeric.IsMatch(pascal))
                || space.IsMatch(pascal)
                || !(startsCapital.IsMatch(pascal)))
                return "Invalid pascal case input. Input must be " +
                    "alphanumeric, no spaces, and begin with a capital letter.";
            //Separate space-delimited text and return pascal-formatted string
            return Spaced(Parse(pascal, capitals));
        }
        public static string ConvertPascalToCamel(string pascal)
        {
            pascal = pascal.Trim();
            //First validate for appropriate alphanumeric pascal-case input
            if (!(alphanumeric.IsMatch(pascal))
                || space.IsMatch(pascal)
                || !(startsCapital.IsMatch(pascal)))
                return "Invalid pascal case input. Input must be " +
                    "alphanumeric, no spaces, and begin with a capital letter.";
            //This one is easy, just lowercase the first character
            return LowercaseFirst(pascal);
        }
        public static string ConvertCamelToPascal(string camel)
        {
            //First validate for appropriate alphanumeric camel-case input
            if (!(alphanumeric.IsMatch(camel))
                || space.IsMatch(camel))
                return "Invalid camel case input. Input must be " +
                    "alphanumeric, no spaces, and begin with an alpha character.";
            //This one is easy, just capitalize the first character
            return CapitalizeFirst(camel);
        }

        //Takes a list and formats it into a case structure
        private static string PascalCase(List<string> list)
        {
            string output = "";
            foreach (string s in list)
            {
                output += CapitalizeFirst(s);
            }
            return output.Trim();
        }
        private static string CamelCase(List<string> list)
        {
            return LowercaseFirst(PascalCase(list));
        }
        private static string Spaced(List<string> list)
        {
            string output = "";
            foreach (string s in list)
            {
                output += " " + s;
            }
            return output.Trim();
        }

        //Capitalizes or lowercases first character of string
        private static string CapitalizeFirst(string str)
        {
            if (str.Length == 0) return "";
            if (str.Length == 1) return str.ToUpper();
            return (str.Substring(0, 1).ToUpper() + str.Substring(1));
        }
        private static string LowercaseFirst(string str)
        {
            if (str.Length == 0) return "";
            if (str.Length == 1) return str.ToLower();
            return (str.Substring(0, 1).ToLower() + str.Substring(1));
        }

        //Separates a string into a collection of lowercase words
        private static List<string> Parse(string input, Regex delimiter)
        {
            List<string> list = new List<string>();
            if (input == "" || allWhiteSpace.IsMatch(input)) return list;
            list.Add(LowercaseFirst(input)); //lowercase ensures it isn't hung on an initial capital
            int i = 0;
            Match match = delimiter.Match(list[i]);
            while (match.Success)
            {
                //Bump the latter string to a new index
                list.Add(LowercaseFirst(list[i].Substring(match.Index).Trim()));
                //Cut off the former string and store as lowercase
                list[i] = list[i].Substring(0, match.Index).Trim().ToLower();
                //Increment and search next index
                i++;
                match = delimiter.Match(list[i]);
            }
            //Ensure the ends are fully lowercased as well
            list[0] = list[0].ToLower();
            list[i] = list[i].ToLower();
            //Done parsing. return the list.
            return list;
        }
        
    }
}
