using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_AgenceVoyage.Entities
{
    public class Agence
    {
        [Key]
        public int IdAgence { get; set; }

        [Required, MaxLength(80)]
        public string NomAgence { get; set; }

        [Required, MaxLength(80)]
        public string AdresseAgence { get; set; }

        [Required, MaxLength(80)]
        public string Ninea { get; set; }

        [Required, MaxLength(80)]
        public string Rccm { get; set; }

        // FK (userId)
        public int UserId { get; set; }

        [ForeignKey("UserId")]  
        public virtual User User { get; set; }
    }
}
