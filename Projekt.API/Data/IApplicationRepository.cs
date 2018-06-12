using System.Collections.Generic;
using System.Threading.Tasks;
using Projekt.API.Models;

namespace Projekt.API.Data
{
    public interface IApplicationRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);
    }
}