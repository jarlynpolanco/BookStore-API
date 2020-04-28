﻿using BookStore_UI.Contracts;
using BookStore_UI.Models;
using BookStore_UI.Static;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_UI.Services
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IHttpClientFactory _client;

        public AuthenticationRepository(IHttpClientFactory client) 
        {
            _client = client;
        }

        public async Task<bool> Register(RegistrationModel user)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Endpoints.RegisterEndpoint)
            {
                Content = new StringContent(JsonConvert.SerializeObject(user),
                Encoding.UTF8, "application/json")
            };

            var client = _client.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            return response.IsSuccessStatusCode;
        }
    }
}
