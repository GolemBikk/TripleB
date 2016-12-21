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
        public DbSet<Message> Messages { get; set; }     
        public DbSet<Rent> Rents { get; set; }

        ///// <summary>
        ///// Метод, необходимый для создания БД
        ///// </summary>
        ///// <param name="options"></param>
        //public TripleBDbContext(DbContextOptions<TripleBDbContext> options) : base(options)
        //{
        //}

        /// <summary>
        /// Метод, необходимый для подключения к БД
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=boatdb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
