namespace TaxService.Api.Dtos.RequestForOrder
{
    public class LineItemRequestDto
    {
        public string id { get; set; }
        public int quantity { get; set; }
        public string product_tax_code { get; set; }
        public double unit_price { get; set; }
        public double discount { get; set; }
    }
}