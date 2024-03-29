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

                List<JObject> listaPeliculas = movieApiService.GetMultipleMovies(300);
                List<int> idsPeliculas200 = movieApiService.crearPeliculasApi(listaPeliculas);



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