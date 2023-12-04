
using System;
// Definición clase RecomendacionesEN
namespace ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto
{
public partial class RecomendacionesEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo recomendador
 */
private ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN recomendador;



/**
 *	Atributo recomendado
 */
private ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN recomendado;



/**
 *	Atributo pelicula
 */
private ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN pelicula;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN Recomendador {
        get { return recomendador; } set { recomendador = value;  }
}



public virtual ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN Recomendado {
        get { return recomendado; } set { recomendado = value;  }
}



public virtual ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN Pelicula {
        get { return pelicula; } set { pelicula = value;  }
}





public RecomendacionesEN()
{
}



public RecomendacionesEN(int id, Nullable<DateTime> fecha, ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN recomendador, ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN recomendado, ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN pelicula
                         )
{
        this.init (Id, fecha, recomendador, recomendado, pelicula);
}


public RecomendacionesEN(RecomendacionesEN recomendaciones)
{
        this.init (recomendaciones.Id, recomendaciones.Fecha, recomendaciones.Recomendador, recomendaciones.Recomendado, recomendaciones.Pelicula);
}

private void init (int id
                   , Nullable<DateTime> fecha, ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN recomendador, ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN recomendado, ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN pelicula)
{
        this.Id = id;


        this.Fecha = fecha;

        this.Recomendador = recomendador;

        this.Recomendado = recomendado;

        this.Pelicula = pelicula;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RecomendacionesEN t = obj as RecomendacionesEN;
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
