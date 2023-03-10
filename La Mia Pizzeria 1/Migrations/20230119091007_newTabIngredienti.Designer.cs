// <auto-generated />
using La_Mia_Pizzeria_1.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LaMiaPizzeria1.Migrations
{
    [DbContext(typeof(PizzeriaContext))]
    [Migration("20230119091007_newTabIngredienti")]
    partial class newTabIngredienti
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IngredientePizza", b =>
                {
                    b.Property<int>("PizzasId")
                        .HasColumnType("int");

                    b.Property<int>("nIngredientiId")
                        .HasColumnType("int");

                    b.HasKey("PizzasId", "nIngredientiId");

                    b.HasIndex("nIngredientiId");

                    b.ToTable("IngredientePizza");
                });

            modelBuilder.Entity("La_Mia_Pizzeria_1.Models.CategoriaPizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CategoriePizze");
                });

            modelBuilder.Entity("La_Mia_Pizzeria_1.Models.Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ingredientis");
                });

            modelBuilder.Entity("La_Mia_Pizzeria_1.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Pizze");
                });

            modelBuilder.Entity("IngredientePizza", b =>
                {
                    b.HasOne("La_Mia_Pizzeria_1.Models.Pizza", null)
                        .WithMany()
                        .HasForeignKey("PizzasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("La_Mia_Pizzeria_1.Models.Ingrediente", null)
                        .WithMany()
                        .HasForeignKey("nIngredientiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("La_Mia_Pizzeria_1.Models.Pizza", b =>
                {
                    b.HasOne("La_Mia_Pizzeria_1.Models.CategoriaPizza", "Categoria")
                        .WithMany("Pizzas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("La_Mia_Pizzeria_1.Models.CategoriaPizza", b =>
                {
                    b.Navigation("Pizzas");
                });
#pragma warning restore 612, 618
        }
    }
}
