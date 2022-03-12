using Framework.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace Framework.UnitTests
{
    public class NumberServiceTest
    {
        [Fact]
        public void NumberServiceDividersSuccess()
        {
            //Arrange
            NumberService numberService = new NumberService();

            var result = numberService.Calculate(10);
            result.Wait();
         
            var dividers = new List<long> { 1, 2, 5, 10 };

            Assert.Equal(dividers, result.Result.Dividers);
        }

        [Fact]
        public void NumberServicePrimesSuccess()
        {
            //Arrange
            NumberService numberService = new NumberService();

            var result = numberService.Calculate(10);
            result.Wait();

            var primes = new List<long> { 2, 5 };

            Assert.Equal(primes, result.Result.Primes);
        }

        [Fact]
        public void NumberServiceSuccess()
        {
            //Arrange
            NumberService numberService = new NumberService();

            var result = numberService.Calculate(45);
            result.Wait();

            var dividers = new List<long> { 1, 3, 5, 9, 15, 45 };
            var primes = new List<long> { 3, 5 };

            Assert.Equal(dividers, result.Result.Dividers);
            Assert.Equal(primes, result.Result.Primes);
        }

        [Fact]
        public void NumberServiceDividersError()
        {
            //Arrange
            NumberService numberService = new NumberService();

            var result = numberService.Calculate(0);
            result.Wait();

            Assert.Empty(result.Result.Dividers);
        }

        [Fact]
        public void NumberServiceError()
        {
            //Arrange
            NumberService numberService = new NumberService();

            var result = numberService.Calculate(-10);
            result.Wait();

            Assert.Empty(result.Result.Dividers);
        }
    }
}
