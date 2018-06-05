using AccesoDatos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Newtonsoft.Json;

namespace ApiPosiciones.Handler
{
    public class ActionLogFilter : ResultFilterAttribute
    {
        public LogContext Context { get; set; }

        public ActionLogFilter(LogContext context)
        {
            Context = context;
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {

            var log = new LogServicio();
            
            log.Request = context.HttpContext.Request.Path;
            var result = context.Result as ObjectResult;
            if (result != null)
            {
                log.Response = JsonConvert.SerializeObject(result.Value);
            }
            log.Fecha = DateTime.Now;
            log.StatusCode = context.HttpContext.Response.StatusCode.ToString();
            Context.Logs.Add(log);
            Context.SaveChanges();
        }

    }
}
