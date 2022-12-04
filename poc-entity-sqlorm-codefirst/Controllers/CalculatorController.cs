using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using poc_voya_entity.Services;

namespace poc_voya_entity.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculatorController : Controller
    {
        private ICalculator _calcServRepo;

        public CalculatorController (ICalculator calcServRepo)
        {
            _calcServRepo = calcServRepo;
        }

        [HttpPost]
        public string getName([FromQuery] string Name)
        {
            return _calcServRepo.getName(Name);
        }

        [HttpPost]
        public string getAdd([FromQuery] int num1, [FromQuery] int num2)
        {
            return _calcServRepo.getAdd(num1, num2);
        }

        [HttpPost]
        public string getSub([FromQuery] int num1, [FromQuery] int num2)
        {
            return _calcServRepo.getSub(num1, num2);
        }

        [HttpPost]
        public string getProd([FromQuery] int num1, [FromQuery] int num2)
        {
            return _calcServRepo.getProd(num1, num2);
        }

        [HttpPost]
        public string getDiv([FromQuery] int num1, [FromQuery] int num2)
        {
            return _calcServRepo.getDiv(num1, num2);
        }
    }
}
