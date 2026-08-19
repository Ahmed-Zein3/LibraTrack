using LibraTrack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraTrack.Infrastructure.Data.Configurations
{
    public class LoanRecordConfiguration : IEntityTypeConfiguration<LoanRecord>
    {
        public void Configure(EntityTypeBuilder<LoanRecord> builder)
        {
            builder.HasKey(l => l.LoanId);

            builder.Property(l => l.DueDate)
                .IsRequired();

            builder.Property(l => l.ReturnedDate)
                .IsRequired(false);

            builder.HasOne(l => l.Member)
                .WithMany()
                .HasForeignKey(l => l.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.Item)
                .WithMany()
                .HasForeignKey(l => l.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(l => l.MemberId);
        }
    }
}