using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaxService.Entities.TaxJar.RequestForOrder
{
    public class TaxJarRequestForOrder
    {
        public string from_country { get; set; }
        public string from_zip { get; set; }
        public string from_state { get; set; }
        public string from_city { get; set; }
        public string from_street { get; set; }
        [Required]
        public string to_country { get; set; }
        public string to_zip { get; set; }
        public string to_state { get; set; }
        public string to_city { get; set; }
        public string to_street { get; set; }
        public double amount { get; set; }
        [Required]
        public double shipping { get; set; }
        public List<NexusAddressRequest> nexus_addresses { get; set; }
        public List<LineItemRequest> line_items { get; set; }
    }
}