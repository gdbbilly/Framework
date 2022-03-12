using System;
using System.Collections.Generic;

namespace Framework
{
    public class NumbersResult
    {
        public NumbersResult()
        {
            Dividers = new List<long>();
            Primes = new List<long>();
        }

        public List<long> Dividers { get; set; }
        public List<long> Primes { get; set; }
    } 
}
