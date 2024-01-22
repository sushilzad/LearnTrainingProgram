﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramTopics
{
    internal class Program
    {
        static void DisplayMessageOnConsole(string message)
        {
            Console.WriteLine("\n\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> " + message + " <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        }

        static void Main(string[] args)
        {
            DisplayMessageOnConsole("TOPIC 2");
            Topic2_ObjectOrientedConcepts_Advanced topic2 = new Topic2_ObjectOrientedConcepts_Advanced();
            topic2.Task1_Demo_Abstraction();

            DisplayMessageOnConsole("TOPIC 3 - TASK 1");
            Topic3.Task1_StringOperations task1_StringOperations = new Topic3.Task1_StringOperations();
            task1_StringOperations.PerformStringOperations();

            DisplayMessageOnConsole("TOPIC 3 - TASK 2");
            Topic3.Task2_CSharpKeywords task2_CSharpKeywords = new Topic3.Task2_CSharpKeywords();
            task2_CSharpKeywords.PerformOperationUsingCSharpKeywords();

            DisplayMessageOnConsole("TOPIC 3 - TASK 3 and TASK 4");
            Topic3.Task3_And_Task4_Exceptions task3_Exceptions = new Topic3.Task3_And_Task4_Exceptions();
            task3_Exceptions.PerformExceptionHandling();

            DisplayMessageOnConsole("TOPIC 3 - TASK 5");
            Topic3.Task5_AccessSpecifiers_And_Enums task5_AccessSpecifiers_And_Enums = new Topic3.Task5_AccessSpecifiers_And_Enums();
            task5_AccessSpecifiers_And_Enums.PerformAccessSpecifierDemo();

            Console.ReadKey();
        }
    }
}
