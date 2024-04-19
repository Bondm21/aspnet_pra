using Asp_net_Lab_1.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;
using DataEmulator.DTOs;

namespace Tests.Models
{
    public class UserViewModelTests
    {


        [Fact]
        public void User_Email_Required()
        {
            // Arrange
            var user = new UserViewModel();
            user.Email = null; 


            // Act

            var result = user.ValidateUserViewModel();

            // Assert
            Xunit.Assert.Contains("The Email field is required.", result.FirstOrDefault().ErrorMessage);
        }



        private string[] ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, serviceProvider: null, items: null);
            Validator.TryValidateObject(model, validationContext, validationResults, validateAllProperties: true);
            return validationResults.Select(r => r.ErrorMessage).ToArray();
        }
        
    }

    public static class ValidationExtensions
    {
        public static IEnumerable<ValidationResult> ValidateUserViewModel(this UserViewModel userViewModel)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(userViewModel, serviceProvider: null, items: null);
            Validator.TryValidateObject(userViewModel, validationContext, validationResults, validateAllProperties: true);
            return validationResults;
        }
    }
}
