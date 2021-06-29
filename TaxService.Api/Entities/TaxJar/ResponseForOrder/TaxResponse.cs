namespace TaxService.Api.Entities.TaxJar.ResponseForOrder
{
    public class TaxResponse
    {
        public double order_total_amount { get; set; }
        public double shipping { get; set; }
        public double taxable_amount { get; set; }
        public double amount_to_collect { get; set; }
        public double rate { get; set; }
        public bool has_nexus { get; set; }
        public bool freight_taxable { get; set; }
        public string exemption_type { get; set; }
        public string tax_source { get; set; }
        public JurisdictionsResponse jurisdictions { get; set; }
        public BreakdownResponse breakdown { get; set; }
    }
}
