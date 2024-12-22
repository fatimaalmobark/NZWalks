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





        // GET Method By ID/Name/Code/regionImageId

        [HttpGet]
        [Route("{Id:Guid}")]
        public IActionResult GetRegionById([FromRoute] Guid Id)
        {
            //the function find() only using with id
            var region = nZWalksDbContext.Regions.Find(Id);
            //the region Domain Models come from Database
            // var regionDomain = nZWalksDbContext.Regions.FirstOrDefault(x =>x. Id == Id);
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
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
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
                Id = RegionDomainModel.Id,
                Name = RegionDomainModel.Name,
                Code = RegionDomainModel.Code,
                RegionImageId = RegionDomainModel.RegionImageId

            };


            return CreatedAtAction(nameof(GetRegionById), new { id = regionDto.Id }, regionDto);

        }
        //UPdate 
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult Update([FromRoute] Guid id, UpdateRegionRequestDto updateRegionRequestDto)
        {
            //check the id
            var regionDomainModel = nZWalksDbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (regionDomainModel == null)
            {
                return NotFound();

            }
            //mapping Dto to Domain Model
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.RegionImageId = updateRegionRequestDto.RegionImageId;
            nZWalksDbContext.SaveChanges();

            // mapping Domain Model to Dto 
            var regionDto = new RegionDTO()
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageId = regionDomainModel.RegionImageId

            };
            return Ok(regionDto);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            //Get Domain Model from DataBase
            var regionDomainModel = nZWalksDbContext.Regions.FirstOrDefault(x=>x.Id==id);
            if (regionDomainModel == null)
            {
                return NotFound();

            }
            // Deleted the Domain Model
            nZWalksDbContext.Regions.Remove(regionDomainModel);
            nZWalksDbContext.SaveChanges();



            // mapping Domain Model to DTOs
            var regionDto = new RegionDTO()
            {
                Id=regionDomainModel.Id,
                Name=regionDomainModel.Name,
                Code = regionDomainModel.Code,  
                RegionImageId=regionDomainModel.RegionImageId

            };

            return Ok(regionDto);
        }
    }
}