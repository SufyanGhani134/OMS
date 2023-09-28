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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class AdminPage : System.Web.UI.Page
    {
        public List<string> SelectedResolutions;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["loggedUser"] != null)
                {
                    Page.Master.FindControl("SignUpBtn").Visible = false;
                    Page.Master.FindControl("logInBtn").Visible = false;
                    Page.Master.FindControl("logOutBtn").Visible = true;
                }
                else
                {
                    Response.Redirect("/Home");

                    
                }
                getResolution();
            }
        }
        public void getResolution()
        {
            List<string> resolutions = new List<string>();
            foreach (var item in Enum.GetValues(typeof(Resolution.resolution)))
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
            foreach (var item in resolutions)
            {
                var itemList = new ListItem
                {
                    Text = item.ToString()
                };
                ResolutionList.Items.Add(itemList);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static List<string> GetAllGenres()
        {
            try
            {
                BL genreBL = new BL();
                List<string> response = genreBL.GetAllGenres();

                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in LogInPage due to "
                   + exception.Message, exception.InnerException);
            }
        }

        protected void addMovie_Click(object sender, EventArgs e)
        {
            
            Movie newMovie = new Movie();
            newMovie.title = movieTitle.Text;
            newMovie.ReleaseYear = Convert.ToInt32(releaseYear.Text);
            newMovie.resolutions = new List<string>();
            foreach (ListItem item in ResolutionList.Items)
            {
                if (item.Selected)
                {
                    newMovie.resolutions.Add(item.Text);
                }
            }

            newMovie.duration = hrs.Text + ":" + mins.Text;
            newMovie.ratings = float.Parse(rating.Text);
            newMovie.description = description.InnerText;
            newMovie.poster = poster.FileName;
            newMovie.price = float.Parse(price.Text);
            newMovie.genres = new List<string>();
            newMovie.genres = JsonConvert.DeserializeObject<List<string>>(arrayData.Value);
            User loggedUser = (User) Session["loggedUser"];
            newMovie.UserID = loggedUser.UserID;

            Admin admin = new Admin();
            string response = admin.Movie.AddMovie(newMovie);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                  "AddMovieResponse('" + response + "');", true);
        }

    }
}