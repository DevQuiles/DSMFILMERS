namespace WebApplication2.Models
{
    public class PlatyListyPeliculasFotosViewModel
    {
        public IList<PlaylistViewModel> Playlist { get; set; }
        public IDictionary<int, IList<string>> CaratulasPorPlaylist { get; set; }
    }
}
