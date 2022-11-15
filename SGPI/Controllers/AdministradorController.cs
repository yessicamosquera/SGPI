using Microsoft.AspNetCore.Mvc;
using SGPI.Models;

namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {

        SGPI_BDContext context = new SGPI_BDContext();


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario user)
        {
            string numeroDoc = user.Documento;
            string pass = user.Password;

           var usuarioLogin = context.Usuarios.Where(consulta => consulta.Documento == numeroDoc && consulta.Password == pass).FirstOrDefault();


             if (usuarioLogin != null)
            {
                //Administrador
                if (usuarioLogin.IdRol == 1)
                {
                    CrearUsuario();
                    return Redirect("/Administrador/CrearUsuario");
                }
                //Coordinador
                else if (usuarioLogin.IdRol == 2)
                {
                    CoordinadorController coordi=new CoordinadorController();
                    coordi.BuscarCoordinador();
                    return Redirect("/Coordinador/BuscarCoordinador");
                }
                //Estudiante
                else if (usuarioLogin.IdRol == 3)
                {
                    EstudianteController estudi=new EstudianteController();
                  
                    return Redirect("/Estudiante/Actualizar/?IdUsuario="+usuarioLogin.IdUsuario);
                }
                
            } 
            else
            {
                ViewBag.mensaje = "Usuario no existe" +
                    "o usuario y/o contraseña invalida";
            }
            return View();
        }

        public IActionResult OlvidarContrasena()
        {
            return View();
        }
        public IActionResult CrearUsuario()
        {
            ViewBag.genero = context.Generos.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.Documento = context.Documentos.ToList();



            return View();
        }
        [HttpPost]
        public IActionResult CrearUsuario(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            context.SaveChanges();
            ViewBag.mensaje = "usuario creado exitosamente";

            ViewBag.genero = context.Generos.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.Documento = context.Documentos.ToList();
            return View();
        }
        public IActionResult EditarUsuario(int? IdUsuario)
        {
            Usuario usuario = context.Usuarios.Find(IdUsuario);
            if (usuario != null)
            {
                ViewBag.rol = context.Rols.ToList();
                ViewBag.programa = context.Programas.ToList();
                ViewBag.genero = context.Generos.ToList();
                ViewBag.Documento = context.Documentos.ToList();
                return View(usuario);
            }
            else
            {
                return Redirect("/Administrador/BuscarUsuario");
            }

        }
        [HttpPost]
        public IActionResult EditarUsuario(Usuario usuario)
        {
            context.Update(usuario);
            context.SaveChanges();
            ViewBag.mensaje = "Usuario modificado exitosamente";

            ViewBag.rol = context.Rols.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.genero = context.Generos.ToList();
            ViewBag.Documento = context.Documentos.ToList();
            return View(usuario);
        }
        [HttpPost]
        public IActionResult EliminarUsuario(Usuario usuario)
        {
            context.Remove(usuario);
            context.SaveChanges();
            return Redirect("/Administrador/BuscarUsuario");
        }

        
        public IActionResult BuscarUsuario()

        {
            Usuario us = new Usuario();
            return View(us);
        }
        [HttpPost]
        public IActionResult BuscarUsuario(Usuario usuario)
        {
            string Doc = usuario.Documento;
            var user = context.Usuarios.Where(consulta => consulta.Documento == Doc).FirstOrDefault();
            if (user != null)
            {
                return View(user);
            }
            else
                return View();
        }
        public IActionResult EliminarUsuario()
        {

            return View();
        }
        
        
        public IActionResult Reportes()
        {
            ViewBag.Documento = context.Documentos.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Reportes(Usuario usuario)
        {
            string Doc = usuario.Documento;
            var user = context.Usuarios.Where(consulta => consulta.Documento == Doc).FirstOrDefault();
            if (user != null)
            {
                return View(user);
            }
            else
                return View();
        }

    }
}
