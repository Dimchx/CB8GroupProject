﻿// <auto-generated />
using System;
using CB8_TeamYBD_GroupProject_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CB8_TeamYBD_GroupProject_MVC.Migrations
{
    [DbContext(typeof(CB8_TeamYBD_GroupProject_MVCContext))]
    [Migration("20190801041904_update3")]
    partial class update3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data.CB8_TeamYBD_GroupProject_MVCUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<bool>("Premium");

                    b.Property<byte[]>("ProfilePicture");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CB8_TeamYBD_GroupProject_MVC.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorId")
                        .IsRequired();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<bool>("Paid");

                    b.Property<DateTime>("PostDateTime");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("CB8_TeamYBD_GroupProject_MVC.Models.ArticleLike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArticleId");

                    b.Property<DateTime>("LikeDateTime");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("ArticleLikes");
                });

            modelBuilder.Entity("CB8_TeamYBD_GroupProject_MVC.Models.ArticlePurchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArticleId");

                    b.Property<DateTime>("PurchaseDateTime");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("ArticlePurchases");
                });

            modelBuilder.Entity("CB8_TeamYBD_GroupProject_MVC.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArticleId");

                    b.Property<DateTime>("CommentDateTime");

                    b.Property<string>("Content");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("CB8_TeamYBD_GroupProject_MVC.Models.CommentLike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CommentId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("UserId");

                    b.ToTable("CommentLikes");
                });

            modelBuilder.Entity("CB8_TeamYBD_GroupProject_MVC.Models.Follow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("FollowerId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("FollowerId");

                    b.HasIndex("UserId");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("CB8_TeamYBD_GroupProject_MVC.Models.Share", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArticleId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Shares");
                });

            modelBuilder.Entity("CB8_TeamYBD_GroupProject_MVC.Models.SubscriptionListing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DayDuration");

                    b.Property<int>("MonthDuration");

                    b.Property<double>("Price");

                    b.Property<string>("Title");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SubscriptionListings");
                });

            modelBuilder.Entity("CB8_TeamYBD_GroupProject_MVC.Models.UserSubcription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("SubscriberId");

                    b.Property<int?>("SubscriptionId");

                    b.HasKey("Id");

                    b.HasIndex("SubscriberId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("UserSubcriptions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CB8_TeamYBD_GroupProject_MVC.Models.Article", b =>
                {
                    b.HasOne("CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data.CB8_TeamYBD_GroupProject_MVCUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CB8_TeamYBD_GroupProject_MVC.Models.ArticleLike", b =>
                {
                    b.HasOne("CB8_TeamYBD_GroupProject_MVC.Models.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId");

                    b.HasOne("CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data.CB8_TeamYBD_GroupProject_MVCUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CB8_TeamYBD_GroupProject_MVC.Models.ArticlePurchase", b =>
                {
                    b.HasOne("CB8_TeamYBD_GroupProject_MVC.Models.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId");

                    b.HasOne("CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data.CB8_TeamYBD_GroupProject_MVCUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CB8_TeamYBD_GroupProject_MVC.Models.Comment", b =>
                {
                    b.HasOne("CB8_TeamYBD_GroupProject_MVC.Models.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId");

                    b.HasOne("CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data.CB8_TeamYBD_GroupProject_MVCUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CB8_TeamYBD_GroupProject_MVC.Models.CommentLike", b =>
                {
                    b.HasOne("CB8_TeamYBD_GroupProject_MVC.Models.Comment", "Comment")
                        .WithMany()
                        .HasForeignKey("CommentId");

                    b.HasOne("CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data.CB8_TeamYBD_GroupProject_MVCUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CB8_TeamYBD_GroupProject_MVC.Models.Follow", b =>
                {
                    b.HasOne("CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data.CB8_TeamYBD_GroupProject_MVCUser", "Follower")
                        .WithMany()
                        .HasForeignKey("FollowerId");

                    b.HasOne("CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data.CB8_TeamYBD_GroupProject_MVCUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CB8_TeamYBD_GroupProject_MVC.Models.Share", b =>
                {
                    b.HasOne("CB8_TeamYBD_GroupProject_MVC.Models.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId");

                    b.HasOne("CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data.CB8_TeamYBD_GroupProject_MVCUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CB8_TeamYBD_GroupProject_MVC.Models.SubscriptionListing", b =>
                {
                    b.HasOne("CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data.CB8_TeamYBD_GroupProject_MVCUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CB8_TeamYBD_GroupProject_MVC.Models.UserSubcription", b =>
                {
                    b.HasOne("CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data.CB8_TeamYBD_GroupProject_MVCUser", "Subscriber")
                        .WithMany()
                        .HasForeignKey("SubscriberId");

                    b.HasOne("CB8_TeamYBD_GroupProject_MVC.Models.SubscriptionListing", "Subscription")
                        .WithMany()
                        .HasForeignKey("SubscriptionId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data.CB8_TeamYBD_GroupProject_MVCUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data.CB8_TeamYBD_GroupProject_MVCUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data.CB8_TeamYBD_GroupProject_MVCUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data.CB8_TeamYBD_GroupProject_MVCUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
