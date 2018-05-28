namespace Rental
{
    public interface IDiscount
    {
        decimal Apply(decimal value);
    }
}
