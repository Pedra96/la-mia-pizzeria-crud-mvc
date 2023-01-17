using La_Mia_Pizzeria_1.Database;
using La_Mia_Pizzeria_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.SqlServer.Server;
using System.Reflection.Metadata.Ecma335;

namespace La_Mia_Pizzeria_1.Controllers {
    public class PizzaController : Controller {

        public IActionResult Index() {
            using PizzeriaContext db = new PizzeriaContext();
            List<Pizza> listaDellePizze = db.Pizze.ToList();

            return View("Index", listaDellePizze);
        }
        public IActionResult Details(int id) {
            using PizzeriaContext db = new PizzeriaContext();
           //un altro modo per associale il titolo della categoria quando si richiama il database
           var PizzaTrovata= db.Pizze.Where(x=>x.Id==id).Include(PizzaTrovata=>PizzaTrovata.Categoria).FirstOrDefault();
            return View(PizzaTrovata);
            /*List<Pizza> listaDellePizze = db.Pizze.ToList();
            foreach (Pizza pizza in listaDellePizze) {
                if (pizza.Id == id) {
                    var categoria = db.CategoriePizze.Where(x => x.Id == pizza.CategoriaId).FirstOrDefault();
                    pizza.Categoria= categoria;
                    return View(pizza);
                }
            }

            return NotFound("Il post con l'id cercato non esiste!");*/
        }

        [HttpGet]
        public IActionResult NuovaPizza() {
            using PizzeriaContext db = new();
                List<CategoriaPizza> CategoriaFromDb=db.CategoriePizze.ToList();
                PizzaCategoriaView ModelForView = new();
                ModelForView.Pizza = new();
                ModelForView.Categorie = CategoriaFromDb;
            return View("NuovaPizza", ModelForView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NuovaPizza(PizzaCategoriaView formdata) {
            using PizzeriaContext db = new PizzeriaContext();
            if (!ModelState.IsValid) {
                List<CategoriaPizza> categorie = db.CategoriePizze.ToList();
                formdata.Categorie = categorie;
                return View("NuovaPizza", formdata);
            }
            db.Pizze.Add(formdata.Pizza);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ModificaPizza(int id) {
            using PizzeriaContext db = new();
            var pizzaUpdate= db.Pizze.Where(x => x.Id == id).FirstOrDefault();
            if (pizzaUpdate == null) {
                return NotFound("Pizza non presente");
            } else {
                List<CategoriaPizza> CategoriaFromDb = db.CategoriePizze.ToList();
                PizzaCategoriaView ModelForView = new();
                ModelForView.Pizza = pizzaUpdate;
                ModelForView.Categorie = CategoriaFromDb;
                return View("ModificaPizza", ModelForView);
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificaPizza(PizzaCategoriaView formdata) {
            if (!ModelState.IsValid) {
                return View("ModificaPizza", formdata);
            }
            using PizzeriaContext db = new PizzeriaContext();
             Pizza? ModificaPizza = db.Pizze.Where(x => x.Id == formdata.Pizza.Id).FirstOrDefault();
            if (ModificaPizza != null) {
                ModificaPizza.Title = formdata.Pizza.Title;
                ModificaPizza.Price = formdata.Pizza.Price;
                ModificaPizza.Description = formdata.Pizza.Description;
                ModificaPizza.Image= formdata.Pizza.Image;
                ModificaPizza.CategoriaId = formdata.Pizza.CategoriaId;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        
        public IActionResult EliminaPizza(int id) {
            using PizzeriaContext db = new PizzeriaContext();
            Pizza? EliminaPizza = db.Pizze.Where(x => x.Id == id).FirstOrDefault();
            if (EliminaPizza != null) {
                db.Remove(EliminaPizza);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
