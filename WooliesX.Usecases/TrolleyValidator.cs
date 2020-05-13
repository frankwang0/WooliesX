using WooliesX.DomainModel.Trolley;

namespace WooliesX.Usecases
{
    public class TrolleyValidator : ITrolleyValidator
    {
        public bool Validate(ShoppingTrolley trolley)
        {
            // Todo: Validate products, specials and quantities
            return (trolley != null);
        }
    }
}
