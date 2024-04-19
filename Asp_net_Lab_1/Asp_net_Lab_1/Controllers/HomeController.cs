using Asp_net_Lab_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Asp_net_Lab_1.Resources;
using Microsoft.Extensions.Localization;
using DataEmulator;
using DataEmulator.DTOs;


namespace Asp_net_Lab_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<Texts> _localizer;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<Texts> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }



        //public IActionResult Index()
        //{
        //    var usersDto = MockData.Users.Select(user => new UserDto
        //    {
        //        Id = user.Id,
        //        FullName = user.FullName,
        //        Email = user.Email,
        //        Address = user.Address,
        //        PhoneNumber = user.PhoneNumber,
        //        RegistrationDate = user.RegistrationDate
        //    }).ToList();
        //    return View(usersDto);

        //}

        //public IActionResult CreateUser()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult CreateUser(UserDto userDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new UserViewModel
        //        {
        //            Id = userDto.Id,
        //            FullName = userDto.FullName,
        //            Email = userDto.Email,
        //            Address = userDto.Address,
        //            PhoneNumber = userDto.PhoneNumber

        //        };

        //        MockData.Users.Add(userDto);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(userDto);
        //}

        //public IActionResult EditUser(int id)
        //{
        //    var user = MockData.Users.FirstOrDefault(u => u.Id == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    var userDTO = new UserDto
        //    {
        //        Id = user.Id,
        //        FullName = user.FullName,
        //        Email = user.Email,
        //        Address = user.Address,
        //        PhoneNumber = user.PhoneNumber,
        //        RegistrationDate = user.RegistrationDate
        //    };

        //    return View("EditUser", userDTO);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditUser(UserDto userDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var existingUser = MockData.Users.FirstOrDefault(u => u.Id == userDto.Id);
        //        if (existingUser != null)
        //        {
        //            existingUser.FullName = userDto.FullName;
        //            existingUser.Email = userDto.Email;
        //            existingUser.Address = userDto.Address;
        //            existingUser.PhoneNumber = userDto.PhoneNumber;

        //            return RedirectToAction(nameof(Index));
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
        //    return View(userDto);
        //}

        //public IActionResult DeleteUser(int id)
        //{
        //    var user = MockData.Users.FirstOrDefault(u => u.Id == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    var userDto = new UserDto
        //    {
        //        Id = user.Id,
        //        FullName = user.FullName,
        //        Email = user.Email,
        //        Address = user.Address,
        //        PhoneNumber = user.PhoneNumber,
        //        RegistrationDate = user.RegistrationDate
        //    };

        //    return View(userDto);
        //}

        //[HttpPost, ActionName("DeleteUser")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    var user = MockData.Users.FirstOrDefault(u => u.Id == id);
        //    if (user != null)
        //    {
        //        MockData.Users.Remove(user);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}




        //public IActionResult Privacy()
        //{
        //    var productsDto = MockData.Products.Select(product => new ProductDto
        //    {
        //        Id = product.Id,
        //        Name = product.Name,
        //        Description = product.Description,
        //        Price = product.Price
        //    }).ToList();

        //    return View(productsDto);
        //}

        //public IActionResult CreateProd()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult CreateProd(ProductDto productDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var product = new Product
        //        {
        //            Id = productDto.Id,
        //            Name = productDto.Name,
        //            Description = productDto.Description,
        //            Price = productDto.Price
        //        };

        //        MockData.Products.Add(productDto);
        //        return RedirectToAction(nameof(Privacy));
        //    }
        //    return View(productDto);
        //}

        //public IActionResult EditProd(int id)
        //{
        //    var product = MockData.Products.FirstOrDefault(p => p.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    var productDto = new ProductDto
        //    {
        //        Id = product.Id,
        //        Name = product.Name,
        //        Description = product.Description,
        //        Price = product.Price
        //    };

        //    return View("EditProd", productDto);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditProd(ProductDto productDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var existingProduct = MockData.Products.FirstOrDefault(p => p.Id == productDto.Id);
        //        if (existingProduct != null)
        //        {
        //            existingProduct.Name = productDto.Name;
        //            existingProduct.Description = productDto.Description;
        //            existingProduct.Price = productDto.Price;
        //            return RedirectToAction(nameof(Privacy));
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
        //    return View(productDto);
        //}

        //public IActionResult DeleteProd(int id)
        //{
        //    var product = MockData.Products.FirstOrDefault(p => p.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    var productDto = new ProductDto
        //    {
        //        Id = product.Id,
        //        Name = product.Name,
        //        Description = product.Description,
        //        Price = product.Price
        //    };

        //    return View(productDto);
        //}

        //[HttpPost, ActionName("DeleteProd")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed_Prod(int id)
        //{
        //    var product = MockData.Products.FirstOrDefault(p => p.Id == id);
        //    if (product != null)
        //    {

        //        MockData.Products.Remove(product);
        //        return RedirectToAction(nameof(Privacy));
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}






        //public IActionResult Order()
        //{
        //    var orders = MockData.Orders.Select(order => new OrderDto
        //    {
        //        Id = order.Id,
        //        UserId = order.UserId,
        //        ProductName = order.ProductName,
        //        TotalPrice = order.TotalPrice
        //    }).ToList();

        //    return View(orders);
        //}

        //public IActionResult CreateOrder()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult CreateOrder(OrderDto orderDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var order = new Order
        //        {
        //            Id = orderDto.Id,
        //            UserId = orderDto.UserId,
        //            ProductName = orderDto.ProductName,
        //            TotalPrice = orderDto.TotalPrice
        //        };

        //        MockData.Orders.Add(orderDto);
        //        return RedirectToAction(nameof(Order));
        //    }
        //    return View(orderDto);
        //}

        //public IActionResult EditOrder(int id)
        //{
        //    var order = MockData.Orders.FirstOrDefault(o => o.Id == id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    var orderDto = new OrderDto
        //    {
        //        Id = order.Id,
        //        UserId = order.UserId,
        //        ProductName = order.ProductName,
        //        TotalPrice = order.TotalPrice
        //    };

        //    return View("EditOrder", orderDto);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditOrder(OrderDto orderDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var existingOrder = MockData.Orders.FirstOrDefault(o => o.Id == orderDto.Id);
        //        if (existingOrder != null)
        //        {
        //            existingOrder.UserId = orderDto.UserId;
        //            existingOrder.ProductName = orderDto.ProductName;
        //            existingOrder.TotalPrice = orderDto.TotalPrice;
        //            return RedirectToAction(nameof(Order));
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
        //    return View(orderDto);
        //}

        //public IActionResult DeleteOrder(int id)
        //{
        //    var order = MockData.Orders.FirstOrDefault(o => o.Id == id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    var orderDto = new OrderDto
        //    {
        //        Id = order.Id,
        //        UserId = order.UserId,
        //        ProductName = order.ProductName,
        //        TotalPrice = order.TotalPrice
        //    };

        //    return View(orderDto);
        //}

        //[HttpPost, ActionName("DeleteOrder")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed_Order(int id)
        //{
        //    var order = MockData.Orders.FirstOrDefault(o => o.Id == id);
        //    if (order != null)
        //    {

        //        MockData.Orders.Remove(order);
        //        return RedirectToAction(nameof(Order));
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}










        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
