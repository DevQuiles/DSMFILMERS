namespace WebApplication2.Models
{
    public class GrupoComunidadesViewModel
    {
        public IEnumerable<ComunidadesViewModel> misComs { get; set; }

        public IEnumerable<ComunidadesViewModel> uniComs { get; set; }
        public IEnumerable<ComunidadesViewModel> todasComs { get; set; }

    }
}
