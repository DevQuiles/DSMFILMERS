
using System;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto;

namespace ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto
{
public partial interface INotificacionesRepository
{
void setSessionCP (GenericSessionCP session);

NotificacionesEN ReadOIDDefault (int id
                                 );

void ModifyDefault (NotificacionesEN notificaciones);

System.Collections.Generic.IList<NotificacionesEN> ReadAllDefault (int first, int size);



int CrearNotificacion (NotificacionesEN notificaciones);


NotificacionesEN DamePorOID (int id
                             );


void ModificarNotificacion (NotificacionesEN notificaciones);




System.Collections.Generic.IList<NotificacionesEN> DameTodos (int first, int size);
}
}
