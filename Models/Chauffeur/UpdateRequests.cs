namespace Api_AgenceVoyage.Models.Chauffeur
{
    public class UpdateRequests
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Age { get; set; }
        // helpers
        private string replaceEmptyWithNull(string value)
        {
            // replace empty string with null to make field optional
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}
