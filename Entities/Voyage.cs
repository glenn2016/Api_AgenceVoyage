using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.Json.Serialization;


namespace Api_AgenceVoyage.Entities
{
    public class Voyage
    {
        [Key]
        public int IdUVoyage { get; set; }

        [Required, MaxLength(80)]
        public string Description { get; set; }

        [Required, MaxLength(80)]
        public string Destination { get; set; }

        [Required]
        public DateTime DateDepart { get; set; }  // Stocke date et heure

        [Required]
        public DateTime DateArrivee { get; set; } // Stocke date et heure


        // FK (userId)
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        // FK (chauffeurid)
        public int chauffeurid { get; set; }

        [ForeignKey("chauffeurid")]
        public virtual Chauffeur Chauffeur { get; set; }
    }
}
