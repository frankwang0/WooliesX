using WooliesX.DomainModel.Trolley;

namespace WooliesX.Usecases
{
    public interface ITrolleyValidator
    {
        bool Validate(ShoppingTrolley trolley);
    }
}