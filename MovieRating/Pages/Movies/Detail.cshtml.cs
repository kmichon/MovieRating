using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieRating.Connectors.SwApi.Interfaces;
using MovieRating.Connectors.SwApi.Models;

namespace MovieRating.Pages.Movies
{
    public class DetailModel : PageModel
    {
        private readonly ISwApiConnector swApiConnector;

        public Movie Movie { get; set; }

        public DetailModel(ISwApiConnector swApiConnector)
        {
            this.swApiConnector = swApiConnector;
        }
        public async Task OnGet(int movieId)
        {
            var characters = new List<string>();

            Movie = await swApiConnector.GetMovieDetails(movieId);

            foreach (var character in Movie.Characters)
            {
                var characterParts = character.Split("/");
                var characterId = Convert.ToInt32(characterParts[characterParts.Length - 2]);

                var characterDetails = await swApiConnector.GetCharacterDetails(characterId);
                characters.Add(characterDetails.Name);
            }

            Movie.Characters = characters;
        }
    }
}