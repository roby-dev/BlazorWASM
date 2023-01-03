using BlazorContact.Wasm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorContact.Maui.Interfaces {
    public interface IContactService {
        Task SaveContact(Wasm.Shared.Contact contact);
        Task<ErrorResponse> saveUser(User user);
        Task DeleteContact(int id);
        Task<UsersResponse> GetAll();
        Task<UserResponse> GetDetails(string id);
      
    }
}
