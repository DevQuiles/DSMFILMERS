namespace WebApplication2.Models
{
    public class PlayList_PeliculasViewModel
    {
        public PlaylistViewModel Playlist { get; set; }
        public IList<PeliculaViewModel> Pelicula { get; set; }    
    }
}
