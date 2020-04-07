using System;

namespace Entity
{
    public class DatosCopago
    {
        public string IdPaciente {get;set;}
        public double ValorServicio {get;set;}
        public decimal SalarioTrabajador {get;set;}
        public double Copago {get;set;}
        public void CalcularCopago()
        {

            if (SalarioTrabajador > 250000)
            {
                Copago = 0.2 * ValorServicio;

            }else
            {
                Copago = 0.1 * ValorServicio;
            }
        }

    }

}
