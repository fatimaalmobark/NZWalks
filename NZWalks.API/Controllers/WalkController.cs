using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
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

        public WalkController(NZWalksDbContext nZWalksDbContext,IMapper mapper, IWalkRepositry walkRepositry)
        {
            this.nZWalksDbContext = nZWalksDbContext;
            this.mapper = mapper;
            this.walkRepositry = walkRepositry;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //mapping Dto to Domain Model
           var WalkDomainModel=mapper.Map<Walk>(addWalkRequestDto);
           await walkRepositry.CreateAsync(WalkDomainModel);

            //mapping Domain Model to DTOs

            return Ok(mapper.Map<WalkDTO>(WalkDomainModel));
        }
    }
}
