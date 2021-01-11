using Microsoft.EntityFrameworkCore;
using MovieRating.Data.Models;

namespace MovieRating.Data
{
    public class MovieRatingDbContext : DbContext
    {
        public MovieRatingDbContext(DbContextOptions<MovieRatingDbContext> options) : base(options)
        {

        }
        public DbSet<MovieRatingModel> MovieRating { get; set; }
    }
}
