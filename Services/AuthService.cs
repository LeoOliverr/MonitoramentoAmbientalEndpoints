using MonitoramentoAmbientalEndpoints.Models;

namespace MonitoramentoAmbientalEndpoints.Services
{
    public class AuthService : IAuthService
    {
        private List<UserModel> _users = new List<UserModel>
        {
            new UserModel {UserId = 1, UserName = "Rogério", Password = "1234", Role = "operador"},
            new UserModel {UserId = 2, UserName = "Marcela", Password = "5678", Role = "gerente" }
        };

        public UserModel Authenticate(string username, string password) { 
        return _users.FirstOrDefault(u => u.UserName == username && u.Password == password);
        }
    }
}
