using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PizzeriaMVC.Models;

namespace PizzeriaMVC.Controllers
{
    [Authorize]
    public class PizzaController : Controller
    {
        private PizzaContext _pizzaContext;
        public PizzaController(PizzaContext pizzaContext)
        {
            _pizzaContext = pizzaContext;
        }

        [Authorize(Roles = "Admin, User")]
        public IActionResult Index()
        {
            List<PizzaModel> pizze = _pizzaContext.Pizzas.Include(p => p.ImageEntry).Include(c => c.Categoria).ToList();
            if (pizze.Count > 0)
                return View(pizze);
            else
                return View("NoPizza");
        }

        [Authorize(Roles = "Admin, User")]
        public IActionResult Show(int Id)
        {
            try
            {
                PizzaModel pizza = _pizzaContext.Pizzas.Include(p => p.ImageEntry).First(p => p.Id == Id);
                return View(pizza);
            }
            catch
            {
                return View("NotFound", Id);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            List<CategoryModel> categories = _pizzaContext.Categories.ToList();
            List<IngredientModel> ingredients = _pizzaContext.Ingredients.ToList();
            List<IngredientCheckboxModel> ingredientCheckboxes = new();
            foreach(var ing in ingredients)
            {
                IngredientCheckboxModel checkbox = new()
                {
                    Ingredient = ing,
                    IsChecked = false,
                };
                ingredientCheckboxes.Add(checkbox);
            }
            PizzaCategoryIngredients model = new()
            {
                Pizza = new PizzaModel(),
                Categories = categories,
                Ingredients = ingredientCheckboxes,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaCategoryIngredients data, int[] selectedIngredients)
        {
            if (!ModelState.IsValid)
            {
                List<CategoryModel> categories = _pizzaContext.Categories.ToList();
                List<IngredientModel> ingredients = _pizzaContext.Ingredients.ToList();
                data.Categories = categories;
                List<IngredientCheckboxModel> ingredientCheckboxes = new();
                foreach (var ing in ingredients)
                {
                    IngredientCheckboxModel checkbox = new()
                    {
                        Ingredient = ing,
                        IsChecked = false,
                    };
                    ingredientCheckboxes.Add(checkbox);
                }

                PizzaCategoryIngredients model = new()
                {
                    Pizza = data.Pizza,
                    Categories = categories,
                    Ingredients = ingredientCheckboxes,
                };
                return View("Create", model);
            }
            List<IngredientModel> checkedIngredients = new();
            foreach(var ing in selectedIngredients)
            {
                IngredientModel matchedIngredient = _pizzaContext.Ingredients.FirstOrDefault(i => i.Id == ing);
                if(matchedIngredient != null)
                    checkedIngredients.Add(matchedIngredient);
            }

            PizzaModel newPizza = new()
            {
                Nome = data.Pizza.Nome,
                Descrizione = data.Pizza.Descrizione,
                Immagine = data.Pizza.Immagine,
                Prezzo = data.Pizza.Prezzo,
                CategoriaId = data.Pizza.CategoriaId,
                Ingredienti = checkedIngredients,
            };

            _pizzaContext.Pizzas.Add(newPizza);
            _pizzaContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                PizzaModel pizza = _pizzaContext.Pizzas.Include(p => p.Ingredienti).First(p => p.Id == Id);
                List<CategoryModel> categories = _pizzaContext.Categories.ToList();
                List<IngredientModel> ingredients = _pizzaContext.Ingredients.ToList();
                List<IngredientCheckboxModel> ingredientCheckboxes = new();
                foreach(var ing in ingredients)
                {
                    IngredientCheckboxModel checkbox = new()
                    {
                        Ingredient = ing,
                        IsChecked = pizza.Ingredienti.Contains(ing),
                    };
                    ingredientCheckboxes.Add(checkbox);
                }

                PizzaCategoryIngredients model = new()
                {
                    Pizza = pizza,
                    Categories = categories,
                    Ingredients = ingredientCheckboxes,
                };
                return View(model);
            }
            catch
            {
                return View("NotFound", Id);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PizzaCategoryIngredients data, int Id, int[] selectedIngredients)
        {
            if (!ModelState.IsValid)
            {
                PizzaModel pizza = _pizzaContext.Pizzas.Include(p => p.Ingredienti).First(p => p.Id == Id);
                List<CategoryModel> categories = _pizzaContext.Categories.ToList();
                List<IngredientModel> ingredients = _pizzaContext.Ingredients.ToList();
                List<IngredientCheckboxModel> ingredientCheckboxes = new();
                foreach (var ing in ingredients)
                {
                    IngredientCheckboxModel checkbox = new()
                    {
                        Ingredient = ing,
                        IsChecked = pizza.Ingredienti.Contains(ing),
                    };
                    ingredientCheckboxes.Add(checkbox);
                }
                data.Categories = categories;
                data.Ingredients = ingredientCheckboxes;
                return View("Edit", data);
            }

            try
            {
                List<IngredientModel> checkedIngredients = new();
                foreach (var ing in selectedIngredients)
                {
                    IngredientModel matchedIngredient = _pizzaContext.Ingredients.FirstOrDefault(i => i.Id == ing);
                    if (matchedIngredient != null)
                        checkedIngredients.Add(matchedIngredient);
                }
                PizzaModel pizzaToEdit = _pizzaContext.Pizzas.Include(p => p.Ingredienti).First(p => p.Id == Id);
                pizzaToEdit.Ingredienti.Clear();
                pizzaToEdit.Nome = data.Pizza.Nome;
                pizzaToEdit.Descrizione = data.Pizza.Descrizione;
                pizzaToEdit.Immagine = data.Pizza.Immagine;
                pizzaToEdit.Prezzo = data.Pizza.Prezzo;
                pizzaToEdit.CategoriaId = data.Pizza.CategoriaId;
                pizzaToEdit.Ingredienti = checkedIngredients;


                if (data.Pizza.Image != null)
                {
                    using var ms = new MemoryStream();
                    data.Pizza.Image.CopyTo(ms);
                    var fileBytes = ms.ToArray();

                    var newImage = new ImageEntry()
                    {
                        Data = fileBytes,
                    };
                    _pizzaContext.ImageEntries.Add(newImage);
                    _pizzaContext.SaveChanges();

                    pizzaToEdit.ImageEntryId = newImage.Id;

                    //string s = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                }

                _pizzaContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("NotFound", Id);
            } 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                PizzaModel pizzaToDelete = _pizzaContext.Pizzas.First(p => p.Id == id);
                _pizzaContext.Pizzas.Remove(pizzaToDelete);
                _pizzaContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("NotFound", id);
            }
        }
    }
}
