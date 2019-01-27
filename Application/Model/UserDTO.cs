using System.ComponentModel.DataAnnotations;

namespace Application.Model
{
    public class UserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
