using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCPAO.PhotoManager.Data.Config
{
	public class PhotoConfig : IEntityTypeConfiguration<Photo>
	{
		public void Configure(EntityTypeBuilder<Photo> builder)
		{
			builder.HasKey(e => e.PhotoId);
			builder.Property(e => e.PropertyId);
			builder.Property(e => e.BuildingId);
			builder.Property(e => e.UserId).IsRequired();
			builder.Property(e => e.BuildingSeq);
			builder.Property(e => e.ImageData).IsRequired();
			builder.Property(e => e.ImageName).HasMaxLength(20);
			builder.Property(e => e.ImageSize);
			builder.Property(e => e.DateTaken);
			builder.Property(e => e.UploadedDate).IsRequired();
			builder.Property(e => e.UploadedBy).HasMaxLength(20).IsRequired();
			builder.Property(e => e.MasterPhoto);
			builder.Property(e => e.FrontPhoto);
			builder.Property(e => e.PublicPhoto);
			builder.Property(e => e.Status).HasMaxLength(10).IsRequired();
			builder.Property(e => e.Active);
			//builder.HasOne(d => d.UploadedByUser).WithMany(p => p.Photos).HasForeignKey(d => d.UserId);
			builder.ToTable("Photos");
		}
	}
}
