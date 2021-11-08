using System;
//basic structure of an album object from the API.
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
    }
}
