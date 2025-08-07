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

    public IActionResult Login (string Email, String Contraseña) 
    {
        int id = BD.Login (Email, Contraseña);
        if (id >-1)
        {
            HttpContext.Session.SetString ("IdUsario", id.ToString());
            return View ("Logueado"); //en este caso tendria que ir a ver las tareas
            //ademas se tiene que guardar la ultima fecha de logiado (Actualizar)

        }
        else
        {
            return View("Index");
        } 
    }

    public IActionResult LoginGuardar () 
    {
        return View ("Index"); //no va asi pero lo pongo para que no tire error
    }

    
    public IActionResult Registro () 
    {
        return View ("Index"); //no va asi pero lo pongo para que no tire error
    }

    
    public IActionResult RegistroGuardarse() 
    {
        return View ("Index"); //no va asi pero lo pongo para que no tire error
        //todo la ultima fecha de login (xq la ultima fecha no existe en este caso, si recien entro xd)
    }

    public IActionResult cerrarSesion () 
    {
        HttpContext.Session.Remove("IdUsuario");
        return View ("Index"); 
    }




}

