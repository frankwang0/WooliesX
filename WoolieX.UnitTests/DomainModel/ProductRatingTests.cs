using System;
using System.Collections.Generic;
using System.Linq;
using WooliesX.DomainModel;
using Xunit;

namespace WooliesX.UnitTests
{
    public class ProductSortingTests
    {
        [Fact]
        public void Can_Sort_Products_Ascendingly_By_Name()
        {
            var products = CreateProducts();

            var sortedProducts = new ProductSorter(products).Sort(SortOption.Ascending).ToList();

            Assert.Equal("ProductA", sortedProducts[0].Name);
            Assert.Equal("ProductB", sortedProducts[1].Name);
            Assert.Equal("ProductC", sortedProducts[2].Name);
        }

        [Fact]
        public void Can_Sort_Products_Descendingly_By_Name()
        {
            var products = CreateProducts();

            var sortedProducts = new ProductSorter(products).Sort(SortOption.Descending).ToList();

            Assert.Equal("ProductC", sortedProducts[0].Name);
            Assert.Equal("ProductB", sortedProducts[1].Name);
            Assert.Equal("ProductA", sortedProducts[2].Name);
        }

        [Fact]
        public void Can_Sort_Products_Ascendingly_By_Price()
        {
            var products = CreateProducts();

            var sortedProducts = new ProductSorter(products).Sort(SortOption.Low).ToList();

            Assert.Equal(10, sortedProducts[0].Price);
            Assert.Equal(20, sortedProducts[1].Price);
            Assert.Equal(50, sortedProducts[2].Price);
        }

        [Fact]
        public void Can_Sort_Products_Descendingly_By_Price()
        {
            var products = CreateProducts();

            var sortedProducts = new ProductSorter(products).Sort(SortOption.High).ToList();

            Assert.Equal(50, sortedProducts[0].Price);
            Assert.Equal(20, sortedProducts[1].Price);
            Assert.Equal(10, sortedProducts[2].Price);
        }

        private IEnumerable<Product> CreateProducts()
        {
            return new List<Product>()
            {
                new Product() { Name = "ProductA", Price = 20 },
                new Product() { Name = "ProductB", Price = 50 },
                new Product() { Name = "ProductC", Price = 10 }
            };
        }
    }
}
