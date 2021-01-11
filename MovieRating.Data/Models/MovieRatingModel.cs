using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRating.Data.Models
{
    public class MovieRatingModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int MovieId { get; set; }
        
        [Required, Range(1,5)]
        public int Rating { get; set; }
    }
}
