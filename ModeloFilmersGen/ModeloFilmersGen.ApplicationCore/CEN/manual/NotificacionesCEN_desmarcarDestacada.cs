
using System;
using System.Text;
using System.Collections.Generic;
using ModeloFilmersGen.ApplicationCore.Exceptions;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;


/*PROTECTED REGION ID(usingModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto_Notificaciones_desmarcarDestacada) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto
{
public partial class NotificacionesCEN
{
public void DesmarcarDestacada (int p_oid)
{
        /*PROTECTED REGION ID(ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto_Notificaciones_desmarcarDestacada) ENABLED START*/

        NotificacionesEN notifiacion = DamePorOID (p_oid);

        notifiacion.Destacada = false;

        _INotificacionesRepository.ModificarNotificacion (notifiacion);

        /*PROTECTED REGION END*/
}
}
}
