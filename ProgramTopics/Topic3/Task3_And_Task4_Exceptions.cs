using System;

namespace ProgramTopics.Topic3
{
    /// <summary>
    /// Plain POCO class Person
    /// </summary>
    class Person
    {
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public Person()
        {
            Age = 1;
            Name = "Test";
        }
        /// <summary>
        /// Parametrized constructor
        /// </summary>
        /// <param name="Age"></param>
        /// <param name="Name"></param>
        public Person(int Age, string Name)
        {
            this.Age = Age;
            this.Name = Name;
        }
        #endregion

        #region Properties
        public int Age { get; set; }
        public string Name { get; set; }
        #endregion
    }

    /// <summary>
    /// Custom exception class for handling incorrect age inputs
    /// </summary>
    class InvalidAgeException : Exception
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="message"></param>
        public InvalidAgeException(string message) : base(message)
        {
            Console.WriteLine("Inside InvalidAgeException custom exception's constructor.\n");
        }
    }

    /// <summary>
    /// This class demonstrates the use of custom Exceptions
    /// </summary>
    class Task3_And_Task4_Exceptions
    {
        #region PUBLIC_METHODS
        /// <summary>
        /// Use this method for the demonstration of exception handling in C#
        /// </summary>
        public void PerformExceptionHandling()
        {
            // CUSTOM EXCEPTION HANDLING
            try
            {
                Person person = new Person(300, "Sushil Zad");

                if (person.Age < 0 || person.Age > 110)
                    throw new InvalidAgeException($"The entered person's age({person.Age}) is beyond the normal limits.");
            }
            catch (InvalidAgeException iae)
            {
                Console.WriteLine("Caught InvalidAgeException: This is a custom type of exception handling.");
                Console.WriteLine("The invalid age exception is caught and handled");
                Console.WriteLine("InvalidAgeException message is: " + iae.Message + "\n");
            }

            // GENERALIZED AND SPECIALIZED EXCEPTION HANDLING
            try
            {
                Person p = null;
                if (p == null)
                    throw new NullReferenceException("The object of Person is not initialized yet.");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Caught NullReferenceException: This is a special type of exception handling");
            }
            catch (Exception)
            {
                Console.WriteLine("Caught Excetpion: This is a general type of exception handling");
            }
        }
        #endregion
    }
}
