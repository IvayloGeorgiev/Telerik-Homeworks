namespace AtmMachine.Data
{
    using AtmMachine.Data.Repositories;
    using AtmMachine.Models;

    public interface IAtmData
    {
        IGenericRepository<CardAccount> CardAccounts { get; }

        IGenericRepository<TransactionHistory> TransactionHistorys { get; }
    }
}
