namespace Asp_net_Lab_1.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProductName { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
 