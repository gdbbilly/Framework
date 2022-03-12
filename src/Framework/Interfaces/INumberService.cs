using System.Threading.Tasks;

namespace Framework.Interfaces
{
    public interface INumberService
    {
        Task<NumbersResult> Calculate(long number);
    }
}
