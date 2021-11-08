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
            //get the search word from the URL and calls the search methods 
            string seachWord = Request.QueryString["Search"];
            searchClass s = new searchClass();
            seachWord = s.cleanWord(seachWord);
            listAPI l = new listAPI();

            StringBuilder str = new StringBuilder();
            //if the search word is an arist 
            if (s.lookForArtist(seachWord))
            {
                //calls to create the list and sets html items to be displayed on the frontend 
                s.searchArtist(seachWord);
                aName.InnerText = s.s1.ArtistName;
                //displays the list of albums made by the artist. creates the list by adding an html hyperlink to the webpage
                foreach (albumClass item in s.relatedAlbList)
                {
                    string link = "<a href=/Album.aspx?ID=" + item.AlbumID + " class=\"list-group-itemlist-group-item-action\">" + item.AlbumName + "</a>";
                    str.Append(link);

                }
                //if there are other albums with the same genre, that list is also shown
                if (s.recommendedAlbList.Count != 0) {
                    string h1 = "<br><br><h2>Recommended albums with the same genre</h2><br><br>";
                    str.Append(h1);
                    foreach (albumClass item in s.recommendedAlbList)
                    {
                        l.getArtList();
                        l.getArtInfo(item.ArtistID);
                        string artname = "<h3>"+ l.a1.ArtistName +"</h3>";
                        str.Append(artname);
                        string link = "<a href=/Album.aspx?ID=" + item.AlbumID + ">" + item.AlbumName + "</a>";
                        str.Append(link);
                    }
                }
            }
            //if the search word is an album 
            else if (s.lookForAlbum(seachWord))
            {
                //calls to create the list and sets html items to be displayed on the frontendc. reates the list by adding an html hyperlink to the webpage
                s.searchAlbum(seachWord);
                aName.InnerText = s.s1.ArtistName;
                //displays the albums that was searched
                foreach (albumClass item in s.relatedAlbList)
                {
                    string link = "<a href=/Album.aspx?ID=" + item.AlbumID + " class=\"list-group-itemlist-group-item-action\">" + item.AlbumName + "</a>";
                    str.Append(link);

                }
                //if there are other albums with the same genre, that list is also shown
                if (s.recommendedAlbList.Count != 0)
                {
                    string h1 = "<br><br><h2>Recommended albums with the same genre</h2><br><br>";
                    str.Append(h1);
                    foreach (albumClass item in s.recommendedAlbList)
                    {
                        l.getArtList();
                        l.getArtInfo(item.ArtistID);
                        string artname = "<h3>" + l.a1.ArtistName + "</h3>";
                        str.Append(artname);
                        string link = "<a href=/Album.aspx?ID=" + item.AlbumID + ">" + item.AlbumName + "</a>";
                        str.Append(link);
                    }
                }
            }
            //if the search word is an song 
            else if (s.LookForSong(seachWord))
            {
                //calls to create the list and sets html items to be displayed on the frontend. creates the list by adding an html hyperlink to the webpage
                s.searchSong(seachWord);
                aName.InnerText = s.s1.ArtistName;
                //if there are other albums with the same genre, that list is also shown
                foreach (albumClass item in s.relatedAlbList)
                {
                    string link = "<a href=/Album.aspx?ID=" + item.AlbumID + " class=\"list-group-itemlist-group-item-action\">" + item.AlbumName + "</a>";
                    str.Append(link);

                }
                //if there are other albums with the same genre, that list is also shown
                if (s.recommendedAlbList.Count != 0)
                {
                    string h1 = "<br><br><h2>Recommended albums with the same genre</h2><br><br>";
                    str.Append(h1);
                    foreach (albumClass item in s.recommendedAlbList)
                    {
                        l.getArtList();
                        l.getArtInfo(item.ArtistID);
                        string artname = "<h3>" + l.a1.ArtistName + "</h3>";
                        str.Append(artname);
                        string link = "<a href=/Album.aspx?ID=" + item.AlbumID + ">" + item.AlbumName + "</a>";
                        str.Append(link);
                    }
                }
            }
            //if nothing is found using the searched word.
            else
            {
                string h1 = "<br><br><h1>Sorry nothing was found</h1><br><br>";
                str.Append(h1);
                
            }
           listAlb.InnerHtml = str.ToString();
        }
    }
}