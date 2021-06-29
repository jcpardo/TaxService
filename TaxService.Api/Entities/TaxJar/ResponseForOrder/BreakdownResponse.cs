using System.Collections.Generic;

namespace TaxService.Entities.TaxJar.ResponseForOrder
{
    public class BreakdownResponse
    {
        public double taxable_amount { get; set; }
        public double tax_collectable { get; set; }
        public double combined_tax_rate { get; set; }
        public double state_taxable_amount { get; set; }
        public double state_tax_rate { get; set; }
        public double state_tax_collectable { get; set; }
        public double county_taxable_amount { get; set; }
        public double county_tax_rate { get; set; }
        public double county_tax_collectable { get; set; }
        public double city_taxable_amount { get; set; }
        public double city_tax_rate { get; set; }
        public double city_tax_collectable { get; set; }
        public double special_district_taxable_amount { get; set; }
        public double special_tax_rate { get; set; }
        public double special_district_tax_collectable { get; set; }
        //public ShippingResponse shipping { get; set; }
        public List<LineItemResponse> line_items { get; set; }
    }

    //public class ShippingResponse
    //{
    //}
}