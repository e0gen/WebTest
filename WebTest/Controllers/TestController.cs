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
            //Θ(n)
            int result = 0;
            bool isSecond = false;
            for (int i = 0; i < digits.Length; i++)
                if (Math.Abs(digits[i] % 2) == 1)
                {
                    if (isSecond) result += Math.Abs(digits[i]);
                    isSecond = !isSecond;
                }
            return result;
        }

        [HttpPost("task2")]
        public ActionResult<int> SumDigitalLinkedLists([FromBody] int[] digits)
        {
            if (digits.Length != 2) return BadRequest();
            //Θ(n)
            return (new DigitalLinkedList(digits[0]) + new DigitalLinkedList(digits[1])).ToInt32();
        }

        [HttpPost("task3")]
        public ActionResult<bool> IsStringPalindrom([FromBody] string value)
        {
            //Θ(n/2)
            for (int i = 0; i < value.Length / 2; i++)
            {
                if (char.ToUpperInvariant(value[i]) != char.ToUpperInvariant(value[value.Length -1 - i]))
                    return false;
            }
            return true;
        }
    }
}
