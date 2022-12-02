﻿namespace DemoWebAPI.Models.Domain
{
    public class Region
    {
        public Guid Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public Double Area { get; set; }
        public Double Lat { get; set; }
        public Double Long { get; set; }
        public Double Population { get; set; }

        //Navigation Property

        public IEnumerable<Walk> Walks { get; set; }
    }
}
