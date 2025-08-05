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