using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;

namespace Api_AgenceVoyage.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Nom { get; set; }

        [Required, MaxLength(80)]
        public string Prenom { set; get; }

        [Required, MaxLength(60), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Role role { get; set; }

        [JsonIgnore, MaxLength(255)]
        public string PasswordHash { get; set; }

    }
}