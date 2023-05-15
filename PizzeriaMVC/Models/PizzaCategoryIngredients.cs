namespace PizzeriaMVC.Models
{
    public class PizzaCategoryIngredients
    {
        public PizzaModel Pizza { get; set; }
        public List<CategoryModel>? Categories { get; set; }
        public List<IngredientCheckboxModel>? Ingredients { get; set;}
    }
}
