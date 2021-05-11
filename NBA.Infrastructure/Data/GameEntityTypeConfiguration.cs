using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NBA.Domain.Entities;

namespace NBA.Infrastructure.Data
{
    class GameEntityTypeConfiguration : IEntityTypeConfiguration<Game>
    {
        private const string tableName = "Games";
        
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable(tableName)
                .HasKey(g => g.Id);

            builder.Property(g => g.AwayTeamId)
                .IsRequired();

            builder.Property(g => g.HomeTeamId)
                .IsRequired();

            builder.Property(g => g.Date)
                .IsRequired();

            builder.OwnsOne(g => g.Score)
                .Property(q => q.AwayTeamScore)
                .IsRequired();

            builder.OwnsOne(g => g.Score)
                .Property(q => q.HomeTeamScore)
                .IsRequired();

            builder.OwnsOne(g => g.Score)
                .Property(q => q.AwayTeamResult)
                .IsRequired();

            builder.OwnsOne(g => g.Score)
                .Property(q => q.HomeTeamResult)
                .IsRequired();

            builder.HasOne(g => g.AwayTeam)
                .WithMany()
                .HasForeignKey(g => g.AwayTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.HomeTeam)
               .WithMany()
               .HasForeignKey(g => g.HomeTeamId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
