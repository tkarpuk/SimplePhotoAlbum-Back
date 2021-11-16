using System.Collections.Generic;

namespace SimplePhotoAlbum.DAL.Repositories
{
    interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll(int limit, int offset);
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        int GetConunt();
    }
}
