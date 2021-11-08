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
    public partial class Arist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string seachWord = Request.QueryString["Search"];
            searchClass s = new searchClass();
            seachWord = s.cleanWord(seachWord);
            
            System.Diagnostics.Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            System.Diagnostics.Debug.WriteLine(s.relatedAlbList.Count);

            StringBuilder str = new StringBuilder();
            if (s.lookForArtist(seachWord))
            {
                s.searchArtist(seachWord);
                aName.InnerText = s.s1.ArtistName;
                foreach (albumClass item in s.relatedAlbList)
                {
                    string link = "<a href=/Album.aspx?ID=" + item.AlbumID + " class=\"list-group-itemlist-group-item-action\">" + item.AlbumName + "</a>";
                    str.Append(link);

                }
                string h1 = "<br><br><h2>Recommended albums with the same genre</h2><br><br>";
                str.Append(h1);
                foreach (albumClass item in s.recommendedAlbList)
                {
                    string link = "<a href=/Album.aspx?ID=" + item.AlbumID + ">" + item.AlbumName + "</a>";
                    str.Append(link);
                }
            }
            else if (s.lookForAlbum(seachWord))
            {
                s.searchAlbum(seachWord);
                aName.InnerText = s.s1.ArtistName;
                foreach (albumClass item in s.relatedAlbList)
                {
                    string link = "<a href=/Album.aspx?ID=" + item.AlbumID + " class=\"list-group-itemlist-group-item-action\">" + item.AlbumName + "</a>";
                    str.Append(link);

                }
                string h1 = "<br><br><h2>Recommended albums with the same genre</h2><br><br>";
                str.Append(h1);
                foreach (albumClass item in s.recommendedAlbList)
                {
                    string link = "<a href=/Album.aspx?ID=" + item.AlbumID + ">" + item.AlbumName + "</a>";
                    str.Append(link);
                }
            }
            else if (s.LookForSong(seachWord))
            {
                s.searchSong(seachWord);
                aName.InnerText = s.s1.ArtistName;
                foreach (albumClass item in s.relatedAlbList)
                {
                    string link = "<a href=/Album.aspx?ID=" + item.AlbumID + " class=\"list-group-itemlist-group-item-action\">" + item.AlbumName + "</a>";
                    str.Append(link);

                }
                string h1 = "<br><br><h2>Recommended albums with the same genre</h2><br><br>";
                str.Append(h1);
                foreach (albumClass item in s.recommendedAlbList)
                {
                    string link = "<a href=/Album.aspx?ID=" + item.AlbumID + ">" + item.AlbumName + "</a>";
                    str.Append(link);
                }
            }
            else
            {
                string h1 = "<br><br><h1>Sorry nothing was found</h1><br><br>";
                str.Append(h1);
                
            }
           listAlb.InnerHtml = str.ToString();
        }
    }
}