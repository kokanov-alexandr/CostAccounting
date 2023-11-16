namespace CostAccounting.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }

    }
}   
