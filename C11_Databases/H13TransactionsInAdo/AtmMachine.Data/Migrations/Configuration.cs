namespace AtmMachine.Data.Migrations
{    
    using System;    
    using System.Data.Entity.Migrations;
    using System.Linq;

    using AtmMachine.Models;

    public sealed class Configuration : DbMigrationsConfiguration<AtmDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

        }

        protected override void Seed(AtmDbContext context)
        {
            if (context.CardAccounts.Count() == 0)
            {
                this.SeedCardAccounts(context);
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        private void SeedCardAccounts(AtmDbContext context)
        {
            context.CardAccounts.Add(new CardAccount()
            {
                CardCash = 1000.50m,
                CardNumber = "9712594242",
                CardPin = "9942"
            });

            context.CardAccounts.Add(new CardAccount()
            {
                CardCash = 400000m,
                CardNumber = "1234567890",
                CardPin = "5231"
            });

            context.CardAccounts.Add(new CardAccount()
            {
                CardCash = 500.23m,
                CardNumber = "1111111111",
                CardPin = "0000"
            });

            context.CardAccounts.Add(new CardAccount()
            {
                CardCash = 1251.72m,
                CardNumber = "4621235109",
                CardPin = "9120"
            });

            context.CardAccounts.Add(new CardAccount()
            {
                CardCash = 400.50m,
                CardNumber = "7712499202",
                CardPin = "8888"
            });

            context.CardAccounts.Add(new CardAccount()
            {
                CardCash = 10000000.01m,
                CardNumber = "0099887766",
                CardPin = "4444"
            });

            context.CardAccounts.Add(new CardAccount()
            {
                CardCash = 3.50m,
                CardNumber = "4444455555",
                CardPin = "1234"
            });
        }
    }
}
