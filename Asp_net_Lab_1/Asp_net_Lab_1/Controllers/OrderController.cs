using Asp_net_Lab_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Asp_net_Lab_1.Resources;
using Microsoft.Extensions.Localization;
using DataEmulator;
using DataEmulator.DTOs;
using System.Linq;

namespace Asp_net_Lab_1.Controllers
{
    public sealed class OrderController : Controller
    {
        public IActionResult Order()
        {
            var orders = MockData.Orders.Select(order => new OrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                ProductName = order.ProductName,
                TotalPrice = order.TotalPrice
            }).ToList();

            return View("Order", orders);
        }

        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrder(OrderDto orderDto)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    Id = orderDto.Id,
                    UserId = orderDto.UserId,
                    ProductName = orderDto.ProductName,
                    TotalPrice = orderDto.TotalPrice
                };

                MockData.Orders.Add(orderDto);
                return RedirectToAction(nameof(Order));
            }
            return View(orderDto);
        }

        public IActionResult EditOrder(int id)
        {
            var order = MockData.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            var orderDto = new OrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                ProductName = order.ProductName,
                TotalPrice = order.TotalPrice
            };

            return View("EditOrder", orderDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditOrder(OrderDto orderDto)
        {
            if (ModelState.IsValid)
            {
                var existingOrder = MockData.Orders.FirstOrDefault(o => o.Id == orderDto.Id);
                if (existingOrder != null)
                {
                    existingOrder.UserId = orderDto.UserId;
                    existingOrder.ProductName = orderDto.ProductName;
                    existingOrder.TotalPrice = orderDto.TotalPrice;
                    return RedirectToAction(nameof(Order));
                }
                else
                {
                    return NotFound();
                }
            }
            return View(orderDto);
        }

        public IActionResult DeleteOrder(int id)
        {
            var order = MockData.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            var orderDto = new OrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                ProductName = order.ProductName,
                TotalPrice = order.TotalPrice
            };

            return View(orderDto);
        }

        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed_Order(int id)
        {
            var order = MockData.Orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {

                MockData.Orders.Remove(order);
                return RedirectToAction(nameof(Order));
            }
            else
            {
                return NotFound();
            }
        }
    }
}