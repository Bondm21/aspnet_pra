namespace DataEmulator.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProductName { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
 