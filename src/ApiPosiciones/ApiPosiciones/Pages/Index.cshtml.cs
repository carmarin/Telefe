using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AccesoDatos;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace WebLog.Pages
{
    public class ListLogModel : PageModel
    {
        string apiUrl = "";

        public ListLogModel(IConfiguration config)
        {
            apiUrl = config["UrlApi"];
        }

        public IList<LogServicio> LogServicio { get;set; }

        public async Task OnGetAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    LogServicio = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<LogServicio>>(data);
                }
            }
        }
    }
}
