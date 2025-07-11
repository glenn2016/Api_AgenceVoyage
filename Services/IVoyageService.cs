using Api_AgenceVoyage.Entities;
using Api_AgenceVoyage.Helpers;
using Api_AgenceVoyage.Models.Reservation;
using Api_AgenceVoyage.Models.Voyage;
using AutoMapper;

namespace Api_AgenceVoyage.Services
{
    public interface IVoyageService
    {
        IEnumerable<Voyage> GetAll();
        Voyage GetById(int id);
        void Create(CreateRequestvoyage model);
        void Update(int id, UpdateRequestVoyage model);
        void Delete(int id);
    }

    public class VoyageService : IVoyageService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public VoyageService(
        DataContext context,
        IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Voyage> GetAll()
        {
            return _context.Voyages;
        }

        public void Create(CreateRequestvoyage model)
        {
            var voyage = _mapper.Map<Voyage>(model);
            _context.Voyages.Add(voyage);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequestVoyage model)
        {
            var voyage = getVoyage(id);
            _mapper.Map(model, voyage);
            _context.Voyages.Update(voyage);
            _context.SaveChanges();
        }

        public Voyage GetById(int id)
        {
            return getVoyage(id);
        }

        private Voyage getVoyage(int id)
        {
            var Voyage = _context.Voyages.Find(id);
            if (Voyage == null) throw new KeyNotFoundException("Voyages not found");
            return Voyage;
        }

        public void Delete(int id)
        {
            var Voyage = getVoyage(id);
            _context.Voyages.Remove(Voyage);
            _context.SaveChanges();
        }
    }
 }
