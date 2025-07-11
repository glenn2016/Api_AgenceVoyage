using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_AgenceVoyage.Models.Offre
{
    public class CreateRequestOffre
    {
        [Required]
        public string NomOfrre { get; set; }

        [Required]
        public string DescriptionOffre { get; set; }

        [Required]
        public float PrisOffre { get; set; }

        // FK (Voyageid)
        public int Voyageid { get; set; }
    }
}
