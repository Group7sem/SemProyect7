using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentasOnline.Models;

namespace VentasOnline.Controllers
{
    public class SesionController : Controller
    {
        Ventas_ONLINEEntities db;
        // GET: Sesion
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autenticar(VT_Perfil perfi)
        {
            db = new Ventas_ONLINEEntities();

            VT_Perfil autenticacion = db.VT_Perfil.FirstOrDefault(b => b.usuario == perfi.usuario && b.contrasena == perfi.contrasena);

            if (autenticacion is null)
            {
                ViewBag.ErrorLogin = "Datos incorrectos / usuario no registrado";
                return View("Index");
            }
            else
            {
                VT_Usuario registroUsuario = db.VT_Usuario.FirstOrDefault(b => b.id == autenticacion.idUsuario);
                Session["usuarioLogueado"] = registroUsuario;
                Session["ErrorLogin"] = registroUsuario.nombre;
                return Redirect("../Home/Index");
            }
        }
        public ActionResult CerrarSesion()
        {
            Session["usuarioLogueado"] = null;
            Session["ErrorLogin"] = null;
            return Redirect("../Home/Index");

        }
    }
}