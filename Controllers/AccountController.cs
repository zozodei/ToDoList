using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public AccountController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    private readonly IWebHostEnvironment _env;

    public AccountController(IWebHostEnvironment env) 
    {
        _env = env;
    }

    public IActionResult SubirArchivo (IFormFile archivo) 
    {
        if (archivo != null && archivo.Length > 0) 
        {
            string NombreArchivo = archivo.FileName;
            
            string RutaCarpeta = Path.Combine(_env.WebRootPath, "imagenes");

            if (!Directory.Exists(RutaCarpeta)) 
            {
                Directory.CreateDirectory(RutaCarpeta);
            }

            string rutaCompleta = Path.Combine(RutaCarpeta, NombreArchivo);

            using (var stream = new FileStream(rutaCompleta, FileMode.Create))
            {
                archivo.CopyTo(stream);
            }

            return View ("VerTareas");
        }

        ViewBag.Mensaje = "No se selecciono ningun archivo";
        return View ("VerTareas");
    }

    public IActionResult Login () 
    {
        return View ("Login"); //no va asi pero lo pongo para que no tire error
    }

    public IActionResult LoginGuardar(string Username, string Contraseña) 
    {
        int id = BD.Login (Username, Contraseña);
        if (id >-1)
        {
            HttpContext.Session.SetString ("IdUsario", id.ToString());
            return View ("VerTareas"); //en este caso tendria que ir a ver las tareas
            //ademas se tiene que guardar la ultima fecha de logiado (Actualizar)
        }
        else
        {
            return View("Login");
        } 
    }
    
    public IActionResult Registro () 
    {
         return View ("Registro"); //no va asi pero lo pongo para que no tire error
        //todo la ultima fecha de login (xq la ultima fecha no existe en este caso, si recien entro xd)
    }
     public IActionResult RegistroGuardarse(Usuario User, IFormFile Foto)
    {
        BD.Registro(User);
        HttpContext.Session.SetString("IdUsuario", User.IdUsuario.ToString());
        return View ("VerTareas"); 
    }

    public IActionResult cerrarSesion () 
    {
        HttpContext.Session.Remove("IdUsuario");
        return View ("Index"); 
    }

}

