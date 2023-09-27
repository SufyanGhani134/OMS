﻿using Project.Business_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Admin: User
    {

        public Admin() {}

        public string AddMovie(Movie movie)
        {
            try
            {
                BL movieBL = new BL();
                string response = movieBL.AddMovie(movie);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in Admin Class due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public List<Movie> GetMovies(int userID) 
        {
            try
            {
                BL movieBL = new BL();
                List<Movie> AdminMovies = movieBL.GetAdminMovies(userID);
                return AdminMovies;
            }catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetMovies method in Admin Class due to "
                   + exception.Message, exception.InnerException);
            }
        }
    }
}