using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace MusicWebSite.backend
{
    class listAPI
    {
        public List<artistClass> artList = new List<artistClass>();
        public List<albumClass> albList = new List<albumClass>();
        public List<songClass> sonList = new List<songClass>();
        public artistClass a1 = new artistClass();
        public albumClass ab1 = new albumClass();
        songClass s1 = new songClass();

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
        public void getArtList()
        {
            artList = createArtistList();
        }
        static List<artistClass> createArtistList()
        {
            WebClient c = new WebClient();
            string artistJson = c.DownloadString("https://cloudapi4633.azurewebsites.net/api/artist");
            var artist = JsonConvert.DeserializeObject<List<artistClass>>(artistJson);
            return artist;
        }
        public void getAlbList()
        {
            albList = createAlbumList();
        }
        static List<albumClass> createAlbumList()
        {
            WebClient c = new WebClient();
            string albumJson = c.DownloadString("https://cloudapi4633.azurewebsites.net/api/album");
            var album = JsonConvert.DeserializeObject<List<albumClass>>(albumJson);
            return album;
        }
        public void getSonList()
        {
            sonList = createSongList();
        }
        static List<songClass> createSongList()
        {
            WebClient c = new WebClient();
            string songJson = c.DownloadString("https://cloudapi4633.azurewebsites.net/api/song");
            var song = JsonConvert.DeserializeObject<List<songClass>>(songJson);
            return song;
        }
    }
}