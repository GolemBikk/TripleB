using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DB
{
    public class TripleBDbContextFactory : IDbContextFactory<TripleBDbContext>
    {
        /// <summary>
        /// Метод, необходимый для использования миграций. Не нужен при дальнейших подключениях
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public TripleBDbContext Create(DbContextFactoryOptions options)
        {
            //var builder = new DbContextOptionsBuilder<TripleBDbContext>();
            //builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=boatdb;Trusted_Connection=True;MultipleActiveResultSets=true");
            //return new TripleBDbContext(builder.Options);
            throw new ArgumentNullException();
        }
    }
}
