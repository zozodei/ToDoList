using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    } 

    public IActionResult VerTarea (int IdTarea)
    {
        Tarea TareaVer = BD.VerTarea(IdTarea);
        ViewBag.Tarea = TareaVer;
        return View("VerTareas.cshtml");
    }

    public IActionResult NuevaTarea (Tarea Tarea)
    {
        BD.AgregarTarea(Tarea);
        return View();   
    }

        public IActionResult NuevaTareaGuardar ()// aca todo lo de la tarea
    {
        return View();  //todo de la tarea, otra vez el ID lo auto genera 
    }

        public IActionResult ModificarTarea ()
    {
        return View();   
    }

        public IActionResult ModificarTareaGuardar () //todo lo modificado
    {
        return View();   
    }

        public IActionResult EliminarTarea ()
    {
        return View();   
    }

       public IActionResult FinalizarTarea ()
    {
        return View();   
    }
    





}
