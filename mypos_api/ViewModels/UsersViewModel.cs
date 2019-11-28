using System.ComponentModel.DataAnnotations;

namespace mypos_api.ViewModel
{
    public partial class UsersViewModel
    {
        [Required]
        public string Username { get; set; }
        
        [MinLength(8, ErrorMessage = "password min-length = 8")]
        [MaxLength(30)]
        public string Password { get; set; }
    }
}

