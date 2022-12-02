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
        public async Task<IActionResult> GetAllRegions()
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
    }
}
