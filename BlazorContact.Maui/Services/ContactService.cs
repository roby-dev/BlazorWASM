using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BlazorContact.Maui.Interfaces;
using BlazorContact.Wasm.Shared;
using Microsoft.Maui.ApplicationModel.Communication;

namespace BlazorContact.Maui.Services {
    internal class ContactService : IContactService {
        private readonly HttpClient _httpClient;
        private readonly IAuthService _authService;
        private readonly string _url = "api/users";
        public ContactService(HttpClient httpClient,IAuthService authService) {
            _httpClient = httpClient;
            _authService = authService;
		}
        public async Task DeleteContact(int id) {
            await _httpClient.DeleteAsync($"{_url}/{id}");
        }



        public async Task<UsersResponse> GetAll() {
            var token = _authService.getToken();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("saeta-token", token);
            return await _httpClient.GetFromJsonAsync<UsersResponse>($"{_url}/all");
        }  

        public async Task<UserResponse> GetDetails(string id) {
            var token = _authService.getToken();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("saeta-token", token);
            return await _httpClient.GetFromJsonAsync<UserResponse>($"{_url}/id/{id}");
        }

        public async Task SaveContact(Wasm.Shared.Contact contact) {
            if (contact.Id == 0)
                await _httpClient.PostAsJsonAsync($"{_url}", contact);
            else
                await _httpClient.PutAsJsonAsync($"{_url}/{contact.Id}", contact);
        }

        public async Task<ErrorResponse> saveUser(User user) {
            ErrorResponse errorResponse;
            var token = _authService.getToken();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("saeta-token", token);
            if (String.IsNullOrEmpty(user._id)) {
                var response = await _httpClient.PostAsJsonAsync<User>($"{_url}", user);     
                errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                if (String.IsNullOrEmpty(errorResponse.msg)) errorResponse.msg = "Usuario creado";
            } else {
                var response = await _httpClient.PutAsJsonAsync($"{_url}/{user._id}", user);
                errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                if (String.IsNullOrEmpty(errorResponse.msg)) errorResponse.msg = "Usuario actualizado";
            }
            return errorResponse;
        }
    }
}
