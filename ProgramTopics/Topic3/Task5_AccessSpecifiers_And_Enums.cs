using System;

namespace ProgramTopics.Topic3
{
    /// <summary>
    /// This class demonstrates the usage of access specifier 
    /// </summary>
    class AccessSpecifier
    {
        #region MEMBER_VARIABLES
        private int privateValue = 100;
        protected int protectedValue = 200;
        public int publicValue = 300;
        internal int internalValue = 400;
        internal protected int internalProtectedValue = 500;
        #endregion

        #region CTOR
        /// <summary>
        /// Default constructor
        /// </summary>
        public AccessSpecifier() {}
        #endregion

        private void TryModifyingPrivateValue()
        {
            Console.WriteLine("Private value before change: " + privateValue);
            privateValue = 999;
            Console.WriteLine("Private value after change: " + privateValue);
        }
        protected void TryModifyingProtectedValue()
        {
            Console.WriteLine("Protected value before change: " + protectedValue);
            protectedValue = 999;
            Console.WriteLine("Protected value after change: " + protectedValue);
        }
        public void TryModifyingPublicValue()
        {
            Console.WriteLine("Public value before change: " + publicValue);
            publicValue = 999;
            Console.WriteLine("Public value after change: " + publicValue);
        }
        internal void TryModifyingInternalValue()
        {
            Console.WriteLine("Internal value before change: " + internalValue);
            internalValue = 999;
            Console.WriteLine("Internal value after change: " + internalValue);
        }
        protected internal void TryModifyingProtectedInternalValue()
        {
            Console.WriteLine("Protected Internal value before change: " + internalProtectedValue);
            internalProtectedValue = 999;
            Console.WriteLine("Protected Internal value after change: " + internalProtectedValue);
        }
    }

    /// <summary>
    /// This class demonstrates the behavior of access specifier
    /// </summary>
    class Task5_AccessSpecifiers_And_Enums : AccessSpecifier
    {
        /// <summary>
        /// Enums indicating three states of an entity
        /// </summary>
        enum Level
        {
            None = 0,       // 0
            Low,            // 1
            Medium = 5,     // 5
            High            // 6
        }

        #region PUBLIC_METHODS
        /// <summary>
        /// Demonstrate the usage of access specifiers and enums
        /// </summary>
        public void PerformAccessSpecifierDemo()
        {
            // ACCESS MODIFIERS
            Task5_AccessSpecifiers_And_Enums accessSpecifier = new Task5_AccessSpecifiers_And_Enums();
            accessSpecifier.TryModifyingProtectedValue();
            accessSpecifier.TryModifyingPublicValue();
            accessSpecifier.TryModifyingInternalValue();
            accessSpecifier.TryModifyingProtectedInternalValue();

            // ENUMS
            Level myVar = Level.High;
            int myValue = (int)Level.High;
            Console.WriteLine("\nSelected enum level is: " + myVar);
            Console.WriteLine("Selected integer value is: " + myValue);
            switch (myVar)
            {
                case Level.None:
                    Console.WriteLine("None");
                    break;
                case Level.Low:
                    Console.WriteLine("Low level");
                    break;
                case Level.Medium:
                    Console.WriteLine("Medium level");
                    break;
                case Level.High:
                    Console.WriteLine("High level");
                    break;
            }
        }
        #endregion
    }
}
