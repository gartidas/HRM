using System.Threading.Tasks;
using WebApi.Domain;
using WebApi.Domain.IdentityModels;

namespace WebApi.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> LoginAsync(string username, string password);
        Task<OperationResult> RegisterAsync(RegisterModel model);
    }
}
