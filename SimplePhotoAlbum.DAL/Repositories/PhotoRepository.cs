using Microsoft.EntityFrameworkCore;
using SimplePhotoAlbum.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SimplePhotoAlbum.DAL.Repositories
{
    public class PhotoRepository : IRepository<PhotoInfo>
    {
        private ApplicationDb _db;
        public PhotoRepository(ApplicationDb dbContext)
        {
            _db = dbContext;
        }

        public void Create(PhotoInfo item)
        {
            _db.PhotoInfos.Add(item);
        }

        public void Delete(int id)
        {
            PhotoInfo photoInfo = _db.PhotoInfos.Find(id);
            if (photoInfo != null)
                _db.PhotoInfos.Remove(photoInfo);
        }

        public PhotoInfo Get(int id)
        {
            return _db.PhotoInfos.Find(id);
        }

        public int GetConunt()
        {
            return _db.PhotoInfos.Count();
        }

        public IEnumerable<PhotoInfo> GetAll(int limit, int offset)
        {
            return _db.PhotoInfos.Skip(limit * (offset - 1)).Take(limit).OrderBy(p => p.Id);
        }

        public void Update(PhotoInfo item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
