using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MusicWebSite.backend
{
    [Serializable]
    class artistClass
    {
        public string ID { get; set; }
        public string ArtistName { get; set; }
        public string ArtistMainGenres { get; set; }

        public void displayArtist()
        {
            Console.WriteLine("Artist ID: " + ID);
            Console.WriteLine("Artist Name: " + ArtistName);
            Console.WriteLine("Artist Genre: " + ArtistMainGenres);
        }
    }
}
