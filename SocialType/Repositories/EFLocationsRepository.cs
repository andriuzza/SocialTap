using SocialType.Models;
using System.Linq;

namespace SocialType.Repositories
{
    // TODO kimutis : ?
    public class EFLocationsRepository: IRepository<Location>
    {
        MyDbContext db = new MyDbContext();
        public IQueryable<Location> GetAll()
        {
            return db.Locations; 
        }
    }
}