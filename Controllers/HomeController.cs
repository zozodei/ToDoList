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

    public IActionResult NuevaTarea ()
    {
        return View("CrearTarea.cshtml");   
    }

    public IActionResult NuevaTareaGuardar (Tarea tarea)
    {
        BD.AgregarTarea(tarea);
        return View();  
    }

        public IActionResult ModificarTarea ()
    {
        
         return View("ModificarTarea");   
    }

        public IActionResult ModificarTareaGuardar (Tarea tarea) //todo lo modificado
    {
         BD.ModificarTarea(tarea);
         return View("VerTareas");   
    }

        public IActionResult EliminarTarea (int IdTarea)
    {
            BD.EliminarTarea(IdTarea);

         return View("VerTareas");   
    }
       public IActionResult FinalizarTarea (Tarea tarea)
    {
        if (tarea.Finalizado != true) 
        {
             BD.MarcasTareaComoFinalizada(tarea);
        }
         return View("VerTareas");   
    }
    





}
