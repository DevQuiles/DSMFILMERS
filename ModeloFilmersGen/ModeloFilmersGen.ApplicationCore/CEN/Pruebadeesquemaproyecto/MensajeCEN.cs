

using System;
using System.Text;
using System.Collections.Generic;

using ModeloFilmersGen.ApplicationCore.Exceptions;

using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;


namespace ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto
{
/*
 *      Definition of the class MensajeCEN
 *
 */
public partial class MensajeCEN
{
private IMensajeRepository _IMensajeRepository;

public MensajeCEN(IMensajeRepository _IMensajeRepository)
{
        this._IMensajeRepository = _IMensajeRepository;
}

public IMensajeRepository get_IMensajeRepository ()
{
        return this._IMensajeRepository;
}

public int CrearMensaje (string p_contenido, Nullable<DateTime> p_fecha, int p_comunidad)
{
        MensajeEN mensajeEN = null;
        int oid;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Contenido = p_contenido;

        mensajeEN.Fecha = p_fecha;


        if (p_comunidad != -1) {
                // El argumento p_comunidad -> Property comunidad es oid = false
                // Lista de oids id
                mensajeEN.Comunidad = new ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN ();
                mensajeEN.Comunidad.Id = p_comunidad;
        }



        oid = _IMensajeRepository.CrearMensaje (mensajeEN);
        return oid;
}

public MensajeEN DamePorOID (int id
                             )
{
        MensajeEN mensajeEN = null;

        mensajeEN = _IMensajeRepository.DamePorOID (id);
        return mensajeEN;
}

public System.Collections.Generic.IList<MensajeEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> list = null;

        list = _IMensajeRepository.DameTodos (first, size);
        return list;
}
public void ModificarMensaje (int p_Mensaje_OID, string p_contenido, Nullable<DateTime> p_fecha)
{
        MensajeEN mensajeEN = null;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Id = p_Mensaje_OID;
        mensajeEN.Contenido = p_contenido;
        mensajeEN.Fecha = p_fecha;
        //Call to MensajeRepository

        _IMensajeRepository.ModificarMensaje (mensajeEN);
}

public void BorrarMensaje (int id
                           )
{
        _IMensajeRepository.BorrarMensaje (id);
}
}
}
