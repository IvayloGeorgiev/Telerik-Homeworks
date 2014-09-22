namespace AtmMachine.Data
{
    using System;
    using System.Collections.Generic;    

    using AtmMachine.Data.Repositories;
    using AtmMachine.Models;

    public class AtmData : IAtmData
    {
        private IAtmDbContext ctx;
        private IDictionary<Type, object> repositories;

        public AtmData()            
            : this(new AtmDbContext())
        {
        }

        public AtmData(IAtmDbContext ctx)
        {
            this.ctx = ctx;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<CardAccount> CardAccounts
        {
            get
            {
                return this.GetRepository<CardAccount>();
            }           
        }

        public IGenericRepository<TransactionHistory> TransactionHistorys
        {
            get
            {
                return this.GetRepository<TransactionHistory>();
            }           
        }

        public int SaveChanges()
        {
            return this.ctx.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.ctx));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
