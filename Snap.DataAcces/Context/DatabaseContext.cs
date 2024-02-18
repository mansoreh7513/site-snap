using System;
using System.Collections.Generic;
using System.Text;

using Snapp.DataAccessLayer.Entites;

using Microsoft.EntityFrameworkCore;

namespace Snapp.DataAccessLayer.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Factor> Factors { get; set; }
        public DbSet<Humidity> Humidities { get; set; }
        public DbSet<MonthType> MonthTypes { get; set; }
        public DbSet<PriceType> priceTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Temperature> temperatures { get; set; }
        public DbSet<Transact> Transacts { get; set; }

        public DbSet<TransactRate> TransactRates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddresse> UserAddresses { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<RateType> RateTypes { get; set; }
        public DbSet<Setting> Settings { get; set; }
    }
}
