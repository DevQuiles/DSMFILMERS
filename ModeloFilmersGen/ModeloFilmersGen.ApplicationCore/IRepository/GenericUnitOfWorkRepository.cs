
using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto
{
public abstract class GenericUnitOfWorkRepository
{
protected IUsuarioRepository usuariorepository;
protected IPeliculaRepository pelicularepository;
protected IPeliculaVistaRepository peliculavistarepository;
protected IPlaylistRepository playlistrepository;
protected IComunidadesRepository comunidadesrepository;
protected INotificacionesRepository notificacionesrepository;
protected IMensajeRepository mensajerepository;
protected IRecomendacionesRepository recomendacionesrepository;


public abstract IUsuarioRepository UsuarioRepository {
        get;
}
public abstract IPeliculaRepository PeliculaRepository {
        get;
}
public abstract IPeliculaVistaRepository PeliculaVistaRepository {
        get;
}
public abstract IPlaylistRepository PlaylistRepository {
        get;
}
public abstract IComunidadesRepository ComunidadesRepository {
        get;
}
public abstract INotificacionesRepository NotificacionesRepository {
        get;
}
public abstract IMensajeRepository MensajeRepository {
        get;
}
public abstract IRecomendacionesRepository RecomendacionesRepository {
        get;
}
}
}
