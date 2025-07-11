using Api_AgenceVoyage.Entities;
using Api_AgenceVoyage.Models.Chauffeur;
using Api_AgenceVoyage.Models.Users;

using AutoMapper;


namespace Api_AgenceVoyage.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateRequests -> Chauffeurs
            CreateMap<CreateRequests, Chauffeur>();
            // UpdateRequests -> Chauffeurs
            CreateMap<UpdateRequests, Chauffeur>();
            // UpdateRequest -> User
            CreateMap<UpdateRequest, User>();
            // CreateRequest -> User
            CreateMap<CreateRequest, User>()
            .ForAllMembers(x => x.Condition(
            (src, dest, prop) =>
            {
                // ignore both null & empty string properties
                if (prop == null) return false;
                if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;
                // ignore null role
                if (x.DestinationMember.Name == "Role" && src.Role == null) return false;
                return true;
            }
            ));
        }
    }
}
