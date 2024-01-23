using System;
using System.Text;

namespace ProgramTopics.Topic3
{
    /// <summary>
    /// This class demonstrates the usage of StringBuilder class and some basic functionalities associated with it
    /// </summary>
    class Task11_StringBuilderOperations
    {
        #region PUBLIC_METHODS
        /// <summary>
        /// This method demonstrates the vairous functionalities associated with the StringBuilder class
        /// </summary>
        public void PerformStringBuilderOperations()
        {
            StringBuilder sb;
            // Different ways of initialization of StringBuilder
            sb = new StringBuilder(); //string will be appended later
            // or
            sb = new StringBuilder("Hello World!"); // with some initial value
            // or
            sb = new StringBuilder(50); // with some initial capacity string will be appended later
            //or
            sb = new StringBuilder("Hello World!", 50); // with some initial value and capacity
            for (int i = 0; i < sb.Length; i++)
                Console.Write(sb[i]); // output: Hello World!
            Console.WriteLine("Value is: " + sb.ToString()); //returns "Hello World!"

            // Using the append method
            sb = new StringBuilder();
            sb.Append("Hello ");
            sb.AppendLine("World!");
            sb.AppendLine("Hello C#");
            Console.WriteLine(sb);

            // Using the AppendFormat method
            StringBuilder sbAmout = new StringBuilder("Your total amount is ");
            sbAmout.AppendFormat("{0:C} ", 25);
            Console.WriteLine(sbAmout);//output: Your total amount is $ 25.00

            // Using the insert method
            sb = new StringBuilder("Hello World!");
            sb.Insert(5, " C#");
            Console.WriteLine(sb); //output: Hello C# World!

            // Using the Remove method to remove a string from specified index upto specified length
            sb = new StringBuilder("Hello World! This is a sample string", 50);
            sb.Remove(6, 7);
            Console.WriteLine(sb); //output: Hello

            // Using the Replace method to replace all the occurences from the string
            sb = new StringBuilder("Hello World!");
            sb.Replace("World", "C#");
            Console.WriteLine(sb);//output: Hello C#!
        }
        #endregion
    }
}
