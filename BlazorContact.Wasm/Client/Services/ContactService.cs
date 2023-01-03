using BlazorContact.Wasm.Shared;
using System.Net.Http.Json;

namespace BlazorContact.Wasm.Client.Services {
    public class ContactService : IContactService {
        private readonly HttpClient _httpClient;
        private readonly string _url = "api/contacts";

        public ContactService(HttpClient httpClient) {
            _httpClient = httpClient;
        }
        public async Task DeleteContact(int id) {
            await _httpClient.DeleteAsync($"{_url}/{id}");
        }

        public async Task<IEnumerable<Contact>> GetAll() {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Contact>>(_url);
        }

        public async Task<Contact> GetDetails(int id) {
            return await _httpClient.GetFromJsonAsync<Contact>($"{_url}/{id}");
        }

        public async Task SaveContact(Contact contact) {
            if (contact.Id == 0)
                await _httpClient.PostAsJsonAsync($"{_url}", contact);
            else
                await _httpClient.PutAsJsonAsync<Contact>($"{_url}/{contact.Id}", contact);
        }
    }
}
