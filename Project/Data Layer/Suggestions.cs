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
        public void AddSearchHistory(int userID, string genre)
        {

            try
            {

                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("AddSearchHistory", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userID", userID);
                    command.Parameters.AddWithValue("@genre", genre);

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

        public DataTable GetSuggestMovies(int userID)
        {
            try
            {
                DataTable moviesTable = new DataTable();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("Suggestions", con);
                    command.Parameters.AddWithValue("@userID", userID);
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