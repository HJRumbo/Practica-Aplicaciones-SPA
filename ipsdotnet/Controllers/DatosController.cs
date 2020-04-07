using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ipsdotnet.Models;

namespace ipsdotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DatosController: Controller
    {
        private readonly DatosService _datosService;
        public IConfiguration Configuration { get; }
        public DatosController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _datosService = new DatosService(connectionString);
        }
        // GET: api/Persona
        [HttpGet]
        public IEnumerable<DatosViewModel> Gets()
        {
            var listadatos = _datosService.ConsultarTodos().Select(d=> new DatosViewModel(d));
            return listadatos;
        }

        // POST: api/Persona
        [HttpPost]
        public ActionResult<DatosViewModel> Post(DatosInputModel datosInput)
        {
            DatosCopago datos = MapearDatos(datosInput);
            var response = _datosService.Guardar(datos);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.DatosCopago);
        }

        private DatosCopago MapearDatos(DatosInputModel datosInput)
        {
            var datos = new DatosCopago
            {
                IdPaciente = datosInput.IdPaciente,
                ValorServicio = datosInput.ValorServicio,
                SalarioTrabajador = datosInput.SalarioTrabajador,
            };
            return datos;
        }
    }
}