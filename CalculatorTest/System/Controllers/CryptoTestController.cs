using CalculatorTest.MockData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using poc_voya_entity.Controllers;
using poc_voya_entity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CalculatorTest.System.Controllers
{
    public class CryptoTestController
    {
        [Fact]
        public async Task getAllCrypto_ShouldReturn200Status()
        {
            /// Arrange
            var cryptoService = new Mock<ICrypto>();
            cryptoService.Setup(_ => _.getAllCrypto()).ReturnsAsync(CryptoMock.CryptoMockList());
            var sut = new CryptoController(cryptoService.Object);

            /// Act
            var result = (OkObjectResult)await sut.getAllCrypto();


            /// Assert
            Assert.Equal(200, result.StatusCode);
        }
    }
}
