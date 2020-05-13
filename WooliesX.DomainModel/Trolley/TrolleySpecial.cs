using System.Collections.Generic;

namespace WooliesX.DomainModel.Trolley
{
    public class TrolleySpecial
    {
        public List<SpecialQuantity> Quantities { get; set; }

        public decimal Total { get; set; }
    }
}
