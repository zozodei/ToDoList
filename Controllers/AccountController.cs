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
     public IActionResult RegistroGuardarse(Usuario User)
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

