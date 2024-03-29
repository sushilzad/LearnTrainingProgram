﻿using ProgramTopics.Topic3;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProgramTopics.Collections
{
    /// <summary>
    /// This class is a collection of Product objects
    /// </summary>
    class Products : IEnumerable<Product>
    {
        #region MEMBER_VARIABLES
        readonly IEnumerable<Product> products;
        #endregion

        #region CTOR
        /// <summary>
        /// Parametrized constructor to initialize from the collection of array
        /// </summary>
        /// <param name="products"></param>
        public Products(Product[] products)
        {
            this.products = new List<Product>(products);
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// This enumerator gets invoked incase of Non-Generic collections are used for iteration
        /// </summary>
        /// <returns>IEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            Console.WriteLine("Using the Non-Generic Enumerator");
            //return this.products.GetEnumerator();
            return GetEnumerator();
        }
        IEnumerator<Product> IEnumerable<Product>.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region PUBLIC_METHODS
        /// <summary>
        /// This generic enumerator gets invoked incase of Generic collections are used for iteration
        /// </summary>
        /// <returns>IEnumerator<Product></returns>
        public ProductEnumerator GetEnumerator()
        {
            Console.WriteLine("Using the Generic Enumerator");
            //return this.products.GetEnumerator();
            return new ProductEnumerator(products);
        }

        #endregion
    }

    class ProductEnumerator : IEnumerator<Product>
    {
        int currentPosition = -1;
        private IEnumerable<Product> products;
        public ProductEnumerator(IEnumerable<Product> products)
        {
            this.products=products;
        }

        public Product Current => products.ElementAt(currentPosition);

        object IEnumerator.Current
        {
            get
            {
                try
                {
                    return Current;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public void Dispose()
        {
            this.currentPosition = -1;
            this.products = null;
        }

        public bool MoveNext()
        {
            currentPosition++;
            return currentPosition < products.Count();
        }

        public void Reset()
        {
            currentPosition = -1;
        }
    }

    /// <summary>
    /// This class demonstrates the useage of IEnumerator interface by its custom usage and modifications
    /// </summary>
    class ImplementingIEnumerator
    {
        #region PUBLIC_METHODS
        /// <summary>
        /// This method demonstrates the implemntation and the usage of IEnumerator interface to iterate over collection of entities
        /// </summary>
        public void DemonstrateUsageOfIEnumeratorInterfaceImplementation()
        {
            Product[] productsArr = new Product[]
            {
                new Product {Value = 55, Name = "Boroline"},
                new Product {Value = 75, Name = "Vaseline"},
                new Product {Value = 110, Name = "Gasoline"}
            };

            Products products = new Products(productsArr);
            Console.WriteLine("GetEnumerator() using ForEach loop");
            // The foreach loop uses the Generic GetEnumertor()
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("\nGetEnumerator() using traditional while loop and MoveNext() iterator");
            IEnumerator enumerator = ((IEnumerable)products).GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
        #endregion
    }
}
