using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetallRegion()
        {
            //Get Domain Models from DataBase
            var RegionDomain = await nZWalksDbContext.Regions.ToListAsync();


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
        public async Task<IActionResult> GetRegionById([FromRoute] Guid Id)
        {
            //the function find() only using with id
            var region = await nZWalksDbContext.Regions.FindAsync(Id);
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
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {


            // mapping DTOs to Domain Models
            var RegionDomainModel = new Region()
            {
                Name = addRegionRequestDto.Name,
                Code = addRegionRequestDto.Code,
                RegionImageId = addRegionRequestDto.RegionImageId

            };
            // using Domain Model to Create Region
           await nZWalksDbContext.Regions.AddAsync(RegionDomainModel);
           await nZWalksDbContext.SaveChangesAsync();

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
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateRegionRequestDto updateRegionRequestDto)
        {
            //check the id
            var regionDomainModel =await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomainModel == null)
            {
                return NotFound();

            }
            //mapping Dto to Domain Model
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.RegionImageId = updateRegionRequestDto.RegionImageId;
            await nZWalksDbContext.SaveChangesAsync();

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
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            //Get Domain Model from DataBase
            var regionDomainModel = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x=>x.Id==id);
            if (regionDomainModel == null)
            {
                return NotFound();

            }
            // Deleted the Domain Model
            nZWalksDbContext.Regions.Remove(regionDomainModel);
            await nZWalksDbContext.SaveChangesAsync();



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