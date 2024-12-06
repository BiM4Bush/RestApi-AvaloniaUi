using FluentAssertions;
using Moq;
using MVVMExampleApp.Frontend.Models;
using MVVMExampleApp.Frontend.Services;
using MVVMExampleApp.Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExampleApp.Tests.Frontend
{
    public class AddViewModelTests
    {
        private readonly Mock<IApiService> _apiServiceMock;
        private readonly AddViewModel _viewModel;

        public AddViewModelTests()
        {
            _apiServiceMock = new Mock<IApiService>();
            _viewModel = new AddViewModel(_apiServiceMock.Object);
        }
        [Fact]
        public void Should_Set_FirstInteger_Property()
        {
            // Arrange
            var newValue = 10;

            // Act
            _viewModel.FirstInteger = newValue;

            // Assert
            _viewModel.FirstInteger.Should().Be(newValue);
        }

        [Fact]
        public void Should_Set_SecondInteger_Property()
        {
            // Arrange
            var newValue = 20;

            // Act
            _viewModel.SecondInteger = newValue;

            // Assert
            _viewModel.SecondInteger.Should().Be(newValue);
        }

        [Fact]
        public async Task AddCommand_Should_Update_Result()
        {
            // Arrange
            var request = new AddRequest { FirstInteger = 5, SecondInteger = 3 };
            var response = new AddResponse { Result = 8 };

            _apiServiceMock.Setup(service => service.AddNumbersAsync(It.IsAny<AddRequest>()))
                .ReturnsAsync(response);

            // Act
            await _viewModel.AddNumbersAsync();

            // Assert
            _viewModel.Result.Should().Be(response.Result);
        }

    }
}
