using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
//creates list using data called from the API
namespace MusicWebSite.backend
{
    class listAPI
    {
        public List<artistClass> artList = new List<artistClass>();
        public List<albumClass> albList = new List<albumClass>();
        public List<songClass> sonList = new List<songClass>();
        public artistClass a1 = new artistClass();
        public albumClass ab1 = new albumClass();

        //gets the information of specific artist from the artist list using its ID
        public void getArtInfo(string id)
        {
            foreach (artistClass item in artList)
            {
                if (item.ID == id)
                {
                    a1 = item;
                }
            }
        }
        //gets the information of specific album from the album list using its ID
        public void getAlbInfo(string id)
        {
            foreach (albumClass item in albList)
            {
                if (item.AlbumID == id)
                {
                    ab1 = item;
                }
            }
        }
        //populates the artist list to used.
        public void getArtList()
        {
            artList = createArtistList();
        }
        //call the API and create a list of arists using the data recived from the API
        static List<artistClass> createArtistList()
        {
            WebClient c = new WebClient();
            string artistJson = c.DownloadString("https://cloudapi4633.azurewebsites.net/api/artist");
            var artist = JsonConvert.DeserializeObject<List<artistClass>>(artistJson);
            return artist;
        }
        //populates the album list to used.
        public void getAlbList()
        {
            albList = createAlbumList();
        }
        //call the API and create a list of albums using the data recived from the API
        static List<albumClass> createAlbumList()
        {
            WebClient c = new WebClient();
            string albumJson = c.DownloadString("https://cloudapi4633.azurewebsites.net/api/album");
            var album = JsonConvert.DeserializeObject<List<albumClass>>(albumJson);
            return album;
        }
        //populates the song list to used.
        public void getSonList()
        {
            sonList = createSongList();
        }
        //call the API and create a list of songs using the data recived from the API
        static List<songClass> createSongList()
        {
            WebClient c = new WebClient();
            string songJson = c.DownloadString("https://cloudapi4633.azurewebsites.net/api/song");
            var song = JsonConvert.DeserializeObject<List<songClass>>(songJson);
            return song;
        }
    }
}