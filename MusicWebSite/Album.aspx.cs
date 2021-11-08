using MusicWebSite.backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusicWebSite
{
    public partial class Album : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //gest the ID of the album from the URL
            string id = Request.QueryString["ID"];
            listAPI l = new listAPI();
            l.getSonList();
            l.getAlbList();
            l.getAlbInfo(id);

            //creates the list of song to be displayed by adding an html hyperlink to the webpage
            StringBuilder str = new StringBuilder();
            aName.InnerText = l.ab1.AlbumName;
            foreach (songClass item in l.sonList)
            {
                if (item.AlbumID == id)
                {
                    string i = "<li class=\"list-group-item\">"+item.SongName+ "</li>";
                    str.Append(i);
                }
            }
            listSong.InnerHtml = str.ToString();
        }
    }
}