using System.Collections.Generic;
using System.Linq;

namespace WooliesX.DomainModel.Trolley
{
    public class ShoppingTrolley
    {
        public ShoppingTrolley()
        {
            // Todo: refactor to use Dictionary internally. 
            // As we might run into CPU usage issue because of excessive lookups in List

            Products = new List<TrolleyProduct>();
            Specials = new List<TrolleySpecial>();
            Quantities = new List<TrolleyQuantity>();
        }

        public List<TrolleyProduct> Products { get; set; }

        public List<TrolleySpecial> Specials { get; set; }

        public List<TrolleyQuantity> Quantities { get; set; }

        public decimal CalculateTotal()
        {
            var lowestTotal = CalculateLowestTotalWithSpecials();

            // Sanity check
            var totalWithoutSpecials = CalculateTotalWithoutSpecials();
            if (lowestTotal == 0 || lowestTotal > totalWithoutSpecials)
            {
                lowestTotal = totalWithoutSpecials;
            }

            return lowestTotal;
        }

        private decimal CalculateLowestTotalWithSpecials()
        {
            var trolleyTotals = new List<decimal>();

            foreach (var special in Specials)
            {
                if (ShouldApplySpecial(special))
                {
                    var factor = FindBestFactorForSpecial(special);

                    var total = CalculateTotalUsingSpecial(factor, special);

                    trolleyTotals.Add(total);
                }
            }

            return trolleyTotals.Count() != 0 ? trolleyTotals.Min() : 0;
        }

        private int FindBestFactorForSpecial(TrolleySpecial special)
        {
            var factors = CalculateFactors(special);

            return FindBestFactor(factors, special);
        }

        private bool ShouldApplySpecial(TrolleySpecial special)
        {
            foreach (var trolleyQuantity in Quantities)
            {
                var specialQuantity = special.Quantities.First(x => x.Name == trolleyQuantity.Name);
                if (specialQuantity.Quantity > trolleyQuantity.Quantity)
                    return false;
            }

            return true;
        }

        private decimal CalculateTotalUsingSpecial(int factor, TrolleySpecial special)
        {
            var total = special.Total * factor;

            foreach (var trolleyQuantity in Quantities)
            {
                var specialQuantity = special.Quantities.First(x => x.Name == trolleyQuantity.Name);
                var remainingQuantity = trolleyQuantity.Quantity - specialQuantity.Quantity * factor;

                if (remainingQuantity > 0)
                {
                    var price = Products.First(x => x.Name == trolleyQuantity.Name).Price;
                    total += price * remainingQuantity;
                }
            }

            return total;
        }

        private decimal CalculateTotalWithoutSpecials()
        {
            var total = 0m;

            foreach (var trolleyQuantity in Quantities)
            {
                var price = Products.First(x => x.Name == trolleyQuantity.Name).Price;
                total += trolleyQuantity.Quantity * price;
            }

            return total;
        }

        public List<int> CalculateFactors(TrolleySpecial special)
        {
            var factors = new List<int>();

            foreach (var trolleyQuantity in Quantities)
            {
                var specialQuantity = special.Quantities.First(x => x.Name == trolleyQuantity.Name);
                var factor = trolleyQuantity.Quantity / specialQuantity.Quantity;
                factors.Add(factor);
            }

            return factors;
        }

        private int FindBestFactor(List<int> factors, TrolleySpecial special)
        {
            var bestFactor = 1;
            foreach (var factor in factors)
            {
                if (factor > bestFactor && CanApplyFactorAcrossSpecial(factor, special))
                {
                    bestFactor = factor;
                }
            }

            return bestFactor;
        }

        private bool CanApplyFactorAcrossSpecial(int factor, TrolleySpecial special)
        {
            foreach (var trolleyQuantity in Quantities)
            {
                var specialQuantity = special.Quantities.First(x => x.Name == trolleyQuantity.Name);

                if (specialQuantity.Quantity * factor > trolleyQuantity.Quantity)
                {
                    return false;
                }
            }

            return true;
        }
    }
}