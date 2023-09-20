using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Project.Data_Layer
{
    public partial class DL
    {
        public string AddMovie(Movie movie)
        {
            try
            {
                string response = "";
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("AddMovie", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userID", movie.UserID);
                    command.Parameters.AddWithValue("@title", movie.title);
                    command.Parameters.AddWithValue("@poster", movie.poster);
                    command.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                    command.Parameters.AddWithValue("@description", movie.description);
                    command.Parameters.AddWithValue("@duration", movie.duration);
                    command.Parameters.AddWithValue("@price", movie.price);
                    command.Parameters.AddWithValue("@ratings", movie.ratings);
                    command.Parameters.Add("@PKID", SqlDbType.Int, 32);
                    command.Parameters["@PKID"].Direction = ParameterDirection.Output;
                    con.Open();
                    command.ExecuteNonQuery();
                    foreach (var item in movie.genres)
                    {
                        DL newGenre = new DL();
                        newGenre.AddGenre(item);
                        AddMovieGenre(Convert.ToInt32(command.Parameters["@PKID"].Value), item);
                    }
                    foreach (var item in movie.resolutions)
                    {
                        AddMovieResolution(Convert.ToInt32(command.Parameters["@PKID"].Value), item);
                    }

                   
                    response = Convert.ToString(command.Parameters["@PKID"].Value);
                    con.Close();
                }
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in AddMovie in DL due to "
                   + exception.Message, exception.InnerException);
            }

        }

        public void AddMovieGenre(int movieID, string genre)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("AddMovieGenre", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@movieID", movieID);
                    command.Parameters.AddWithValue("@genre", genre);

                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in AddMovieGenre in DL due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public void AddMovieResolution(int movieID, string resolution)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("AddMovieResolution", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@movieID", movieID);
                    command.Parameters.AddWithValue("@resolution", resolution);

                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in AddMovieResolution in DL due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public DataTable GetAllMovies()
        {
            try
            {
                DataTable moviesTable = new DataTable();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("AllMovies", con);
                    command.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(moviesTable);
                    con.Close();
                }
                return moviesTable;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetAllMovies in DL due to "
                   + exception.Message, exception.InnerException);
            }

        }

        public string DeleteMovie(int userID, int movieID)
        {
            string response = "";
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("RemoveMovies", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@movieID", movieID);
                    command.Parameters.AddWithValue("@userID", userID);

                    con.Open();
                    command.ExecuteNonQuery();
                    if (Convert.ToInt32(command.Parameters["@isValid"].Value) == 1)
                    {
                        response = "Movie Deleted Successfully!";
                    }
                    else
                    {
                        response = "Failed to Delete the movie!";
                    }
                    con.Close();
                }
                return response;

            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in DeleteMovie in DL due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public string updateMovie(Movie movie)
        {
            string response = "";
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("UpdateMovie", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@movieID", movie.movieId);
                    command.Parameters.AddWithValue("@userID", movie.UserID);
                    command.Parameters.AddWithValue("@title", movie.title);
                    command.Parameters.AddWithValue("@poster", movie.poster);
                    command.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                    command.Parameters.AddWithValue("@description", movie.description);
                    command.Parameters.AddWithValue("@duration", movie.duration);
                    command.Parameters.AddWithValue("@price", movie.price);
                    command.Parameters.AddWithValue("@ratings", movie.ratings);
                    foreach (var genre in movie.genres)
                    {
                        DL updateGenre = new DL();
                        updateGenre.UpdateMovieGenre(movie.movieId, genre);
                    }
                    foreach (var resolution in movie.resolutions)
                    {
                        DL updateResolution = new DL();
                        updateResolution.UpdateMovieResolution(movie.movieId, resolution);
                    }


                    con.Open();
                    command.ExecuteNonQuery();
                    if (Convert.ToInt32(command.Parameters["@isValid"].Value) == 1)
                    {
                        response = "Movie uodated Successfully!";
                    }
                    else
                    {
                        response = "Failed to update the movie!";
                    }
                    con.Close();
                }
                return response;

            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in updateMovie in DL due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public DataTable GetAdminMovies(int userID)
        {
            try
            {
                DataTable moviesTable = new DataTable();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("GetAdminMovies", con);
                    command.Parameters.AddWithValue("userID", userID);
                    command.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(moviesTable);
                    con.Close();
                }
                return moviesTable;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetAdminMovies in DL due to "
                   + exception.Message, exception.InnerException);
            }

        }
    }
}