namespace ToDoList.Models;

public class Usuario
{

     public int IdUsuario {get; private set;}
     public string Nombre {get; private set;}
     public string Apellido {get; private set;}

     public string Username {get; private set;}

     public string Foto {get; private set;}

     public DateTime FechaUltimoInicio {get; private set;}

     public string Contraseña {get; private set;}


    public Usuario (int IdUsuario, string Nombre, string Apellido, string Username, string Foto, DateTime FechaUltimoInicio, string Contraseña) 
    {
        this.IdUsuario = IdUsuario;
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.Username  = Username;
        this.Foto = Foto;
        this.FechaUltimoInicio = FechaUltimoInicio;
    }

    public Usuario ()
    {

    }

}