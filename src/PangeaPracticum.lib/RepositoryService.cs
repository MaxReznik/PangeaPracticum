using Microsoft.EntityFrameworkCore;
using PangeaPracticum.lib.Domain;
using System.Linq;

namespace PangeaPracticum.lib
{
    public interface IRepositoryService
    {
        Repo[] GetAll();
        void SaveAll(Repo[] repo);
    }

    public class RepositoryService : IRepositoryService
    {
        public Repo[] GetAll()
        {
            using (var context = new RepositoryContext())
            {
                return context.Repos.Include(x=>x.owner).Include(x=>x.permissions).ToArray();
            }
        }

        public void SaveAll(Repo[] repo)
        {
            using (var context = new RepositoryContext())
            {
                context.Database.EnsureCreated();

                foreach (var r in repo)
                    context.Repos.Add(r);
                context.SaveChanges();
            }
        }
    }
}
