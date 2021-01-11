using MovieRating.Data.Interface;
using MovieRating.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieRating.Data
{
    public class SqlMovieRating : ISqlMovieRating
    {
        private readonly MovieRatingDbContext db;

        public SqlMovieRating(MovieRatingDbContext db)
        {
            this.db = db;
        }
        public MovieRatingModel Add(MovieRatingModel newMovieRating)
        {
            db.Add(newMovieRating);
            return newMovieRating;
        }

        public List<MovieRatingModel> GetAll()
        {
            return db.MovieRating.ToList();
        }

        public List<MovieRatingModel> GetById(int movieId)
        {
            return db.MovieRating.Where(m => m.MovieId == movieId).ToList();
        }
        public int Commit()
        {
            return db.SaveChanges();
        }
    }
}
