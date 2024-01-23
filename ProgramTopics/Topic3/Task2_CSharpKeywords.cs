using System;

namespace ProgramTopics.Topic3
{
    /// <summary>
    /// Interface for logging purpose
    /// </summary>
    interface ILogger
    {
        void LogToFile();
    }

    /// <summary>
    /// This is a sealed class which means it cannot be inherited furthermore
    /// </summary>
    sealed class Logger : ILogger
    {
        public Logger() { }

        /// <summary>
        /// Performs logging operation to the file
        /// </summary>
        public void LogToFile()
        {
            Console.WriteLine("Invoked the LogToFile() method of Logger's class.");
        }
    }

    /// <summary>
    /// This is a helper class which doesn't require to be instantiated and shall be used referencing the class name
    /// </summary>
    static class PageHelper
    {
        // static reference to Logger object which means only one instance will be created for it
        private static Logger currentLogger = null;

        /// <summary>
        /// static constructor gets invoked for the first time when the class is referenced
        /// </summary>
        static PageHelper()
        {
            Console.WriteLine("Usage of static keyword example: ");
            Console.WriteLine("This is PageHelper's static constructor which will be invoked only once");
            currentLogger = new Logger();
        }

        /// <summary>
        /// perform logging to file operation
        /// </summary>
        public static void LogToFile()
        {
            currentLogger.LogToFile();
        }

        /// <summary>
        /// Gets the current initialized Logger
        /// </summary>
        /// <returns>Logger</returns>
        public static Logger GetLogger() 
        {
            return currentLogger;
        }
    }

    /// <summary>
    /// This class focuses on demonstrating C Sharp keywords like, static, final (in C# --> const, readonly and sealed), finally, throw, break and continue, instance of etc.
    /// </summary>
    class Task2_CSharpKeywords
    {
        #region MEMBER_VARIABLES
        public const double PI_VALUE = 3.14;        // this is a constant value which remains immutable
        public readonly double DOUBLE_PI_VALUE;     // this is a special constant value which will be set at construction time
        #endregion

        #region CTOR
        public Task2_CSharpKeywords()
        {
            DOUBLE_PI_VALUE = PI_VALUE * 2;
        }
        #endregion

        #region PROPERTIES
        #endregion

        #region PRIVATE_METHODS
        #endregion

        #region PUBLIC_METHODS
        /// <summary>
        /// Method to perform some random operation using C Sharp keywords
        /// </summary>
        public void PerformOperationUsingCSharpKeywords()
        {
            PageHelper.LogToFile();

            // FINALLY EXAMPLE
            Logger logger;
            try
            {
                // BREAK AND CONTINUE
                int i;
                for (i = 10; i> 0; i--)
                {
                    if (i > 7)
                    {
                        Console.WriteLine($"{i} > 7. Yes! So skip this and jump to next iteration");
                        continue;
                    }
                    if (i == 5)
                    {
                        Console.WriteLine($"{i} == 5. The expected criteria is met so break the loop now");
                        break;
                    }
                }
                Console.WriteLine($"Value of i = {i}. Please note the value of i never reaches to 0 as the loop is breaked using Break keyword.");

                // TYPEOF() operator
                Type l1 = typeof(Logger);
                Type l2 = typeof(ILogger);

                if(l1 != l2)
                {
                    throw new Exception("The type of both are same");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Inside of Exception block after using the throw keyword");
                logger = PageHelper.GetLogger();

                Console.WriteLine("Since the Logger instance was null initially, now we've initialized it correctly");
            }
            finally
            {
                Console.WriteLine("This will be executed in finally block regardless of exception");
            }
        }
        #endregion
    }
}
