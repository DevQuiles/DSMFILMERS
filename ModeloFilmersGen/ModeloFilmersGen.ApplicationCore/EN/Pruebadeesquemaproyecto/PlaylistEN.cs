
using System;
// Definición clase PlaylistEN
namespace ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto
{
public partial class PlaylistEN
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
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo propietario
 */
private ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN propietario;



/**
 *	Atributo peliculas
 */
private System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN> peliculas;



/**
 *	Atributo suscriptores
 */
private System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> suscriptores;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN Propietario {
        get { return propietario; } set { propietario = value;  }
}



public virtual System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN> Peliculas {
        get { return peliculas; } set { peliculas = value;  }
}



public virtual System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> Suscriptores {
        get { return suscriptores; } set { suscriptores = value;  }
}





public PlaylistEN()
{
        peliculas = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN>();
        suscriptores = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN>();
}



public PlaylistEN(int id, string nombre, string descripcion, ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN propietario, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN> peliculas, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> suscriptores
                  )
{
        this.init (Id, nombre, descripcion, propietario, peliculas, suscriptores);
}


public PlaylistEN(PlaylistEN playlist)
{
        this.init (playlist.Id, playlist.Nombre, playlist.Descripcion, playlist.Propietario, playlist.Peliculas, playlist.Suscriptores);
}

private void init (int id
                   , string nombre, string descripcion, ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN propietario, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN> peliculas, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> suscriptores)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Propietario = propietario;

        this.Peliculas = peliculas;

        this.Suscriptores = suscriptores;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PlaylistEN t = obj as PlaylistEN;
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
