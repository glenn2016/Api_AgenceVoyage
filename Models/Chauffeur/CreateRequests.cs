using System.ComponentModel.DataAnnotations;

namespace Api_AgenceVoyage.Models.Chauffeur
{
    public class CreateRequests
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Age { get; set; }
        public int UserId { get; set; }
    }
}
