using System;

namespace TaxService.Entities.TaxJar.RequestForOrder
{
    public class NexusAddressRequest
    {
        public string id { get; set; }
        public string country { get; set; }
        public string zip { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string street { get; set; }
    }
}