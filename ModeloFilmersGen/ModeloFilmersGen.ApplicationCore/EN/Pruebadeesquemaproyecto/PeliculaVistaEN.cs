
using System;
// Definición clase PeliculaVistaEN
namespace ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto
{
public partial class PeliculaVistaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo comentario
 */
private string comentario;



/**
 *	Atributo valoracion
 */
private ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.EstrellasEnum valoracion;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo pelicula
 */
private ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN pelicula;



/**
 *	Atributo usuario
 */
private ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN usuario;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.EstrellasEnum Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN Pelicula {
        get { return pelicula; } set { pelicula = value;  }
}



public virtual ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public PeliculaVistaEN()
{
}



public PeliculaVistaEN(int id, string comentario, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.EstrellasEnum valoracion, Nullable<DateTime> fecha, ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN pelicula, ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN usuario
                       )
{
        this.init (Id, comentario, valoracion, fecha, pelicula, usuario);
}


public PeliculaVistaEN(PeliculaVistaEN peliculaVista)
{
        this.init (peliculaVista.Id, peliculaVista.Comentario, peliculaVista.Valoracion, peliculaVista.Fecha, peliculaVista.Pelicula, peliculaVista.Usuario);
}

private void init (int id
                   , string comentario, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.EstrellasEnum valoracion, Nullable<DateTime> fecha, ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN pelicula, ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN usuario)
{
        this.Id = id;


        this.Comentario = comentario;

        this.Valoracion = valoracion;

        this.Fecha = fecha;

        this.Pelicula = pelicula;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PeliculaVistaEN t = obj as PeliculaVistaEN;
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
