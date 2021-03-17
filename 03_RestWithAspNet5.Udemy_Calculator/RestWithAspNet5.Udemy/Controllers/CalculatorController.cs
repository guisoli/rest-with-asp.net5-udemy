using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithAspNet5.Udemy.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CalculatorController : ControllerBase
	{
		private readonly ILogger<CalculatorController> _logger;

		public CalculatorController(ILogger<CalculatorController> logger)
		{
			_logger = logger;
		}

		[HttpGet("sum/{firstNumber}/{secondNumber}")]
		public IActionResult Sum(string firstNumber, string secondNumber)
		{
			if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
			{
				var sum = Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber);
				return Ok(sum.ToString());
			}
			return BadRequest("Invalid input.");

		}

		[HttpGet("sub/{firstNumber}/{secondNumber}")]
		public IActionResult Sub(string firstNumber, string secondNumber)
		{
			if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
			{
				var result = Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber);
				return Ok(result.ToString());
			}
			return BadRequest("Invalid input.");

		}

		[HttpGet("multiply/{firstNumber}/{secondNumber}")]
		public IActionResult Multiply(string firstNumber, string secondNumber)
		{
			if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
			{
				var result = Convert.ToDecimal(firstNumber) * Convert.ToDecimal(secondNumber);
				return Ok(result.ToString());
			}
			return BadRequest("Invalid input.");

		}

		[HttpGet("divide/{firstNumber}/{secondNumber}")]
		public IActionResult Divide(string firstNumber, string secondNumber)
		{
			if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
			{
				var result = Convert.ToDecimal(firstNumber) / Convert.ToDecimal(secondNumber);
				return Ok(result.ToString());
			}
			return BadRequest("Invalid input.");

		}

		[HttpGet("average/{firstNumber}/{secondNumber}")]
		public IActionResult Average(string firstNumber, string secondNumber)
		{
			if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
			{
				var result = (Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber))/2;
				return Ok(result.ToString());
			}
			return BadRequest("Invalid input.");

		}

		[HttpGet("square-root/{number}")]
		public IActionResult SquareRoot(string number)
		{
			if (IsNumeric(number))
			{
				var result = Math.Sqrt(Convert.ToDouble(number));
				return Ok(result.ToString());
			}
			return BadRequest("Invalid input.");

		}
		public Boolean IsNumeric(string strNumber)
		{
			double dblNumber;
			bool isNumber = double.TryParse(
				strNumber,
				System.Globalization.NumberStyles.Any,

				System.Globalization.NumberFormatInfo.InvariantInfo, out dblNumber);
			return isNumber;
		}
		public Decimal ConvertToDecimal(string strNumber)
		{
			decimal decimalValue;
			if(decimal.TryParse(strNumber, out decimalValue))
			{
				return decimalValue;
			}
			return 0;
		}
	}
}
