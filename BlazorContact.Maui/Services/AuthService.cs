using BlazorContact.Maui.Interfaces;
using BlazorContact.Wasm.Shared;
using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorContact.Maui.Services {
    public class AuthService : IAuthService {
        // api/login
        private readonly string _URL = @"api/login";
        private readonly HttpClient _httpClient;
        private static User? user;
        private static string? token;
        public AuthService(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<LoginResponse> login(Auth auth) {
            var response = await _httpClient.PostAsJsonAsync($"{_URL}/base", auth);
            return await response.Content.ReadFromJsonAsync<LoginResponse>();
        }

        public void logout() {
            user = null;
            token = null;
            Preferences.Clear();
        }

        public async Task<LoginResponse> renewToken(string token) {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("saeta-token", token);
            var response = await _httpClient.GetAsync($"{_URL}/renew");
            return await response.Content.ReadFromJsonAsync<LoginResponse>();
        }

        public async Task<User> isLogged() {
            string token = Preferences.Get("token", "");
            if(string.IsNullOrEmpty(token)) 
                return null;            

            var response = await renewToken(token);

            if (!response.ok)
                return null;

            Preferences.Clear();
            Preferences.Set("token", response.token);
            setToken(response.token);
            return response.user;
        }

        public void setUser(User _user) {
            user = _user;
        }

		public void setToken(string _token) {
            token = _token;
		}

		public string getToken() {
            return token;
		}
	}
}
