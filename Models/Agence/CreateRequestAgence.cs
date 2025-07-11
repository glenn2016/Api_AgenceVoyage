using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_AgenceVoyage.Models.Agence
{
    public class CreateRequestAgence
    {
        [Required]
        public string NomAgence { get; set; }
        [Required]
        public string AdresseAgence { get; set; }
        [Required]
        public string Ninea { get; set; }
        [Required]
        public string Rccm { get; set; }
        public int UserId { get; set; }
    }
}
