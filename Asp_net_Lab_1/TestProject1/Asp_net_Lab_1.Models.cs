using Asp_net_Lab_1.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;
using Asp_net_Lab_1.DTOs;

namespace Tests.Models
{
    public class UserTests
    {


        [Fact]
        public void User_Email_Required()
        {
            // Arrange
            var user = new User();

            // Act
            user.Email = null; // Спроба встановити значення null для Email

            // Assert
            var result = ValidateModel(user);
            Xunit.Assert.Contains("The Email field is required.", result);
        }


        // Допоміжний метод для валідації моделі за допомогою DataAnnotations
        private string[] ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, serviceProvider: null, items: null);
            Validator.TryValidateObject(model, validationContext, validationResults, validateAllProperties: true);
            return validationResults.Select(r => r.ErrorMessage).ToArray();
        }
    }
}
