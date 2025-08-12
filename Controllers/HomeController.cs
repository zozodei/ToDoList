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

    public IActionResult VerTarea ()
    {
         return View();
    }

    public IActionResult NuevaTarea ()
    {
         return View();   
    }

        public IActionResult NuevaTareaGuardar ()// aca todo lo de la tarea
    {
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
