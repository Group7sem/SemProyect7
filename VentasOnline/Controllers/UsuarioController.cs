using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentasOnline.Models;

namespace VentasOnline.Controllers
{
    public class UsuarioController : Controller
    {
        Ventas_ONLINEEntities db;
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearCuenta(string nombre, string apellidos, string correo, VT_Perfil perfil)
        {
            db = new Ventas_ONLINEEntities();

            VT_Usuario usuarioNuevo = new VT_Usuario();
            usuarioNuevo.nombre = nombre;
            usuarioNuevo.apellidos = apellidos;
            usuarioNuevo.correo = correo;

            db.VT_Usuario.Add(usuarioNuevo);
            db.SaveChanges();

            VT_Usuario registroUsuario = db.VT_Usuario.FirstOrDefault(b => b.correo == correo);

            VT_Perfil perfilNuevo = new VT_Perfil();
            perfilNuevo.idTipoPerfil = 1;
            perfilNuevo.idUsuario = registroUsuario.id;
            perfilNuevo.usuario = perfil.usuario;
            perfilNuevo.contrasena = perfil.contrasena;

            db.VT_Perfil.Add(perfilNuevo);
            db.SaveChanges();

            Session["usuarioLogueado"] = registroUsuario;

            return View("../Home/Index");
        }
    }
}