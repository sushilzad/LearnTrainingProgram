using System;

namespace ProgramTopics.Topic3
{
    /// <summary>
    /// Interface for logging functionality
    /// </summary>
    interface IBaseLogger
    {
        void Log(string message);
    }

    /// <summary>
    /// Abstract base class serving as the base parent of all the logging classes
    /// </summary>
    abstract class BaseLogger : IBaseLogger
    {
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseLogger()
        {
            this.Initialize();
        }
        #endregion

        /// <summary>
        /// Do some initialization stuff viz. required for setting up the basic parameters of the class
        /// </summary>
        private void Initialize()
        {
            // do some initializing business logic here
            Console.WriteLine("BaseLogger: Inside Initialize()");
        }

        /// <summary>
        /// The actual definition would be specified by the underlying classes
        /// </summary>
        /// <param name="message"></param>
        public abstract void Log(string message);
    }

    /// <summary>
    /// This class logs the data into database
    /// </summary>
    class DatabaseLogger : BaseLogger
    {
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public DatabaseLogger() : base() // give call to base to do the initial initialization inside base class
        {
            Console.WriteLine($"{nameof(DatabaseLogger)} : Inside default constructor - establish database connection setup here");
        }
        #endregion

        /// <summary>
        /// Log method for database functionality
        /// </summary>
        /// <param name="message"></param>
        public override void Log(string message)
        {
            Console.WriteLine($"Dump this Message=[{message}] in database");
        }
    }

    /// <summary>
    /// This class logs the data into file.
    /// </summary>
    class FileLogger : BaseLogger
    {
        #region
        /// <summary>
        /// Default constructor
        /// </summary>
        public FileLogger() : base() // give call to base to do the initial initialization inside base class
        {
            Console.WriteLine($"{nameof(FileLogger)} : Inside default constructor - establish file input stream setup here");
        }
        #endregion

        /// <summary>
        /// Log method for file functionality
        /// </summary>
        /// <param name="message"></param>
        public override void Log(string message)
        {
            Console.WriteLine($"Dump this Message=[{message}] in file.");
        }
    }

    /// <summary>
    /// This class demonstrates the usage of Interface, Abstract classes in Inheritance
    /// </summary>
    class Task6_Inhertiance
    {
        #region PUBLIC_METHODS
        public void PerformInheritanceDemonstration()
        { 
            IBaseLogger dbLogger = new DatabaseLogger();
            dbLogger.Log("Log this sample text into database file");

            Console.WriteLine("\n");

            IBaseLogger fileLogger = new FileLogger();
            fileLogger.Log("Log this sample text into specified log file");
        }
        #endregion
    }
}
