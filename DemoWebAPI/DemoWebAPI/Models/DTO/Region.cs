using DemoWebAPI.Models.Domain;

namespace DemoWebAPI.Models.DTO
{
    public class Region
    {

        public Guid Id { get; set; }

        public string RegionCode { get; set; }
        public string Name { get; set; }
        public Double Area { get; set; }
        public Double Lat { get; set; }
        public Double Long { get; set; }
        public Double Population { get; set; }

        //Navigation Property

        public IEnumerable<Walk> Walks { get; set; }
    }
}
