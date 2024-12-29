using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositries;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficaltiesController : ControllerBase
    {
        private readonly NZWalksDbContext nZWalksDbContext;
        private readonly IMapper mapper;

        public DifficaltiesController(NZWalksDbContext nZWalksDbContext,IMapper mapper)
        {
            this.nZWalksDbContext = nZWalksDbContext;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> createAsync([FromBody]DifficaltyDTOs difficaltyDTOs)
        {
             
            //mapping Dto to Domain Model
            var diff = mapper.Map<Difficalty>(difficaltyDTOs);
           // await walkRepositry.CreateAsync(WalkDomainModel);
           await nZWalksDbContext.AddAsync(diff);
            await nZWalksDbContext.SaveChangesAsync();
            //mapping Domain Model to DTOs

            return Ok(mapper.Map<DifficaltyDTOs>(diff));


        }
    }
}
