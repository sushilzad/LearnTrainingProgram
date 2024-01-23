using System;

namespace ProgramTopics.Topic3
{
    /// <summary>
    /// CustomClass demonstrating the usage of overloaded '==' operator
    /// </summary>
    public class Product
    {
        #region Constructor
        public Product()
        {
            Value = 1;
            Name = string.Empty;
        }
        public Product(int Value, string Name)
        {
            this.Value = Value;
            this.Name = Name;
        }
        #endregion

        #region Properties
        public int Value { get; set; }
        public string Name { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Overload the == operator to define the meaning of comparing the objects values
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>bool</returns>
        public static bool operator ==(Product a, Product b)
        {
            return a.Value == b.Value && a.Name.Equals(b.Name);
        }
        /// <summary>
        /// Overload the != operator to define the meaning of comparing unequal objects values
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>bool</returns>
        public static bool operator !=(Product a, Product b)
        {
            return !(a == b);
        }

        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType()) return false;

            Product p = (Product)obj;
            return (this.Value == p.Value) && (this.Name == p.Name);
        }
        public override int GetHashCode()
        {
            return this.Value.GetHashCode() ^ this.Name.GetHashCode();
        }
        public override string ToString()
        {
            return $"Product[Name: {this.Name}, Value: {this.Value}]";
        }
        #endregion
        #endregion

    }

    /// <summary>
    /// This class demonstrates the usage of object comparison in .Net
    /// </summary>
    class Task10_ObjectComparison
    {
        #region PUBLIC_METHODS
        /// <summary>
        /// This method demonstrates the usage of object comparison operation in .Net
        /// </summary>
        public void DemonstrateCompareOperation()
        {
            Console.WriteLine("COMPARISON OF THE OBJECTS WITH SAME REFERENCES SCENARIO: ");
            // COMPARISON OF THE OBJECTS WITH SAME REFERENCES SCENARIO
            Product foo = new Product { Value = 10, Name = "foo" };
            Product loo = new Product();
            loo = foo;

            Console.WriteLine("Foo = " + foo.ToString());
            Console.WriteLine("Loo = " + loo.ToString());
            Console.WriteLine("Foo Hashcode = " + foo.GetHashCode());
            Console.WriteLine("Loo Hashcode = " + loo.GetHashCode());

            var valueEqual = foo.Equals(loo);
            Console.WriteLine("\nfoo.Equals(loo): " + valueEqual);

            var objRefEqual = Object.ReferenceEquals(foo, loo);
            Console.WriteLine("Object.ReferenceEquals(foo, loo): " +objRefEqual);

            var objEqual = Object.Equals(foo, loo);
            Console.WriteLine("Object.Equals(foo, loo): " + objEqual);

            bool isEquals = foo == loo;
            Console.WriteLine("foo == loo: " + isEquals);

            Console.WriteLine("\n\nCOMPARISON OF THE OBJECTS WITH DIFFERENT REFERENCES SCENARIO: ");
            // COMPARISON OF THE OBJECTS WITH DIFFERENT REFERENCES SCENARIO
            foo = new Product { Value = 20, Name = "zoo" };
            loo = new Product();
            loo.Value = 20;
            loo.Name = "zoo";

            Console.WriteLine("Foo = " + foo.ToString());
            Console.WriteLine("Loo = " + loo.ToString());
            Console.WriteLine("Foo Hashcode = " + foo.GetHashCode());
            Console.WriteLine("Loo Hashcode = " + loo.GetHashCode());

            valueEqual = foo.Equals(loo);
            Console.WriteLine("\nfoo.Equals(loo): " + valueEqual);

            objRefEqual = Object.ReferenceEquals(foo, loo);
            Console.WriteLine("Object.ReferenceEquals(foo, loo): " + objRefEqual);

            objEqual = Object.Equals(foo, loo);
            Console.WriteLine("Object.Equals(foo, loo): " + objEqual);

            isEquals = foo == loo;
            Console.WriteLine("foo == loo: " + isEquals);
        }
        #endregion
    }
}
