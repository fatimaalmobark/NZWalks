using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositries;

namespace NZWalks.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionController : ControllerBase
    {
        private readonly NZWalksDbContext nZWalksDbContext;
        private readonly IRegionRepositry regionRepositry;
        private readonly IMapper mapper;

        public RegionController(NZWalksDbContext context,IRegionRepositry regionRepositry,IMapper mapper)
        {
            this.nZWalksDbContext = context;
            this.regionRepositry = regionRepositry;
            this.mapper = mapper;
        }

        //GET ALL Method 
        [HttpGet]
        public async Task<IActionResult> GetallRegion() 
        {
            //Get Domain Models from DataBase
            var RegionDomain = await regionRepositry.GetallRegionAsync();


            //// Mapping Doamin Models to DTOs
            //var regionDto = new List<RegionDTO>();
            //foreach (var item in RegionDomain)
            //{
            //    regionDto.Add(new RegionDTO()
            //    {
            //        Id = item.Id,
            //        Name = item.Name,
            //        Code = item.Code,
            //        RegionImageId = item.RegionImageId
            //    });
            //}

            // Mapping Doamin Models to DTOs
           // var regionDto = mapper.Map<List<RegionDTO>>(RegionDomain);
            

            // return Dto to CLients
            return Ok(mapper.Map<List<RegionDTO>>(RegionDomain));
        }





        // GET Method By ID/Name/Code/regionImageId
        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid Id)
        {
            //the function find() only using with id
           // var region = nZWalksDbContext.Regions.Find(Id);
            var region = await regionRepositry.GetRegionByIdAsync(Id);
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
            return Ok(mapper.Map<RegionDTO>(regionDto));
        }
        // POST DTOs From Client 
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {


            // mapping DTOs to Domain Models
            //var RegionDomainModel = new Region()
            //{
            //    Name = addRegionRequestDto.Name,
            //    Code = addRegionRequestDto.Code,
            //    RegionImageId = addRegionRequestDto.RegionImageId

            //};
            var RegionDomainModel = mapper.Map<Region>(addRegionRequestDto);
            // using Domain Model to Create Region
            RegionDomainModel = await regionRepositry.CreateAsync(RegionDomainModel);


            //return Domain Model to DTos
            //var regionDto = new RegionDTO()
            //{
            //    Id = RegionDomainModel.Id,
            //    Name = RegionDomainModel.Name,
            //    Code = RegionDomainModel.Code,
            //    RegionImageId = RegionDomainModel.RegionImageId

            //};
            var regionDto = mapper.Map<RegionDTO>(RegionDomainModel);
            return Ok(regionDto);

          //  return CreatedAtAction(nameof(GetRegionById), new { id = regionDto.Id }, regionDto);

        }
        //UPdate 
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateRegionRequestDto updateRegionRequestDto)
        {
        //    //mapping Dto to Domain Model
        //    var RegionDomainModel = new Region()
        //    {
        //        Name = updateRegionRequestDto.Name,
        //        Code = updateRegionRequestDto.Code,
        //        RegionImageId = updateRegionRequestDto.RegionImageId
        //    };
            var regionDomainModel=mapper.Map<Region>(updateRegionRequestDto);

             regionDomainModel = await regionRepositry.UpdateAsync(id, regionDomainModel);
            if (regionDomainModel == null)
            {
                return NotFound();

            }
           
            // mapping Domain Model to Dto 
            //var regionDto = new RegionDTO()
            //{
            //    Id = regionDomainModel.Id,
            //    Name = regionDomainModel.Name,
            //    Code = regionDomainModel.Code,
            //    RegionImageId = regionDomainModel.RegionImageId

            //};
          
            return Ok(mapper.Map<RegionDTO>(regionDomainModel));
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) 
        {
            //Get Domain Model from DataBase
            var regionDomainModel=await regionRepositry.DeleteAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();

            }

            // mapping Domain Model to DTOs
            //var regionDto = new RegionDTO()
            //{
            //    Id=regionDomainModel.Id,
            //    Name=regionDomainModel.Name,
            //    Code = regionDomainModel.Code,  
            //    RegionImageId=regionDomainModel.RegionImageId

            //};

            return Ok(mapper.Map<RegionDTO>(regionDomainModel));

        }
    }
}