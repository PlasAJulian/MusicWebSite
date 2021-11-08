using System;
//basic structure of an artist object from the API.
namespace MusicWebSite.backend
{
    [Serializable]
    class artistClass
    {
        public string ID { get; set; }
        public string ArtistName { get; set; }
        public string ArtistMainGenres { get; set; }
    }
}
