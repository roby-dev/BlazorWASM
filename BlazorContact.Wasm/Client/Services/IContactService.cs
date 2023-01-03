using BlazorContact.Wasm.Shared;

namespace BlazorContact.Wasm.Client.Services {
    public interface IContactService {
        Task SaveContact(Contact contact);
        Task DeleteContact(int id);
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> GetDetails(int id);
    }
}
