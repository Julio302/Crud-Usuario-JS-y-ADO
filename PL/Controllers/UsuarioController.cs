using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult GetAllUsuario()
        {
            ML.Result result = BL.Usuario.GetAllUsuario();
            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = result.Objects;
            return View(usuario);
        }

        [HttpGet]
        public ActionResult AddUsuario()
        {
            return View();
        }

        // Agregar
        [HttpPost]
        public ActionResult UsuarioAdd(ML.Usuario usuario)
        {
            if (usuario.Nombre == null || usuario.ApellidoPaterno == null || usuario.ApellidoMaterno == null || usuario.Telefono == null || usuario.Direccion == null)
            {
                return null;
            }
            else
            {
                ML.Result result = BL.Usuario.AddUsuario(usuario);
                return RedirectToAction("GetAllUsuario");
            }
        }

        // POST: Usuario/Create
        [HttpGet]
        public ActionResult DeleteUsuario(int? Id)
        {
            ML.Result result = new ML.Result();

            if (Id != null || Id > 0)
            {
                BL.Usuario.DeleteUsuario(Id.Value);
                return RedirectToAction("GetAllUsuario");
            }

            return RedirectToAction("GetAllUsuario");

        }

        [HttpGet]
        public ActionResult UpdateUsuario(int? Id)
        {
            ML.Result result = new ML.Result();
            if (Id > 0)
            {
                //si existe
                result = BL.Usuario.GetByIdUsuario(Id.Value);
                ML.Usuario usuario = new ML.Usuario();
                usuario.IDUsuario = ((ML.Usuario)result.Object).IDUsuario;
                usuario.Nombre = ((ML.Usuario)result.Object).Nombre;
                usuario.ApellidoPaterno = ((ML.Usuario)result.Object).ApellidoPaterno;
                usuario.ApellidoMaterno = ((ML.Usuario)result.Object).ApellidoMaterno;
                usuario.Telefono = ((ML.Usuario)result.Object).Telefono;
                usuario.Direccion = ((ML.Usuario)result.Object).Direccion;

                return View(usuario);
            }
            return RedirectToAction("GetAllUsuario");

        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult UsuarioUpdate(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            result = BL.Usuario.UpdateUsuario(usuario);
            return RedirectToAction("GetAllUsuario");
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
