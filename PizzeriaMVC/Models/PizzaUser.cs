using Microsoft.AspNetCore.Identity;

namespace PizzeriaMVC.Models
{
    public class PizzaUser : IdentityUser
    {
        public string UserDescription { get; set; }
    }
}
