using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieRating.Connectors.SwApi.Models
{
    public class MoviesResponse
    {
        public int Count { get; set; }

        public object Next { get; set; }

        public object Previous { get; set; }

        [JsonProperty("results")]
        public List<Movie> Movies { get; set; }
    }
}
