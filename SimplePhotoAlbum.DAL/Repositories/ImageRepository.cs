using Microsoft.EntityFrameworkCore;
using SimplePhotoAlbum.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplePhotoAlbum.DAL.Repositories
{
    public class ImageRepository : IRepository<PhotoImage>
    {
        private readonly ApplicationDb _db;
        public ImageRepository(ApplicationDb dbContext)
        {
            _db = dbContext;
        }

        public async Task CreateAsync(PhotoImage item)
        {
            await Task.FromResult(_db.PhotoImages.Add(item));
        }

        public async Task DeleteAsync(int id)
        {
            PhotoImage photoImage = await _db.PhotoImages.FindAsync(id);
            if (photoImage != null)
                await Task.FromResult(_db.PhotoImages.Remove(photoImage));
        }

        public async Task<PhotoImage> GetAsync(int id)
        {
            return await _db.PhotoImages.FindAsync(id);
        }

        public async Task<PhotoImage> GetByInfoIdAsync(int infoId)
        {
            return await _db.PhotoImages.FirstOrDefaultAsync(i => i.InfoId == infoId);
        }

        public async Task<IEnumerable<PhotoImage>> GetAllAsync(int limit, int offset)
        {
            return await _db.PhotoImages.Skip(limit * (offset - 1)).Take(limit).OrderBy(i => i.Id).ToListAsync();
        }

        public async Task<int> GetConuntAsync()
        {
            return await Task.FromResult(_db.PhotoImages.Count());
        }

        public async Task UpdateAsync(PhotoImage item)
        {
            await Task.FromResult(_db.Entry(item).State = EntityState.Modified);
        }
    }
}
