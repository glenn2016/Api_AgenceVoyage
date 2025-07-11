using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_AgenceVoyage.Entities
{
    public class Offre
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string NomOfrre { get; set; }

        [Required, MaxLength(80)]
        public string DescriptionOffre { get; set; }

        [Required, MaxLength(80)]
        public float PrisOffre { get; set; }

        // FK (Voyageid)
        public int Voyageid { get; set; }

        [ForeignKey("Voyageid")]
        public virtual Voyage voyage { get; set; }
    }
}
