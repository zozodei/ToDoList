using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers;

public class AccountController : Controller
{
    private readonly IWebHostEnvironment _env;

    public AccountController(IWebHostEnvironment env) 
    {
        _env = env;
    }

    
    public IActionResult Login () 
    {
        return View ("Login"); //no va asi pero lo pongo para que no tire error
    }

    public IActionResult LoginGuardar(string Username, string Contraseña)
    {
        if (!BD.existeUsuario(Username))
        {
            return View("Login");
        }
        else
        {
            int id = BD.Login(Username, Contraseña);
            if (id > -1)
            {
                HttpContext.Session.SetString("IdUsuario", id.ToString());
                return RedirectToAction("VerTareas", "Home");
                //en este caso tendria que ir a ver las tareas
                //ademas se tiene que guardar la ultima fecha de logiado (Actualizar)
            }
            else
            {
                return View("Login");
            }
        }
    }
    
    public IActionResult Registro () 
    {
         return View ("Registro"); //no va asi pero lo pongo para que no tire error
        //todo la ultima fecha de login (xq la ultima fecha no existe en este caso, si recien entro xd)
    }
    public IActionResult RegistroGuardarse(IFormFile Foto, string Nombre, string Apellido, string Username, string Contraseña)
    {
        string NombreArchivo ="";
        if (Foto != null && Foto.Length > 0) 
        {
            NombreArchivo = Foto.FileName;
            string RutaCarpeta = Path.Combine(_env.WebRootPath, "imagenes");

            if (!Directory.Exists(RutaCarpeta)) 
            {
                Directory.CreateDirectory(RutaCarpeta);
            }

            string rutaCompleta = Path.Combine(RutaCarpeta, NombreArchivo);

            using (var stream = new FileStream(rutaCompleta, FileMode.Create))
            {
            Foto.CopyTo(stream);
            }
        }
        BD.Registro(Nombre, Apellido, Username, Contraseña, NombreArchivo);
        return RedirectToAction ("Login", "Account");
    }

    public IActionResult cerrarSesion()
    {
        HttpContext.Session.Remove("IdUsuario");
        return RedirectToAction("Index", "Home");
        //return View ("Index");
    }

}

