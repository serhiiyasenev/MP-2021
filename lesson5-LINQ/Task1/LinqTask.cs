using System;
using System.Collections.Generic;
using System.Linq;
using Task1.DoNotChange;

namespace Task1
{
    public static class LinqTask
    {
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers
        )
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers
        )
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            /* Сгруппируйте все продукты по категориям, внутри – по наличию на складе, 
             * внутри последней группы отсортируйте по стоимости
             * example of Linq7result

             category - Beverages
	            UnitsInStock - 39
		            price - 19.0000
		            price - 18.0000
	            UnitsInStock - 17
		            price - 18.0000
		            price - 19.0000
             */
            var result = products
                .GroupBy(p => p.Category)
                .Select(c => new Linq7CategoryGroup
                {
                    Category = c.Key,
                    UnitsInStockGroup = c
                        .GroupBy(ug => ug.UnitsInStock)
                        .Select(ug => new Linq7UnitsInStockGroup
                        {
                            UnitsInStock = ug.Key,
                            Prices = ug.Select(u => u.UnitPrice)
                        })
                })
                .Select(group =>
                {
                    var stocks = group.UnitsInStockGroup.ToArray();
                    stocks.Last().Prices = stocks.Last().Prices.OrderBy(p => p);
                    group.UnitsInStockGroup = stocks;
                    return group;
                });

            return result;
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers
        )
        {
            throw new NotImplementedException();
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            throw new NotImplementedException();
        }
    }
}