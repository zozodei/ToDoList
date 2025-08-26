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

    //public IActionResult VerTarea (int IdTarea)
    // {
    //Tarea TareaVer = BD.VerTarea(IdTarea);
    //ViewBag.Tarea = TareaVer;
    //return View("VerTareas");
    //}
    public IActionResult VerTareas()
    {
        int id = int.Parse(HttpContext.Session.GetString("IdUsuario"));
        List<Tarea> ListaTareas = BD.LevantarTareas(id);
        ViewBag.Tareas = ListaTareas;
        ViewBag.Usuario = BD.ObtenerUsuarioPorId(id);
        return View("VerTareas");
    }

    public IActionResult NuevaTarea()
    {
        return View("CrearTarea");
    }

    public IActionResult NuevaTareaGuardar(string Titulo, string Descripcion, DateTime FechaTarea)
    {
        ViewBag.Mensaje = "";
        if (!BD.existeTarea(Titulo, int.Parse(HttpContext.Session.GetString("IdUsuario"))))
        {
            BD.AgregarTarea(Titulo, Descripcion, FechaTarea, int.Parse(HttpContext.Session.GetString("IdUsuario")));
        }
        else
        {
            ViewBag.Mensaje = "Ya existe una tarea con ese titulo, por favor elija otro";
            return View("CrearTarea");
        }
        return RedirectToAction("VerTareas", "Home");
    }

    public IActionResult ModificarTarea(int IdTarea)
    {
        Tarea tarea = BD.ObtenerTareaPorId(IdTarea);
        ViewBag.tarea = tarea;
        return View("ModificarTarea");
    }

    public IActionResult ModificarTareaGuardar(int IdTarea, string Titulo, string Descripcion, DateTime FechaTarea) //tarea?
    {
        ViewBag.Mensaje = "";
        if (!BD.existeTarea(Titulo, int.Parse(HttpContext.Session.GetString("IdUsuario"))))
        {
            BD.ModificarTarea(IdTarea, Titulo, Descripcion, FechaTarea);
        }
        else
        {
            ViewBag.Mensaje = "Ya existe una tarea con ese titulo, por favor elija otro";
            ViewBag.tarea = BD.ObtenerTareaPorId(IdTarea);
            return View("ModificarTarea");
        }
        return RedirectToAction("VerTareas", "Home");
    }

    public IActionResult EliminarTarea(int IdTarea)
    {
        BD.EliminarTarea(IdTarea);

        return RedirectToAction("VerTareas", "Home");
    }
    public IActionResult FinalizarTarea(int IdTarea)
    {
        Tarea tarea = BD.ObtenerTareaPorId(IdTarea);
        if (tarea.Finalizado != true)
        {
            BD.MarcasTareaComoFinalizada(tarea);
        }
        return RedirectToAction("VerTareas", "Home");
    }
    public IActionResult CompartirTareaView(int IdTarea)
    {
        ViewBag.IdTarea = IdTarea;
        return View("CompartirTarea");
    }
    public IActionResult CompartirTarea(int IdTarea, string usernameCompartir)
    {
        Tarea tarea = BD.ObtenerTareaPorId(IdTarea);
        ViewBag.Mensaje = "";
        if (BD.existeUsuario(usernameCompartir))
        {
            if (BD.existeTarea(tarea.Titulo, BD.ObtenerUsuarioPorUsername(usernameCompartir).IdUsuario))
            {
                ViewBag.Mensaje = "El usuario ya tiene una tarea con ese titulo, por favor cambie el titulo de la tarea antes de compartirla";
                ViewBag.IdTarea = IdTarea;
                return View("CompartirTarea");
            }
            else
            {
                BD.CompartirTarea(tarea, usernameCompartir);
                ViewBag.MensajeCompartir = "Tarea compartida con " + usernameCompartir + " correctamente";
            }
        }
        else
        {
            ViewBag.Mensaje = "No existe un usuario con ese username";
            ViewBag.IdTarea = IdTarea;
            return View("CompartirTarea");
        }
        return RedirectToAction("VerTareas", "Home");
    }




}
