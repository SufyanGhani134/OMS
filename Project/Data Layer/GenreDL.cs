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
        public void AddGenre(Genre genre)
        {

            try
            {

                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("AddGenre", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@genre", genre.title);
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in AddGenre in DL due to "
                   + exception.Message, exception.InnerException);
            }

        }

        public DataTable GetGenres(int genreID)
        {
            try
            {
                DataTable genresTable = new DataTable();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("GetGenres", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@genreID", genreID);


                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(genresTable);
                    con.Close();
                }
                return genresTable;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetGenres in DL due to "
                   + exception.Message, exception.InnerException);
            }

        }

        public DataTable GetGenreIDs(int movieID)
        {
            try
            {
                DataTable genreIDsTable = new DataTable();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("GetGenreIDs", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@movieID", movieID);
                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(genreIDsTable);
                    con.Close();
                }
                return genreIDsTable;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetGenreIDs in DL due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public void UpdateMovieGenre(int movieID, Genre genre)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("UpdateMovieGenre", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@genre", genre.title);
                    command.Parameters.AddWithValue("@movieID", movieID);
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in UpdateMovieGenre in DL due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public DataTable GetAllGenres()
        {
            try
            {
                DataTable genresTable = new DataTable();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("GetAllGenres", con);
                    command.CommandType = CommandType.StoredProcedure;


                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(genresTable);
                    con.Close();
                }
                return genresTable;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetAllGenres in DL due to "
                   + exception.Message, exception.InnerException);
            }

        }
    }
}
