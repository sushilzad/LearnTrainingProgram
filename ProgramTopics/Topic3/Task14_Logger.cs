using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interface to interact with the LogCreator
    /// </summary>
    interface ILogCreator
    {
        IDataLogger GetDataLogger(string type);
    }

    /// <summary>
    /// Singleton log object for synchronization purpose and thread saftey point of view
    /// </summary>
    static class Singleton<T> where T : new()
    {
        #region Private Variables
        private static Lazy<T> _lazy = new Lazy<T>(() => new T());
        #endregion
        #region Properties
        public static T Instance => _lazy.Value;
        #endregion
    }

    /// <summary>
    /// Abstratct class forming as the base and containing all the basic logging functionality
    /// </summary>
    abstract class DataLogger : IDataLogger
    {
        protected readonly LogTarget logTarget;
        // object required for synchronization
        protected static object LockObject = new object();
        /// <summary>
        /// Parametrized constructor to create a logger based on the log target enum state
        /// </summary>
        /// <param name="logTarget"></param>
        public DataLogger(LogTarget logTarget)
        {
            this.logTarget = logTarget;
            // do other initialization here...
        }
        public abstract void Log(string message);
    }

    /// <summary>
    /// This class is responsible for logging all the log data into file
    /// </summary>
    class FileDataLogger : DataLogger
    {
        private readonly string logFilePath = string.Empty; // log file path

        /// <summary>
        /// Default constructor
        /// </summary>
        public FileDataLogger() : base(LogTarget.File)
        {
            logFilePath = @"C:\myLogData.txt";
        }
        /// <summary>
        /// The actual log method for logging
        /// </summary>
        /// <param name="message"></param>
        public override void Log(string message)
        {
            lock (DataLogger.LockObject)
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
        // connection url pointing to the database
        private readonly string connectionUrl = string.Empty;

        /// <summary>
        /// Default constructor
        /// </summary>
        public DatabaseDataLogger() : base(LogTarget.Database)
        {
            connectionUrl = ""; // do the database connection setup here by reading all the parameters from config file
            // perform db connection operation here
        }
        /// <summary>
        /// The actual log method to log all the data
        /// </summary>
        /// <param name="message"></param>
        public override void Log(string message)
        {
            lock (DataLogger.LockObject)
            {
                Console.WriteLine($"{nameof(DatabaseDataLogger)}: " + message);
                // code here to log data to the database
            }
        }
    }
    /// <summary>
    /// This class initializes the required logger and facilitates its usage
    /// </summary>
    class LogFactory : ILogCreator
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public LogFactory()  {}

        public IDataLogger GetDataLogger(string type)
        {
            switch (type)
            {
                case nameof(DatabaseDataLogger):
                    return Singleton<DatabaseDataLogger>.Instance;

                case nameof(FileDataLogger):
                    return Singleton<FileDataLogger>.Instance;

                default: return null;
            }
        }
    }

    /// <summary>
    /// Interface for formatting messages
    /// </summary>
    interface IMessageFormatter
    {
        void ApplyFormat();
        string GetFormattedString();
    }
    /// <summary>
    /// Concrete message formatter class to provide actual defintions to formatting of the messages
    /// </summary>
    public class MessageFormatter : IMessageFormatter
    {
        #region Variables
        System.Globalization.CultureInfo culture;
        private string message;
        #endregion
        #region Constructor
        public MessageFormatter(string message)
        {
            this.culture = new System.Globalization.CultureInfo("en-US");
            this.message = message;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// This method is actually respsonsible for formatting your messages on the go
        /// </summary>
        public void ApplyFormat()
        {
            message = String.Format(culture,"[{0}] :\t{1}", DateTime.Now, message);
        }
        /// <summary>
        /// Fetches the formatted string
        /// </summary>
        /// <returns></returns>
        public string GetFormattedString() => message;
        #endregion
    }

    /// <summary>
    /// LogDecorator class is an example of Decorator pattern
    /// </summary>
    class LogAdapter : IDataLogger
    {
        #region VARIABLES
        private IDataLogger dataLogger;
        #endregion
        #region CONSTRUCTOR
        public LogAdapter(IDataLogger dataLogger)
        {
            this.dataLogger = dataLogger;
        }
        #endregion
        #region PUBLIC METHODS
        public void Log(string message)
        {
            IMessageFormatter formatter = new MessageFormatter(message);
            formatter.ApplyFormat();
            dataLogger.Log(formatter.GetFormattedString());
        }
        #endregion
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

            logger = Singleton<LogFactory>.Instance.GetDataLogger(nameof(DatabaseDataLogger));
            logger.Log("this entry will go into database");

            logger = Singleton<LogFactory>.Instance.GetDataLogger(nameof(FileDataLogger));
            logger.Log("this entry will go into file");

            LogAdapter logAdapter = new LogAdapter(logger);
            logAdapter.Log("this entry will go into file but as a formatted string");
        }
        #endregion

    }
}