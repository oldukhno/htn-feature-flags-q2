﻿using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Web;

namespace QClient
{
    internal static class AzUtils
    {
        private static AccessSettings Settings;

        static AzUtils()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: true);

            IConfiguration config = builder.Build();

            Settings = config.GetSection(nameof(AccessSettings)).Get<AccessSettings>();
        }

        public static Stream DownloadResources()
        {
            Console.WriteLine("Authenticating and downloading the resources");

            using var httpClient = CreateHttpClient();
            var httpResult = httpClient.GetAsync(Settings.ResourceUri).GetAwaiter().GetResult();

            if (!httpResult.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Not authenticated. {httpResult.ReasonPhrase}");
            }

            Console.WriteLine("Resources downloaded");

            return httpResult.Content.ReadAsStream();
        }

        public static string DownloadEntities(string mapName)
        {
            Console.WriteLine("Authenticating and downloading the entities");

            var builder = new UriBuilder(Settings.EntitiesUri);
            var query = HttpUtility.ParseQueryString(builder.Query);

            // for demo purposes, we are using the map name as the current client user id
            mapName = Environment.UserName;
            Console.WriteLine($"Current user: {mapName}");

            query["mapName"] = mapName.Substring(mapName.IndexOf("/") + 1);
            builder.Query = query.ToString();
            string url = builder.ToString();

            using var httpClient = CreateHttpClient();
            var httpResult = httpClient.GetAsync(url).GetAwaiter().GetResult();

            if (!httpResult.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Not authenticated. {httpResult.ReasonPhrase}");
            }

            Console.WriteLine("Entities downloaded");

            return httpResult.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        private static HttpClient CreateHttpClient()
        {
            ClientSecretCredential clientSecretCredential = new ClientSecretCredential(
                Settings.TenantId,
                Settings.ClientId,
                Settings.ClientSecret);

            TokenRequestContext tokenRequestContext =
                new TokenRequestContext(
                    new string[] {
                        $"api://{Settings.ClientId}/.default", });

            string token = clientSecretCredential.GetToken(tokenRequestContext).Token;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            return httpClient;
        }

    }
}
