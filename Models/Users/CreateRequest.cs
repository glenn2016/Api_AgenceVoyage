using Api_AgenceVoyage.Entities;
using System.ComponentModel.DataAnnotations;

namespace Api_AgenceVoyage.Models.Users
{
    public class CreateRequest
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { set; get; }
        [Required]
        [EnumDataType(typeof(Role))]
        public string Role { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
