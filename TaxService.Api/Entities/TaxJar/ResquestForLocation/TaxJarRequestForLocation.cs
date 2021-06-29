using System.ComponentModel.DataAnnotations;

namespace TaxService.Api.Entities.TaxJar.ResquestForLocation
{
    public class TaxJarRequestForLocation
    {
        public string city { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        [Required]
        public string zip { get; set; }
    }
}