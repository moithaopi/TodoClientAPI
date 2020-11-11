using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TodoClientApi.Models;

namespace TodoClientApi.Controllers
{
    public class TodoController : Controller
    {
        private HttpClient _HttpClient;
        private Todo _todo;
        public TodoController(HttpClient httpClient,Todo todo)
        {
            _todo = todo;
            _HttpClient = httpClient;
        }
        public IActionResult Index()
        {

            return View();
        }

        public async Task<Todo> getTodos()
        {
            var response = await _HttpClient.GetAsync("https://localhost:5001/api/todo");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                _todo = JsonConvert.DeserializeObject<Todo>(content);
            }
            return _todo;
        }
    }
}
