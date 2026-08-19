
using LibraTrack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraTrack.Infrastructure.Data
{
    public class LibraryItemConfiguration : IEntityTypeConfiguration<LibraryItem>
    {
        public void Configure(EntityTypeBuilder<LibraryItem> builder)
        {
            builder.HasKey(li => li.ItemId);
            builder.Property(li => li.Title)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(li => li.IsAvailable)
                .HasDefaultValue(true);
            builder.HasDiscriminator<string>("ItemType")
                .HasValue<Book>("Book")
                .HasValue<Dvd>("Dvd")
                .HasValue<Magazine>("Magazine");
        }
    }
}
