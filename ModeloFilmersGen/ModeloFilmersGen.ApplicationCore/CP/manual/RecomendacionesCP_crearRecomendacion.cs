
using System;
using System.Text;

using System.Collections.Generic;
using ModeloFilmersGen.ApplicationCore.Exceptions;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;



/*PROTECTED REGION ID(usingModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto_Recomendaciones_crearRecomendacion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto
{
public partial class RecomendacionesCP : GenericBasicCP
{
public ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.RecomendacionesEN CrearRecomendacion (Nullable<DateTime> p_fecha, string p_recomendador, string p_recomendado, int p_pelicula)
{
        /*PROTECTED REGION ID(ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto_Recomendaciones_crearRecomendacion) ENABLED START*/

        RecomendacionesCEN recomendacionesCEN = null;

        ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.RecomendacionesEN result = null;


        try
        {
                CPSession.SessionInitializeTransaction ();
                recomendacionesCEN = new  RecomendacionesCEN (CPSession.UnitRepo.RecomendacionesRepository);

                recomendacionesCEN.CrearRecomendacionDefault (p_fecha, p_recomendador, p_recomendado, p_pelicula);

                NotificacionesCEN notiCEN = new NotificacionesCEN (CPSession.UnitRepo.NotificacionesRepository);

                int i = notiCEN.CrearNotificacion ("Nueva recomendacion: --> " + p_recomendador + " te ha recomendado " + p_pelicula, p_recomendado, DateTime.Now, false, false);

                Console.WriteLine (notiCEN.DamePorOID (i).Contenido);


                CPSession.Commit ();
        }
        catch (Exception ex)
        {
                CPSession.RollBack ();
                throw ex;
        }
        finally
        {
                CPSession.SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
