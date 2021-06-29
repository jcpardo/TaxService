using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TaxService.Api.Dtos.RequestForLocation
{
    [BindProperties]
    public class TaxRequestForLocationDto
    {
        public string city { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        [Required]
        public string zip { get; set; }
    }
}