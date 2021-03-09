using System;

namespace Task1
{
    public static class Utilities
    {
        /// <summary>
        /// Sorts an array in ascending order using bubble sort.
        /// </summary>
        /// <param name="array">Numbers to sort. Should not be null</param>
        public static void BubbleSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            var length = array.Length;

            for (var j = 0; j < length; j++)
            {
                for (var i = 0; i < length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        var x = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = x;
                    }
                }
            }
        }

        /// <summary>
        /// Searches for the index of a product in an <paramref name="products"/> 
        /// based on a <paramref name="predicate"/>.
        /// </summary>
        /// <param name="products">Products used for searching.</param>
        /// <param name="predicate">Product predicate.</param>
        /// <returns>If match found then returns index of product in <paramref name="products"/>
        /// otherwise -1.</returns>
        public static int IndexOf(Product[] products, Predicate<Product> predicate)
        {

            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            for (var i = 0; i < products.Length; i++)
            {
                var product = products[i];
                var isResultTrue = predicate(product);
                if (isResultTrue)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
