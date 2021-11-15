using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimplePhotoAlbum.DAL.Entities;

namespace SimplePhotoAlbum.DAL.Configurations
{
    public class PhotoImageConfig : IEntityTypeConfiguration<PhotoImage>
    {
        public void Configure(EntityTypeBuilder<PhotoImage> builder)
        {
            builder.ToTable("images");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ImageType).IsRequired().HasMaxLength(20);
            builder.Property(p => p.FileName).IsRequired().HasMaxLength(50);
            builder.HasOne(p => p.Info).WithOne(i => i.Image).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
