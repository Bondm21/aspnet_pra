using Asp_net_Lab_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Asp_net_Lab_1.Resources;
using Microsoft.Extensions.Localization;
using Asp_net_Lab_1.DTOs;



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

       


        public IActionResult Index()
        {
            var usersDTO = DataEmulator.Users.Select(user => new UserDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                RegistrationDate = user.RegistrationDate
            }).ToList();

            ViewBag.Користувачі = _localizer["Користувачі"].Value;
            return View(usersDTO);
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser(UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Id = userDTO.Id,
                    FullName = userDTO.FullName,
                    Email = userDTO.Email,
                    Address = userDTO.Address,
                    PhoneNumber = userDTO.PhoneNumber
                    // RegistrationDate is not editable in this action
                };

                // Додати нового користувача до списку
                DataEmulator.Users.Add(user);
                return RedirectToAction(nameof(Index));
            }
            return View(userDTO);
        }

        public IActionResult EditUser(int id)
        {
            var user = DataEmulator.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            var userDTO = new UserDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                RegistrationDate = user.RegistrationDate
            };

            return View("EditUser", userDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditUser(UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var existingUser = DataEmulator.Users.FirstOrDefault(u => u.Id == userDTO.Id);
                if (existingUser != null)
                {
                    existingUser.FullName = userDTO.FullName;
                    existingUser.Email = userDTO.Email;
                    existingUser.Address = userDTO.Address;
                    existingUser.PhoneNumber = userDTO.PhoneNumber;
                    // RegistrationDate is not editable in this action
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            return View(userDTO);
        }

        public IActionResult DeleteUser(int id)
        {
            var user = DataEmulator.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            var userDTO = new UserDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                RegistrationDate = user.RegistrationDate
            };

            return View(userDTO);
        }

        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = DataEmulator.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                DataEmulator.Users.Remove(user);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }




        public IActionResult Privacy()
        {
            var productsDTO = DataEmulator.Products.Select(product => new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            }).ToList();

            return View(productsDTO);
        }

        public IActionResult CreateProd()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProd(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Id = productDTO.Id,
                    Name = productDTO.Name,
                    Description = productDTO.Description,
                    Price = productDTO.Price
                };

                // Додати новий продукт до списку
                DataEmulator.Products.Add(product);
                return RedirectToAction(nameof(Privacy));
            }
            return View(productDTO);
        }

        public IActionResult EditProd(int id)
        {
            var product = DataEmulator.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var productDTO = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };

            return View("EditProd", productDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProd(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = DataEmulator.Products.FirstOrDefault(p => p.Id == productDTO.Id);
                if (existingProduct != null)
                {
                    existingProduct.Name = productDTO.Name;
                    existingProduct.Description = productDTO.Description;
                    existingProduct.Price = productDTO.Price;
                    return RedirectToAction(nameof(Privacy));
                }
                else
                {
                    return NotFound();
                }
            }
            return View(productDTO);
        }

        public IActionResult DeleteProd(int id)
        {
            var product = DataEmulator.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var productDTO = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };

            return View(productDTO);
        }

        [HttpPost, ActionName("DeleteProd")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed_Prod(int id)
        {
            var product = DataEmulator.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                // Видалити продукт зі списку
                DataEmulator.Products.Remove(product);
                return RedirectToAction(nameof(Privacy));
            }
            else
            {
                return NotFound();
            }
        }






        public IActionResult Order()
        {
            var orders = DataEmulator.Orders.Select(order => new OrderDTO
            {
                Id = order.Id,
                UserId = order.UserId,
                ProductName = order.ProductName,
                TotalPrice = order.TotalPrice
            }).ToList();

            return View(orders);
        }

        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrder(OrderDTO orderDTO)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    Id = orderDTO.Id,
                    UserId = orderDTO.UserId,
                    ProductName = orderDTO.ProductName,
                    TotalPrice = orderDTO.TotalPrice
                };

                // Додати нове замовлення до списку
                DataEmulator.Orders.Add(order);
                return RedirectToAction(nameof(Order));
            }
            return View(orderDTO);
        }

        public IActionResult EditOrder(int id)
        {
            var order = DataEmulator.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            var orderDTO = new OrderDTO
            {
                Id = order.Id,
                UserId = order.UserId,
                ProductName = order.ProductName,
                TotalPrice = order.TotalPrice
            };

            return View("EditOrder", orderDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditOrder(OrderDTO orderDTO)
        {
            if (ModelState.IsValid)
            {
                var existingOrder = DataEmulator.Orders.FirstOrDefault(o => o.Id == orderDTO.Id);
                if (existingOrder != null)
                {
                    existingOrder.UserId = orderDTO.UserId;
                    existingOrder.ProductName = orderDTO.ProductName;
                    existingOrder.TotalPrice = orderDTO.TotalPrice;
                    return RedirectToAction(nameof(Order));
                }
                else
                {
                    return NotFound();
                }
            }
            return View(orderDTO);
        }

        public IActionResult DeleteOrder(int id)
        {
            var order = DataEmulator.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            var orderDTO = new OrderDTO
            {
                Id = order.Id,
                UserId = order.UserId,
                ProductName = order.ProductName,
                TotalPrice = order.TotalPrice
            };

            return View(orderDTO);
        }

        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed_Order(int id)
        {
            var order = DataEmulator.Orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                // Видалити замовлення зі списку
                DataEmulator.Orders.Remove(order);
                return RedirectToAction(nameof(Order));
            }
            else
            {
                return NotFound();
            }
        }










        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
