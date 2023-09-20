using Project.Data_Layer;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Project.Business_Layer
{
    public partial class BL
    {
        public string AddMovie(Movie movie)
        {
            try
            {
                string response = DL.AddMovie(movie);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in AddMovie in BL due to "
                   + exception.Message, exception.InnerException);

            }
        }

        public List<Movie> GetAllMovies()
        {
            try
            {
                DataTable moviesTable = new DataTable();
                List<Movie> movies = new List<Movie>();
                moviesTable = DL.GetAllMovies();
                if (moviesTable != null && moviesTable.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in moviesTable.Rows)
                    {
                        Movie movie = new Movie();
                        movie.title = dataRow["title"].ToString();
                        movie.description = dataRow["description"].ToString();
                        movie.ReleaseYear = Convert.ToInt32(dataRow["releaseYear"]);
                        movie.poster = dataRow["poster"].ToString();
                        movie.duration = dataRow["duration"].ToString();
                        movie.price = Convert.ToInt32(dataRow["price"]);
                        movie.ratings = Convert.ToInt32(dataRow["ratings"]);
                        DL genreDL = new DL();
                        DataTable genreIDs = genreDL.GetGenreIDs(Convert.ToInt32(dataRow["movieID"]));
                        foreach (DataRow genreIDRow in genreIDs.Rows)
                        {
                            DataTable genres = genreDL.GetGenres(Convert.ToInt32(dataRow["genreID"]));
                            foreach (DataRow genreRow in genres.Rows)
                            {
                                Genre genre = new Genre();
                                genre.title = genreIDRow["title"].ToString();
                                genre.genreID = Convert.ToInt32(genreIDRow["genreID"]);
                                movie.genres.Add(genre.title);
                            }
                        }
                        DL resolutionDL = new DL();
                        DataTable resolutionIDs = resolutionDL.GetResolutions(Convert.ToInt32(dataRow["movieID"]));
                        foreach (DataRow resolutionIDRow in resolutionIDs.Rows)
                        {
                            DataTable resolutions = resolutionDL.GetResolutions(Convert.ToInt32(dataRow["resolutionID"]));
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
                   + " is encountered in GetAllMovies in BL due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public string DeleteMovie(int userID, int movieID)
        {
            try
            {
                string response = DL.DeleteMovie(userID, movieID);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in DeleteMovie in BL due to "
                   + exception.Message, exception.InnerException);

            }
        }

        public List<Movie> GetAdminMovies(int userID)
        {
            try
            {
                DataTable moviesTable = new DataTable();
                List<Movie> movies = new List<Movie>();
                moviesTable = DL.GetAdminMovies(userID);
                if (moviesTable != null && moviesTable.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in moviesTable.Rows)
                    {
                        Movie movie = new Movie();
                        movie.title = dataRow["title"].ToString();
                        movie.description = dataRow["description"].ToString();
                        movie.ReleaseYear = Convert.ToInt32(dataRow["releaseYear"]);
                        movie.poster = dataRow["poster"].ToString();
                        movie.duration = dataRow["duration"].ToString();
                        movie.price = Convert.ToInt32(dataRow["price"]);
                        movie.ratings = Convert.ToInt32(dataRow["ratings"]);
                        DL genreDL = new DL();
                        DataTable genreIDs = genreDL.GetGenreIDs(Convert.ToInt32(dataRow["movieID"]));
                        foreach (DataRow genreIDRow in genreIDs.Rows)
                        {
                            DataTable genres = genreDL.GetGenres(Convert.ToInt32(dataRow["genreID"]));
                            foreach (DataRow genreRow in genres.Rows)
                            {
                                Genre genre = new Genre();
                                genre.title = genreIDRow["title"].ToString();
                                genre.genreID = Convert.ToInt32(genreIDRow["genreID"]);
                                movie.genres.Add(genre.title);
                            }
                        }
                        DL resolutionDL = new DL();
                        DataTable resolutionIDs = resolutionDL.GetResolutions(Convert.ToInt32(dataRow["movieID"]));
                        foreach (DataRow resolutionIDRow in resolutionIDs.Rows)
                        {
                            DataTable resolutions = resolutionDL.GetResolutions(Convert.ToInt32(dataRow["resolutionID"]));
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
                   + " is encountered in GetAdminMovies in BL due to "
                   + exception.Message, exception.InnerException);
            }
        }
    }
}