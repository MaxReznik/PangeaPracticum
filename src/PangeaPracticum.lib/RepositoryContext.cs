using Microsoft.EntityFrameworkCore;
using PangeaPracticum.lib.Domain;

namespace PangeaPracticum.lib
{
    public class RepositoryContext: DbContext
    {
        public DbSet<Repo> Repos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
        }
    }
}
