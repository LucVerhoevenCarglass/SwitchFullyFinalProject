﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Swintake.domain.Data;

namespace Swintake.domain.Migrations
{
    [DbContext(typeof(SwintakeContext))]
    partial class SwintakeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Swintake.domain.Campaigns.Campaign", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ClassStartDate");

                    b.Property<string>("Client")
                        .HasMaxLength(60);

                    b.Property<string>("Comment")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasMaxLength(60);

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Campaigns");

                    b.HasData(
                        new { Id = new Guid("623a2cf0-fb14-4d72-8f85-cb880f8444f4"), ClassStartDate = new DateTime(2018, 12, 14, 15, 0, 23, 699, DateTimeKind.Local), Client = "CM", Comment = "cm comment", Name = "Java academy 2019", StartDate = new DateTime(2018, 12, 14, 15, 0, 23, 701, DateTimeKind.Local), Status = 1 }
                    );
                });

            modelBuilder.Entity("Swintake.domain.Candidates.Candidate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment")
                        .HasMaxLength(500);

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .HasMaxLength(60);

                    b.Property<string>("GitHubUsername")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .HasMaxLength(60);

                    b.Property<string>("LinkedIn")
                        .HasMaxLength(200);

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Candidates");

                    b.HasData(
                        new { Id = new Guid("fe8706d4-228d-4198-b2d9-c1357429c3b8"), Comment = "", Email = "gwen.jamroziak@cegeka.com", FirstName = "Gween", GitHubUsername = "gwenjamroziak", LastName = "Jamroziak", LinkedIn = "gwenjamroziak", PhoneNumber = "0472697959" }
                    );
                });

            modelBuilder.Entity("Swintake.domain.JobApplications.JobApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CampaignId");

                    b.Property<Guid>("CandiDateId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("CandiDateId");

                    b.ToTable("JobApplications");
                });

            modelBuilder.Entity("Swintake.domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = new Guid("6ea4d9e1-8014-417c-ad3a-f7c7a76902f9"), Email = "reinout@switchfully.com", FirstName = "Reinout" },
                        new { Id = new Guid("d4f24e23-efc6-4712-9020-fde8794905d3"), Email = "niels@switchfully.com", FirstName = "Niels" }
                    );
                });

            modelBuilder.Entity("Swintake.domain.JobApplications.JobApplication", b =>
                {
                    b.HasOne("Swintake.domain.Campaigns.Campaign", "Campaign")
                        .WithMany()
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Swintake.domain.Candidates.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandiDateId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Swintake.domain.Users.User", b =>
                {
                    b.OwnsOne("Swintake.domain.Users.UserSecurity", "UserSecurity", b1 =>
                        {
                            b1.Property<Guid?>("UserId");

                            b1.Property<string>("AppliedSalt")
                                .HasColumnName("AppliedSalt");

                            b1.Property<string>("PasswordHashedAndSalted")
                                .HasColumnName("PasswordHashed");

                            b1.ToTable("Users");

                            b1.HasOne("Swintake.domain.Users.User")
                                .WithOne("UserSecurity")
                                .HasForeignKey("Swintake.domain.Users.UserSecurity", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.HasData(
                                new { UserId = new Guid("6ea4d9e1-8014-417c-ad3a-f7c7a76902f9"), AppliedSalt = "NgBFEGiYlnKAVlAkBj6Qkg==", PasswordHashedAndSalted = "p1irTnDYNZBcCOfoph9UZaEmX5h4kd/UqkofgCUMMrA=" },
                                new { UserId = new Guid("d4f24e23-efc6-4712-9020-fde8794905d3"), AppliedSalt = "rODZhnBsLGRP908sBZiXzg==", PasswordHashedAndSalted = "TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=" }
                            );
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
