using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BlazorApp1.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient("BlazorApp1.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorApp1.ServerAPI"));

            //builder.Services.AddApiAuthorization();
            //builder.Services.AddOidcAuthentication(options =>
            //{
            //    options.ProviderOptions.Authority = "https://localhost:5001";
            //    options.ProviderOptions.ClientId = "BlazorApp1.Client";
            //    options.ProviderOptions.DefaultScopes.Add("BlazorApp1.ServerAPI");
            //    options.ProviderOptions.RedirectUri = "https://localhost:44367/authentication/login-callback";
            //    options.ProviderOptions.PostLogoutRedirectUri = "https://localhost:44367/authentication/logout-callback";
            //    options.ProviderOptions.ResponseType = "code";

            //    options.AuthenticationPaths.RemoteRegisterPath = "https://localhost:5001/Account/Register";
            //    options.AuthenticationPaths.RemoteProfilePath = "https://localhost:5001/Account/Manage";
            //});

            builder.Services.AddOidcAuthentication(options =>
            {
                options.ProviderOptions.Authority = "https://localhost:44387";
                options.ProviderOptions.ClientId = "AbpBlazorApp.Client";
                options.ProviderOptions.DefaultScopes.Add("AbpBlazorApp.ServerAPI");
                options.ProviderOptions.RedirectUri = "https://localhost:44367/authentication/login-callback";
                options.ProviderOptions.PostLogoutRedirectUri = "https://localhost:44367/authentication/logout-callback";
                options.ProviderOptions.ResponseType = "id_token token";

                options.AuthenticationPaths.RemoteRegisterPath = "https://localhost:44387/Account/Register";
                options.AuthenticationPaths.RemoteProfilePath = "https://localhost:44387/Account/Manage";
            });


            //https://localhost:44367/_configuration/BlazorApp1.Client

            await builder.Build().RunAsync();
        }
    }
}
