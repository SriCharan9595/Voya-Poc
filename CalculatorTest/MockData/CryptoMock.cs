using poc_voya_entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest.MockData
{
    public class CryptoMock
    {
        public static List<crypto> CryptoMockList()
        {
            return new List<crypto>{
                new crypto{
                    cryptoID = 1000,
                    cryptoName = "Bitcoin",
                    priceUSD = 5000.25
                },
                new crypto{
                    cryptoID = 1001,
                    cryptoName = "Dogecoin",
                    priceUSD = 0.5
                },
            };

        }
    }
}
