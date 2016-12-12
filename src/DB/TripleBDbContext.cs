using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;

namespace DB
{
    public class TripleBDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Boat> Boats { get; set; }
        public DbSet<BoatModel> BoatModels { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<TextBlock> NewsTexts { get; set; }
        public DbSet<Recall> Recalls { get; set; }     
        public DbSet<Rent> Rents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\\mssqllocaldb; Database = boatdb; Trusted_Connection = True; MultipleActiveResultSets = true");
        }
    }
}
