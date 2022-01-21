using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

namespace server.Models {

    public class BankContext : DbContext {

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySQL(Config.GetConnectionString());
        }

    }
}