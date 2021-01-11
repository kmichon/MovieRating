using MovieRating.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Data.Interface
{
    public interface ISqlMovieRating
    {
        MovieRatingModel Add(MovieRatingModel newMovieRating);

        List<MovieRatingModel> GetAll();

        List<MovieRatingModel> GetById(int movieId);

        int Commit();
    }
}
