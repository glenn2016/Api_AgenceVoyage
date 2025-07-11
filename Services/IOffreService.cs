using Api_AgenceVoyage.Entities;
using Api_AgenceVoyage.Helpers;
using Api_AgenceVoyage.Models.Offre;
using AutoMapper;

namespace Api_AgenceVoyage.Services
{
    public interface IOffreService
    {
        IEnumerable<Offre> GetAll();
        Offre GetById(int id);
        void Create(CreateRequestOffre model);
        void Update(int id, UpdateRequestOffre model);
        void Delete(int id);
    }

    public class OffrerService : IOffreService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public OffrerService(
        DataContext context,
        IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public IEnumerable<Offre> GetAll()
        {
            return _context.Offres;
        }

        public void Create(CreateRequestOffre model)
        {
            var offre = _mapper.Map<Offre>(model);
            _context.Offres.Add(offre);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequestOffre model)
        {
            var offre = getOffre(id);
            _mapper.Map(model, offre);
            _context.Offres.Update(offre);
            _context.SaveChanges();
        }

        public Offre GetById(int id)
        {
            return getOffre(id);
        }

        private Offre getOffre(int id)
        {
            var Offre = _context.Offres.Find(id);
            if (Offre == null) throw new KeyNotFoundException("Offres not found");
            return Offre;
        }

        public void Delete(int id)
        {
            var Offre = getOffre(id);
            _context.Offres.Remove(Offre);
            _context.SaveChanges();
        }


    }

 }
