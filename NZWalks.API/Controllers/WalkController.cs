using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NZWalks.API.CustomActionFilter;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositries;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly NZWalksDbContext nZWalksDbContext;
        private readonly IMapper mapper;
        private readonly IWalkRepositry walkRepositry;

        public WalkController(NZWalksDbContext nZWalksDbContext, IMapper mapper, IWalkRepositry walkRepositry)
        {
            this.nZWalksDbContext = nZWalksDbContext;
            this.mapper = mapper;
            this.walkRepositry = walkRepositry;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWalks([FromQuery] string? FilterOn, [FromQuery] string? FilterQuery)
        {
            //mapping Domain Model to DTos
            var WalkDomain = await walkRepositry.GetAllWalkAsync(FilterOn, FilterQuery);


            return Ok(mapper.Map<List<WalkDTO>>(WalkDomain));


        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetWAlkByIdAsync([FromRoute] Guid id)
        {
            //domain model
            var WalkDomainModel = await walkRepositry.GetWalkByIdAsync(id);
            if (WalkDomainModel == null)
            {
                return NotFound();
            }
            var walkDto = new WalkDTO()
            {
                Id = WalkDomainModel.Id,
                Name = WalkDomainModel.Name,
                Description = WalkDomainModel.Description,
                LengthInKm = WalkDomainModel.LengthInKm,
                WalkImageId = WalkDomainModel.WalkImageId,
                RegionId = WalkDomainModel.RegionId,
                DifficaltyId = WalkDomainModel.DifficaltyId,
            };
            return Ok(mapper.Map<WalkDTO>(WalkDomainModel));

        }




        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //mapping Dto to Domain Model
            var WalkDomainModel = mapper.Map<Walk>(addWalkRequestDto);
            await walkRepositry.CreateAsync(WalkDomainModel);

            //mapping Domain Model to DTOs

            return Ok(mapper.Map<WalkDTO>(WalkDomainModel));

        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id,UpdateWalkRequestDto updateWalkRequestDto)
        {
            //Dtos to Domain Model
           
           var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

           

            walkDomainModel = await walkRepositry.updateWalkAsync(id, walkDomainModel);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            //mapping Domain Model to Dtos
            return Ok(mapper.Map<WalkDTO>(walkDomainModel));

        }



        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var ExistingWalk=await walkRepositry.DeleteAsync(id);
            if (ExistingWalk == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDTO>(ExistingWalk));
        }
    }
}
