using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api_Consume.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api_Consume.Controllers
{
    public class AmigoController : Controller
    {
        // GET: AmigoController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Amigo> amigoList = new List<Amigo>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:49173/api/amigo"))
                {
                    string apiResponse = await
                   response.Content.ReadAsStringAsync();

                    // desserializa o JSON para um objeto do tipo Lista usando o pacote Newtonsoft.Json
                    amigoList = JsonConvert.DeserializeObject<List<Amigo>>(apiResponse);
                }
            }

            return View(amigoList);
        }

        // GET: AmigoController/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Amigo amigo = new Amigo();
            using (var httpClient = new HttpClient())
            {
                using (var response = await
                httpClient.GetAsync("http://localhost:49173/api/amigo/" + id))
                {
                    string apiResponse = await
                    response.Content.ReadAsStringAsync();
                    amigo = JsonConvert.DeserializeObject<Amigo>(apiResponse);
                }
            }
            return View(amigo);

            
        }

        // POST: AmigoController
        [HttpPost]
        public async Task<IActionResult> Create(Amigo amigo)
        {
            Amigo receivedAmigo = new Amigo();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(amigo),
                    Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:49173/api/amigo",
                    content))
                {
                    string apiResponse = await
                    response.Content.ReadAsStringAsync();
                    receivedAmigo = JsonConvert.DeserializeObject<Amigo>(apiResponse);
                }
            }

            return View(receivedAmigo);
        }

        // PUT: AmigoController/Create
        [HttpPost]
        public async Task<IActionResult> Update(int id)
        {
            Amigo amigo = new Amigo();
            using (var httpClient = new HttpClient())
            {
                using (var response = await
                httpClient.GetAsync("http://localhost:49173/api/amigo/" + id))
                {
                    string apiResponse = await
                    response.Content.ReadAsStringAsync();
                    amigo = JsonConvert.DeserializeObject<Amigo>(apiResponse);
                }
            }
            return View(amigo);
        }

        // GET: AmigoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AmigoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AmigoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AmigoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
