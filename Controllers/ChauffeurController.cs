using Api_AgenceVoyage.Models.Chauffeur;
using Api_AgenceVoyage.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_AgenceVoyage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChauffeurController : ControllerBase
    {
        private iChauffeurService __chauffeurService;
        private IMapper _mapper;

        public ChauffeurController(
        iChauffeurService ChauffeurService,
        IMapper mapper)
        {
            __chauffeurService = ChauffeurService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var chauffeurs = __chauffeurService.GetAll();
            return Ok(chauffeurs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var chauffeur = __chauffeurService.GetById(id);
            return Ok(chauffeur);
        }

        [HttpPost]
        public IActionResult Create(CreateRequests model)
        {
            __chauffeurService.Create(model);
            return Ok(new { message = "Chauffeur created" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRequests model)
        {
            __chauffeurService.Update(id, model);
            return Ok(new { message = "Chauffeurs updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            __chauffeurService.Delete(id);
            return Ok(new { message = "Chauffeur deleted" });
        }
    }
}
