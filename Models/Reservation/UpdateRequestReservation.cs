using System.ComponentModel.DataAnnotations;

namespace Api_AgenceVoyage.Models.Reservation
{
    public class UpdateRequestReservation
    {
        public int UserId { get; set; }
        public int OffreId { get; set; }
        public string statut { get; set; }

        // helpers
        private string replaceEmptyWithNull(string value)
        {
            // replace empty string with null to make field optional
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}
