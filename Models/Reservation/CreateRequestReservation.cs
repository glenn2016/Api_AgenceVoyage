using Api_AgenceVoyage.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_AgenceVoyage.Models.Reservation
{
    public class CreateRequestReservation
    {
        public int UserId { get; set; }

        // Offre
        public int OffreId { get; set; }

        [MaxLength(80)]
        public string statut { get; set; }
    }
}