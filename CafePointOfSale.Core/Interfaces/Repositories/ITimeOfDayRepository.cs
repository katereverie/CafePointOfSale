namespace CafePointOfSale.Core.Interfaces.Repositories
{
    public interface ITimeOfDayRepository
    {
        DateTime CurrentTime { get; }

        int GetTimeOfDayID();
    }
}
