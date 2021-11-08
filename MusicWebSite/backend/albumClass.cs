using System;
using System.Collections.Generic;
using System.Text;

namespace MusicWebSite.backend
{
    [Serializable]
    class albumClass
    {
        public string AlbumID { get; set; }
        public string AlbumName { get; set; }
        public string AlbumGenres { get; set; }
        public string AlbumNumOfSongs { get; set; }
        public string ArtistID { get; set; }

        public void displayAlbum()
        {
            Console.WriteLine("ID: " + AlbumID);
            Console.WriteLine("Name: " + AlbumName);
            Console.WriteLine("Genre: " + AlbumGenres);
            Console.WriteLine("Number of songs: " + AlbumNumOfSongs);
            Console.WriteLine("Artist ID : " + ArtistID);
        }
    }
}
