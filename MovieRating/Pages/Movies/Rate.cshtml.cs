using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieRating.Connectors.SwApi.Interfaces;
using MovieRating.Connectors.SwApi.Models;
using MovieRating.Data.Interface;
using MovieRating.Data.Models;

namespace MovieRating.Pages.Movies
{
    public class RateModel : PageModel
    {
        private readonly ISqlMovieRating movieData;
        private readonly ISwApiConnector swApiConnector;

        [BindProperty]
        public Movie Movie { get; set; }

        [BindProperty]
        public MovieRatingModel NewMovieRating { get; set; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public RateModel(ISqlMovieRating movieData, ISwApiConnector swApiConnector)
        {
            this.movieData = movieData;
            this.swApiConnector = swApiConnector;
        }
        public async Task OnGet(int movieId)
        {
            Movie = await swApiConnector.GetMovieDetails(movieId);
        }

        public IActionResult OnPost()
        {
            NewMovieRating.MovieId = Movie.MovieId;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            movieData.Add(NewMovieRating);

            movieData.Commit();
            TempData["message"] = "Ranking saved!";
            return RedirectToPage("./List");
        }
    }
}