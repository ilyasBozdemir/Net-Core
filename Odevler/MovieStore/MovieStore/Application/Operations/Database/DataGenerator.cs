using System;
using System.Linq;
using MovieStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Org.BouncyCastle.Crypto.Generators;
using MovieStore.Application.Helpers;

namespace MovieStore.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider
                .GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }

                //Datalar rastgele oluþturulmuþtur.
                #region entities

                Genre genreAction = new(), genreFantasy = new(), genreDrama = new(), genreRomance = new(), genreHorror = new(), genreComedy = new();
                Director director = new(), director2 = new(), director3 = new(), director4 = new();
                Movie movieColette = new(), movieTheLastSong = new(), movieASpecialDay = new(), movieGothika = new(), movieNappilyEverAfter = new();
                Customer customer = new(), customer2 = new(), customer3 = new();
                Order order, order2, order3, order4, order5;
                Actor actor, actor2, actor3, actor4;


                #region Genres
                genreAction = new() { Name = "Action" };
                genreFantasy = new() { Name = "Fantasy" };
                genreDrama = new() { Name = "Drama" };
                genreRomance = new() { Name = "Romance" };
                genreHorror = new() { Name = "Horror" };
                genreComedy = new() { Name = "Comedy" };
                #endregion
                #region Directors
                director = new()
                {
                    FirstName = "Ramin",
                    LastName = "Bahrani"
                };
                director2 = new()
                {
                    FirstName = "Pete",
                    LastName = "Docter"
                };
                director3 = new()
                {
                    FirstName = "Rian",
                    LastName = "Johnson"
                };
                director4 = new()
                {
                    FirstName = "Guy",
                    LastName = "Maddin"
                };
                #endregion
                #region Movies
                movieColette = new Movie()
                {
                    GenreId = genreFantasy.Id,
                    Name = "Colette",
                    DirectorId = director.Id,
                    Price = 15,
                    ReleaseYear = 2015
                };
                movieTheLastSong = new Movie()
                {
                    GenreId = genreComedy.Id,
                    Name = "The Last Song",
                    DirectorId = director4.Id,
                    Price = 20,
                    ReleaseYear = 1995
                };
                movieASpecialDay = new Movie()
                {
                    GenreId = genreHorror.Id,
                    Name = "A Special Day",
                    DirectorId = director2.Id,
                    Price = 35,
                    ReleaseYear = 1997

                };
                movieGothika = new Movie()
                {
                    GenreId = genreDrama.Id,
                    Name = "Gothika",
                    DirectorId = director3.Id,
                    Price = 25,
                    ReleaseYear = 2008
                };
                movieNappilyEverAfter = new Movie()
                {
                    GenreId = genreRomance.Id,
                    Name = "Nappily Ever After",
                    DirectorId = director.Id,
                    Price = 20,
                    ReleaseYear = 2010

                };

                #endregion
                #region Orders

                order = new()
                {
                    CustomerId = customer.Id,
                    MovieId = movieASpecialDay.Id,
                    Price = movieASpecialDay.Price,
                    ProcessDate = DateTime.Now.AddDays(-8)
                };
                order2 = new()
                {
                    CustomerId = customer.Id,
                    MovieId = movieGothika.Id,
                    Price = movieGothika.Price,
                    ProcessDate = DateTime.Now.AddDays(-5)
                };
                order3 = new()
                {
                    CustomerId = customer2.Id,
                    MovieId = movieTheLastSong.Id,
                    Price = movieTheLastSong.Price,
                    ProcessDate = DateTime.Now.AddDays(-5)
                };
                order4 = new()
                {
                    CustomerId = customer3.Id,
                    MovieId = movieColette.Id,
                    Price = movieColette.Price,
                    ProcessDate = DateTime.Now.AddDays(-3)
                };
                order5 = new()
                {
                    CustomerId = customer2.Id,
                    MovieId = movieNappilyEverAfter.Id,
                    Price = movieNappilyEverAfter.Price,
                    ProcessDate = DateTime.Now.AddDays(-4)
                };


                #endregion
                #region Customers

                customer = new()
                {
                    FirstName = "Dorothy",
                    LastName = "Moore",
                    Email = "denpenza717@fernet89.com",
                    FavoriteGenres = new List<Genre>() { genreAction, genreFantasy, genreRomance },
                    Orders = new List<Order>() { order, order2 },
                    Password = SiteCryptography.MD5Sifrele("KvqEhSzQAX5kG8tu")
                };
                customer2 = new()
                {
                    FirstName = "Laura",
                    LastName = "Bolton",
                    Email = "piolap4@greendike.com",
                    FavoriteGenres = new List<Genre>() { genreDrama, genreComedy },
                    Orders = new List<Order>() { order3, order5 },
                    Password = SiteCryptography.MD5Sifrele("6bt7ttf7WHm2wQZe")
                };
                customer3 = new()
                {
                    FirstName = "Traci",
                    LastName = "Farmer",
                    Email = "l2e3n0a7@ggo.one",
                    FavoriteGenres = new List<Genre>() { genreFantasy, genreHorror },
                    Orders = new List<Order>() { order4 },
                    Password = SiteCryptography.MD5Sifrele("KE3KsWbNTwsAJ24P")
                };

                #endregion
                #region Actors

                actor = new()
                {
                    FirstName = "Ekkehart",
                    LastName = "Klemt",
                    Movies = new List<Movie>() { movieASpecialDay, movieGothika }
                };
                actor2 = new()
                {
                    FirstName = "Irmingard",
                    LastName = "Davids",
                    Movies = new List<Movie>() { movieNappilyEverAfter, movieTheLastSong }
                };
                actor3 = new()
                {
                    FirstName = "Constantin",
                    LastName = "Gerlach",
                    Movies = new List<Movie>() { movieNappilyEverAfter }
                };
                actor4 = new()
                {
                    FirstName = "Martine",
                    LastName = "Segebahn",
                    Movies = new List<Movie>() { movieColette, movieASpecialDay }
                };

                #endregion

                #endregion

                context.Directors.AddRange(director, director2, director3, director4);
                context.Orders.AddRange(order, order2, order3, order4, order5);
                context.Movies.AddRange(movieColette, movieTheLastSong, movieASpecialDay, movieGothika, movieNappilyEverAfter);
                context.Customers.AddRange(customer, customer2, customer3);

                context.SaveChanges();
            }
        }
    }
}