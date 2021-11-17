using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplePhotoAlbum.DAL.Repositories
{
    interface IRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAllAsync(int limit, int offset);
        Task<T> GetAsync(int id);
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
        Task<int> GetConuntAsync();
    }
}
