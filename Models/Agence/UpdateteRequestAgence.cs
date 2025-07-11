using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_AgenceVoyage.Models.Agence
{
    public class UpdateteRequestAgence
    {
        public string NomAgence { get; set; }
        public string AdresseAgence { get; set; }
        public string Ninea { get; set; }
        public string Rccm { get; set; }
        public int UserId { get; set; }
        private string replaceEmptyWithNull(string value)
        {
            // replace empty string with null to make field optional
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}
