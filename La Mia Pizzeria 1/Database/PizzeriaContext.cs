using La_Mia_Pizzeria_1.Models;
using Microsoft.EntityFrameworkCore;

namespace La_Mia_Pizzeria_1.Database {
    public class PizzeriaContext : DbContext {
        public DbSet<Pizza> Pizze { get; set; }
        public DbSet<CategoriaPizza> CategoriePizze { get; set; }
        public DbSet<Ingrediente> ingredientis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            optionsBuilder.UseSqlServer("Data Source=localhost;Database=PizzeriaDB;Integrated Security=True;TrustServerCertificate=True");

        }

    }
}
