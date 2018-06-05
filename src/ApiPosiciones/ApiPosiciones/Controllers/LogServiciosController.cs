using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AccesoDatos;

namespace ApiPosiciones.Controllers
{
    [Produces("application/json")]
    [Route("api/LogServicios")]
    public class LogServiciosController : Controller
    {
        private readonly LogContext _context;

        public LogServiciosController(LogContext context)
        {
            _context = context;
        }

        // GET: api/LogServicios
        [HttpGet]
        public IEnumerable<LogServicio> GetLogs()
        {
            return _context.Logs;
        }
    }
}