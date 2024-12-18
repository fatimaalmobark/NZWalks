using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NZWalksDbContext nZWalksDbContext;
        public RegionController(NZWalksDbContext context)
        {
            nZWalksDbContext = context;
        }

        //GET ALL METHOD
        [HttpGet]
        public IActionResult GetallRegion() 
        {
            //Get Domain Models from DataBase
            var RegionDomain = nZWalksDbContext.Regions.ToList();


            // Mapping Doamin Models to DTOs
            var regionDto = new List<RegionDTO>();
            foreach (var item in RegionDomain)
            {
                regionDto.Add(new RegionDTO() 
                {
                    Id= item.Id,
                    Name= item.Name,
                    Code = item.Code,
                    RegionImageId= item.RegionImageId
                });
            }
            // return Dto to CLients
            return Ok (regionDto);
        }

        // GET Method By ID/Name/COde/regionImageId

        [HttpGet]
        [Route("{Name:alpha}")]
        public IActionResult GetRegionById([FromRoute] string Name)
        {
            //the function find() only using with id
            //var region = nZWalksDbContext.Regions.Find(id);
            //the region Domain Models come from Database
            var regionDomain = nZWalksDbContext.Regions.FirstOrDefault(x => Name == Name);
            if(regionDomain==null)
            {
                return NotFound();
            }

            var regionDto = new RegionDTO()
            {
                Id= regionDomain.Id,
                Name=regionDomain.Name,
                Code=regionDomain.Code,
                RegionImageId=regionDomain.RegionImageId

            };
            return Ok(regionDomain);
        }

    }
}
