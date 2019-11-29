using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpPost("task1")]
        public ActionResult<int> SumEverySecondNonOddDigit([FromBody] int[] digits)
        {
            return digits.Where((x) => Math.Abs(x % 2) == 1).Where((x, i) => i % 2 == 1).Select(x => Math.Abs(x)).Sum();
        }

        [HttpPost("task2")]
        public ActionResult<int[]> SumDigitalLinkedLists([FromBody]Task2Dto request)
        {
            return (new DigitalLinkedList(request.First) + new DigitalLinkedList(request.Second)).ToArray();
        }

        [HttpPost("task3")]
        public ActionResult<bool> IsStringPalindrom([FromBody] string value)
        {
            return value.ToUpper().SequenceEqual(value.ToUpper().Reverse());
        }
    }
}
