using Microsoft.EntityFrameworkCore;
using SimplePhotoAlbum.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplePhotoAlbum.DAL.Repositories
{
    public class PhotoRepository : IRepository<PhotoInfo>
    {
        private readonly ApplicationDb _db;
        public PhotoRepository(ApplicationDb dbContext)
        {
            _db = dbContext;
        }

        public async Task CreateAsync(PhotoInfo item)
        {
            await Task.FromResult(_db.PhotoInfos.Add(item));
        }

        public async Task DeleteAsync(int id)
        {
            PhotoInfo photoInfo = await _db.PhotoInfos.FindAsync(id);
            if (photoInfo != null)
                await Task.FromResult(_db.PhotoInfos.Remove(photoInfo));
        }

        public async Task<PhotoInfo> GetAsync(int id)
        {
            return await _db.PhotoInfos.FindAsync(id);
        }

        public async Task<int> GetConuntAsync()
        {
            return await Task.FromResult(_db.PhotoInfos.Count());
        }

        public async Task<IEnumerable<PhotoInfo>> GetAllAsync(int limit, int offset)
        {
            return await _db.PhotoInfos.Skip(limit * (offset - 1)).Take(limit).OrderBy(p => p.Id).ToListAsync();
        }

        public async Task UpdateAsync(PhotoInfo item)
        {
            await Task.FromResult(_db.Entry(item).State = EntityState.Modified);
        }
    }
}
