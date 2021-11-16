using Microsoft.EntityFrameworkCore;
using SimplePhotoAlbum.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SimplePhotoAlbum.DAL.Repositories
{
    public class ImageRepository : IRepository<PhotoImage>
    {
        private ApplicationDb _db;
        public ImageRepository(ApplicationDb dbContext)
        {
            _db = dbContext;
        }

        public void Create(PhotoImage item)
        {
            _db.PhotoImages.Add(item);
        }

        public void Delete(int id)
        {
            PhotoImage photoImage = _db.PhotoImages.Find(id);
            if (photoImage != null)
                _db.PhotoImages.Remove(photoImage);
        }

        public PhotoImage Get(int id)
        {
            return _db.PhotoImages.Find(id);
        }

        public PhotoImage GetByInfoId(int infoId)
        {
            return _db.PhotoImages.FirstOrDefault(i => i.InfoId == infoId);
        }

        public IEnumerable<PhotoImage> GetAll(int limit, int offset)
        {
            return _db.PhotoImages.Skip(limit * (offset - 1)).Take(limit).OrderBy(i => i.Id);
        }

        public int GetConunt()
        {
            return _db.PhotoImages.Count();
        }

        public void Update(PhotoImage item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
