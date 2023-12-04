

using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;
using ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto;
using ModeloFilmersGen.Infraestructure.CP;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloFilmersGen.Infraestructure.Repository
{
public class UnitOfWorkRepository : GenericUnitOfWorkRepository
{
SessionCPNHibernate session;


public UnitOfWorkRepository(SessionCPNHibernate session)
{
        this.session = session;
}

public override IUsuarioRepository UsuarioRepository {
        get
        {
                this.usuariorepository = new UsuarioRepository ();
                this.usuariorepository.setSessionCP (session);
                return this.usuariorepository;
        }
}

public override IPeliculaRepository PeliculaRepository {
        get
        {
                this.pelicularepository = new PeliculaRepository ();
                this.pelicularepository.setSessionCP (session);
                return this.pelicularepository;
        }
}

public override IPeliculaVistaRepository PeliculaVistaRepository {
        get
        {
                this.peliculavistarepository = new PeliculaVistaRepository ();
                this.peliculavistarepository.setSessionCP (session);
                return this.peliculavistarepository;
        }
}

public override IPlaylistRepository PlaylistRepository {
        get
        {
                this.playlistrepository = new PlaylistRepository ();
                this.playlistrepository.setSessionCP (session);
                return this.playlistrepository;
        }
}

public override IComunidadesRepository ComunidadesRepository {
        get
        {
                this.comunidadesrepository = new ComunidadesRepository ();
                this.comunidadesrepository.setSessionCP (session);
                return this.comunidadesrepository;
        }
}

public override INotificacionesRepository NotificacionesRepository {
        get
        {
                this.notificacionesrepository = new NotificacionesRepository ();
                this.notificacionesrepository.setSessionCP (session);
                return this.notificacionesrepository;
        }
}

public override IMensajeRepository MensajeRepository {
        get
        {
                this.mensajerepository = new MensajeRepository ();
                this.mensajerepository.setSessionCP (session);
                return this.mensajerepository;
        }
}

public override IRecomendacionesRepository RecomendacionesRepository {
        get
        {
                this.recomendacionesrepository = new RecomendacionesRepository ();
                this.recomendacionesrepository.setSessionCP (session);
                return this.recomendacionesrepository;
        }
}
}
}

