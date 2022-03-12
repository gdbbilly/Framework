using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application.Interfaces
{
    public interface INumberService
    {
        Task<NumbersResult> Calculate(long number);
    }
}
