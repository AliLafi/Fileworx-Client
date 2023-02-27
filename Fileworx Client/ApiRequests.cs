using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileworxObjects;
using Newtonsoft.Json;
using FileworxObjects.DTOs;
using System.Net.Http.Headers;
using System.Xml.Serialization;
using FileworxObjects.Objects;
using System.Security.Policy;

namespace Fileworx_Client
{
    internal class ApiRequests
    {
        HttpClient _httpClient = new HttpClient();
        public ApiRequests()
        {

            _httpClient.BaseAddress = new Uri("https://localhost:7126/");
        }



        public async Task<List<T>> GetAll<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = new List<T>();

            result = JsonConvert.DeserializeObject<List<T>>(content);



            return result;
        }

        public async Task<List<T>> GetSearch<T>(string url, SearchObject search)
        {
            StringBuilder cat = new StringBuilder();
            foreach (string s in search.categories)
            {
                cat.Append(s);
                cat.Append(" ");
            }
            string u = url + "\\search?" + $"start={search.Start}&" + $"end={search.End}&" + $"cat={cat}&" + $"query={search.query}";
            var response = await _httpClient.GetAsync(u);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = new List<T>();

            result = JsonConvert.DeserializeObject<List<T>>(content);



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
            var resMessage = content.ToString();

            return resMessage;
        }




        public async Task<string> Delete<T>(string url, int id)
        {
            var response = await _httpClient.DeleteAsync(url + "/" + id);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var resMessage = content.ToString();
            return resMessage;
        }



        public async Task<bool> getLoginInfo(string user, string pass)
        {
            LoginCredentials l = new LoginCredentials(user, pass);
            var itemJson = new StringContent(
                    JsonConvert.SerializeObject(l),
                    Encoding.UTF8,
                    "application/json");
            var response = await _httpClient.PostAsync(
                "login",
                itemJson);
            var content = await response.Content.ReadAsStringAsync();
            var res = content.ToString();
            return bool.Parse(res);

        }



    }
}
