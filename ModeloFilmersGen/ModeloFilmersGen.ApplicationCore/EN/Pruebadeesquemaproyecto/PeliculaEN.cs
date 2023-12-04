
using System;
// Definición clase PeliculaEN
namespace ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto
{
public partial class PeliculaEN
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
 *	Atributo caratula
 */
private string caratula;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo genero
 */
private System.Collections.Generic.IList<string> genero;



/**
 *	Atributo duracion
 */
private int duracion;



/**
 *	Atributo usuarios
 */
private System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> usuarios;



/**
 *	Atributo peliculasVistas
 */
private System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaVistaEN> peliculasVistas;



/**
 *	Atributo playlist
 */
private System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PlaylistEN> playlist;



/**
 *	Atributo recomendaciones
 */
private System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.RecomendacionesEN> recomendaciones;



/**
 *	Atributo puntuacion
 */
private int puntuacion;



/**
 *	Atributo estado
 */
private string estado;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Caratula {
        get { return caratula; } set { caratula = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual System.Collections.Generic.IList<string> Genero {
        get { return genero; } set { genero = value;  }
}



public virtual int Duracion {
        get { return duracion; } set { duracion = value;  }
}



public virtual System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> Usuarios {
        get { return usuarios; } set { usuarios = value;  }
}



public virtual System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaVistaEN> PeliculasVistas {
        get { return peliculasVistas; } set { peliculasVistas = value;  }
}



public virtual System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PlaylistEN> Playlist {
        get { return playlist; } set { playlist = value;  }
}



public virtual System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.RecomendacionesEN> Recomendaciones {
        get { return recomendaciones; } set { recomendaciones = value;  }
}



public virtual int Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}



public virtual string Estado {
        get { return estado; } set { estado = value;  }
}





public PeliculaEN()
{
        usuarios = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN>();
        peliculasVistas = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaVistaEN>();
        playlist = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PlaylistEN>();
        recomendaciones = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.RecomendacionesEN>();
}



public PeliculaEN(int id, string nombre, string caratula, string descripcion, Nullable<DateTime> fecha, System.Collections.Generic.IList<string> genero, int duracion, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> usuarios, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaVistaEN> peliculasVistas, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PlaylistEN> playlist, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.RecomendacionesEN> recomendaciones, int puntuacion, string estado
                  )
{
        this.init (Id, nombre, caratula, descripcion, fecha, genero, duracion, usuarios, peliculasVistas, playlist, recomendaciones, puntuacion, estado);
}


public PeliculaEN(PeliculaEN pelicula)
{
        this.init (pelicula.Id, pelicula.Nombre, pelicula.Caratula, pelicula.Descripcion, pelicula.Fecha, pelicula.Genero, pelicula.Duracion, pelicula.Usuarios, pelicula.PeliculasVistas, pelicula.Playlist, pelicula.Recomendaciones, pelicula.Puntuacion, pelicula.Estado);
}

private void init (int id
                   , string nombre, string caratula, string descripcion, Nullable<DateTime> fecha, System.Collections.Generic.IList<string> genero, int duracion, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> usuarios, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaVistaEN> peliculasVistas, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PlaylistEN> playlist, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.RecomendacionesEN> recomendaciones, int puntuacion, string estado)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Caratula = caratula;

        this.Descripcion = descripcion;

        this.Fecha = fecha;

        this.Genero = genero;

        this.Duracion = duracion;

        this.Usuarios = usuarios;

        this.PeliculasVistas = peliculasVistas;

        this.Playlist = playlist;

        this.Recomendaciones = recomendaciones;

        this.Puntuacion = puntuacion;

        this.Estado = estado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PeliculaEN t = obj as PeliculaEN;
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
