using System.ComponentModel.DataAnnotations;

namespace Api_AgenceVoyage.Models.Offre
{
    public class UpdateRequestOffre
    {
        public string NomOfrre { get; set; }

        public string DescriptionOffre { get; set; }

        public float PrisOffre { get; set; }

        // FK (Voyageid)
        public int Voyageid { get; set; }

        // helpers
        private string replaceEmptyWithNull(string value)
        {
            // replace empty string with null to make field optional
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}
