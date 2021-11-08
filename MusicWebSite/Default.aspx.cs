using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusicWebSite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Btn_Click(Object sender, EventArgs e)
        {
            //send the search word to be used in the next page
            string searchWord = SearchW.Value;
            Response.Redirect("Artist.aspx?Search=" + searchWord);
        }
    }
}