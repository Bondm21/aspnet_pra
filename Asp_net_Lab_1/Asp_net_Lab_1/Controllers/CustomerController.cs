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
    public sealed class CustomerController : Controller
    {

        public IActionResult Privacy()
        {
            var productsDto = MockData.Products.Select(product => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            }).ToList();

            return View(productsDto);
        }

        public IActionResult CreateProd()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProd(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Id = productDto.Id,
                    Name = productDto.Name,
                    Description = productDto.Description,
                    Price = productDto.Price
                };

                MockData.Products.Add(productDto);
                return RedirectToAction(nameof(Privacy));
            }
            return View(productDto);
        }

        public IActionResult EditProd(int id)
        {
            var product = MockData.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };

            return View("EditProd", productDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProd(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = MockData.Products.FirstOrDefault(p => p.Id == productDto.Id);
                if (existingProduct != null)
                {
                    existingProduct.Name = productDto.Name;
                    existingProduct.Description = productDto.Description;
                    existingProduct.Price = productDto.Price;
                    return RedirectToAction(nameof(Privacy));
                }
                else
                {
                    return NotFound();
                }
            }
            return View(productDto);
        }

        public IActionResult DeleteProd(int id)
        {
            var product = MockData.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };

            return View(productDto);
        }

        [HttpPost, ActionName("DeleteProd")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed_Prod(int id)
        {
            var product = MockData.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {

                MockData.Products.Remove(product);
                return RedirectToAction(nameof(Privacy));
            }
            else
            {
                return NotFound();
            }
        }


    }
}
