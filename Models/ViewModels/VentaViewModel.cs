using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaestroDetalle.Models.ViewModels
{
    //Modelo de Ventas
    //indicamos los campos que usaremos
    public class VentaViewModel
    {
        public string Cliente { get; set; }
        public List<ConceptoViewModel> Conceptos { get; set; }
    }

    //Modelo de Concepto
    //indicamos los campos que usaremos
    //el resto de campos los calcularemos atomaticamente y estan en el modelo Concepto que crea entity de forma automatica
    public class ConceptoViewModel
    {
        public int Cantidad { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}