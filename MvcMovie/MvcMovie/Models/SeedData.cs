using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "17 Miracles",
                    ReleaseDate = DateTime.Parse("2011-6-3"),
                    Genre = "Adventure",
                    Rating = "PG",
                    Price = 7.99M,
                    ImageName = "17miracles.jpeg"
                },
                new Movie
                {
                    Title = "Ephraim's Rescue",
                    ReleaseDate = DateTime.Parse("2013-5-31"),
                    Genre = "Drama",
                    Rating = "PG",
                    Price = 8.99M,
                    ImageName = "ephraim.jpeg"

                },
                new Movie
                {
                    Title = "Singles Ward",
                    ReleaseDate = DateTime.Parse("2002-1-30"),
                    Genre = "Comedy",
                    Rating = "PG",
                    Price = 9.99M,
                    ImageName = "singlesWard.jpeg"
                 
                },
                new Movie
                {
                    Title = "The Saratov Approach",
                    ReleaseDate = DateTime.Parse("2013-10-1"),
                    Genre = "Action",
                    Rating = "PG-13",
                    Price = 3.99M,
                    ImageName = "saratov.jpeg"
                }
            );
            context.SaveChanges();
        }
    }
}