
using System;
// Definición clase UsuarioEN
namespace ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto
{
public partial class UsuarioEN
{
/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo nomUsuario
 */
private string nomUsuario;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo fechaNac
 */
private Nullable<DateTime> fechaNac;



/**
 *	Atributo localidad
 */
private string localidad;



/**
 *	Atributo pais
 */
private string pais;



/**
 *	Atributo deseadas
 */
private System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN> deseadas;



/**
 *	Atributo peliculasVistas
 */
private System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaVistaEN> peliculasVistas;



/**
 *	Atributo seguidos
 */
private System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> seguidos;



/**
 *	Atributo seguidores
 */
private System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> seguidores;



/**
 *	Atributo playlistcreadas
 */
private System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PlaylistEN> playlistcreadas;



/**
 *	Atributo playlistguardadas
 */
private System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PlaylistEN> playlistguardadas;



/**
 *	Atributo recomendaciones_Hechas
 */
private System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.RecomendacionesEN> recomendaciones_Hechas;



/**
 *	Atributo recomendaciones_Recibidas
 */
private System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.RecomendacionesEN> recomendaciones_Recibidas;



/**
 *	Atributo comunidades
 */
private System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN> comunidades;



/**
 *	Atributo comunidades_0
 */
private System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN> comunidades_0;



/**
 *	Atributo nivel
 */
private ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.NivelesEnum nivel;



/**
 *	Atributo notificaciones
 */
private System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.NotificacionesEN> notificaciones;



/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo recompensaDisponible
 */
private bool recompensaDisponible;



/**
 *	Atributo avatarIcon
 */
private ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.AvatarEnum avatarIcon;



/**
 *	Atributo usuarioGoogle
 */
private string usuarioGoogle;






public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string NomUsuario {
        get { return nomUsuario; } set { nomUsuario = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual Nullable<DateTime> FechaNac {
        get { return fechaNac; } set { fechaNac = value;  }
}



public virtual string Localidad {
        get { return localidad; } set { localidad = value;  }
}



public virtual string Pais {
        get { return pais; } set { pais = value;  }
}



public virtual System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN> Deseadas {
        get { return deseadas; } set { deseadas = value;  }
}



public virtual System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaVistaEN> PeliculasVistas {
        get { return peliculasVistas; } set { peliculasVistas = value;  }
}



public virtual System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> Seguidos {
        get { return seguidos; } set { seguidos = value;  }
}



public virtual System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> Seguidores {
        get { return seguidores; } set { seguidores = value;  }
}



public virtual System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PlaylistEN> Playlistcreadas {
        get { return playlistcreadas; } set { playlistcreadas = value;  }
}



public virtual System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PlaylistEN> Playlistguardadas {
        get { return playlistguardadas; } set { playlistguardadas = value;  }
}



public virtual System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.RecomendacionesEN> Recomendaciones_Hechas {
        get { return recomendaciones_Hechas; } set { recomendaciones_Hechas = value;  }
}



public virtual System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.RecomendacionesEN> Recomendaciones_Recibidas {
        get { return recomendaciones_Recibidas; } set { recomendaciones_Recibidas = value;  }
}



public virtual System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN> Comunidades {
        get { return comunidades; } set { comunidades = value;  }
}



public virtual System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN> Comunidades_0 {
        get { return comunidades_0; } set { comunidades_0 = value;  }
}



public virtual ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.NivelesEnum Nivel {
        get { return nivel; } set { nivel = value;  }
}



public virtual System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.NotificacionesEN> Notificaciones {
        get { return notificaciones; } set { notificaciones = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual bool RecompensaDisponible {
        get { return recompensaDisponible; } set { recompensaDisponible = value;  }
}



public virtual ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.AvatarEnum AvatarIcon {
        get { return avatarIcon; } set { avatarIcon = value;  }
}



public virtual string UsuarioGoogle {
        get { return usuarioGoogle; } set { usuarioGoogle = value;  }
}





public UsuarioEN()
{
        deseadas = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN>();
        peliculasVistas = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaVistaEN>();
        seguidos = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN>();
        seguidores = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN>();
        playlistcreadas = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PlaylistEN>();
        playlistguardadas = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PlaylistEN>();
        recomendaciones_Hechas = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.RecomendacionesEN>();
        recomendaciones_Recibidas = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.RecomendacionesEN>();
        comunidades = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN>();
        comunidades_0 = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN>();
        notificaciones = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.NotificacionesEN>();
}



public UsuarioEN(string email, string nomUsuario, string nombre, Nullable<DateTime> fechaNac, string localidad, string pais, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN> deseadas, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaVistaEN> peliculasVistas, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> seguidos, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> seguidores, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PlaylistEN> playlistcreadas, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PlaylistEN> playlistguardadas, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.RecomendacionesEN> recomendaciones_Hechas, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.RecomendacionesEN> recomendaciones_Recibidas, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN> comunidades, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN> comunidades_0, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.NivelesEnum nivel, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.NotificacionesEN> notificaciones, String pass, bool recompensaDisponible, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.AvatarEnum avatarIcon, string usuarioGoogle
                 )
{
        this.init (Email, nomUsuario, nombre, fechaNac, localidad, pais, deseadas, peliculasVistas, seguidos, seguidores, playlistcreadas, playlistguardadas, recomendaciones_Hechas, recomendaciones_Recibidas, comunidades, comunidades_0, nivel, notificaciones, pass, recompensaDisponible, avatarIcon, usuarioGoogle);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (usuario.Email, usuario.NomUsuario, usuario.Nombre, usuario.FechaNac, usuario.Localidad, usuario.Pais, usuario.Deseadas, usuario.PeliculasVistas, usuario.Seguidos, usuario.Seguidores, usuario.Playlistcreadas, usuario.Playlistguardadas, usuario.Recomendaciones_Hechas, usuario.Recomendaciones_Recibidas, usuario.Comunidades, usuario.Comunidades_0, usuario.Nivel, usuario.Notificaciones, usuario.Pass, usuario.RecompensaDisponible, usuario.AvatarIcon, usuario.UsuarioGoogle);
}

private void init (string email
                   , string nomUsuario, string nombre, Nullable<DateTime> fechaNac, string localidad, string pais, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN> deseadas, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaVistaEN> peliculasVistas, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> seguidos, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> seguidores, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PlaylistEN> playlistcreadas, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PlaylistEN> playlistguardadas, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.RecomendacionesEN> recomendaciones_Hechas, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.RecomendacionesEN> recomendaciones_Recibidas, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN> comunidades, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN> comunidades_0, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.NivelesEnum nivel, System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.NotificacionesEN> notificaciones, String pass, bool recompensaDisponible, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.AvatarEnum avatarIcon, string usuarioGoogle)
{
        this.Email = email;


        this.NomUsuario = nomUsuario;

        this.Nombre = nombre;

        this.FechaNac = fechaNac;

        this.Localidad = localidad;

        this.Pais = pais;

        this.Deseadas = deseadas;

        this.PeliculasVistas = peliculasVistas;

        this.Seguidos = seguidos;

        this.Seguidores = seguidores;

        this.Playlistcreadas = playlistcreadas;

        this.Playlistguardadas = playlistguardadas;

        this.Recomendaciones_Hechas = recomendaciones_Hechas;

        this.Recomendaciones_Recibidas = recomendaciones_Recibidas;

        this.Comunidades = comunidades;

        this.Comunidades_0 = comunidades_0;

        this.Nivel = nivel;

        this.Notificaciones = notificaciones;

        this.Pass = pass;

        this.RecompensaDisponible = recompensaDisponible;

        this.AvatarIcon = avatarIcon;

        this.UsuarioGoogle = usuarioGoogle;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
