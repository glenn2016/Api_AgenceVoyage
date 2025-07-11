using Api_AgenceVoyage.Entities;
using Api_AgenceVoyage.Models.Offre;
using Api_AgenceVoyage.Models.Reservation;
using Api_AgenceVoyage.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_AgenceVoyage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IReservationService _reservationService;
        private IMapper _mapper;

        public ReservationController(IReservationService ReservationService, IMapper mapper)
        {
            _reservationService = ReservationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var reservations = _reservationService.GetAll();
            return Ok(reservations);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var reservation = _reservationService.GetById(id);
            return Ok(reservation);
        }


        [HttpPost]
        public IActionResult Create(CreateRequestReservation model)
        {
            _reservationService.Create(model);
            return Ok(new { message = "Reservation created" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRequestReservation model)
        {
            _reservationService.Update(id, model);
            return Ok(new { message = "Reservation updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _reservationService.Delete(id);
            return Ok(new { message = "Reservation deleted" });
        }
    }
}
