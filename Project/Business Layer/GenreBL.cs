using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Project.Data_Layer;

namespace Project.Business_Layer
{
    public partial class BL
    {
        public List<Genre> GetGenres(int genreID)
        {
            try
            {
                DataTable genresTable = new DataTable();
                List<Genre> genres = new List<Genre>();
                genresTable = DL.GetGenres(genreID);
                if (genresTable != null && genresTable.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in genresTable.Rows)
                    {
                        Genre genre = new Genre();
                        genre.title = dataRow["title"].ToString();
                        genres.Add(genre);
                    }
                }
                return genres;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetGenres in BL due to "
                   + exception.Message, exception.InnerException);
            }
        }
    }
}