using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using static System.Net.WebRequestMethods;

namespace PizzeriaMVC.Models
{
    [Table("pizzas")]
    [Index(nameof(Nome), IsUnique = true)]
    public class PizzaModel
    {
        [Key][Column("id")] public long Id { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [StringLength(50, ErrorMessage = "Il nome non può contentere più di 50 caratteri")]
        [Column("name")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Column("description")]
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Url(ErrorMessage = "L'immagine inserita deve avere un URL valido")]
        [Column("image")]
        public string? Immagine { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Range(1, 30, ErrorMessage = "Il prezzo deve essere compreso tra 1 e 30")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Column("price")]
        public double Prezzo { get; set; }

        [NotMapped] public IFormFile? Image { get; set; }
        public int? ImageEntryId { get; set; }
        public ImageEntry? ImageEntry { get; set; }
        [NotMapped] public string ImageEntryBase64 => ImageEntry == null ? "" : "data:image/jpg;base64," + Convert.ToBase64String(ImageEntry.Data);

        [Column("created_at")] public DateTime? CreatedAt { get; set; }
        [Column("updated_at")] public DateTime? UpdatedAt { get; set; }
        [Column("category_id")] public long CategoriaId { get; set; }
        public CategoryModel? Categoria { get; set; }
        public List<IngredientModel>? Ingredienti { get; set; }

        public PizzaModel()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        /*public PizzaModel(string nome, string descrizione, string immagine, double prezzo)
        {
            Nome = nome;
            Descrizione = descrizione;
            Immagine = immagine;
            Prezzo = prezzo;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }*/
    }
}