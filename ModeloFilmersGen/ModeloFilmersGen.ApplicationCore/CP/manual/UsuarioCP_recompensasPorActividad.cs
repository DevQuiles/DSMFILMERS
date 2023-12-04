
using System;
using System.Text;

using System.Collections.Generic;
using ModeloFilmersGen.ApplicationCore.Exceptions;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;



/*PROTECTED REGION ID(usingModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto_Usuario_recompensasPorActividad) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto
{
public partial class UsuarioCP : GenericBasicCP
{
public void RecompensasPorActividad (string p_oid)
{
        /*PROTECTED REGION ID(ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto_Usuario_recompensasPorActividad) ENABLED START*/

        UsuarioCEN usuarioCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                usuarioCEN = new  UsuarioCEN (CPSession.UnitRepo.UsuarioRepository);




                UsuarioEN usua = usuarioCEN.DamePorOID (p_oid);

                Enumerated.Pruebadeesquemaproyecto.NivelesEnum nivelInicial = usua.Nivel;

                if (usua.Email != null) {
                        int numPeliculas = usua.PeliculasVistas.Count;

                        if (numPeliculas >= 1 && numPeliculas <= 3) {
                                usua.Nivel = Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Principiante_cinefilo;
                        }
                        else if (numPeliculas <= 6) {
                                usua.Nivel = Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Aficionado;
                        }
                        else if (numPeliculas <= 9) {
                                usua.Nivel = Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Entusiasta_de_la_Pantalla;
                        }
                        else if (numPeliculas <= 12) {
                                usua.Nivel = Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Connoisseur_Cinematografico;
                        }
                        else if (numPeliculas <= 15) {
                                usua.Nivel = Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Experto_en_Filmografia;
                        }
                        else if (numPeliculas <= 18) {
                                usua.Nivel = Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Maestro_del_Cine;
                        }
                        else if (numPeliculas <= 21) {
                                usua.Nivel = Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Cinefilo_Supremo;
                        }
                        else if (numPeliculas <= 24) {
                                usua.Nivel = Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Guardian_de_la_Filmoteca;
                        }
                        else if (numPeliculas <= 27) {
                                usua.Nivel = Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Leyenda_del_Cine;
                        }
                        else if (numPeliculas <= 30) {
                                usua.Nivel = Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Cinefago_Celestial;
                        }
                }

                Enumerated.Pruebadeesquemaproyecto.NivelesEnum nivelFinal = usua.Nivel;

                if (!nivelFinal.Equals (nivelInicial)) {
                        usua.RecompensaDisponible = true;
                }

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


        /*PROTECTED REGION END*/
}
}
}
