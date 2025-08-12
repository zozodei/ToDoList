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
        return View();  //todo de la tarea, otra vez el ID lo auto genera 
    }




        public IActionResult ModificarTarea (Tarea tarea)
    {
        BD.ModificarTarea(tarea);
        
         return View("VerTareas");   
    }



        public IActionResult ModificarTareaGuardar () //todo lo modificado
    {
         return View("VerTareas");   
    }



        public IActionResult EliminarTarea (int IdTarea)
    {
            BD.EliminarTarea(IdTarea);

         return View("VerTareas");   
    }

       public IActionResult FinalizarTarea (Tarea tarea)
    {
        if (tarea.Finalizado != True) 
        {
             BD.MarcasTareaComoFinalizada(IdTarea);
        }
         return View("VerTareas");   
    }
    





}
