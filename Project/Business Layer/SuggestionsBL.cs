using Project.Data_Layer;
using Project.Models;
using Project.User_Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Project.Business_Layer
{
    public partial class BL
    {
        public string AddSearchHistory(int userID, List<string> genres)
        {
            try
            {
                foreach (var genre in genres)
                {
                    DL.AddSearchHistory(userID, genre);

                }
                return "seacrh Added!";
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in AddSearch in BL due to "
                   + exception.Message, exception.InnerException);

            }
        }

        public List<Movie> GetSuggestMovies(int userID)
        {
            try
            {
                DataTable moviesTable = new DataTable();
                List<Movie> movies = new List<Movie>();
                moviesTable = DL.GetSuggestMovies(userID);
                if (moviesTable != null && moviesTable.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in moviesTable.Rows)
                    {
                        Movie movie = new Movie();
                        movie.movieId = Convert.ToInt32(dataRow["movieID"]);
                        movie.title = dataRow["title"].ToString();
                        movie.description = dataRow["description"].ToString();
                        movie.ReleaseYear = Convert.ToInt32(dataRow["releaseYear"]);
                        movie.poster = dataRow["poster"].ToString();
                        movie.duration = dataRow["duration"].ToString();
                        movie.price = Convert.ToInt32(dataRow["price"]);
                        movie.ratings = Convert.ToInt32(dataRow["ratings"]);
                        movie.genres = new List<string>();
                        movie.resolutions = new List<string>();
                        DL genreDL = new DL();
                        DataTable genreIDs = genreDL.GetGenreIDs(movie.movieId);
                        foreach (DataRow genreIDRow in genreIDs.Rows)
                        {
                            DataTable genres = genreDL.GetGenres(Convert.ToInt32(genreIDRow["genreID"]));
                            foreach (DataRow genreRow in genres.Rows)
                            {
                                Genre genre = new Genre();
                                genre.title = genreRow["title"].ToString();
                                genre.genreID = Convert.ToInt32(genreRow["genreID"]);
                                movie.genres.Add(genre.title);
                            }
                        }
                        DL resolutionDL = new DL();
                        DataTable resolutionIDs = resolutionDL.GetResolutionIDs(movie.movieId);
                        foreach (DataRow resolutionIDRow in resolutionIDs.Rows)
                        {
                            DataTable resolutions = resolutionDL.GetResolutions(Convert.ToInt32(resolutionIDRow["resolutionID"]));
                            foreach (DataRow resolutionRow in resolutions.Rows)
                            {
                                movie.resolutions.Add(resolutionRow["title"].ToString());
                            }
                        }
                        movies.Add(movie);
                    }
                }
                return movies;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetSuggestMovies in BL due to "
                   + exception.Message, exception.InnerException);
            }
        }
    }
}