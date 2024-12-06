using MVVMExampleApp.Backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExampleApp.Tests.Backend.UnitTests
{
    public class AddServiceTests
    {
        private readonly AddService _service;

        public AddServiceTests()
        {
            _service = new AddService();
        }

        [Theory]
        [InlineData(1, 5, 6)]
        [InlineData(-4, -1, -5)]
        [InlineData(0,0,0)]
        public void Add_ShouldReturnCorrectSum(int a, int b, int expectedSum)
        {
            //Act
            var result = _service.Add(a, b);

            //Assert
            Assert.Equal(expectedSum, result);
        }
    }
}
