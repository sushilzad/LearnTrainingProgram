using ProgramTopics.Topic3;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProgramTopics.Collections
{
    /// <summary>
    /// This class demonstrates the implementation of some of the collections classes
    /// </summary>
    class CollectionImplementation
    {
        #region PUBLIC_METHODS
        /// <summary>
        /// This method demonstrates the usage of Collections like List, ArrayList and Dictionary
        /// </summary>
        public void DemonstrateCollectionsClassesImplementation()
        {
            Console.WriteLine("\n\nARRAYLIST");
            // IMPLEMENTATION OF ARRAYLIST
            ArrayList arlist = new ArrayList();
            // or 
            //var arlist = new ArrayList(); // recommended

            // adding elements using ArrayList.Add() method
            var arlist1 = new ArrayList();
            arlist1.Add(1);
            arlist1.Add("Bill");
            arlist1.Add("Bill is a new statement added");
            arlist1.Add(" ");
            arlist1.Add(true);
            arlist1.Add(4.5);
            arlist1.Add(null);

            // adding elements using object initializer syntax
            var arlist2 = new ArrayList()
            {
                2, "Steve", " ", "Steve is another long string", 'c', 99999999999999999999d, true, 4.5, null
            };

            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(true);
            queue.Enqueue(arlist1);

            arlist1.Remove(null); //Removes first occurance of null
            arlist1.RemoveAt(4); //Removes element at index 4
            arlist1.RemoveRange(0, 2);//Removes two elements starting from 1st item (0 index)

            var arListRange = new ArrayList();
            arListRange.AddRange(arlist);
            arListRange.AddRange(arlist1);
            arListRange.AddRange(arlist2);
            arListRange.AddRange(queue);

            Console.Write("Collection: [");
            foreach (var ar in arListRange)
            {
                if (ar is ICollection)
                {
                    Console.Write("Collection: [");
                    foreach (var ar2 in (ArrayList)ar)
                        Console.Write(ar2 + ", ");
                    Console.Write("]");
                }
                else Console.Write(ar + ", ");
            }
            Console.Write("]");


            Console.WriteLine("\n\nLIST");
            // IMPLEMENTATION OF LIST
            List<int> primeNumbers = new List<int>();
            primeNumbers.Add(2); // adding elements using add() method
            primeNumbers.Add(3);
            primeNumbers.Add(5);
            primeNumbers.Add(7);

            var cities = new List<string>();
            cities.Add("New York");
            cities.Add("London");
            cities.Add("Mumbai");
            cities.Add("Chicago");
            cities.Add(null);// nulls are allowed for reference type list

            //adding elements using collection-initializer syntax
            var bigCities = new List<string>()
                    {
                        "New York",
                        "London",
                        "Mumbai",
                        "Chicago"
                    };

            // ACCESSING LIST USING LINQ
            var products = new List<Product>() {
                new Product(){ Value = 1, Name="Bill"},
                new Product(){ Value = 2, Name="Steve"},
                new Product(){ Value = 3, Name="Ram"},
                new Product(){ Value = 4, Name="Sushil"}
            };

            //get all products whose name is Bill
            var result = from p in products
                         where p.Name == "Bill"
                         select p;

            foreach (var product in result)
                Console.WriteLine(product.Value + ", " + product.Name);


            // Example: Add Arrays in List
            string[] cities1 = new string[3] { "Mumbai", "London", "New York" };

            var popularCities = new List<string>();

            // adding an array in a List
            popularCities.AddRange(cities1);

            var favouriteCities = new List<string>();

            // adding a List 
            favouriteCities.AddRange(popularCities);

            // Example: Insert elements into List
            var numbers = new List<int>() { 10, 20, 30, 40 };

            numbers.Insert(1, 11);// inserts 11 at 1st index: after 10.

            foreach (var num in numbers)
                Console.Write(num + ", ");

            // CHECKING THE ELEMENTS IN THE LIST
            Console.WriteLine("\n\nnumbers.Contains(10): " + numbers.Contains(10)); // returns true
            Console.WriteLine("numbers.Contains(12): " + numbers.Contains(12)); // returns false
            Console.WriteLine("numbers.Contains(20): " + numbers.Contains(20)); // returns true


            // REMOVING ELEMENTS FROM THE LIST
            numbers.Remove(10); // removes the first 10 from a list
            numbers.RemoveAt(2); //removes the 3rd element (index starts from 0)

            //numbers.RemoveAt(10); //throws ArgumentOutOfRangeException

            foreach (var el in numbers)
                Console.Write(el + ", "); //prints 20 30


            Console.WriteLine("\n\nDICTIONARY");
            // DICTIONARY
            // Example: Create Dictionary and Add Elements
            IDictionary<int, string> numberNames = new Dictionary<int, string>();
            numberNames.Add(1, "One"); //adding a key/value using the Add() method
            numberNames.Add(2, "Two");
            numberNames.Add(3, "Three");

            //The following throws run-time exception: key already added.
            //numberNames.Add(3, "Three"); 

            foreach (KeyValuePair<int, string> kvp in numberNames)
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);

            //creating a dictionary using collection-initializer syntax
            var dictCities = new Dictionary<string, string>(){
                {"UK", "London, Manchester, Birmingham"},
                {"USA", "Chicago, New York, Washington"},
                {"India", "Mumbai, New Delhi, Pune"}
            };

            foreach (var kvp in dictCities)
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);

            Console.WriteLine(dictCities["UK"]); //prints value of UK key
            Console.WriteLine(dictCities["USA"]);//prints value of USA key
                                             //Console.WriteLine(cities["France"]); // run-time exception: Key does not exist

            //use ContainsKey() to check for an unknown key
            if (dictCities.ContainsKey("France"))
            {
                Console.WriteLine(dictCities["France"]);
            }

            //use TryGetValue() to get a value of unknown key
            string resValue;
            if (dictCities.TryGetValue("France", out resValue))
            {
                Console.WriteLine(resValue);
            }

            //use ElementAt() to retrieve key-value pair using index
            for (int i = 0; i < dictCities.Count; i++)
            {
                Console.WriteLine("Key: {0}, Value: {1}",
                                                        dictCities.ElementAt(i).Key,
                                                        dictCities.ElementAt(i).Value);
            }

            dictCities["UK"] = "Liverpool, Bristol"; // update value of UK key
            dictCities["USA"] = "Los Angeles, Boston"; // update value of USA key
                                                   //cities["France"] = "Paris"; //throws run-time exception: KeyNotFoundException

            if (dictCities.ContainsKey("France"))
            {
                dictCities["France"] = "Paris";
            }

            dictCities.Remove("UK"); // removes UK 
                                 //cities.Remove("France"); //throws run-time exception: KeyNotFoundException

            if (dictCities.ContainsKey("France"))
            { // check key before removing it
                dictCities.Remove("France");
            }
            dictCities.Clear(); //removes all elements
        }
        #endregion
    } 
}
