using Api_AgenceVoyage.Entities;
using Api_AgenceVoyage.Helpers;
using Api_AgenceVoyage.Models.Reservation;
using AutoMapper;

namespace Api_AgenceVoyage.Services
{
    public interface IReservationService
    {
        IEnumerable<Reservation> GetAll();
        Reservation GetById(int id);
        void Create(CreateRequestReservation model);
        void Update(int id, UpdateRequestReservation model);
        void Delete(int id);
    }

    public class ReservationService : IReservationService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public ReservationService(
        DataContext context,
        IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _context.Reservations;
        }

        public void Create(CreateRequestReservation model)
        {
            var reservation = _mapper.Map<Reservation>(model);
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequestReservation model)
        {
            var reservation = getReservation(id);
            _mapper.Map(model, reservation);
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
        }

        public Reservation GetById(int id)
        {
            return getReservation(id);
        }

        private Reservation getReservation(int id)
        {
            var Reservation = _context.Reservations.Find(id);
            if (Reservation == null) throw new KeyNotFoundException("Reservations not found");
            return Reservation;
        }

        public void Delete(int id)
        {
            var Reservation = getReservation(id);
            _context.Reservations.Remove(Reservation);
            _context.SaveChanges();
        }
    }
 }
