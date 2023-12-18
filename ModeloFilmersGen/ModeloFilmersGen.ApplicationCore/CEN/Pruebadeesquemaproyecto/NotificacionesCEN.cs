

using System;
using System.Text;
using System.Collections.Generic;

using ModeloFilmersGen.ApplicationCore.Exceptions;

using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;


namespace ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto
{
/*
 *      Definition of the class NotificacionesCEN
 *
 */
public partial class NotificacionesCEN
{
private INotificacionesRepository _INotificacionesRepository;

public NotificacionesCEN(INotificacionesRepository _INotificacionesRepository)
{
        this._INotificacionesRepository = _INotificacionesRepository;
}

public INotificacionesRepository get_INotificacionesRepository ()
{
        return this._INotificacionesRepository;
}

public int CrearNotificacion (string p_contenido, string p_usuario, Nullable<DateTime> p_fecha, bool p_estado, bool p_destacada, string p_usuariorEmisor, int p_pelicula)
{
        NotificacionesEN notificacionesEN = null;
        int oid;

        //Initialized NotificacionesEN
        notificacionesEN = new NotificacionesEN ();
        notificacionesEN.Contenido = p_contenido;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                notificacionesEN.Usuario = new ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN ();
                notificacionesEN.Usuario.Email = p_usuario;
        }

        notificacionesEN.Fecha = p_fecha;

        notificacionesEN.Estado = p_estado;

        notificacionesEN.Destacada = p_destacada;

        notificacionesEN.UsuariorEmisor = p_usuariorEmisor;

        notificacionesEN.Pelicula = p_pelicula;



        oid = _INotificacionesRepository.CrearNotificacion (notificacionesEN);
        return oid;
}

public NotificacionesEN DamePorOID (int id
                                    )
{
        NotificacionesEN notificacionesEN = null;

        notificacionesEN = _INotificacionesRepository.DamePorOID (id);
        return notificacionesEN;
}

public void ModificarNotificacion (int p_Notificaciones_OID, string p_contenido, Nullable<DateTime> p_fecha, bool p_estado, bool p_destacada, string p_usuariorEmisor, int p_pelicula)
{
        NotificacionesEN notificacionesEN = null;

        //Initialized NotificacionesEN
        notificacionesEN = new NotificacionesEN ();
        notificacionesEN.Id = p_Notificaciones_OID;
        notificacionesEN.Contenido = p_contenido;
        notificacionesEN.Fecha = p_fecha;
        notificacionesEN.Estado = p_estado;
        notificacionesEN.Destacada = p_destacada;
        notificacionesEN.UsuariorEmisor = p_usuariorEmisor;
        notificacionesEN.Pelicula = p_pelicula;
        //Call to NotificacionesRepository

        _INotificacionesRepository.ModificarNotificacion (notificacionesEN);
}

public System.Collections.Generic.IList<NotificacionesEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<NotificacionesEN> list = null;

        list = _INotificacionesRepository.DameTodos (first, size);
        return list;
}
}
}
