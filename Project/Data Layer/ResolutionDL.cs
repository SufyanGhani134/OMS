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
        public DataTable GetResolutions(int resolutionID)
        {
            try
            {
                DataTable resolutionsTable = new DataTable();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("GetResolutions", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@resolutionID", resolutionID);


                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(resolutionsTable);
                    con.Close();
                }
                return resolutionsTable;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetResolutions in DL due to "
                   + exception.Message, exception.InnerException);
            }

        }

        public DataTable GetResolutionIDs(int movieID)
        {
            try
            {
                DataTable resolutionIDsTable = new DataTable();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("GetResolutionIDs", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@movieID", movieID);
                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(resolutionIDsTable);
                    con.Close();
                }
                return resolutionIDsTable;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetResolutionsIDs in DL due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public void UpdateMovieResolution(int movieId, string resolution)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("UpdateMovieResolution", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@resolution", resolution);
                    command.Parameters.AddWithValue("@movieID", movieId);
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in UpdateMovieResolution in DL due to "
                   + exception.Message, exception.InnerException);
            }
        }
    }
}