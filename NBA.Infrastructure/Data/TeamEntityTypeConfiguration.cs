using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NBA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.Infrastructure.Data
{
    public class TeamEntityTypeConfiguration : IEntityTypeConfiguration<Team>
    {
        private const string tableName = "Teams";
        
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable(tableName)
                .HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.City)
                .IsRequired()
                .HasMaxLength(200);

            builder.Ignore(t => t.FullName);
        }
    }
}
