using System.Threading.Tasks;
using WisT.DemoWeb.API.DTO;

namespace WisT.DemoWeb.API.Services
{
    public interface IRegistrationService
    {
        Task<WisTResponse> RegisterAsync(RegistrationInfo userInfo);
    }
}
