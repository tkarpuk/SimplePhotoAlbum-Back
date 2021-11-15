using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimplePhotoAlbum.DAL.Entities;

namespace SimplePhotoAlbum.DAL.Configurations
{
    public class PotoInfoConfig : IEntityTypeConfiguration<PhotoInfo>
    {
        public void Configure(EntityTypeBuilder<PhotoInfo> builder)
        {
            builder.ToTable("photos");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Caption).IsRequired().HasMaxLength(50);
            builder.Property(i => i.Description).HasMaxLength(100);
            builder.HasOne(i => i.Image).WithOne(p => p.Info);
        }
    }
}
