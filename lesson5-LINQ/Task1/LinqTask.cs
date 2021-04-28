using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Task1.DoNotChange;

namespace Task1
{
    public static class LinqTask
    {
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            var result = customers.Where(c => c.Orders.Sum(o => o.Total) > limit);
            return result;
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(IEnumerable<Customer> customers, IEnumerable<Supplier> suppliers)
        {
            var result = customers.Select(c => (c, suppliers.Where(s => s.Country == c.Country && s.City == c.City)));
            return result;
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(IEnumerable<Customer> customers, IEnumerable<Supplier> suppliers)
        {
            var result = customers.GroupJoin(suppliers,
                 customer      => new { customer.City, customer.Country },
                 innerSupplier => new { innerSupplier.City, innerSupplier.Country },
                 (selectedCustomer, innerSupplier) => (selectedCustomer, innerSupplier));
            return result;
        }

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            var result = customers.Where(c => c.Orders.Any(o => o.Total > limit));
            return result;
        }


        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(IEnumerable<Customer> customers)
        {
            var result = customers.Where(c => c.Orders.Length > 0).Select(c => (c, c.Orders.Min(o => o.OrderDate)));
            return result;
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(IEnumerable<Customer> customers)
        {
            var result = customers
                .Where(c => c.Orders.Length > 0)
                .Select(c => (c, c.Orders.Min(o => o.OrderDate)))
                .OrderBy(cd => cd.Item2.Year)
                .ThenBy(cd => cd.Item2.Month)
                .ThenByDescending(cd => cd.c.Orders.Sum(o => o.Total))
                .ThenBy(cd => cd.c.CompanyName);

            return result;
        }

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            var result = customers.Where(c =>
                Regex.IsMatch(c.PostalCode, @"[A-Za-z]+") 
                || !Regex.IsMatch(c.Phone, @"^\(.*?\)") 
                || c.Region == string.Empty || c.Region == null
                );

            return result;
        }

        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            /* Сгруппируйте все продукты по категориям,
             * внутри – по наличию на складе, 
             * внутри последней группы отсортируйте по стоимости
             * example
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
                });

            return result;
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(IEnumerable<Product> products, decimal cheap, decimal middle, decimal expensive)
        {
            var result = products.GroupBy(p => new
            {
                isCheap = p.UnitPrice <= cheap,
                isMiddle = p.UnitPrice <= middle & p.UnitPrice > cheap,
                isExpensive = p.UnitPrice <= expensive & p.UnitPrice > middle
            }).Select(g => 
                g.Key.isExpensive 
                ? (expensive, g.AsEnumerable()) 
                : g.Key.isMiddle 
                    ? (middle, g.AsEnumerable()) 
                    : (cheap, g.AsEnumerable())).ToList();

            return result;
        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(IEnumerable<Customer> customers)
        {
            var result = customers
                .GroupBy(c => c.City)
                .Select(g => 
                    (g.Key, 
                        (int)Math.Round(g.Average(c => c.Orders.Sum(o => o.Total))), 
                        (int)Math.Round(g.Average(c => c.Orders.Length))));
            
            return result;
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            var result = string.Join("", suppliers
                .Select(s => s.Country)
                .Distinct()
                .OrderBy(c => c.Length)
                .ThenBy(c => c?[0]));

            return result;
        }
    }
}