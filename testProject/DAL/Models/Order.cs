namespace DAL.Models
{
    public partial class Order
    {
        public int OrderID { get; set; }

        public int UserID { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal OrderCost { get; set; }

        public string? ItemsDescription { get; set; }

        public string ShippingAddress { get; set; } = null!;
    }
}
