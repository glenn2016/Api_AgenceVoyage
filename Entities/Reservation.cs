using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;


namespace Api_AgenceVoyage.Entities
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        // Cleient
        // FK (userId)
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        // Offre
        public int OffreId { get; set; }

        [ForeignKey("OffreId")]
        public virtual Offre Offre { get; set; }

        [MaxLength(80)]
        public string statut { get; set; }
    }
}
