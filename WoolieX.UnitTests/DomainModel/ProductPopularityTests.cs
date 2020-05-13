using System;
using System.Collections.Generic;
using System.Linq;
using WooliesX.DomainModel;
using Xunit;

namespace WooliesX.UnitTests
{
    public class ProductPopularityTests
    {
        [Fact]
        public void Can_Calculate_Product_Popularity()
        {
            var orders = CreateOrders();

            var popularity = new ShopperHistory(orders).CalculatePopularity();

            Assert.Equal(6, popularity["ProductA"].QuantitySold);
            Assert.Equal(5, popularity["ProductB"].QuantitySold);
            Assert.Equal(7, popularity["ProductC"].QuantitySold);
        }

        [Fact]
        public void Can_Sort_Products_By_Popularity()
        {
            var history = new ShopperHistory(CreateOrders());

            var products = CreateProducts();
            var sortedProducts = history.SortProductsByPopularity(products).ToList();

            Assert.Equal("ProductC", sortedProducts[0].Name);
            Assert.Equal("ProductA", sortedProducts[1].Name);
            Assert.Equal("ProductB", sortedProducts[2].Name);
        }

        private List<Order> CreateOrders()
        {
            return new List<Order>()
            {
                new Order()
                {
                    Products = new List<Product>()
                    {
                        new Product{Name = "ProductA", Quantity = 3 },
                        new Product{Name = "ProductB", Quantity = 2 },
                    }
                },
                new Order()
                {
                    Products = new List<Product>()
                    {
                        new Product{Name = "ProductC", Quantity = 4 },
                        new Product{Name = "ProductA", Quantity = 3 },
                    }
                },
                new Order()
                {
                    Products = new List<Product>()
                    {
                        new Product{Name = "ProductC", Quantity = 3 },
                        new Product{Name = "ProductB", Quantity = 3 },
                    }
                }
            };
        }

        private List<Product> CreateProducts()
        {
            return new List<Product>
            {
                new Product{Name = "ProductA"},
                new Product{Name = "ProductB"},
                new Product{Name = "ProductC"}
            };
        }

    }
}