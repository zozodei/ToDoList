namespace ToDoList.Models;

public class Tarea
{
     public int IdTarea {get; private set;}
     public string Titulo {get; private set;}
     public string Descripcion {get; private set;}
     public DateTime FechaTarea {get; private set;}
     public bool Finalizado {get; private set;}


     public Tarea (int IdTarea, string Titulo, string Descripcion, DateTime FechaTarea, bool Finalizado) 
     {
        this.IdTarea = IdTarea;
        this.Titulo = Titulo;
        this.Descripcion = Descripcion;
        this.FechaTarea = FechaTarea;
        this.Finalizado = Finalizado;
     }

     public Tarea ()
     {
        
     }





}