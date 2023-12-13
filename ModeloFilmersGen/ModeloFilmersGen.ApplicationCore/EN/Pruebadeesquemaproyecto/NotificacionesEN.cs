
using System;
// Definición clase NotificacionesEN
namespace ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto
{
public partial class NotificacionesEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo contenido
 */
private string contenido;



/**
 *	Atributo usuario
 */
private ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN usuario;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo estado
 */
private bool estado;



/**
 *	Atributo destacada
 */
private bool destacada;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}



public virtual ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual bool Estado {
        get { return estado; } set { estado = value;  }
}



public virtual bool Destacada {
        get { return destacada; } set { destacada = value;  }
}





public NotificacionesEN()
{
}



public NotificacionesEN(int id, string contenido, ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN usuario, Nullable<DateTime> fecha, bool estado, bool destacada
                        )
{
        this.init (Id, contenido, usuario, fecha, estado, destacada);
}


public NotificacionesEN(NotificacionesEN notificaciones)
{
        this.init (notificaciones.Id, notificaciones.Contenido, notificaciones.Usuario, notificaciones.Fecha, notificaciones.Estado, notificaciones.Destacada);
}

private void init (int id
                   , string contenido, ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN usuario, Nullable<DateTime> fecha, bool estado, bool destacada)
{
        this.Id = id;


        this.Contenido = contenido;

        this.Usuario = usuario;

        this.Fecha = fecha;

        this.Estado = estado;

        this.Destacada = destacada;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionesEN t = obj as NotificacionesEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
