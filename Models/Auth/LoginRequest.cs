using Api_AgenceVoyage.Entities;
using System.ComponentModel.DataAnnotations;


namespace Api_AgenceVoyage.Models.Auth
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
