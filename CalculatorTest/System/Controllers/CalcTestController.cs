using poc_voya_entity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CalculatorTest.System.Controllers
{
    public class CalcTestController
    {
        private CalculatorService _tester;

        public CalcTestController()
        {
            if(_tester == null)
            {
                _tester = new CalculatorService();
            }
        }

        [Fact]
        public void getName()
        {
            string name = "SK", expected = $"{name} logged in successfully";
            var actual = _tester.getName(name);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void getAdd()
        {
            int a = 8, b = 2; string expected = $"The sum is {a+b}";
            var actual = _tester.getAdd(a, b);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void getSub()
        {
            int a = 8, b = 2; string expected = $"The difference is {a - b}";
            var actual = _tester.getSub(a, b);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void getProd()
        {
            int a = 8, b = 2; string expected = $"The product is {a * b}";
            var actual = _tester.getProd(a, b);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void getDiv()
        {
            int a = 8, b = 2; string expected = $"The quotient is {a / b}";
            var actual = _tester.getDiv(a, b);
            Assert.Equal(expected, actual);
        }
    }
}
