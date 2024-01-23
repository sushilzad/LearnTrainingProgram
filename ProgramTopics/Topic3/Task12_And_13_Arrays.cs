using System;
using System.Linq;

namespace ProgramTopics.Topic3
{
    /// <summary>
    /// This class is demonstrates the usage of Arrays in the C# language construct
    /// </summary>
    class Task12_And_13_Arrays
    {
        #region PUBLIC_METHODS
        /// <summary>
        /// This method demonstrates the usage of Arrays and its functionalities like searching, sorting...etc
        /// </summary>
        public void DemonstrateUsageOfArrays()
        {
            // INITIALIZING ARRAYS WITHOUT NEW KEYWORD
            string[] cars = { "Volvo", "BMW", "Ford", "Mazda" };            // declare and initialize a string array
            int[] myNum = { 10, 20, 30, 40 };                               // declare and initialize an integer array

            // ACCESSING AND MODIFYING ELEMENTS OF THE ARRAY
            string[] newcars = { "Volvo", "BMW", "Ford", "Mazda" };
            Console.WriteLine(newcars[0]);                                  // Outputs Volvo

            newcars[0] = "Opel";
            Console.WriteLine(newcars[0]);                                  // Now outputs Opel instead of Volvo

            // ARRAY LENGTH
            string[] cars1 = { "Volvo", "BMW", "Ford", "Mazda" };
            Console.WriteLine(cars1.Length);                                // Outputs 4

            // Create an array of four elements, and add values later
            cars = new string[4];

            // Create an array of four elements and add values right away 
            cars = new string[4] { "Volvo", "BMW", "Ford", "Mazda" };

            // Create an array of four elements without specifying the size 
            cars = new string[] { "Volvo", "BMW", "Ford", "Mazda" };

            // Create an array of four elements, omitting the new keyword, and without specifying the size
            string[] carsArray = { "Volvo", "BMW", "Ford", "Mazda" };

            // Declare an array
            string[] carNames;
            // Add values, using new
            carNames = new string[] { "Volvo", "BMW", "Ford" };


            // LOOP THROUGH ARRAYS USING TRADITIONAL FOR LOOP WITH INDEXES
            string[] nameOfCars = { "Volvo", "BMW", "Ford", "Mazda" };
            for (int i = 0; i < nameOfCars.Length; i++)
            {
                Console.WriteLine(nameOfCars[i]);
            }

            // LOOP THROUGH ARRAYS USING FOREACH LOOP
            string[] latestCars = { "Volvo", "BMW", "Ford", "Mazda" };
            foreach (string i in cars)
            {
                Console.WriteLine(i);
            }


            // SORTING ARRAYS USING INBUILT SORT METHOD FROM ARRAY CLASS
            // Sort a string array
            string[] carNames2 = { "Volvo", "BMW", "Ford", "Mazda" };
            Array.Sort(carNames2);
            foreach (string i in carNames2)
            {
                Console.WriteLine(i);
            }

            // Sort an integer array
            int[] myNumbers = { 5, 1, 8, 9 };
            Array.Sort(myNumbers);
            foreach (int i in myNumbers)
            {
                Console.WriteLine(i);
            }

            // System.Linq Namespace
            int[] myNewNumbers = { 5, 1, 8, 9 };
            Console.WriteLine(myNewNumbers.Max());                              // returns the largest value
            Console.WriteLine(myNewNumbers.Min());                              // returns the smallest value
            Console.WriteLine(myNewNumbers.Sum());                              // returns the sum of elements


            // MULTIDIMENSIONAL ARRAYS
            int[,] numbers = { { 1, 4, 2 }, { 3, 6, 8 } };
            
            // ACCESS ELEMENTS ON 2D ARRAY
            int[,] newNumbers = { { 1, 4, 2}, { 3, 6, 8} };
            Console.WriteLine(newNumbers[0, 2]);                                // Outputs 2

            // MODIFYING VALUES OF 2D ARRAYS
            int[,] myNums = { { 1, 4, 2 }, { 3, 6, 8 } };
            myNums[0, 0] = 5;                                                   // Change value to 5
            Console.WriteLine(myNums[0, 0]);                                    // Outputs 5 instead of 1

            // LOOP THROUGH 2D ARRAY
            int[,] myNewNums = { { 1, 4, 2 }, { 3, 6, 8 } };
            foreach (int i in myNewNums)
            {
                Console.WriteLine(i);
            }

            // LOOP THROUGH 2D ARRAY USING TRADITIONAL LOOP
            int[,] numsLoop = { { 1, 4, 2}, { 3, 6, 8} };
            for (int i = 0; i < numsLoop.GetLength(0); i++)
            {
                for (int j = 0; j < numsLoop.GetLength(1); j++)
                {
                    Console.WriteLine(numsLoop[i, j]);
                }
            }
        }
        #endregion
    }
}
