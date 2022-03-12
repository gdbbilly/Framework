using Framework.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace Framework.UnitTests
{
    public class NumberServiceTest
    {
        /// <summary>
        /// Testa os divisores do número 10.
        /// </summary>
        [Fact]
        public void NumberServiceDividersSuccess()
        {
            NumberService numberService = new NumberService();

            var result = numberService.Calculate(10);
            result.Wait();
         
            var dividers = new List<long> { 1, 2, 5, 10 };

            Assert.Equal(dividers, result.Result.Dividers);
        }

        /// <summary>
        /// Testa os divisores primos do número 10.
        /// </summary>
        [Fact]
        public void NumberServicePrimesSuccess()
        {
            NumberService numberService = new NumberService();

            var result = numberService.Calculate(10);
            result.Wait();

            var primes = new List<long> { 2, 5 };

            Assert.Equal(primes, result.Result.Primes);
        }

        /// <summary>
        /// Testa os divisores do número 45.
        /// Testa os divisores primos do número 45.
        /// </summary>
        [Fact]
        public void NumberServiceSuccess()
        {
            NumberService numberService = new NumberService();

            var result = numberService.Calculate(45);
            result.Wait();

            var dividers = new List<long> { 1, 3, 5, 9, 15, 45 };
            var primes = new List<long> { 3, 5 };

            Assert.Equal(dividers, result.Result.Dividers);
            Assert.Equal(primes, result.Result.Primes);
        }

        /// <summary>
        /// Testa caso o número seja 0
        /// </summary>
        [Fact]
        public void NumberServiceDividersError()
        {
            NumberService numberService = new NumberService();

            var result = numberService.Calculate(0);
            result.Wait();

            Assert.Empty(result.Result.Dividers);
        }

        /// <summary>
        /// Testa caso o número seja negativo
        /// </summary>
        [Fact]
        public void NumberServiceError()
        {
            NumberService numberService = new NumberService();

            var result = numberService.Calculate(-10);
            result.Wait();

            Assert.Empty(result.Result.Dividers);
        }
    }
}
