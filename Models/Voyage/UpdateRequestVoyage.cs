using System.ComponentModel.DataAnnotations;

namespace Api_AgenceVoyage.Models.Voyage
{
    public class UpdateRequestVoyage
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

        // helpers
        private string replaceEmptyWithNull(string value)
        {
            // replace empty string with null to make field optional
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}