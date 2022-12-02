using AutoMapper;
using DemoWebAPI.Models.DTO;
using DemoWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await regionRepository.GetAllAsync();

            #region DTO Explaination
            //// return DTO regions (Data Transform Objects)
            //var regionsDTO = new List<Region>();
            //regions.ToList().ForEach(region =>
            //{
            //    var regionDTO = new Region()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population,
            //        Walks = region.Walks
            //    };
            //    regionsDTO.Add(regionDTO);
            //});
            #endregion

            var regionsDTO =  mapper.Map<List<Region>>(regions);

            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionRepository.GetAsync(id);
            if(region == null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<Region>(region);
            return Ok(regionDTO);
        }

        [HttpPost]
       
        public async Task<IActionResult> AddRegionAsync(AddRegionRequest addRegionRequest)
        {
            // Convert Request to domain model
            var region = new Models.Domain.Region()
            {
                Code = addRegionRequest.Code,
                Name = addRegionRequest.Name,
                Area = addRegionRequest.Area,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Population = addRegionRequest.Population,
            };

            // pass details to repository
            region =  await regionRepository.AddAsync(region);

            // Convert back to DTO
            var regionDTO = mapper.Map<Region>(region);
            return CreatedAtAction(nameof(GetRegionAsync), new { id = region.Id}, regionDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var region = await regionRepository.DeleteAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<Region>(region);
            return Ok(regionDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute]Guid id,[FromBody] UpdateRegionRequest updateRegionRequest)
        {
            // Convert Request to domain model
            var region = new Models.Domain.Region()
            {
                Code = updateRegionRequest.Code,
                Name = updateRegionRequest.Name,
                Area = updateRegionRequest.Area,
                Lat = updateRegionRequest.Lat,
                Long = updateRegionRequest.Long,
                Population = updateRegionRequest.Population,
            };

            // pass details to repository
            region = await regionRepository.UpdateAsync(id, region);

            // if null return not found
            if (region == null)
            {
                return NotFound();
            }
            // Convert back to DTO
            var regionDTO = mapper.Map<Region>(region);
            return Ok(regionDTO);
        }
    }
}
