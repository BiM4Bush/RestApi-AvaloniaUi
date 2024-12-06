using MVVMExampleApp.Frontend.Models;
using System.Threading.Tasks;

namespace MVVMExampleApp.Frontend.Services
{
    public interface IApiService
    {
        Task<AddResponse> AddNumbersAsync(AddRequest request);

    }
}
