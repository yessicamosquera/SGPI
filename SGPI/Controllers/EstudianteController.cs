using Microsoft.AspNetCore.Mvc;
using SGPI.Models;

namespace SGPI.Controllers
{
    public class EstudianteController : Controller

    {
        SGPI_BDContext context = new SGPI_BDContext();

        public List<Pago> ListPago { get; private set; }

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
                return Redirect("/Estudiante/Actualizar");
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

        public IActionResult Pagos(int? IdUsuario)
        {
            Usuario usuario = new Usuario();
            var usr = context.Usuarios.Where(consulta => consulta.IdUsuario == IdUsuario).FirstOrDefault();


            return View();
        }

        [HttpPost]
        public IActionResult Pagos(Pago pago)
        {
            pago.Estado = true;
            ViewBag.mensaje = "Pago enviado";
            context.Pagos.Add(pago);
            context.SaveChanges();
            return View();

        }
    }
}




