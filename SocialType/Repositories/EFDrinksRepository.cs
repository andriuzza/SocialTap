using SocialType.Models;
using System.Linq;
namespace SocialType.Repositories
{
    public class EFDrinksRepository: IRepository<Drink>
    {
        MyDbContext db = new MyDbContext();
        /*IQueryable works on client side */
        public IQueryable<Drink> GetAll()
        {
            return db.drinks;
        }
    }
}