using Newtonsoft.Json;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database
{
    public class Database<T> : IDatabase<T> where T : Product
    {
        private List<T> _productList { get; set; }
        private string _urlPath = "https://interview-task-api.mca.dev/qr-scanner-codes/alpha-qr-gFpwhsQ8fkY1";

        public Database()
        {
            _productList = ConvertToObject(GetUrlString(_urlPath).Result);
        }

        public List<T> GetAllProducts()
        {
            return _productList;
        }

        public void UpdateProducts(List<T> updatedProducts)
        {
            _productList = updatedProducts;
        }

        public async Task<string> GetUrlString(string url)
        {
            string responseString = string.Empty;
            using (HttpClient httpClient = new HttpClient())
                try
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await httpClient.GetAsync(url);
                    responseString = await response.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            return responseString;
        }

        private List<T> ConvertToObject(string data)
        {
            return JsonConvert.DeserializeObject<List<T>>(data);
        }
    }
}
