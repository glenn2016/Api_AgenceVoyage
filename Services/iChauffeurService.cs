using Api_AgenceVoyage.Entities;
using Api_AgenceVoyage.Helpers;
using Api_AgenceVoyage.Models.Chauffeur;
using AutoMapper;

namespace Api_AgenceVoyage.Services
{
    public interface iChauffeurService
    {
        IEnumerable<Chauffeur> GetAll();
        Chauffeur GetById(int id);
        void Create(CreateRequests model);
        void Update(int id, UpdateRequests model);
        void Delete(int id);
    }

    public class ChauffeurService : iChauffeurService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public ChauffeurService(
        DataContext context,
        IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Chauffeur> GetAll()
        {
            return _context.Chauffeurs;
        }

        public void Create(CreateRequests model)
        {
            var chauffeur = _mapper.Map<Chauffeur>(model);
            _context.Chauffeurs.Add(chauffeur);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequests model)
        {
            var chauffeur = getCahuffeur(id);
            _mapper.Map(model, chauffeur);
            _context.Chauffeurs.Update(chauffeur);
            _context.SaveChanges();
        }

        public Chauffeur GetById(int id)
        {
            return getCahuffeur(id);
        }

        private Chauffeur getCahuffeur(int id)
        {
            var Chauffeur = _context.Chauffeurs.Find(id);
            if (Chauffeur == null) throw new KeyNotFoundException("Chauffeurs not found");
            return Chauffeur;
        }

        public void Delete(int id)
        {
            var Chauffeur = getCahuffeur(id);
            _context.Chauffeurs.Remove(Chauffeur);
            _context.SaveChanges();
        }
    }
}
