using Microsoft.Data.SqlClient;
using Dapper;
namespace ToDoList.Models;

public static class BD
{
     private static string _connectionString = @"Server=localhost;DataBase=ToDoList;Integrated Security = True;TrustServerCertificate = True;";

     public static int Login(string Username, string Contraseña)
    {
        int ID=-1;
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT ID FROM Usuarios WHERE Username = @pUsername AND contraseña = @pContraseña";
            ID = connection.QueryFirstOrDefault<int>(query, new {pUsername = Username, pContraseña = Contraseña});
        }
        return ID;
    }

     public static void Registro(Usuario User)
    {
        string query = "INSERT INTO Usuario ( Nombre, Apellido, Username, Foto, FechaUltimoInicio, Contraseña) VALUES (@pNombre, @pApellido, @pUsername, @pFoto, @pFechaUltimoInicio, @pContraseña)";
        using (SqlConnection connection = new SqlConnection (_connectionString))
        {
            connection.Execute(query, new {pIdUsuario = User.IdUsuario, pNombre = User.Nombre ,pApellido = User.Apellido, pUsername = User.Username, pFoto = User.Foto, pFechaUltimoInicio = User.FechaUltimoInicio, pContraseña = User.Contraseña });
        }
    }

    public static void AgregarTarea (Tarea tarea)
    {
       string query = "INSERT INTO Tarea (IdTarea, Titulo, Descripcion, FechaTarea, Finalizado) VALUES (@pIdTarea, @pTitulo, @pDescrpcion, @pFechaTarea, @pFinalizado)";
        using (SqlConnection connection = new SqlConnection (_connectionString))
        {
            connection.Execute(query, new {pIdTarea = tarea.IdTarea, pTitulo = tarea.Titulo ,pDescripcion = tarea.Descripcion, pFechaTarea = tarea.FechaTarea, pFinalizado = tarea.Finalizado});
        }
    }

    public static void ModificarTarea (Tarea tarea) 
    {
         string query = "UPDATE Tarea SET Titulo = @tarea.Titulo, Descripcion = @tarea.Descripcion, FechaTarea = @tarea.FechaTarea, Finalizado = @tarea.Finalizado";

         using (SqlConnection connection = new SqlConnection(_connectionString))
         {
            connection.Execute (query, new {pTitulo = tarea.Titulo ,pDescripcion = tarea.Descripcion, pFechaTarea = tarea.FechaTarea, pFinalizado = tarea.Finalizado});
         }
    }

    public static void EliminarTarea (int IdTarea) 
    {
        string query = "DELETE FROM Tarea WHERE IdTarea = @IdTarea";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new {pIdTarea = IdTarea});
        }
    }

    public static Tarea VerTarea (int IdTarea) 
    {
        Tarea TareaVer;

         using (SqlConnection connection = new SqlConnection (_connectionString)) 
        {
                 string query = "SELECT * FROM Tarea WHERE IdTarea = @IdTarea";
                TareaVer = connection.QueryFirstOrDefault<Tarea>(query, new { pIdTarea = IdTarea });    // no sabemos como poner esto hay qye revisar. 
        } 
        return TareaVer;
    } 

    public static List<Tarea> LevantarTareas (int IdUsuario) 
    {
        List<Tarea> tareas = new List<Tarea> ();
        using (SqlConnection connection = new SqlConnection (_connectionString)) 
        {
                string query = "SELECT * FROM Tarea WHERE IdUsuario = @IdUsuario";
                tareas = connection.Query<Tarea>(query, new { IdUsuario }).ToList();    
        }

        return tareas;  
    }

    public static void MarcasTareaComoFinalizada (Tarea tarea) 
    {
        string query = "UPDATE Usuario SET Finalizado = 1 WHERE IdTarea = @tarea.IdTarea";
         using (SqlConnection connection = new SqlConnection (_connectionString)) 
        {
             connection.Execute(query, new {pIdTarea = tarea.IdTarea, pTitulo = tarea.Titulo ,pDescripcion = tarea.Descripcion, pFechaTarea = tarea.FechaTarea, pFinalizado = tarea.Finalizado});
        }
    }

    public static void ActualizarFecha (Usuario User) 
    {
        string query = "UPDATE Usuario SET FechaUltimoInicio = GETDATE() WHERE IdUsuario = @User.IdUsuario";
         using (SqlConnection connection = new SqlConnection (_connectionString)) 
        {
          connection.Execute(query, new {pIdUsuario = User.IdUsuario, pNombre = User.Nombre ,pApellido = User.Apellido, pUsername = User.Username, pFoto = User.Foto, pFechaUltimoInicio = User.FechaUltimoInicio, pContraseña = User.Contraseña });        }

    }
  
}





// clase estatica, es una unica BD. Tarea y Usuarios pueden tener muchos.  Va  atener muchos metodos, oseas de tareas y usuarios. Login x ejemplo (usuario y contraseña) mejor estaria bueno que devuelva el Usuario ( si devuelve algo nulo es que no lo encontro pero si lo encuentra tenes ya todo el objeto). Dsp de login hay que registrarse que le llega todo el objeto usuario, pero el Id va a estar vacio, ni se manda a la BD xq lo auto genera (es un void no devuelve nada). Agregar tareas , se le manda el objeto del tipo tarea, que tiene el id del usuario de session, el id de tarea lo msimo que registro, se pone solo.  Despues modificar tarea que necesita el ID de la tarea para modificarlo. Eliminar tarea que solo te interesa el ID de la tarea, no hace falta cargar todo tarea.id. Ver tarea tmb hay que tenerlo que tambien tiene que tener el id
// en el modificar tarea te manda al formualrio de tarea pero queres que la info ya esta cargada de ante mano, no tener que completar todo, esto te devuelve el objeto tarea (osea mostrar), para poder enseñarla, pero todas las anteriores son void. 
//Dsp esta ver tareas, al que solo le podrias mandar el Id de Usuario, ya que con eso es suficiente para poder ver todas las tareas de ese usuario (La que esta logeada, osea hay que recuperarlo por session)
// falta marcar tarea como finalizada (podria ser en modificar pero mas facil esto), solo le pasas el id y cambia el bool. tmb falta ActualizarFecha (id Usuario)

//Controller:
//A medida que hacemos ejercicios, la info de los mdoels es mas grande. (muchas clases y metodos). Se crea + de un controller, fuera del home controller. Dividiendo las tareas entre muchos controllers
// por ejmeplo uno para la gestion y otro para los usuario,s varias acciones. 
// 1 homecontroller / Accountcontroller (va a tener el login (si esta mal vuelve a pedir, si no va a tareas, pero tenemos que actualizar la fecha del login), loginguardarUsernameypassword, registro, resgistroGuardar (va a tener toda la info del usuario menos la fecha de login, osea es nulla si recien se registra), CerrarSession (loggout  )
// Home controller tiene (Index (pagina principal), VerTareas, NuevaTarea, NuevaTareaGuardar (todo lo de la tarea),  ModificarTera, ModificarTareaGuardar(..), EliminarTarea (Id Tarea), finalizarTarea (Id tarea))
// cerrar sesion, es como remover la session. Todo lo de la session se hace en el controller. Pero se hace en el Account

//View: 
//Index (Si hay + de 1 controller se crea la view dentro de la carpeta llamada home y Account osea en la carpeta view)
// el index va en Home
//En home va: index, ver tareas (botones de eliminarla, modificarla, finalizarla, crear mas), crear tareas (formulario y dsp va devuelta a ver todas las tareas), modificar tarea (es muy parecida a ver tarea), 
// En account: view de login con un forma (Login), view registrar tmb (va al login)