
using System;
// Definición clase MensajeEN
namespace ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto
{
public partial class MensajeEN
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
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo comunidad
 */
private ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN comunidad;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN Comunidad {
        get { return comunidad; } set { comunidad = value;  }
}





public MensajeEN()
{
}



public MensajeEN(int id, string contenido, Nullable<DateTime> fecha, ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN comunidad
                 )
{
        this.init (Id, contenido, fecha, comunidad);
}


public MensajeEN(MensajeEN mensaje)
{
        this.init (mensaje.Id, mensaje.Contenido, mensaje.Fecha, mensaje.Comunidad);
}

private void init (int id
                   , string contenido, Nullable<DateTime> fecha, ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN comunidad)
{
        this.Id = id;


        this.Contenido = contenido;

        this.Fecha = fecha;

        this.Comunidad = comunidad;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MensajeEN t = obj as MensajeEN;
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
