using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MovieRating.Connectors.SwApi.Interfaces;
using MovieRating.Connectors.SwApi.Models;
using Newtonsoft.Json;

namespace MovieRating.Connectors.SwApi
{
    public class SwApiConnector : ISwApiConnector
    {
        private const string baseUrl = "http://swapi.dev/api/";

        public async Task<List<Movie>> GetMovies()
        {
            var movies = new MoviesResponse();

            var httpClient = CreateHttpClient();

            var httpResponse = await httpClient.GetAsync($"{baseUrl}films/");

            //TODO: Extract to external private validation method
            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Error while connecting to SwApi.");
            }

            string response = await httpResponse.Content.ReadAsStringAsync();
            
            movies = JsonConvert.DeserializeObject<MoviesResponse>(response);

            foreach (var movie in movies.Movies)
            {
                var movieUrlParts = movie.Url.Split("/");
                movie.MovieId = Convert.ToInt32(movieUrlParts[movieUrlParts.Length - 2]);
            }

            return movies.Movies;
        }

        public async Task<Movie> GetMovieDetails(int movieId)
        {
            var movie = new Movie();

            var httpClient = CreateHttpClient();

            var httpResponse = await httpClient.GetAsync($"{baseUrl}films/{movieId}/");

            string response = await httpResponse.Content.ReadAsStringAsync();
            
            movie = JsonConvert.DeserializeObject<Movie>(response);
            movie.MovieId = movieId;

            return movie;
        }

        public async Task<Character> GetCharacterDetails(int characterId)
        {
            var httpClient = CreateHttpClient();

            var httpResponse = await httpClient.GetAsync($"{baseUrl}people/{characterId}/");

            string response = await httpResponse.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<Character>(response);
        }

        private HttpClient CreateHttpClient() 
        {
            var clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            return new HttpClient(clientHandler);
        }
    }
}
