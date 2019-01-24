using System;
using Microsoft.AspNetCore.Mvc;

namespace MyWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        enum Operation { Add, Subtract, Multiply, Divide }

        public Func<double, double, double> Sum = (x, y) => x + y;
        public Func<double, double, double> Substract = (x, y) => x - y;
        public Func<double, double, double> Multiply = (x, y) => x * y;
        public Func<double, double, double> Divide = (x, y) => x / y;

        // GET api/values/5
        [HttpGet("{x:double}-{y:double}-{operatorCode:int}")]
        public ActionResult<double> Get(double x, double y, int operatorCode)
        {
            switch (operatorCode)
            {
                case (int)Operation.Add:
                    return Sum(x, y);
                case (int)Operation.Subtract:
                    return Substract(x, y);
                case (int)Operation.Multiply:
                    return Multiply(x, y);
                case (int)Operation.Divide:
                    return Divide(x, y);
                default:
                    throw new Exception();
            }
        }
    }
}
