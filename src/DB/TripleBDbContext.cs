using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public TripleBDbContext(DbContextOptions<TripleBDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelbuilder);
        }
    }
}
