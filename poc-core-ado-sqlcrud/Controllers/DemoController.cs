using dotnet_ado_sql_poc.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_ado_sql_poc.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class DemoController : Controller
    {
        private IDemoCalc _demoServ;

        public DemoController (IDemoCalc demoServ)
        {
            _demoServ = demoServ;
        }

        [HttpGet]
        public string getName()
        {
            var result = _demoServ.getName();
            return result;
        }

        [HttpPost]
        public string getAdd([FromQuery] int num1, [FromQuery] int num2)
        {
            var result = _demoServ.getAdd(num1, num2);
            return result;
        }

        [HttpPost]  
        public string getSub([FromQuery] int num1, [FromQuery] int num2)
        {
            var result = _demoServ.getSub(num1, num2);
            return result;
        }

        [HttpPost]
        public string getProd([FromQuery] int num1, [FromQuery] int num2)
        {
            var result = _demoServ.getProd(num1, num2);
            return result;
        }

        [HttpPost]
        public string getDiv([FromQuery] int num1, [FromQuery] int num2)
        {
            var result = _demoServ.getDiv(num1, num2);
            return result;
        }
    }
}
