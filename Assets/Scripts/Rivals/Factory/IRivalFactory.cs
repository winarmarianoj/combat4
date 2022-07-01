namespace Rivals.factory
{
    public interface IRivalFactory
    {
        domain.impl.Rival Create(string rivalId);
    }
}