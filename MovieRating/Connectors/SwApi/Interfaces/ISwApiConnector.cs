using MovieRating.Connectors.SwApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieRating.Connectors.SwApi.Interfaces
{
    public interface ISwApiConnector
    {
        Task<List<Movie>> GetMovies();

        Task<Movie> GetMovieDetails(int movieId);

        Task<Character> GetCharacterDetails(int characterId);
    }
}
