using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;

using SmartGreenhouse4.Apis.Interfrface;

namespace SmartGreenhouse4.Apis
{
    static class Backend
    {
        public static string endpoint = "https://greenhouse.pythonanywhere.com/";
        private static HttpClient client = new HttpClient();
        public class Result
        {
            public bool success = true;
            public string content = "";
            public Result(string content, bool success = true)
            {
                this.content = content;
                this.success = success;
            }
        }
        public static async Task<Result> SendRequest(string path, Action<String> onSuccess = null, Action<String> onFailure = null)
        {
            Log.Write("http", "sending request to " + endpoint + path);
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri(endpoint + path);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            
            HttpResponseMessage response = await client.SendAsync(request);
            Log.Write("http", "response: " + response.StatusCode.ToString());
            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var result = await responseContent.ReadAsStringAsync();
                Log.Write("http", "response content: " + result);
                if (onSuccess != null) onSuccess(result);
                return new Result(result, true);
            } else
            {
                var error = response.StatusCode.ToString();
                if (onFailure != null) onFailure(error);
                return new Result(error, false);
            }
        }
        public static async Task<Result> Login(string login, string password, Action<String> onSuccess = null, Action<String> onFailure = null)
        {
            return await SendRequest("login?login=" + login + "&password=" + password, onSuccess, onFailure);
        }
        public static async Task<Result> GetUser(string session, Action<String> onSuccess = null, Action<String> onFailure = null)
        {
            return await SendRequest("user/" + session, onSuccess, onFailure);
        }
    }
}
