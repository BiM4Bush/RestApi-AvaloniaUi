using MVVMExampleApp.Backend.Models;
using System.ComponentModel.DataAnnotations;

namespace MVVMExampleApp.Tests.Backend.UnitTests
{
    public class AddRequestValidationTests
    {
        [Fact]
        public void AddRequest_ShouldBeInvalid_WhenFirstIntegerIsMissing()
        {
            // Arrange
            var model = new AddRequest { SecondInteger = 5 };  
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(model, context, results, true);

            // Assert
            Assert.False(isValid); 
            Assert.Contains(results, r => r.ErrorMessage.Contains("Field FirstInteger is requierd"));
        }

        [Fact]
        public void AddRequest_ShouldBeValid_WhenBothIntegersAreValid()
        {
            // Arrange
            var model = new AddRequest { FirstInteger = 1, SecondInteger = 2 };
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(model, context, results, true);

            // Assert
            Assert.True(isValid);
        }

    }
}
