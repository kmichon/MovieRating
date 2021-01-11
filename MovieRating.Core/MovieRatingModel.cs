using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieRating.Core
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
