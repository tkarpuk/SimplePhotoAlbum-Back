using SimplePhotoAlbum.DAL.Repositories;
using System;

namespace SimplePhotoAlbum.DAL
{
    public class UnitOfWork : IDisposable
    {
        private bool _disposed = false;
        private readonly ApplicationDb _db;
        private PhotoRepository _photoRepository;
        private ImageRepository _imageRepository;

        public UnitOfWork(ApplicationDb db)
        {
            _db = db;
        }

        public PhotoRepository PhotoRepository 
        { 
            get
            {
                if (_photoRepository == null)
                    _photoRepository = new PhotoRepository(_db);
                return _photoRepository; 
            }
        }

        public ImageRepository ImageRepository
        {
            get
            {
                if (_imageRepository == null)
                    _imageRepository = new ImageRepository(_db);
                return _imageRepository;
            }
        }
        
        public void SaveAll()
        {
            _db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
