
using System;
// Definición clase ComunidadesEN
namespace ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto
{
public partial class ComunidadesEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo fechaCreacion
 */
private Nullable<DateTime> fechaCreacion;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo creador_Emisor
 */
private ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN creador_Emisor;



/**
 *	Atributo menesajes
 */
private System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.MensajeEN> menesajes;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> usuario;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual Nullable<DateTime> FechaCreacion {
        get { return fechaCreacion; } set { fechaCreacion = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN Creador_Emisor {
        get { return creador_Emisor; } set { creador_Emisor = value;  }
}



public virtual System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.MensajeEN> Menesajes {
        get { return menesajes; } set { menesajes = value;  }
}



public virtual System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}





public ComunidadesEN()
{
        menesajes = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.MensajeEN>();
        usuario = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN>();
}



public ComunidadesEN(int id, string nombre, Nullable<DateTime> fechaCreacion, string descripcion, ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN creador_Emisor, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.MensajeEN> menesajes, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> usuario
                     )
{
        this.init (Id, nombre, fechaCreacion, descripcion, creador_Emisor, menesajes, usuario);
}


public ComunidadesEN(ComunidadesEN comunidades)
{
        this.init (comunidades.Id, comunidades.Nombre, comunidades.FechaCreacion, comunidades.Descripcion, comunidades.Creador_Emisor, comunidades.Menesajes, comunidades.Usuario);
}

private void init (int id
                   , string nombre, Nullable<DateTime> fechaCreacion, string descripcion, ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN creador_Emisor, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.MensajeEN> menesajes, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> usuario)
{
        this.Id = id;


        this.Nombre = nombre;

        this.FechaCreacion = fechaCreacion;

        this.Descripcion = descripcion;

        this.Creador_Emisor = creador_Emisor;

        this.Menesajes = menesajes;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComunidadesEN t = obj as ComunidadesEN;
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
