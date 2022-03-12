using Framework.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Framework.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumbersController : ControllerBase
    {
        private readonly INumberService _numbersService;

        public NumbersController(INumberService numbersService)
        {
            _numbersService = numbersService;
        }

        /// <summary>
        /// Calcula quais os divisores de um número e quais dos divisores são primos.
        /// </summary>
        /// <param name="number">Número de entrada para calcular os divisores</param>
        /// <returns></returns>
        [HttpGet("Dividers")]
        public async Task<IActionResult> Dividers(int number)
        {
            try
            {
                var result = await _numbersService.Calculate(number);

                string resultFormated = $"Número de Entrada: {number}{Environment.NewLine}";
                resultFormated += $"Números Divisores: {string.Join(",", result.Dividers)}{Environment.NewLine}";
                resultFormated += $"Divisores Primos: {string.Join(",", result.Primes)}";

                return Ok(resultFormated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
