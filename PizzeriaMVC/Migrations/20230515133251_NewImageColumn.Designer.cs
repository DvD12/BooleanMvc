﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzeriaMVC;

#nullable disable

namespace PizzeriaMVC.Migrations
{
    [DbContext(typeof(PizzaContext))]
    [Migration("20230515133251_NewImageColumn")]
    partial class NewImageColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IngredientModelPizzaModel", b =>
                {
                    b.Property<long>("IngredientiId")
                        .HasColumnType("bigint");

                    b.Property<long>("PizzeId")
                        .HasColumnType("bigint");

                    b.HasKey("IngredientiId", "PizzeId");

                    b.HasIndex("PizzeId");

                    b.ToTable("IngredientModelPizzaModel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            ConcurrencyStamp = "11/05/2023",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            ConcurrencyStamp = "11/05/2023",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PizzeriaMVC.Models.CategoryModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Descrizione = "A pizza with a traditional flavor profile that includes a tomato-based sauce, cheese, and a variety of classic toppings.",
                            Nome = "Classic"
                        },
                        new
                        {
                            Id = 2L,
                            Descrizione = "A pizza that excludes any meat-based toppings and includes a range of vegetables and cheeses.",
                            Nome = "Vegetarian"
                        },
                        new
                        {
                            Id = 3L,
                            Descrizione = "A pizza that is entirely plant-based and excludes any animal-based products.",
                            Nome = "Vegan"
                        },
                        new
                        {
                            Id = 4L,
                            Descrizione = "A pizza made with premium ingredients and unique flavor combinations that go beyond traditional toppings.",
                            Nome = "Gourmet"
                        },
                        new
                        {
                            Id = 5L,
                            Descrizione = "A sweet pizza made with dessert toppings, such as fruit, chocolate, or caramel, and a crust that may be sweetened with sugar or honey.",
                            Nome = "Dessert"
                        });
                });

            modelBuilder.Entity("PizzeriaMVC.Models.ImageEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("ImageEntries");
                });

            modelBuilder.Entity("PizzeriaMVC.Models.IngredientModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Nome = "tomato sauce"
                        },
                        new
                        {
                            Id = 2L,
                            Nome = "mozzarella"
                        },
                        new
                        {
                            Id = 3L,
                            Nome = "olives"
                        },
                        new
                        {
                            Id = 4L,
                            Nome = "pepperoni"
                        },
                        new
                        {
                            Id = 5L,
                            Nome = "mushrooms"
                        },
                        new
                        {
                            Id = 6L,
                            Nome = "onions"
                        },
                        new
                        {
                            Id = 7L,
                            Nome = "bell peppers"
                        },
                        new
                        {
                            Id = 8L,
                            Nome = "bacon"
                        },
                        new
                        {
                            Id = 9L,
                            Nome = "ham"
                        },
                        new
                        {
                            Id = 10L,
                            Nome = "pineapple"
                        },
                        new
                        {
                            Id = 11L,
                            Nome = "sausage"
                        },
                        new
                        {
                            Id = 12L,
                            Nome = "anchovies"
                        },
                        new
                        {
                            Id = 13L,
                            Nome = "spinach"
                        },
                        new
                        {
                            Id = 14L,
                            Nome = "artichokes"
                        },
                        new
                        {
                            Id = 15L,
                            Nome = "garlic"
                        },
                        new
                        {
                            Id = 16L,
                            Nome = "basil"
                        },
                        new
                        {
                            Id = 17L,
                            Nome = "oregano"
                        },
                        new
                        {
                            Id = 18L,
                            Nome = "parmesan"
                        },
                        new
                        {
                            Id = 19L,
                            Nome = "ricotta"
                        },
                        new
                        {
                            Id = 20L,
                            Nome = "goat cheese"
                        },
                        new
                        {
                            Id = 21L,
                            Nome = "feta cheese"
                        },
                        new
                        {
                            Id = 22L,
                            Nome = "nutella"
                        },
                        new
                        {
                            Id = 23L,
                            Nome = "honey"
                        },
                        new
                        {
                            Id = 24L,
                            Nome = "shredded coconut"
                        });
                });

            modelBuilder.Entity("PizzeriaMVC.Models.PizzaModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CategoriaId")
                        .HasColumnType("bigint")
                        .HasColumnName("category_id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<int>("ImageEntryId")
                        .HasColumnType("int");

                    b.Property<string>("Immagine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<double>("Prezzo")
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ImageEntryId");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("pizzas");
                });

            modelBuilder.Entity("IngredientModelPizzaModel", b =>
                {
                    b.HasOne("PizzeriaMVC.Models.IngredientModel", null)
                        .WithMany()
                        .HasForeignKey("IngredientiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzeriaMVC.Models.PizzaModel", null)
                        .WithMany()
                        .HasForeignKey("PizzeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzeriaMVC.Models.PizzaModel", b =>
                {
                    b.HasOne("PizzeriaMVC.Models.CategoryModel", "Categoria")
                        .WithMany("Pizze")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzeriaMVC.Models.ImageEntry", "ImageEntry")
                        .WithMany("PizzaModels")
                        .HasForeignKey("ImageEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("ImageEntry");
                });

            modelBuilder.Entity("PizzeriaMVC.Models.CategoryModel", b =>
                {
                    b.Navigation("Pizze");
                });

            modelBuilder.Entity("PizzeriaMVC.Models.ImageEntry", b =>
                {
                    b.Navigation("PizzaModels");
                });
#pragma warning restore 612, 618
        }
    }
}
