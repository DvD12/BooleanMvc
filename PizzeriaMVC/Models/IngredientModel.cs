using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaMVC.Models
{
    [Table("ingredients")]
    [Index(nameof(Nome), IsUnique = true)]
    public class IngredientModel
    {
        [Key][Column("id")] public long Id { get; set; }
        [Column("name")] public string Nome { get; set; }

        public List<PizzaModel> Pizze { get; set; }

        public IngredientModel() { }
    }
}
