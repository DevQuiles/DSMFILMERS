using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto;
using Newtonsoft.Json.Linq;

public class PeliculaApiService
{
    private readonly string apiKey;
    private readonly string baseUrl = "https://api.themoviedb.org/3/";

    public PeliculaApiService(string apiKey)
    {
        this.apiKey = apiKey;
    }

    public List<int> crearPeliculasApi(List<JObject> peliculas)
    {
        PeliculaRepository pelicularepository = new PeliculaRepository();
        PeliculaCEN peliculacen = new PeliculaCEN(pelicularepository);
        List<int> idsPelis = new List<int>();

        foreach (JObject item in peliculas)
        {
            int movieId = (int)item["id"];
            string movieDetailsJson = GetMovieDetails(movieId);
            JObject movie2 = JObject.Parse(movieDetailsJson);

            List<String> genero = new List<String>();

            foreach (var genre in movie2["genres"])
            {
                genero.Add($"{genre["name"]}");
            }

            var runtimeValue = movie2["runtime"];
            int runtime = Convert.ToInt32(runtimeValue);

            var voto = movie2["vote_average"];
            int votoagregar = (int)Math.Truncate(Convert.ToDouble(voto));

            DateTime releaseDate = DateTime.Parse($"{movie2["release_date"]}");

            int idPE = peliculacen.CrearPelicula($"{movie2["title"]}", $"{movie2["poster_path"]}", $"{movie2["overview"]}", releaseDate, genero, runtime, votoagregar, $"{movie2["status"]}");

            idsPelis.Add(idPE);
        }
        return idsPelis;
    }

    public List<JObject> GetMultipleMovies(int count)
    {
        List<JObject> allMovies = new List<JObject>();

        int currentPage = 1;
        int moviesPerPage = 20; // Ajusta según la API que estás utilizando y sus límites

        while (allMovies.Count < count)
        {
            string url = $"{baseUrl}movie/now_playing?api_key={apiKey}&page={currentPage}";
            var movies = GetMoviesPerPage(url);

            if (movies.Count == 0)
            {
                // No hay más resultados disponibles
                break;
            }

            allMovies.AddRange(movies);

            currentPage++;
        }

        // Devolver la cantidad solicitada o menos si no hay suficientes películas
        return allMovies.Take(count).ToList();
    }

    private List<JObject> GetMoviesPerPage(string url)
    {
        using (var httpClient = new HttpClient())
        {
            HttpResponseMessage response = httpClient.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                JObject releases = JObject.Parse(responseBody);

                // Extraer la lista de películas
                List<JObject> movies = releases["results"].ToObject<List<JObject>>();
                return movies;
            }
            else
            {
                // Manejar el error según tus necesidades
                throw new Exception($"Error al obtener películas. Código de estado: {response.StatusCode}");
            }
        }
    }

    public List<JObject> GetLatestReleases()
    {
        using (var httpClient = new HttpClient())
        {
            string url = $"{baseUrl}movie/now_playing?api_key={apiKey}";

            HttpResponseMessage response = httpClient.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                JObject releases = JObject.Parse(responseBody);

                // Extraer la lista de películas
                List<JObject> movies = releases["results"].ToObject<List<JObject>>();
                return movies;
            }
            else
            {
                throw new Exception($"Error al obtener los últimos lanzamientos. Código de estado: {response.StatusCode}");
            }
        }
    }

    public string GetMovieDetails(int movieId)
    {
        using (var httpClient = new HttpClient())
        {
            string url = $"{baseUrl}movie/{movieId}?api_key={apiKey}";

            HttpResponseMessage response = httpClient.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                throw new Exception($"Error al obtener detalles de la película. Código de estado: {response.StatusCode}");
            }
        }
    }
}