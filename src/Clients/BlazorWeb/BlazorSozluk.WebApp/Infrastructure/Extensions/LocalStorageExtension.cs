using Blazored.LocalStorage;

namespace BlazorSozluk.WebApp.Infrastructure.Extensions
{
    public static class LocalStorageExtension
    {
        public const string TokenName = "token";
        public const string UserName = "username";
        public const string UserId = "userid";

        public static bool IsUserLoggedIn(this ISyncLocalStorageService localStorageService)
        {
            return !string.IsNullOrEmpty(GetToken(localStorageService));
        }

        public static string GetUserName(this ISyncLocalStorageService localStorageService)
        {
            return localStorageService.GetItem<string>(UserName);
        }
        public static async Task<string> GetUserName(this ILocalStorageService localStorageService)
        {
            return await localStorageService.GetItemAsync<string>(UserName);
        }

        public static void SetUsername(this ISyncLocalStorageService localStorageService, string value)
        {
            localStorageService.SetItem(UserName, value);
        }

        public static async Task SetUsername(this ILocalStorageService localStorageService, string value)
        {
            await localStorageService.SetItemAsync(UserName, value);
        }

        public static void SetUserId(this ISyncLocalStorageService localStorageService, Guid value)
        {
            localStorageService.SetItem(UserId, value);
        }

        public static async Task SetUserId(this ILocalStorageService localStorageService, Guid value)
        {
            await localStorageService.SetItemAsync(UserId, value);
        }

        public static Guid GetUserId(this ISyncLocalStorageService localStorageService)
        {
            return localStorageService.GetItem<Guid>(UserId);
        }

        public static async Task<Guid> GetUserId(this ILocalStorageService localStorageService)
        {
            return await localStorageService.GetItemAsync<Guid>(UserId);
        }

        public static async Task<string> GetToken(this ILocalStorageService localStorageService)
        {
            var token = await localStorageService.GetItemAsync<string>(TokenName);
            return token;
        }
        public static string GetToken(this ISyncLocalStorageService localStorageService)
        {
            var token = localStorageService.GetItem<string>(TokenName);
            return token;
        }

        public static void SetToken(this ISyncLocalStorageService localStorageService, string value)
        {
            localStorageService.SetItem(TokenName, value);
        }

        public static async Task SetToken(this ILocalStorageService localStorageService, string value)
        {
            await localStorageService.SetItemAsync(TokenName, value);
        }
    }
}
