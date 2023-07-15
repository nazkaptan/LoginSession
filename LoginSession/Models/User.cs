using System.ComponentModel.DataAnnotations;

namespace LoginSession.Models
{
    public class User
    {
        [Required, Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
