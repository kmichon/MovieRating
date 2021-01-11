using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System;
using MovieRating.Connectors.SwApi.Models;
using MovieRating.Connectors.SwApi.Interfaces;
using MovieRating.Data.Interface;

namespace MovieRating.Pages.Movies
{
    public class ListModel : PageModel
    {
        private readonly ISqlMovieRating movieRatingData;
        private readonly ISwApiConnector swApiConnector;

        public string Message { get; set; }
        public IEnumerable<Movie> Movies { get; set; }

        public ListModel(ISqlMovieRating movieRatingData, ISwApiConnector swApiConnector)
        {
            this.movieRatingData = movieRatingData;
            this.swApiConnector = swApiConnector;
        }

        public async Task OnGet()
        {
            Movies = await swApiConnector.GetMovies();

            var moviesRatings = movieRatingData.GetAll();

            foreach (var movie in Movies)
            {
                var movieRatings = moviesRatings.Where(m => m.MovieId == movie.MovieId);
                if (movieRatings.Count() > 0)
                {
                    var movieRatingAverage = decimal.Divide(movieRatings.Sum(item => item.Rating), movieRatings.Count());
                    var movieRatingRounded = Math.Round(movieRatingAverage, 2);
                    movie.MovieRating = movieRatingRounded;
                }
            }
        }
    }
}