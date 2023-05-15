using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PizzeriaMVC.Models;

namespace PizzeriaMVC.Seeders
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            string[] pizzaIngredients = new string[]
            {
                "tomato sauce",
                "mozzarella",
                "olives",
                "pepperoni",
                "mushrooms",
                "onions",
                "bell peppers",
                "bacon",
                "ham",
                "pineapple",
                "sausage",
                "anchovies",
                "spinach",
                "artichokes",
                "garlic",
                "basil",
                "oregano",
                "parmesan",
                "ricotta",
                "goat cheese",
                "feta cheese",
                "nutella",
                "honey",
                "shredded coconut"
            };

            for (int i = 0; i < pizzaIngredients.Length; i++)
            {
                modelBuilder.Entity<IngredientModel>().HasData(
                    new IngredientModel { Id = i + 1, Nome = pizzaIngredients[i] }
                    );
            }

            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { Id = 1, Nome = "Classic", Descrizione = "A pizza with a traditional flavor profile that includes a tomato-based sauce, cheese, and a variety of classic toppings." },
                new CategoryModel { Id = 2, Nome = "Vegetarian", Descrizione = "A pizza that excludes any meat-based toppings and includes a range of vegetables and cheeses." },
                new CategoryModel { Id = 3, Nome = "Vegan", Descrizione = "A pizza that is entirely plant-based and excludes any animal-based products." },
                new CategoryModel { Id = 4, Nome = "Gourmet", Descrizione = "A pizza made with premium ingredients and unique flavor combinations that go beyond traditional toppings." },
                new CategoryModel { Id = 5, Nome = "Dessert", Descrizione = "A sweet pizza made with dessert toppings, such as fruit, chocolate, or caramel, and a crust that may be sweetened with sugar or honey." }
                );

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "11/05/2023"},
                new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER", ConcurrencyStamp = "11/05/2023" }
                );
        }
    }
}
