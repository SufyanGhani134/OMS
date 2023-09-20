using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project.Business_Layer;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.User_Controls
{
    public partial class AddMovieUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        public List<string> getResolution()
        {
            List<string> resolutions = new List<string>();
            foreach (var item in Enum.GetValues( typeof(Resolution.resolution)))
            {
                if (item is Resolution.resolution resolutionEnumValue)
                {
                    var enumField = resolutionEnumValue.GetType().GetField(resolutionEnumValue.ToString());
                    var attributes = enumField.GetCustomAttributes(typeof(EnumStringValueAttribute), false);

                    if (attributes.Length > 0)
                    {
                        var stringValueAttribute = (EnumStringValueAttribute)attributes[0];
                        resolutions.Add(stringValueAttribute.Value);
                    }
                }
            }

            return resolutions;
        }

        public List<string> getGenres()
        {
            List<string> genres = AdminPage.GetAllGenres();
            return genres;
        }


    }
}