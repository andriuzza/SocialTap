using System.Linq;

namespace SocialType.Repositories
{
    public interface IRepository<T> where T: class /*where T means what constraint
        we will apply on, at this example we see it will be the class only waiting in this interface*/
    {
        IQueryable<T> GetAll();
    }
}