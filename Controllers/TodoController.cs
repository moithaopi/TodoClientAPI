using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public async Task<IActionResult> IndexAsync()
        {
            _todo=await getTodos();
            return View(_todo);
        }

        public async Task<Todo> getTodos()
        {
            _HttpClient = new HttpClient();
            //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            _todo = new Todo();
            var response = await _HttpClient.GetAsync("http://localhost:5001/api/todo");
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                _todo = JsonConvert.DeserializeObject<Todo>(content);
            }
            return _todo;
        }
    }
}
