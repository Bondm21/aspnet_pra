
using DataEmulator.DTOs;

namespace DataEmulator
{
    public class MockData 
    {
        
        public static List<UserDto> Users { get; set; } = new List<UserDto>
        {
            new UserDto { Id = 1, FullName = "John Doe", Email = "john@example.com", PhoneNumber = "1234567890", Address = "123 Main St" },
            new UserDto { Id = 2, FullName = "Jane Smith", Email = "jane@example.com", PhoneNumber = "0987654321", Address = "456 Elm St" }
        };
        public static List<ProductDto> Products { get; set; } = new List<ProductDto>
        {
            new ProductDto { Id = 1, Name = "Product 1", Description = "Description of Product 1", Price = 10.99m },
            new ProductDto { Id = 2, Name = "Product 2", Description = "Description of Product 2", Price = 20.99m }
        };
        public static List<OrderDto> Orders { get; set; } = new List<OrderDto>
        {
            new OrderDto { Id = 1, UserId = 1, ProductName = "Product 1", TotalPrice = 10.99m },
            new OrderDto { Id = 2, UserId = 2, ProductName = "Product 2", TotalPrice = 20.99m }
        };
    }
}
