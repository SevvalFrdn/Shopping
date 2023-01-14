using Microsoft.AspNetCore.Mvc;
using Shopping.Models;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace Shopping.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var responseMessage = client.GetAsync("http://localhost:65062/api/Products").Result;
            List<Product> product = null;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                product = JsonConvert.DeserializeObject<List<Product>>(responseMessage.Content.ReadAsStringAsync().Result);
            }
            return View(product);
        }
    }
}
