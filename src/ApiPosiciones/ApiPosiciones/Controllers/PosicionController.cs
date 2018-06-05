using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlPosiciones;
using ApiPosiciones.Handler;
using AccesoDatos;

namespace ApiPosiciones.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PosicionController : Controller
    {
        public PosicionController()
        {

        }
        // GET api/values
        [HttpGet]
        [TypeFilter(typeof(ActionLogFilter))]
        public int[,] Get()
        {
            BlPosiciones.BlPosiciones posicion = new BlPosiciones.BlPosiciones() ;
            return posicion.GetPosiciones("JAVA");
        }

        // GET api/values/5
        [HttpGet("{palabra}")]
        [TypeFilter(typeof(ActionLogFilter))]
        public int[,] Get(string palabra)
        {
            BlPosiciones.BlPosiciones posicion = new BlPosiciones.BlPosiciones();
            return posicion.GetPosiciones(palabra);
        }

    }
}
