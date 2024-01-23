using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramTopics.Topic3
{
    /// <summary>
    /// This class is repsonsible to perform all string functionality related operations
    /// </summary>
    internal class Task1_StringOperations
    {
        #region CTOR
        /// <summary>
        /// Default constructor
        /// </summary>
        public Task1_StringOperations() { }
        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// This method performs string related operations like concatenation, navigation, comparison.
        /// </summary>
        public void PerformStringOperations()
        {
            // STRING CONCATENATION
            Console.WriteLine("\nBelow are some examples of string concatenation: ");
            string str1 = "This is first string";
            string str2 = "This is second string";
            Console.WriteLine("str1 + str2 = " + str1 + str2);
            Console.WriteLine("string.Concat(str1, str2) = " + string.Concat(str1, str2));
            string str3 = str1 + str2;
            Console.WriteLine("str3 = str1 + str2;\n value of str3 = " + str3);
            string str4 = 100 + str3; // number (any data type) plus string results as string only

            // STRING NAVIGATION BY FIXED INDEX
            Console.WriteLine("\nNavigating string and accessing single character by a fixed index: ");
            string sampleStr = "This is a sample string";
            Console.WriteLine("sampleStr = " + sampleStr);
            Console.WriteLine("sampleStr[0] = " + sampleStr[0]);
            Console.WriteLine("sampleStr[6] = " + sampleStr[6]);
            Console.WriteLine("sampleStr[sampleStr.Length] = " + sampleStr[sampleStr.Length-1]);
            Console.WriteLine("\nNavigating string character by character: ");
            for (int i = 0; i < sampleStr.Length - 1; i++)
                Console.WriteLine(sampleStr[i]);

            // STRING COMPARISON
            Console.WriteLine("\nBelow are some examples of string comparison: ");
            string name1 = "Sushil Zad";
            string name2 = "Sunil Zad";
            string name3 = "Sushil Zad";

            // Compare strings using String.Equals
            if (String.Equals(name1, name2))
                Console.WriteLine($"{name1} and {name2} have same value.");
            else
                Console.WriteLine($"{name1} and {name2} are different.");

            if (String.Equals(name1, name3))
                Console.WriteLine($"{name1} and {name3} have same value.");
            else
                Console.WriteLine($"{name1} and {name3} are different.");

            // Use String.Compare method
            if (String.Compare(name1, name2) == 0)
                Console.WriteLine($"Both strings have same value.");
            else if (String.Compare(name1, name2) < 0)
                Console.WriteLine($"{name1} precedes {name2}.");
            else if (String.Compare(name1, name2) > 0)
                Console.WriteLine($"{name1} follows {name2}.");

            // Use CompareTo method
            if (name1.CompareTo(name2) == 0)
                Console.WriteLine($"Both strings have same value.");
            else if (name1.CompareTo(name2) < 0)
                Console.WriteLine($"{name1} precedes {name2}.");
            else if (name1.CompareTo(name2) > 0)
                Console.WriteLine($"{name1} follows {name2}.");

            //Use StringComparer
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (comparer.Compare(name1, name2) == 0)
                Console.WriteLine($"Both strings have same value.");
            else if (comparer.Compare(name1, name2) < 0)
                Console.WriteLine($"{name1} precedes {name2}.");
            else if (comparer.Compare(name1, name2) > 0)
                Console.WriteLine($"{name1} follows {name2}.");
        }
        #endregion
    }
}
