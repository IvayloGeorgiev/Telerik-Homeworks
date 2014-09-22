namespace AtmMachine.Data
{    
    using System.Data.Entity;

    using AtmMachine.Data.Migrations;
    using AtmMachine.Models;    

    public class AtmDbContext : DbContext, IAtmDbContext
    {
        public AtmDbContext() 
            : base("AtmMachineConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AtmDbContext, Configuration>());
        }

        public IDbSet<CardAccount> CardAccounts { get; set; }

        public IDbSet<TransactionHistory> TransactionHistorys { get; set; }


        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
