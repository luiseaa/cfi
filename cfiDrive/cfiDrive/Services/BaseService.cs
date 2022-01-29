using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using cfiDrive.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace cfiDrive.Services
{
    public class BaseService
    {
        private HttpClient _client;
        private string _endpointUrl;

        /// <summary>
        /// Base Service
        /// </summary>
        public BaseService()
        {
            _client = new HttpClient();
             _endpointUrl = "https://jsonplaceholder.typicode.com/";
        }

        /// <summary>
        /// Get Async method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        protected async Task<ObservableCollection<TodoItems>> GetAsync<T>(string endpoint)
        {
            var responseResult = new ObservableCollection<TodoItems>();
            var url = new Uri(_endpointUrl + endpoint);
            string resString = string.Empty;
            try
            {
                HttpResponseMessage result = await InvokeGetAsync(url);
                resString = await HandleServerResponse(result, url, "GetAsync", string.Empty);
                responseResult = JsonConvert.DeserializeObject<ObservableCollection<TodoItems>>(resString);
            }
            catch (WebException requestException)
            {
                Debug.Write(requestException.Message);
            }
            return responseResult;
        }

        /// <summary>
        /// Invoke Get async
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> InvokeGetAsync(Uri url)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            responseMessage = await _client.GetAsync(url);
            return responseMessage;
        }

        
        /// <summary>
        /// Handle Server Response
        /// </summary>
        /// <param name="response"></param>
        /// <param name="url"></param>
        /// <param name="methodType"></param>
        /// <param name="requestPayload"></param>
        /// <returns></returns>
        private async Task<string> HandleServerResponse(HttpResponseMessage response, Uri url, string methodType, string requestPayload)
        {
            string resString = string.Empty;
            using (Stream stream = await response.Content?.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            {
                resString = reader.ReadToEnd();
            }
            return resString;
        }

    }
}