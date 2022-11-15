using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGPI.Models;

namespace SGPI.Controllers
{
    public class EstudianteController : Controller

    {
        SGPI_BDContext context = new SGPI_BDContext();
       

        public IActionResult Actualizar(int? IdUsuario)
        {
            Usuario usuario = context.Usuarios.Find(IdUsuario);
            if (usuario != null)
            {
                ViewBag.genero = context.Generos.ToList();
                ViewBag.programa = context.Programas.ToList();
                ViewBag.rol = context.Rols.ToList();
                ViewBag.Documento = context.Documentos.ToList();

                return View(usuario);
            }
            else
            {
                return Redirect("/Estudiante/Actualizar?IdUsuario");
            }

        }
        [HttpPost]
        public IActionResult Actualizar(Usuario usuario)
        {
            
            context.Update(usuario);
            context.SaveChanges();
            ViewBag.mensaje = "Estudiante modificado exitosamente";

            ViewBag.genero = context.Generos.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.Documento = context.Documentos.ToList();

            return View(usuario);
        }

        public IActionResult Pagos(int?IdUsuario)
        {
            Usuario usuario = new Usuario();
            var usr = context.Usuarios.Where(consulta => consulta.IdUsuario == IdUsuario).FirstOrDefault();
            ViewBag.Idusuario = usr.IdUsuario;
            return View();
        }

        [HttpPost]
        public IActionResult Pagos(int? IdUsuario, Pago usuario)
        {
            Usuario usr = context.Usuarios.Find(IdUsuario);

            usuario.Estado = true;
            context.Pagos.Add(usuario);
            context.SaveChanges();
            ViewBag.mensaje = "Pago Ingresado";

            Estudiante est = new Estudiante();
            est.Archivo = "";
            est.IdUsuario = usr.IdUsuario;
            est.IdPago = usuario.IdPago;
            est.Egresado = true;
            context.Estudiantes.Add(est);
            context.SaveChanges();
            return View();

        }
    }
}




