using System;

namespace ProgramTopics
{
    /// <summary>
    /// This class represents the Student entity
    /// </summary>
    class Student
    {
        #region MEMBER_VARIABLES
        int rollNo = 0;
        string name = string.Empty;
        #endregion

        #region CTOR
        /// <summary>
        /// Default constructor
        /// </summary>
        public Student()
        {
            rollNo = 0;
            name = string.Empty;
        }
        /// <summary>
        /// Parametrized constructor
        /// </summary>
        /// <param name="rollNo"></param>
        /// <param name="name"></param>
        public Student(int rollNo, string name)
        {
            this.rollNo = rollNo;
            this.name = name;
        }
        #endregion

        #region PROPERTIES
        int RollNo => rollNo;
        string Name => name;
        #endregion

        #region PRIVATE_METHODS
        private void GetYourselfReady()
        {
            Console.WriteLine($"{Name} is getting himself ready...");
        }
        private void GoToSchool()
        {
            this.GetYourselfReady();
            Console.WriteLine("Go to school");
            this.RegisterYourPresence();
        }
        private void RegisterYourPresence() 
        {
            Console.WriteLine($"Roll No#{RollNo} is present in person at school today.");
        }

        #endregion

        #region PUBLIC_METHODS
        /// <summary>
        /// This method perfroms the action of going to school by getting ready first and then registering his in person presence in class
        /// </summary>
        public void AttendClass()
        {
            this.GoToSchool();
        }
        #endregion
    }

    /// <summary>
    /// Solution to the Topic2_ObjectOrientedConcepts_Advanced
    /// </summary>
    internal class Topic2_ObjectOrientedConcepts_Advanced
    {
        /// <summary>
        /// The below method is used to demonstrate Abstraction and the way how it hide un-necessary details from the end user
        /// </summary>
        public void Task1_Demo_Abstraction()
        { 
            Student sushil = new Student(07, "Sushil Zad");
            sushil.AttendClass();
        }
    }
}