using Api_AgenceVoyage.Models.Offre;
using Api_AgenceVoyage.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api_AgenceVoyage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffreController : ControllerBase
    {
        private IOffreService __offreService;
        private IMapper _mapper;

        public OffreController(IOffreService OffreService, IMapper mapper)
        {
            __offreService = OffreService;
             _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var offres = __offreService.GetAll();
            return Ok(offres);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var offre = __offreService.GetById(id);
            return Ok(offre);
        }

        [HttpPost]
        public IActionResult Create(CreateRequestOffre model)
        {
            __offreService.Create(model);
            return Ok(new { message = "Offre created" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRequestOffre model)
        {
            __offreService.Update(id, model);
            return Ok(new { message = "Offre updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            __offreService.Delete(id);
            return Ok(new { message = "Offre deleted" });
        }

    }
}
