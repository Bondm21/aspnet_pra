using Asp_net_Lab_1.Controllers;
using Asp_net_Lab_1.Models;
using DataEmulator.DTOs;
using Asp_net_Lab_1.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Xunit;

namespace Asp_net_Lab_1.Tests
{
    public class HomeControllerTests
    {


        [Fact]
        public void CreateUser_ReturnsViewResult()
        {
            // Arrange
            var controller = new HomeController(null, null); 


            // Act
            var result = controller.CreateUser();

            // Assert
            Xunit.Assert.IsType<ViewResult>(result);
        }

        [Xunit.Theory]
        [Xunit.InlineData(1, "John Doe", "john@example.com", "123 Main St", "1234567890")]
        [Xunit.InlineData(2, "Jane Smith", "jane@example.com", "456 Elm St", "9876543210")]
        public void CreateUser_ValidInput_RedirectsToIndex(int id, string fullName, string email, string address, string phoneNumber)
        {
            // Arrange
            var logger = new NullLogger<HomeController>();
            var loggerFactory = new LoggerFactory();
            var localizer = new StringLocalizer<Texts>(new ResourceManagerStringLocalizerFactory(Options.Create(new LocalizationOptions()), loggerFactory));
            var controller = new HomeController(logger, localizer);
            var userDto = new UserDto { Id = id, FullName = fullName, Email = email, Address = address, PhoneNumber = phoneNumber };

            // Act
            var result = controller.CreateUser(userDto) as RedirectToActionResult;

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal("Index", result.ActionName);
        }

        [Xunit.Theory]
        [Xunit.InlineData(3, "", "jane@example.com", "456 Elm St", "9876543210")] // Missing FullName
        [Xunit.InlineData(4, "John Doe", "", "123 Main St", "1234567890")] // Missing Email
        public void CreateUser_InvalidInput_ReturnsView(int id, string fullName, string email, string address, string phoneNumber)
        {
            // Arrange
            var logger = new NullLogger<HomeController>();
            var loggerFactory = new LoggerFactory();
            var localizer = new StringLocalizer<Texts>(new ResourceManagerStringLocalizerFactory(Options.Create(new LocalizationOptions()), loggerFactory));
            var controller = new HomeController(logger, localizer);
            var userDto = new UserDto { Id = id, FullName = fullName, Email = email, Address = address, PhoneNumber = phoneNumber };
            controller.ModelState.AddModelError("", "Invalid input");

            // Act
            var result = controller.CreateUser(userDto) as ViewResult;

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(userDto, result.Model); // Ensure model returned to the view is the same as provided
        }

    }
}
