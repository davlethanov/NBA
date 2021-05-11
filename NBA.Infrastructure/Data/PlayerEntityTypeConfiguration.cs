using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NBA.Domain.Entities;

namespace NBA.Infrastructure.Data
{
    public class PlayerEntityTypeConfiguration : IEntityTypeConfiguration<Player>
    {
        private const string tableName = "Players";
        
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable(tableName)
                .HasKey(p => p.Id);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.SecondName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.BirthDate)
                .IsRequired();

            builder.OwnsOne(p => p.TeamIdentity)
                .Property(q => q.TeamId)
                .IsRequired();

            builder.OwnsOne(p => p.TeamIdentity)
                .Property(q => q.Number)
                .IsRequired();

            builder.OwnsOne(p => p.TeamIdentity)
                .HasOne(q => q.Team)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
