using Blazored.LocalStorage;
using BlazorSozluk.Common.Infrastructure.Exceptions;
using BlazorSozluk.Common.Infrastructure.Results;
using BlazorSozluk.Common.Models.Queries;
using BlazorSozluk.Common.Models.RequestModels;
using BlazorSozluk.WebApp.Infrastructure.Extensions;
using BlazorSozluk.WebApp.Infrastructure.Services.Interfaces;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorSozluk.WebApp.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient client;
        private readonly ISyncLocalStorageService syncLocalStorageService;

        public IdentityService(HttpClient client, ISyncLocalStorageService syncLocalStorageService)
        {
            this.client = client;
            this.syncLocalStorageService = syncLocalStorageService;
        }
        public bool IsLoggedIn => !string.IsNullOrEmpty(GetUserToken());

        public string GetUserToken()
        {
            return syncLocalStorageService.GetToken();
        }

        public string GetUserName()
        {
            return syncLocalStorageService.GetUserName();
        }

        public Guid GetUserId()
        {
            return syncLocalStorageService.GetUserId();
        }
        public async Task<bool> Login(LoginUserCommand command)
        {
            string responseStr;
            var httpResponse = await client.PostAsJsonAsync("/api/user/login", command);
            if (httpResponse != null && !httpResponse.IsSuccessStatusCode)
            {
                if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                {

                    responseStr = await httpResponse.Content.ReadAsStringAsync();
                    var validation = JsonSerializer.Deserialize<ValidationResponseModel>(responseStr);
                    responseStr = validation.FlattenErros;
                    throw new DatabaseValidationException(responseStr);
                }
                return false;
            }

            responseStr = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<LoginUserViewModel>(responseStr);
            if (!string.IsNullOrEmpty(response.Token))// login success
            {
                syncLocalStorageService.SetToken(response.Token);
                syncLocalStorageService.SetUsername(response.UserName);
                syncLocalStorageService.SetUserId(response.Id);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer ");
                return true;
            }
            return false;
        }

        public void Logout()
        {
            syncLocalStorageService.RemoveItem(LocalStorageExtension.TokenName);
            syncLocalStorageService.RemoveItem(LocalStorageExtension.UserName);
            syncLocalStorageService.RemoveItem(LocalStorageExtension.UserId);
            client.DefaultRequestHeaders.Authorization = null;
        }
    }
}