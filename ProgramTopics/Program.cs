using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramTopics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Topic2_ObjectOrientedConcepts_Advanced topic2 = new Topic2_ObjectOrientedConcepts_Advanced();
            topic2.Task1_Demo_Abstraction();

            Topic3.Task1_StringOperations task1_StringOperations = new Topic3.Task1_StringOperations();
            task1_StringOperations.PerformStringOperations();

            Console.ReadKey();
        }
    }
}
