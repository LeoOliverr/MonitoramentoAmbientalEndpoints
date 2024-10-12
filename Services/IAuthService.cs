using MonitoramentoAmbientalEndpoints.Models;

namespace MonitoramentoAmbientalEndpoints.Services
{
    public interface IAuthService
    {
        UserModel Authenticate(string username, string password);
    }
}
