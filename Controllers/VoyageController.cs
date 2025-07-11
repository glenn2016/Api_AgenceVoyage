using Api_AgenceVoyage.Models.Reservation;
using Api_AgenceVoyage.Models.Voyage;
using Api_AgenceVoyage.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_AgenceVoyage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoyageController : ControllerBase
    {

        private IVoyageService _voyageService;
        private IMapper _mapper;

        public VoyageController(IVoyageService VoyageService, IMapper mapper)
        {
            _voyageService = VoyageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var voyages = _voyageService.GetAll();
            return Ok(voyages);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var voyage = _voyageService.GetById(id);
            return Ok(voyage);
        }

        [HttpPost]
        public IActionResult Create(CreateRequestvoyage model)
        {
            _voyageService.Create(model);
            return Ok(new { message = "Voyage created" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRequestVoyage model)
        {
            _voyageService.Update(id, model);
            return Ok(new { message = "Voyage updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _voyageService.Delete(id);
            return Ok(new { message = "Voyage deleted" });
        }
    }
}