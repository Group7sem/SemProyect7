using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentasOnline.Models;

namespace VentasOnline.Controllers
{
    public class ArticulosController : Controller
    {
        Ventas_ONLINEEntities db;
        // GET: Articulos
        public ActionResult Accesorios_Index()
        {
            db = new Ventas_ONLINEEntities();

            return View();
        }

        public ActionResult Playeras_Index()
        {
            db = new Ventas_ONLINEEntities();
            List<VT_Articulo> playeras = db.VT_Articulo.Where(n => n.idTipoArticulo == 1).ToList();
            return View(playeras);
        }

        [HttpPost]
        public ActionResult AgregarCarrito(int idArticulo, int cantidad, string direccion)
        {
            List<VT_Orden> carrito = new List<VT_Orden>();
            VT_Orden articulo = new VT_Orden();

            articulo.idArticulo = idArticulo;
            articulo.cantidad = cantidad;
            articulo.direccion = direccion;
            if (Session["carrito"] is null)
            {
                carrito.Add(articulo);
                Session["carrito"] = carrito;
            } else
            {
                carrito = (List<VT_Orden>)Session["carrito"];
                carrito.Add(articulo);
                Session["carrito"] = carrito;
            }

            db = new Ventas_ONLINEEntities();
            List<VT_Articulo> playeras = db.VT_Articulo.Where(n => n.idTipoArticulo == 1).ToList();

            return View("Playeras_Index", playeras);
        }
    }
}