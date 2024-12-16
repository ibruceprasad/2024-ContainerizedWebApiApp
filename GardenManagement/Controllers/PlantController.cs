
using Garden.Management.Data.Entity;
using Garden.Management.Dto;
using Garden.Management.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Garden.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private readonly GardenDbContext _gardenDbContext;
        public PlantController(GardenDbContext gardenDbContext) 
        {
            _gardenDbContext = gardenDbContext;
        }

        [HttpGet("all", Name = "GetAllPlants")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<Plant>>> GetAllPlants()
        {
            var plants = await _gardenDbContext.Plants.Select(x=> new PlantDto() { Name=  x.Name }).ToListAsync();
            return Ok(plants);
        }
    }


}

