using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentasOnline.Models;

namespace VentasOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            VT_Usuario usuarioLoguead = new VT_Usuario(); 
            if (Session["usuarioLogueado"] != null){
                usuarioLoguead = (VT_Usuario)Session["usuarioLogueado"];
                ViewBag.UsuarioNombre = usuarioLoguead.nombre;
            } else
            {
                Session["usuarioLogueado"] = new VT_Usuario();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult EliminarArticulo(int idArticulo)
        {
            List<VT_Orden> carrito = new List<VT_Orden>();
            if (Session["carrito"] != null)
            {
                carrito = (List<VT_Orden>)Session["carrito"];
                carrito.RemoveAt(carrito.FindIndex(m => m.idArticulo == idArticulo));

                Session["carrito"] = carrito;
                
            }

            return RedirectToAction("Contact");
        }

        public ActionResult Contact()
        {
            //ViewBag.display = "none";
            List<VT_Orden> carrito = new List<VT_Orden>();

            ViewBag.displayDetalle = "";
            if (Session["carrito"] != null)
            {
                ViewBag.display = "none";
                ViewBag.displayDetalle = "";
                carrito = (List<VT_Orden>)Session["carrito"];
            }

            return View(carrito);
        }
    }
}