using Framework.Interfaces;
using System;
using System.Threading.Tasks;

namespace Framework.Services
{
    public class NumberService : INumberService
    {
        /// <summary>
        /// Calcula quais os divisores e quais dos divisores são primos
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public async Task<NumbersResult> Calculate(long number)
        {
            if (number <= 0)
                throw new Exception($"O número {number} não possui divisores!");

            NumbersResult result = new NumbersResult();

            for (long i = 1; i <= number; i++)
            {
                if (CheckDivider(number, i))
                {
                    result.Dividers.Add(i);
                }
            }

            foreach (var item in result.Dividers)
            {
                if (CheckPrime(item))
                {
                    result.Primes.Add(item);
                }
            }

            return result;
        }


        /// <summary>
        /// Verifica os possíveis divisores
        /// </summary>
        /// <param name="number"></param>
        /// <param name="divider"></param>
        /// <returns></returns>
        private bool CheckDivider(long number, long divider)
        {
            if (number % divider == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Verifica se o número passado é primo
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private bool CheckPrime(long number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var m = number / 2;
            for (var i = 2; i <= m; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
