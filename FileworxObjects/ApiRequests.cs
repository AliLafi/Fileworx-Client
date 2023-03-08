using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FileworxObjects.Objects;

namespace Fileworx_Client
{
    public class ApiRequests
    {
        HttpClient _httpClient = new HttpClient();

        public ApiRequests()
        {

            _httpClient.BaseAddress = new Uri("https://localhost:7126/");
        }

        public async Task<T> GetByID<T>(string url , int id)
        {
            var response = await _httpClient.GetAsync(url+"/"+id);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            Console.Write(content);

            var res = JsonConvert.DeserializeObject<T>(content);
            return res;
        }

        public async Task<List<T>> GetAll<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            List<T> result = JsonConvert.DeserializeObject<List<T>>(content);
            return result;
        }

        public async Task<List<T>> GetSearch<T>(string url, SearchObject search)
        {
            StringBuilder cat = new StringBuilder();
            foreach (string s in search.Categories)
            {
                cat.Append(s);
                cat.Append(" ");
            }

            string u = url + "\\search?" + $"start={search.Start}&" + $"end={search.End}&" + $"cat={cat}&" + $"query={search.Query}";

            var response = await _httpClient.GetAsync(u);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            List<T> result = JsonConvert.DeserializeObject<List<T>>(content);
            return result;
        }

        public async Task<string> Create<T>(string url, T item)
        {
            var itemJson = new StringContent(
                    JsonConvert.SerializeObject(item),
                    Encoding.UTF8,
                    "application/json");

            var response = await _httpClient.PostAsync(
                url,
                itemJson);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var resMessage = content.ToString();
            return resMessage;
        }

        public async Task<string> Update<T>(string url, T item)
        {
            var itemJson = new StringContent(
                   JsonConvert.SerializeObject(item),
                   System.Text.Encoding.UTF8,
                   "application/json");

            var response = await _httpClient.PutAsync(
               url,
              itemJson);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return content.ToString(); ;
        }

        public async Task<string> Delete(string url, int id)
        {
            var response = await _httpClient.DeleteAsync(url + "/" + id);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();            
            return content.ToString();
        }

        public async Task<int> GetLoginInfo(string user, string pass)
        {
            LoginCredentials credentials = new LoginCredentials(user, pass);

            var itemJson = new StringContent(
                    JsonConvert.SerializeObject(credentials),
                    Encoding.UTF8,
                    "application/json");

            var response = await _httpClient.PostAsync(
                "login",
                itemJson);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var res = content.ToString();
            return int.Parse(res);
        }
    }
}
