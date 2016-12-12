using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DB
{
    public class TripleBDbContextFactory : IDbContextFactory<TripleBDbContext>
    {
        public TripleBDbContext Create(DbContextFactoryOptions options)
        {
            //var builder = new DbContextOptionsBuilder<TripleBDbContext>();
            //builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=boatdb;Trusted_Connection=True;MultipleActiveResultSets=true");
            //return new TripleBDbContext(builder.Options);
            throw new ArgumentNullException();
        }
    }
}
