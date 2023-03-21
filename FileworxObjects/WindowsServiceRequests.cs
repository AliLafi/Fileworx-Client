using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FileworxObjects
{
    public class WindowsServiceRequests
    {
        HttpClient _httpClient = new HttpClient();

        public WindowsServiceRequests()
        {
            _httpClient.BaseAddress = new Uri("http://localhost:5000/");
        }

        public async Task<string> TransmitFile(string type, int id, int contactId)
        {
            string url = type + "/" + id + "/" + contactId;
            var response = await _httpClient.GetAsync(url);
            return response.ToString();
        }
    }
}
