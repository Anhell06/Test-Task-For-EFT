using System.Threading;
using System.Threading.Tasks;

namespace Test_Task
{
    public interface ITextLoader
    {
        Task<string> GetDataAsync(params string[] arg);
    }
}