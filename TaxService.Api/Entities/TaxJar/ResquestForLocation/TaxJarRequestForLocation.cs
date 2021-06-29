using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TaxService.Entities.TaxJar.ResquestForLocation
{
    [BindProperties]
    public class TaxJarRequestForLocation
    {
        public string city { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        [Required]
        public string zip { get; set; }
    }
}