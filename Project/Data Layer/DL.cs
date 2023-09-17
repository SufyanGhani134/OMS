using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Project.Data_Layer
{
    public partial class DL
    {
        string _connectionString = "";
        public DL()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["OnlineMovieSystemCN"].ConnectionString;
        }
    }
}