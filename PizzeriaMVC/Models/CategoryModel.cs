using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaMVC.Models
{
    [Table("categories")]
    [Index(nameof(Nome), IsUnique = true)]
    public class CategoryModel
    {
        [Key][Column("id")] public long Id { get; set; }
        [Column("name")] public string Nome { get; set; }
        [Column("description")] public string Descrizione { get; set; }

        public List<PizzaModel> Pizze { get; set; }

        public CategoryModel() { }
    }
}
