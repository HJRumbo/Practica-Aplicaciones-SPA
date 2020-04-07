using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Entity;

namespace ipsdotnet.Models
{
        public class DatosInputModel
        
        {
        public string IdPaciente {get;set;}
        public double ValorServicio {get;set;}
        public decimal SalarioTrabajador {get;set;}

        }

        public class DatosViewModel : DatosInputModel
        {

        public DatosViewModel()
        {

        }

        public DatosViewModel(DatosCopago datos)
        {
            IdPaciente = datos.IdPaciente;
            ValorServicio = datos.ValorServicio;
            SalarioTrabajador = datos.SalarioTrabajador;
            Copago = datos.Copago;
        }

        public double Copago {get;set;}
        
        }

    
}