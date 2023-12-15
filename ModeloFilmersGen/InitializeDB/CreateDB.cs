
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto;
using ModeloFilmersGen.Infraestructure.CP;
using ModeloFilmersGen.ApplicationCore.Exceptions;

using ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto;
using ModeloFilmersGen.Infraestructure.Repository;
using Newtonsoft.Json.Linq;
using ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto;
using System.Linq;

/*PROTECTED REGION END*/
namespace InitializeDB
{
    public class CreateDB
    {
        public static void Create(string databaseArg, string userArg, string passArg)
        {
            String database = databaseArg;
            String user = userArg;
            String pass = passArg;

            // Conex DB
            SqlConnection cnn = new SqlConnection(@"Server=(local)\sqlexpress; database=master; integrated security=yes");

            // Order T-SQL create user
            String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN [" + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END";

            //Order delete user if exist
            String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
            //Order create databas
            string createBD = "CREATE DATABASE " + database;
            //Order associate user with database
            String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
            SqlCommand cmd = null;

            try
            {
                // Open conex
                cnn.Open();

                //Create user in SQLSERVER
                cmd = new SqlCommand(createUser, cnn);
                cmd.ExecuteNonQuery();

                //DELETE database if exist
                cmd = new SqlCommand(deleteDataBase, cnn);
                cmd.ExecuteNonQuery();

                //CREATE DB
                cmd = new SqlCommand(createBD, cnn);
                cmd.ExecuteNonQuery();

                //Associate user with db
                cmd = new SqlCommand(associatedUser, cnn);
                cmd.ExecuteNonQuery();

                System.Console.WriteLine("DataBase create sucessfully..");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        public static void InitializeData()
        {
            try
            {
                // Initialising  CENs
                UsuarioRepository usuariorepository = new UsuarioRepository();
                UsuarioCEN usuariocen = new UsuarioCEN(usuariorepository);
                PeliculaRepository pelicularepository = new PeliculaRepository();
                PeliculaCEN peliculacen = new PeliculaCEN(pelicularepository);
                PeliculaVistaRepository peliculavistarepository = new PeliculaVistaRepository();
                PeliculaVistaCEN peliculavistacen = new PeliculaVistaCEN(peliculavistarepository);
                PlaylistRepository playlistrepository = new PlaylistRepository();
                PlaylistCEN playlistcen = new PlaylistCEN(playlistrepository);
                ComunidadesRepository comunidadesrepository = new ComunidadesRepository();
                ComunidadesCEN comunidadescen = new ComunidadesCEN(comunidadesrepository);
                NotificacionesRepository notificacionesrepository = new NotificacionesRepository();
                NotificacionesCEN notificacionescen = new NotificacionesCEN(notificacionesrepository);
                MensajeRepository mensajerepository = new MensajeRepository();
                MensajeCEN mensajecen = new MensajeCEN(mensajerepository);
                RecomendacionesRepository recomendacionesrepository = new RecomendacionesRepository();
                RecomendacionesCEN recomendacionescen = new RecomendacionesCEN(recomendacionesrepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

                string apiKey = "29dbc78bafd9c304e5c105beed320b91";
                PeliculaApiService movieApiService = new PeliculaApiService(apiKey);

                //-------------------------------------------------------------
                //---------------OBTENER 200 PELICULAS DEL API---------------- -
                //-------------------------------------------------------------

                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("++++++++++++++20 PELICULAS+++++++++++++");

                List<JObject> listaPeliculas = movieApiService.GetMultipleMovies(50);
                List<int> idsPeliculas200 = movieApiService.crearPeliculasApi(listaPeliculas);

                Console.WriteLine("---------------------");
                Console.WriteLine("---PELICULAS---------");
                Console.WriteLine("---------------------");

                //foreach (int movieId in idsPeliculas200)
                //{
                //    PeliculaEN peli = peliculacen.DamePorOID(movieId);
                //    Console.WriteLine(peli.Nombre);
                //}

                Console.WriteLine("+++++++++++++++++++++++++++");
                Console.WriteLine("+++++++++++++++++++++++++++");

                //Obtener los últimos lanzamientos
                //List<JObject> movies = movieApiService.GetLatestReleases();
                //List<int> idsPeliculasLast = movieApiService.crearPeliculasApi(movies);

                Console.WriteLine("++++++++++++++LAS ULTIMAS PELICULAS+++++++++++++");
                Console.WriteLine("++++++++++++++LAS ULTIMAS PELICULAS+++++++++++++");
                Console.WriteLine("++++++++++++++LAS ULTIMAS PELICULAS+++++++++++++");


                ////----------------------------------------------------------------------------------------------------------------------------------------------------------
                ////----------------------------------------------------------AGREGAR PELICULAS A VISTAS----------------------------------------------------------------------
                ////----------------------------------------------------------------------------------------------------------------------------------------------------------

                //-----------------------------------------------------USUARIO1
                //-------------------------------------------------------------
                Console.WriteLine("---------------------");
                Console.WriteLine("---PV usuario1-------");
                Console.WriteLine("---------------------");

                IList<PeliculaEN> peliculas = peliculacen.DameTodos(0, 6);
                string emailUsuario1 = usuariocen.CrearUsuario("email1", "usuario1", "nombre1", new DateTime(2003, 02, 02), "loc1", "pais1", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Aficionado, "pass1", true, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.AvatarEnum.avatar_1);
                DateTime now2022 = new DateTime(2022, 11, 1);

                //CREO PELICULAS VISTAS
                foreach (var item in peliculas)
                {
                    int pv = peliculavistacen.CrearPeliculaVista("Comentario de pelicula", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.EstrellasEnum.Tres, now2022, item.Id, emailUsuario1);
                }

                int anioActual = now2022.Year;
                int mesActual = now2022.Month;

                IList<PeliculaVistaEN> res = peliculavistacen.DameTodosMes(mesActual, anioActual);
                //muesro peliculas vistas por usuario 1
                foreach (var item in res)
                {
                    Console.WriteLine(item.Pelicula.Id + "-------" + item.Id);
                }
                //-----------------------------------------------------USUARIO2
                //-------------------------------------------------------------

                Console.WriteLine("---------------------");
                Console.WriteLine("---PV usuario2-------");
                Console.WriteLine("---------------------");

                DateTime now = DateTime.Now;
                int anioActual2 = now.Year;
                int mesActual2 = now.Month;

                IList<PeliculaEN> peliculas2 = peliculacen.DameTodos(3, 10);
                string emailUsuario2 = usuariocen.CrearUsuario("email2", "usuario2", "nombre1", new DateTime(2003, 02, 02), "loc1", "pais1", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Aficionado, "pass1", false, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.AvatarEnum.avatar_2);

                foreach (var item in peliculas2)
                {
                    int pv = peliculavistacen.CrearPeliculaVista("Comentario de pelicula324", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.EstrellasEnum.Dos, now, item.Id, emailUsuario2);
                }
                IList<PeliculaVistaEN> res2 = peliculavistacen.DameTodosMes(mesActual2, anioActual2);
                foreach (var item in res2)
                {
                    PeliculaEN peli = peliculacen.DamePorOID(item.Pelicula.Id);
                    Console.WriteLine(peli.Nombre + "-------" + item.Id);
                }

                //IList<PeliculaVistaEN> res = usuariocen.GenerarReporteMensual(mesActual, anioActual,);

                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine("CONSULTAS EVA NURIA -->");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

                //------------------------------------------------------------------------------------------------------------------------------------------------
                //---------------------CRUDS----------------------------------------------------------------------------------------------------------------------
                //------------------------------------------------------------------------------------------------------------------------------------------------

                //----------------------------------------------PELICULAS CRUD--------------------------------------------------------------

                //Dame pelicula por nombre para tener 3

                Console.WriteLine("++++++++++++++ PELICULAS POR NOMBRE: +++++++++++++");
                IList<PeliculaEN> lista = peliculacen.DamePeliculaPorNombre("a");
                Console.WriteLine("Peliculas que contienen la cadena 'a': " + lista.Count());
                foreach (PeliculaEN p in lista)
                {
                    Console.WriteLine(p.Nombre);
                }
                PeliculaEN peli1 = lista[1];
                int idPeli1 = lista[1].Id;
                int idPeli2 = lista[0].Id;
                int idPeli3 = lista[2].Id;

                //Modificar pelicula y dame por OID
                Console.WriteLine("++++++++++++++ PELICULAS POR OID + MODIFICAR PELICULA : +++++++++++++");
                peliculacen.ModificarPelicula(idPeli1, "Talk To Me ACTUALIZADA", peli1.Caratula, peli1.Descripcion, peli1.Fecha, peli1.Genero, peli1.Duracion, peli1.Puntuacion, peli1.Estado);
                peli1 = peliculacen.DamePorOID(idPeli1);
                Console.WriteLine("Pelicula modificada: ");
                Console.WriteLine("ID:" + peli1.Id);
                Console.WriteLine("Nombre: " + peli1.Nombre);
                Console.WriteLine("Fecha de lanzamiento: " + peli1.Fecha);
                Console.WriteLine("Caratula: " + peli1.Caratula);
                Console.WriteLine("Puntuacion: " + peli1.Puntuacion);
                Console.WriteLine("Descripcion --> " + peli1.Descripcion);
                Console.WriteLine("Duración: " + peli1.Duracion);
                Console.WriteLine("Estado de la pelicula status: " + peli1.Estado);


                //Borrar pelicula
                //Console.WriteLine("++++++++++++++BORRAR PELICULA: +++++++++++++");
                //peliculacen.BorrarPelicula(idPeli1);
                //peli1 = peliculacen.DamePorOID(idPeli1);
                //Console.WriteLine("Pelicula borrada: ");
                //if (peli1 == null) Console.WriteLine("La pelicula que se busca ya no pertenece a la base de datos");

                //Dame todas las peliculas
                Console.WriteLine("++++++++++++++DAME TODAS LAS PELICULAS: +++++++++++++");
                lista = peliculacen.DameTodos(0, 30);
                Console.WriteLine("Tenemos un total de " + lista.Count + "peliculas");

                //----------------------------------------USUARIOS CRUDS------------------------------------

                //Creamos usuarios
                //string emailUsuario1 = usuariocen.CrearUsuario ("email1", "usuario1", "nombre1", new DateTime (2003, 02, 02), "loc1", "pais1", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Aficionado, "pass1");
                //string emailUsuario2 = usuariocen.CrearUsuario ("email2", "usuario2", "nombre2", new DateTime (2005, 07, 03), "loc2", "pais2", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Cinefago_Celestial, "pass2");
                string emailUsuario3 = usuariocen.CrearUsuario("email3", "usuario3", "nombre3", new DateTime(2003, 02, 02), "loc3", "pais3", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Principiante_cinefilo, "pass3", true, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.AvatarEnum.avatar_3);
                string emailUsuario4 = usuariocen.CrearUsuario("email4", "usuario4", "nombre4", new DateTime(2005, 07, 03), "loc4", "pais4", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Entusiasta_de_la_Pantalla, "pass4", true, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.AvatarEnum.avatar_4);

                // Modificamos suario
                usuariocen.ModificarUsuario(emailUsuario1, "UsuarioModificado", "nombre1", new DateTime(2003, 02, 02), "loc1", "pais1", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Aficionado, "pass1", false, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.AvatarEnum.avatar_5);

                // Dame por OID y ver que se ha modificado bien
                UsuarioEN usuarioPorOID = usuariocen.DamePorOID(emailUsuario1);

                Console.WriteLine("++++++++++++++ USUARIO POR OID MODIFICADO: +++++++++++++");

                if (usuarioPorOID != null)
                {
                    Console.WriteLine($"Usuario obtenido: {usuarioPorOID.Email}, {usuarioPorOID.NomUsuario}, {usuarioPorOID.Nombre}");
                }
                else
                {
                    Console.WriteLine("Usuario no encontrado");
                }

                // Dame todos
                Console.WriteLine("++++++++++++++ TODOS LOS USUARIOS: +++++++++++++");
                var todosLosUsuarios = usuariocen.DameTodos(0, 10);

                foreach (var usuario in todosLosUsuarios)
                {
                    Console.WriteLine("Usuarios:" + usuario.Nombre);
                }

                // Borrar usuario
                usuariocen.BorrarUsuario(emailUsuario1);

                usuarioPorOID = usuariocen.DamePorOID(emailUsuario1);

                Console.WriteLine("++++++++++++++ Compruebo que ya no aparece el usuario: +++++++++++++");

                if (usuarioPorOID != null)
                {
                    Console.WriteLine($"Usuario obtenido: {usuarioPorOID.Email}, {usuarioPorOID.NomUsuario}, {usuarioPorOID.Nombre}");
                }
                else
                {
                    Console.WriteLine("Usuario no encontrado");
                }

                // Asignar y desasignar usuarios al usuario
                usuariocen.AsignarSeguidores(emailUsuario2, new List<string> { emailUsuario3 });
                //usuariocen.DesasignarSeguidores (emailUsuario2, new List<string> { emailUsuario4 });

                //---------------------------------------- PLAYLIST CRUD--------------------------------------------------------------
                //Crear playlist
                Console.WriteLine("-----------------------------------------------PLAYLISTS------------------------------------");
                int idPlaylist = playlistcen.CrearPlaylist("Mi primera playlist", "descripcion1", emailUsuario2);
                int idPlaylist2 = playlistcen.CrearPlaylist("Mi segunda playlist", "descripcion2", emailUsuario2);
                int idPlaylist3 = playlistcen.CrearPlaylist("Mi tercera playlist", "descripcion3", emailUsuario2);

                //Dame todas las playlist
                Console.WriteLine("-----------------------------------------------DAME TODAS PLAYLISTS------------------------------------");
                IList<PlaylistEN> listaPlaylists = playlistcen.DameTodos(0, 10);
                foreach (PlaylistEN playlist in listaPlaylists)
                {
                    Console.WriteLine("+++++++PLAYLIST " + playlist.Nombre + " : " + playlist.Propietario.Email);
                }

                //Dame playlist por OID y modificar playlist
                Console.WriteLine("-----------------------------------------------MODIFICAR PLAYLIST------------------------------------");
                playlistcen.ModificarPlaylist(idPlaylist, "Mi primera playlist ACTUALIZADA", "descripcion1");
                Console.WriteLine("-----------------------------------------------DAME PLAYLIST POR OID------------------------------------");
                PlaylistEN playlist1 = playlistcen.DamePorOID(idPlaylist);
                Console.WriteLine(playlist1.Nombre + " : " + playlist1.Propietario.Email);

                //Borrar playlist
                Console.WriteLine("-----------------------------------------------BORRAR PLAYLIST------------------------------------");
                playlistcen.BorrarPlaylist(idPlaylist);
                playlist1 = playlistcen.DamePorOID(idPlaylist);
                Console.WriteLine("Playlist borrada: ");
                if (playlist1 == null) Console.WriteLine("La Playlist que se busca ya no pertenece a la base de datos");

                //Asignar y desasignar playlist pelicula
                //Console.WriteLine ("-----------------------------------------------ASIGNAR PELICULA A  PLAYLIST------------------------------------");
                //PlaylistEN playlist2 = playlistcen.DamePorOID (idPlaylist2);
                //peliculacen.AsignarPlaylist (idPeli2, new List<int> { idPlaylist2, idPlaylist3 });
                //Console.WriteLine ("-----------------------------------------------DESASIGNAR PELICULA A  PLAYLIST------------------------------------");
                //peliculacen.DesasignarPlaylist (idPeli2, new List<int> { idPlaylist2 });

                //Asignar y desasignar usuarios y playlist
                Console.WriteLine("-----------------------------------------------ASIGNAR SUSCRIPTORES A  PLAYLIST------------------------------------");
                playlistcen.AsignarSuscriptor(idPlaylist2, new List<String> { emailUsuario3, emailUsuario2 });
                Console.WriteLine("-----------------------------------------------DESASIGNAR SUSCRIPTORES A  PLAYLIST------------------------------------");
                playlistcen.DesasignarSuscriptor(idPlaylist2, new List<String> { emailUsuario3 });

                //Asignar y desasignar pelicula vista y usuario
                Console.WriteLine("-----------------------------------------------ASIGNAR PELICULA A WATCHLIST------------------------------------");
                usuariocen.AsignarPeliculaWatchList(emailUsuario2, new List<int> { idPeli2, idPeli3 });
                Console.WriteLine("-----------------------------------------------DESASIGNAR PELICULA A WATCHLIST------------------------------------");
                usuariocen.DesasignarPeliculaWatchList(emailUsuario2, new List<int> { idPeli2 });

                //---------------------------------------------- COMUNIDADES CRUDS -------------------------------------

                // Crear una comunidad
                int idComunidad1 = comunidadescen.CrearComunidad("NuevaComunidad", DateTime.Now, "Descripción de la nueva comunidad", emailUsuario2);
                int idComunidad2 = comunidadescen.CrearComunidad("comunidad2", DateTime.Today, "Descripcion 2 ", emailUsuario2);
                int idComunidad3 = comunidadescen.CrearComunidad("comunidad3", DateTime.Today, "Descripcion 3 ", emailUsuario2);

                // Modificar la comunidad
                comunidadescen.ModificarComunidad(idComunidad1, "ComunidadModificada", DateTime.Now, "Nueva descripción de la comunidad");

                // Dame por oid
                Console.WriteLine("++++++++++++++ COMUNIDAD POR OID MODIFICADA: +++++++++++++");
                ComunidadesEN comunidadObtenida = comunidadescen.DamePorOID(idComunidad1);

                if (comunidadObtenida != null)
                {
                    Console.WriteLine($"Comunidad obtenida: {comunidadObtenida.Id}, {comunidadObtenida.Nombre}, {comunidadObtenida.Descripcion}");
                }
                else
                {
                    Console.WriteLine("Comunidad no encontrada");
                }

                // Dame todas
                var todasLasComunidades = comunidadescen.DameTodos(0, 10);

                Console.WriteLine("++++++++++++++ TODAS LAS COMUNIDADES: +++++++++++++");

                foreach (var comunidad in todasLasComunidades)
                {
                    Console.WriteLine($"Comunidad: {comunidad.Id}, {comunidad.Nombre}, {comunidad.Descripcion}");
                }

                // Borrar una comunidad
                comunidadescen.BorrarComunidad(idComunidad1);

                comunidadObtenida = comunidadescen.DamePorOID(idComunidad1);

                Console.WriteLine("++++++++++++++ Compruebo que ya no aparece la comunidad: +++++++++++++");

                if (comunidadObtenida != null)
                {
                    Console.WriteLine($"Comunidad obtenida: {comunidadObtenida.Id}, {comunidadObtenida.Nombre}, {comunidadObtenida.Descripcion}");
                }
                else
                {
                    Console.WriteLine("Comunidad no encontrada");
                }

                // Asignar y desasignar la comunidad al usuario
                usuariocen.AsignarComunidad(emailUsuario2, new List<int> { idComunidad2, idComunidad3 });
                usuariocen.DesasignarComunidad(emailUsuario2, new List<int> { idComunidad2 });



                //----------------------------------------------------------------------------------------------------------------------------------------------------------
                //----------------------------------------------------------CONSULTAS FILTER--------------------------------------------------------------------------------
                //----------------------------------------------------------------------------------------------------------------------------------------------------------

                //CONSULTA DAME PELICULAS POR FILTRO
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++ Peliculas por filtro: +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

                IList<PeliculaEN> peliculaPorFiltro = peliculacen.DamePeliculasPorFiltro("Drama", 2023, 7);
                IList<PeliculaEN> peliculaPorFiltro2 = peliculacen.DamePeliculasPorFiltro("Drama", null, null);
                IList<PeliculaEN> peliculaPorFiltro3 = peliculacen.DamePeliculasPorFiltro(null, null, null);
                IList<PeliculaEN> peliculaPorFiltro4 = peliculacen.DamePeliculasPorFiltro(null, null, 7);

                foreach (PeliculaEN pelicula in peliculaPorFiltro)
                {
                    Console.WriteLine("la pelicula buscada es :" + pelicula.Nombre);
                }
                int cont = 0;

                foreach (PeliculaEN pelicula in peliculaPorFiltro2)
                {
                    cont++;
                }

                Console.WriteLine("PRUEBA 1:::::::::::::::::::::::::::::::::::::::::::::::::::" + cont);

                cont = 0;

                foreach (PeliculaEN pelicula in peliculaPorFiltro3)
                {
                    cont++;
                }

                Console.WriteLine("PRUEBA 2:::::::::::::::::::::::::::::::::::::::::::::::::::" + cont);

                cont = 0;

                foreach (PeliculaEN pelicula in peliculaPorFiltro4)
                {
                    cont++;
                }

                Console.WriteLine("PRUEBA 3:::::::::::::::::::::::::::::::::::::::::::::::::::" + cont);

                //CONSULTA DAME USUARIOS POR NOMBRE
                Console.WriteLine("++++++++++++++ Usuarios por nombre: +++++++++++++");
                IList<UsuarioEN> usuarioPorNombre = usuariocen.DameUsuarioPorNombre("usu");

                foreach (UsuarioEN usuario in usuarioPorNombre)
                {
                    Console.WriteLine("El usuario buscado es :" + usuario.Nombre);
                }
                //CONSULTA DAME PELICULAS POR NOMBRE
                Console.WriteLine("++++++++++++++ Peliculas por nombre: +++++++++++++");
                IList<PeliculaEN> peliculaPorNombre = peliculacen.DamePeliculaPorNombre("li");


                foreach (PeliculaEN pelicula in peliculaPorNombre)
                {
                    Console.WriteLine("la pelicula buscada es :" + pelicula.Nombre);
                }

                //CONSULTA COMUNIDADES POR NOMBRE
                IList<ComunidadesEN> comunidadPorNombre = comunidadescen.DameComunidadPorNombre("comunidad2");

                Console.WriteLine("+++++++++++++++++++++++comunidades buscadas: +++++++++++++++++++++++++");

                foreach (ComunidadesEN comunidad in comunidadPorNombre)
                {
                    Console.WriteLine("la comunidad buscada:" + comunidad.Nombre);
                }

                //----------------------------------------------------------------------------------------------------------------------------------------------------------
                //----------------------------------------------------------CUSTOMS-----------------------------------------------------------------------------------------
                //----------------------------------------------------------------------------------------------------------------------------------------------------------

                //recogerRecompensa --------------------------------------------------------
                usuariocen.RecogerRecompensa(emailUsuario4);
                UsuarioEN usuarioR = usuariocen.DamePorOID(emailUsuario4);
                Console.WriteLine("++++++++++++++RECOGER RECOMPENSA++++++++++++++++++");
                Console.WriteLine("Disponible? -> " + usuarioR.RecompensaDisponible);

                //marcarDestacada --------------------------------------------------------
                int i = notificacionescen.CrearNotificacion("hola", emailUsuario2, now, false, false);
                notificacionescen.MarcarDestacada(i);
                Console.WriteLine(i);
                NotificacionesEN not = notificacionescen.DamePorOID(i);
                Console.WriteLine("+++++++++++++++++++++++++++Destacado? -> " + not.Destacada);

                Console.WriteLine("Id:"+ not.Id);
                Console.WriteLine("Id:" + not.Contenido);
                Console.WriteLine("Id:" + not.Destacada);

                //desmarcarDestacada --------------------------------------------------------

                notificacionescen.DesmarcarDestacada(i);
                not = notificacionescen.DamePorOID(i);
                Console.WriteLine("+++++++++++++++++++++++++++Destacado? -> " + not.Destacada);

                //PREUBA DEL ESTADO LEIDO
                notificacionescen.MarcarLeido(i);
                not = notificacionescen.DamePorOID(i);
                Console.WriteLine("+++++++++++++++++++++++++++Estado? -> " + not.Estado);


                //--------------------------------------------------------------------------------------------------
                //---------------------------------------CUSTOM TRANSACTIONS----------------------------------------
                //--------------------------------------------------------------------------------------------------
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("----------------------------------PRUEBA SEGUIR A UNO REPETIDO--------------------------------------------------------------");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                //Prueba follow
                UsuarioCP usCP = new UsuarioCP(new SessionCPNHibernate());
                usCP.Follow(emailUsuario4, emailUsuario2);
                usCP.Follow(emailUsuario4, emailUsuario2);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("------------------------------------------------------------------------------------------------");

                //Prueba unfollow
                UsuarioCP usCP1 = new UsuarioCP(new SessionCPNHibernate());
                usCP1.Unfollow(emailUsuario4, emailUsuario2);

                //Prueba Recomendacion
                RecomendacionesCP recCP1 = new RecomendacionesCP(new SessionCPNHibernate());
                recCP1.CrearRecomendacion(DateTime.Now, emailUsuario4, emailUsuario2, idPeli1);

                //Prueba combinar
                PlaylistCP plCP = new PlaylistCP(new SessionCPNHibernate());
                int idPlaylist5 = playlistcen.CrearPlaylist("hola", "descripcion1", emailUsuario2);
                int idPlaylist4 = playlistcen.CrearPlaylist("adios", "descripcion2", emailUsuario2);
                playlistcen.AsignarPeliculas(idPlaylist5, new List<int> { idPeli1, idPeli2 });
                playlistcen.AsignarPeliculas(idPlaylist4, new List<int> { idPeli3, idPeli2 });

                plCP.CombinarPlaylists(idPlaylist5, idPlaylist4);

                //Recompensa por actividad
                UsuarioCP usCP2 = new UsuarioCP(new SessionCPNHibernate());
                IList<PeliculaEN> peliculasV = new List<PeliculaEN>();
                peliculasV.Add(peli1);
                peliculasV.Add(peliculacen.DamePorOID(idPeli2));
                UsuarioEN usuar = usuariocen.DamePorOID(emailUsuario4);
                Console.WriteLine("++++++++++++++++++++++++++++CAMBIO NIVEL +++++++++++++++++++++++++++++++++++");
                Console.WriteLine(usuar.Nivel);

                foreach (var item in peliculasV)
                {
                    int pv = peliculavistacen.CrearPeliculaVista("Comentario de pelicula", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.EstrellasEnum.Tres, now2022, item.Id, emailUsuario4);
                }

                usCP2.RecompensasPorActividad(emailUsuario4);

                usuar = usuariocen.DamePorOID(emailUsuario4);
                Console.WriteLine(usuar.Nivel);

                Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
                string emailUsuario6 = usuariocen.CrearUsuario("email6", "usuario6", "nombre6", new DateTime(2003, 02, 02), "loc1", "pais1", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Aficionado, "pass6", true, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.AvatarEnum.avatar_4);
                string emailUsuario7 = usuariocen.CrearUsuario("email7", "usuario7", "nombre7", new DateTime(2003, 02, 02), "loc1", "pais1", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Aficionado, "pass7", true, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.AvatarEnum.avatar_5);
                string emailUsuario8 = usuariocen.CrearUsuario("email8", "usuario8", "nombre8", new DateTime(2003, 02, 02), "loc1", "pais1", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Aficionado, "pass8", true, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.AvatarEnum.avatar_5);



                peliculavistacen.CrearPeliculaVista("Comentario de pelicula", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.EstrellasEnum.Tres, new DateTime(2023, 11, 4), peliculas[0].Id, emailUsuario7);
                peliculavistacen.CrearPeliculaVista("Comentario de pelicula", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.EstrellasEnum.Uno, new DateTime(2023, 11, 3), peliculas[1].Id, emailUsuario7);
                peliculavistacen.CrearPeliculaVista("Comentario de pelicula", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.EstrellasEnum.Cuatro, new DateTime(2023, 11, 2), peliculas[0].Id, emailUsuario7);
                peliculavistacen.CrearPeliculaVista("Comentario de pelicula", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.EstrellasEnum.Tres, new DateTime(2023, 11, 1), peliculas[1].Id, emailUsuario7);

                peliculavistacen.CrearPeliculaVista("Comentario de pelicula", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.EstrellasEnum.Cuatro, new DateTime(2023, 11, 4), peliculas[2].Id, emailUsuario8);
                peliculavistacen.CrearPeliculaVista("Comentario de pelicula", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.EstrellasEnum.Dos, new DateTime(2023, 11, 3), peliculas[3].Id, emailUsuario8);
                peliculavistacen.CrearPeliculaVista("Comentario de pelicula", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.EstrellasEnum.Cuatro, new DateTime(2023, 11, 2), peliculas[2].Id, emailUsuario8);
                peliculavistacen.CrearPeliculaVista("Comentario de pelicula", ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.EstrellasEnum.Tres, new DateTime(2023, 11, 1), peliculas[3].Id, emailUsuario8);

                UsuarioEN usuarioprueba6 = usuariocen.DamePorOID(emailUsuario6);

                usCP.Follow(emailUsuario6, emailUsuario7);
                usCP.Follow(emailUsuario6, emailUsuario8);

                IList<PeliculaVistaEN> listactividades = usCP.ActividadAmigos(emailUsuario6);

                foreach (var item in listactividades)
                {
                    Console.WriteLine(item.Fecha);
                }



                Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
                /*PROTECTED REGION END*/
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.InnerException);
                throw;
            }
        }
    }
}
