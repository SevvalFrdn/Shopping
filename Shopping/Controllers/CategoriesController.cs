using Microsoft.AspNetCore.Mvc;
using Shopping.Models;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace Shopping.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var responseMessage = client.GetAsync("http://localhost:65062/api/Categories").Result;
            List<Category> category = null;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                category = JsonConvert.DeserializeObject<List<Category>>(responseMessage.Content.ReadAsStringAsync().Result);
            }
            return View(category);
        }
        public IActionResult Add()
        {

            return View(new Category());
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(category), System.Text.Encoding.UTF8, "application/json");
            var responseMessage = httpClient.PostAsync("http://localhost:65062/api/Categories", content).Result;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return RedirectToAction("Index");
            }
            //ModelState.AddModelError("", "Ekleme İşlemi Başarısız");
            return View();
        }
        //public IActionResult Edit(string id)
        //{
        //    HttpClient httpClient = new HttpClient();
        //    var responseMessage = httpClient.GetAsync($"http://localhost:65062/api/Categories/{id}").Result;
        //    if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        var musteris = JsonConvert.DeserializeObject<musteri>(responseMessage.Content.ReadAsStringAsync().Result);
        //        return View(musteris);
        //    }
        //    return RedirectToAction("Index");

        //}
        //[HttpPost]
        //public IActionResult Edit(musteri musteris)
        //{
        //    HttpClient httpClient = new HttpClient();
        //    StringContent content = new StringContent(JsonConvert.SerializeObject(musteris), System.Text.Encoding.UTF8, "application/json");
        //    var responseMessage = httpClient.PutAsync($"http://localhost:65062/api/Categories/{musteris.Id}", content).Result;
        //    return RedirectToAction("Index");
        //}
        public IActionResult Delete(string id)
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = httpClient.DeleteAsync($"http://localhost:65062/api/Categories/{id}").Result;
            return RedirectToAction("Index");

        }
    }
}
