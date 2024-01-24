using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramTopics.Topic3
{
    /// <summary>
    /// Enum depciting different states of target log containment
    /// </summary>
    public enum LogTarget
    {
        None,
        File,
        Database
    }

    /// <summary>
    /// Interface providing methods for accessing log related operations
    /// </summary>
    interface IDataLogger
    { 
        void Log(string message);
        // void Info(string message)
        // void Warn(string message);
        // void Debug(string message);
    }

    /// <summary>
    /// Interface to interact with the LogBuilder 
    /// </summary>
    interface ILogBuilder
    {
        IDataLogger GetFileLogger();
        IDataLogger GetDataBaseLogger();
    }
    /// <summary>
    /// Abstratct class forming as the base and containing all the basic logging functionality
    /// </summary>
    abstract class DataLogger : IDataLogger
    {
        protected readonly LogTarget logTarget;
        protected readonly object lockObject = null;
        /// <summary>
        /// Parametrized constructor to create a logger based on the log target enum state
        /// </summary>
        /// <param name="logTarget"></param>
        public DataLogger(LogTarget logTarget)
        {
            this.logTarget = logTarget;
            lockObject = new object();
            // do other initialization here...
        }
        public abstract void Log(string message);
    }

    /// <summary>
    /// This class is responsible for logging all the log data into file
    /// </summary>
    class FileDataLogger : DataLogger
    {
        private static FileDataLogger instance;
        private readonly string logFilePath = string.Empty; // log file path

        /// <summary>
        /// Default constructor
        /// </summary>
        private FileDataLogger() : base(LogTarget.File)
        {
            logFilePath = @"C:\myLogData.txt";
        }

        /// <summary>
        /// Gets the singleton instance of FileDataLogger class
        /// </summary>
        /// <returns>FileDataLogger</returns>
        public static FileDataLogger GetInstance()
        {
            if (instance == null)
                instance = new FileDataLogger();
            return instance;
        }

        /// <summary>
        /// The actual log method for logging
        /// </summary>
        /// <param name="message"></param>
        public override void Log(string message)
        {
            lock (lockObject)
            {
                Console.WriteLine($"{nameof(FileDataLogger)}: " + message);
                /*
                using (StreamWriter streamWriter = new StreamWriter(logFilePath))
                {
                    streamWriter.WriteLine(message);
                    streamWriter.Close();
                }*/
            }
        }
    }

    /// <summary>
    /// This class is responsible for logging all the log data into database
    /// </summary>
    class DatabaseDataLogger : DataLogger
    {
        private static DatabaseDataLogger instance;
        // connection url pointing to the database
        private readonly string connectionUrl = string.Empty;

        /// <summary>
        /// Default constructor
        /// </summary>
        private DatabaseDataLogger() : base(LogTarget.Database)
        {
            connectionUrl = ""; // do the database connection setup here by reading all the parameters from config file
            // perform db connection operation here
        }

        /// <summary>
        /// Gets the singleton insance of DatabaseDataLogger class
        /// </summary>
        /// <returns>DatabaseDataLogger</returns>
        public static DatabaseDataLogger GetInstance()
        {
            if (instance == null)
                instance = new DatabaseDataLogger();
            return instance;
        }

        /// <summary>
        /// The actual log method to log all the data
        /// </summary>
        /// <param name="message"></param>
        public override void Log(string message)
        {
            lock (lockObject)
            {
                Console.WriteLine($"{nameof(DatabaseDataLogger)}: " + message);
                // code here to log data to the database
            }
        }
    }
    /// <summary>
    /// This class initializes the required logger and facilitates its usage
    /// </summary>
    class LogManager : ILogBuilder
    {
        private static ILogBuilder instance;
        /// <summary>
        /// Default constructor
        /// </summary>
        private LogManager()
        {
            
        }
        /// <summary>
        /// Gets the singleton instance of LogManager class
        /// </summary>
        /// <returns></returns>
        public static ILogBuilder GetInstance()
        { 
            if(instance == null)
                instance = new LogManager();
            return instance;
        }

        public IDataLogger GetFileLogger()
        {
            return FileDataLogger.GetInstance();
        }

        public IDataLogger GetDataBaseLogger()
        {
            return DatabaseDataLogger.GetInstance();
        }
    }

    /// <summary>
    /// This class demonstrates the usage of the custom Logger class to implement the logging mechanism
    /// </summary>
    class Task14_Logger
    {
        #region PUBLIC_METHODS
        /// <summary>
        /// This method demonstrates the implementation of the custom logger clas
        /// </summary>
        public void DemonstrateLoggerImplementation()
        {
            IDataLogger logger;

            logger = LogManager.GetInstance()
                                .GetFileLogger();
            logger.Log("this entry will go into file");

            logger = LogManager.GetInstance()
                    .GetDataBaseLogger();
            logger.Log("this entry will go into database");
        }
        #endregion
    }
}