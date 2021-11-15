using Microsoft.EntityFrameworkCore;
using SimplePhotoAlbum.DAL.Configurations;
using SimplePhotoAlbum.DAL.Entities;

namespace SimplePhotoAlbum.DAL
{
    public class ApplicationDb : DbContext
    {
        public DbSet<PhotoInfo> photoInfos { get; set; }
        public DbSet<PhotoImage> photoImages { get; set; }

        public ApplicationDb(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PotoInfoConfig());
            modelBuilder.ApplyConfiguration(new PhotoImageConfig());
        }

    }
}
