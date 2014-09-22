namespace AtmMachine.Data
{
    using System.Data.Entity;    
    using System.Data.Entity.Infrastructure;

    using AtmMachine.Models;

    public interface IAtmDbContext
    {       
        IDbSet<CardAccount> CardAccounts { get; set; }

        IDbSet<TransactionHistory> TransactionHistorys { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}