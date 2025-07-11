using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_AgenceVoyage.Models.Voyage
{
    public class CreateRequestvoyage
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public DateTime DateDepart { get; set; }  // Stocke date et heure

        [Required]
        public DateTime DateArrivee { get; set; } // Stocke date et heure

        // FK (userId)
        public int UserId { get; set; }

        // FK (chauffeurid)
        public int chauffeurid { get; set; }

    }
}