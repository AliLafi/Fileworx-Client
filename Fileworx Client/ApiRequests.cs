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

namespace Fileworx_Client
{
    internal class ApiRequests
    {
          HttpClient _httpClient = new HttpClient();
        public ApiRequests() {
               
        _httpClient.BaseAddress=new Uri("https://localhost:7126/");
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

 


        public async Task<HttpResponseMessage> Delete<T>(string url, T item)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress + url)
            };
            return await _httpClient.SendAsync(request);
        }



        public async Task<Hashtable> getLoginInfo()
        {

            var response = await _httpClient.GetAsync("users").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<Hashtable>(content);
            return res;


        }



    }
}
