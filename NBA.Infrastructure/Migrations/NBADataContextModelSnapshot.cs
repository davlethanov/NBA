﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NBA.Infrastructure.Data;

namespace NBA.Infrastructure.Migrations
{
    [DbContext(typeof(NBADataContext))]
    partial class NBADataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NBA.ApplicationCore.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AwayTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("HomeTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.ToTable("Games", "NBA");
                });

            modelBuilder.Entity("NBA.ApplicationCore.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Players", "NBA");
                });

            modelBuilder.Entity("NBA.ApplicationCore.Models.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Teams", "NBA");
                });

            modelBuilder.Entity("NBA.ApplicationCore.Models.Game", b =>
                {
                    b.HasOne("NBA.ApplicationCore.Models.Team", "AwayTeam")
                        .WithMany()
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("NBA.ApplicationCore.Models.Team", "HomeTeam")
                        .WithMany()
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("NBA.ApplicationCore.Models.Score", "Score", b1 =>
                        {
                            b1.Property<Guid>("GameId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("AwayTeamResult")
                                .HasColumnType("int");

                            b1.Property<int>("AwayTeamScore")
                                .HasColumnType("int");

                            b1.Property<int>("HomeTeamResult")
                                .HasColumnType("int");

                            b1.Property<int>("HomeTeamScore")
                                .HasColumnType("int");

                            b1.HasKey("GameId");

                            b1.ToTable("Games", "NBA");

                            b1.WithOwner()
                                .HasForeignKey("GameId");
                        });

                    b.Navigation("AwayTeam");

                    b.Navigation("HomeTeam");

                    b.Navigation("Score");
                });

            modelBuilder.Entity("NBA.ApplicationCore.Models.Player", b =>
                {
                    b.OwnsOne("NBA.ApplicationCore.Models.TeamIdentity", "TeamIdentity", b1 =>
                        {
                            b1.Property<Guid>("PlayerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Number")
                                .HasColumnType("int");

                            b1.Property<Guid>("TeamId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("PlayerId");

                            b1.HasIndex("TeamId");

                            b1.ToTable("Players", "NBA");

                            b1.WithOwner()
                                .HasForeignKey("PlayerId");

                            b1.HasOne("NBA.ApplicationCore.Models.Team", "Team")
                                .WithMany()
                                .HasForeignKey("TeamId")
                                .OnDelete(DeleteBehavior.Restrict)
                                .IsRequired();

                            b1.Navigation("Team");
                        });

                    b.Navigation("TeamIdentity");
                });
#pragma warning restore 612, 618
        }
    }
}