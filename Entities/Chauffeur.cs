using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_AgenceVoyage.Entities
{
    public class Chauffeur
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Nom { get; set; }

        [Required, MaxLength(80)]
        public string Prenom { get; set; }

        [Required, MaxLength(80)]
        public string Age { get; set; }

        // FK (userId)
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
