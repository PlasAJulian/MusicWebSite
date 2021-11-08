using System;
using System.Collections.Generic;
using System.Text;

namespace MusicWebSite.backend
{
    [Serializable]
    class songClass
    {
        public string SongID { get; set; }
        public string SongName { get; set; }
        public string SongGenre { get; set; }
        public string AlbumID { get; set; }
        public string ArtistID { get; set; }

        public void displaySong()
        {
            Console.WriteLine("Song ID: " + SongID);
            Console.WriteLine("Song Name: " + SongName);
            Console.WriteLine("Song Genre: " + SongGenre);
            Console.WriteLine("Album ID: " + AlbumID);
            Console.WriteLine("Artist ID: " + ArtistID);
        }
    }
}