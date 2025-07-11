using Api_AgenceVoyage.Entities;
using Api_AgenceVoyage.Helpers;
using Api_AgenceVoyage.Models.Agence;
using Api_AgenceVoyage.Models.Chauffeur;
using AutoMapper;

namespace Api_AgenceVoyage.Services
{
    public interface IAgenceService
    {
        IEnumerable<Agence> GetAll();
        Agence GetById(int id);
        void Create(CreateRequestAgence model);
        void Update(int id, UpdateteRequestAgence model);
        void Delete(int id);
    }

    public class AgenceService : IAgenceService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public AgenceService(
        DataContext context,
        IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Agence> GetAll()
        {
            return _context.Agences;
        }

        public void Create(CreateRequestAgence model)
        {
            var agence = _mapper.Map<Agence>(model);
            _context.Agences.Add(agence);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateteRequestAgence model)
        {
            var agence = getAgence(id);
            _mapper.Map(model, agence);
            _context.Agences.Update(agence);
            _context.SaveChanges();
        }
        public Agence GetById(int id)
        {
            return getAgence(id);
        }

        private Agence getAgence(int id)
        {
            var Agence = _context.Agences.Find(id);
            if (Agence == null) throw new KeyNotFoundException("Agences not found");
            return Agence;
        }

        public void Delete(int id)
        {
            var Agence = getAgence(id);
            _context.Agences.Remove(Agence);
            _context.SaveChanges();
        }

    }
}
