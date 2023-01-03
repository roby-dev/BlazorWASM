using BlazorContact.Wasm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorContact.Maui.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> login(Auth auth);
        void logout();
        Task<LoginResponse> renewToken(string token);
        Task<User> isLogged();
        void setUser(User user);
        void setToken(string token);
        string getToken();
    }
}
