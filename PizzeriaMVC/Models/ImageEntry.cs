using System.ComponentModel.DataAnnotations;

namespace PizzeriaMVC.Models
{
    public class ImageEntry
    {
        [Key] public int Id { get; set; }
        public byte[] Data { get; set; }
        public List<PizzaModel>? PizzaModels { get; set; }
    }
}
