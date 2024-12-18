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
                    Id = item.Id,
                    Name = item.Name,
                    Code = item.Code,
                    RegionImageId = item.RegionImageId
                });
            }
            // return Dto to CLients
            return Ok(regionDto);
        }

        // GET Method By ID/Name/COde/regionImageId

        [HttpGet]
        [Route("{Id:Guid}")]
        public IActionResult GetRegionById([FromRoute] Guid Id)
        {
            //the function find() only using with id
            var region = nZWalksDbContext.Regions.Find(Id);
            //the region Domain Models come from Database
            //var regionDomain = nZWalksDbContext.Regions.FirstOrDefault(x => Id == Id);
            if (region == null)
            {
                return NotFound();
            }

            var regionDto = new RegionDTO()
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageId = region.RegionImageId

            };
            return Ok(region);
        }
        // POST DTOs form Client 
        [HttpPost]
        public IActionResult Create([FromBody]AddRegionRequestDto addRegionRequestDto)
        {
          

            // mapping DTOs to Domain Models
            var RegionDomainModel = new Region()
            {
                Name = addRegionRequestDto.Name,
                Code = addRegionRequestDto.Code,
                RegionImageId = addRegionRequestDto.RegionImageId

            };
            // using Domain Model to Create Region
            nZWalksDbContext.Regions.Add(RegionDomainModel);
            nZWalksDbContext.SaveChanges();

            //return Domain Model to DTos
            var regionDto = new RegionDTO()
            {
                Id=RegionDomainModel.Id,
                Name = RegionDomainModel.Name,
                Code= RegionDomainModel.Code,
                RegionImageId= RegionDomainModel.RegionImageId

            };


            return CreatedAtAction(nameof(GetRegionById),new { id = RegionDomainModel.Id },RegionDomainModel);

        }

    }
}