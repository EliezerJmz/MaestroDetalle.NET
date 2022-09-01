using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//usamos nuestro modelos
using MaestroDetalle.Models;
using MaestroDetalle.Models.ViewModels;

namespace MaestroDetalle.Controllers
{
    public class MaestroDetalleController : Controller
    {
        // GET: MaestroDetalle
        [HttpGet]
        public ActionResult Add()
        {          
                return View();
        }

        //Agrgar registro
        [HttpPost]
        public ActionResult Add(VentaViewModel model)
        {
            try
            {
                //conectar a la base de datos usando entity
                using (MaestroDetalleEntities db = new MaestroDetalleEntities())
                {
                    //creamos un objeto tipo Ventas para cargar los datos del modelo
                    Venta venta = new Venta();

                    venta.Fecha = DateTime.Now;
                    venta.Cliente = model.Cliente;

                    //agregamos el objeto ventas a la base de datos y guardamos
                    db.Venta.Add(venta);
                    //al momento de guardar se le genera a ventas un id
                    db.SaveChanges();


                    //VentaViewModel posee un campo tipo lista de Conceptos
                    //Agregar la lista de Conceptos a la tabla concepto de la base de datos
                    //debemos reccorrer model.Conceptos que es de tipo VentaViewModel 
                    foreach (var ConceptoModel in model.Conceptos)
                    {
                        //creamos un objeto para llenar los campos que vienen en el model.Conceptos y los campos que se calcular automaticamente
                        Concepto concepto = new Concepto();
                        concepto.Cantidad = ConceptoModel.Cantidad;
                        concepto.Nombre = ConceptoModel.Nombre;
                        concepto.PrecioUnitario = ConceptoModel.PrecioUnitario;
                        concepto.Total = ConceptoModel.Cantidad * ConceptoModel.PrecioUnitario;
                        //son los id que estan relacionados
                        //se le asigna el mismo venta.Id al listado de conceptos
                        concepto.IdVenta = venta.Id;

                        //agregamos el prinmer objeto a la tabla Concepto de la db
                        db.Concepto.Add(concepto);
                    }
                    //gurdamos los cambios en la db
                    db.SaveChanges();

                }
                ViewBag.Mensaje = "Registro Insertado en la DB";
                //como tenemos otra vista que se llama Add nos retorna a ella misma sin necesidad de indicar su nombre
                return View();
            }
            catch(Exception ex)
            {
                return View(model);
            }
        }





        [HttpGet]
        public ActionResult DataTable()
        {
            return View();
        }

        //Agrgar registro
        [HttpPost]
        public ActionResult DataTable(VentaViewModel model)
        {
            try
            {
                //conectar a la base de datos usando entity
                using (MaestroDetalleEntities db = new MaestroDetalleEntities())
                {
                   
                    //creamos un objeto tipo Ventas para cargar los datos del modelo
                    Venta venta = new Venta();

                    venta.Fecha = DateTime.Now;
                    venta.Cliente = model.Cliente;

                    //agregamos el objeto ventas a la base de datos y guardamos
                    db.Venta.Add(venta);
                    db.SaveChanges();
                }
                //como tenemos otra vista que se llama Add nos retorna a ella misma sin necesidad de indicar su nombre
                return View();
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }






    }
}