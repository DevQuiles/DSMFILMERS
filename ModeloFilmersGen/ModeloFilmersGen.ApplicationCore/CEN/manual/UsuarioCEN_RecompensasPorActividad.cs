
using System;
using System.Text;
using System.Collections.Generic;
using ModeloFilmersGen.ApplicationCore.Exceptions;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;


/*PROTECTED REGION ID(usingModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto_Usuario_RecompensasPorActividad) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto
{
public partial class UsuarioCEN
{
public void RecompensasPorActividad (string p_oid)
{
        /*PROTECTED REGION ID(ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto_Usuario_RecompensasPorActividad) ENABLED START*/



        UsuarioEN usua = DamePorOID (p_oid);

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

        _IUsuarioRepository.ModificarUsuario (usua);

        /*PROTECTED REGION END*/
}
}
}
