namespace AvalphaTechnologies.CommissionCalculator.DTO
{
    public class CommissionCalRequestDTO
    {
        public int LocalSalesCount { get; set; }
        public int ForeignSalesCount { get; set; }
        public decimal AverageSaleAmount { get; set; }
    }
}