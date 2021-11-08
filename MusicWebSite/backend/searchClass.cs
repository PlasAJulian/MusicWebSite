using System.Collections.Generic;
//runs the search function of the website 
namespace MusicWebSite.backend
{
    class searchClass
    {
        public List<albumClass> relatedAlbList = new List<albumClass>();
        public List<albumClass> recommendedAlbList = new List<albumClass>();
        public artistClass s1 = new artistClass();
        public albumClass ab1 = new albumClass();
        listAPI l;
        //cleans the searched word by making it all lower case and removing any additional spaces
        public string cleanWord(string s)
        {
            s = s.ToLower();
            return s.Trim();
        }
        //checks if the searched word is an artist from the list or if an artist name contains the search word 
        public bool lookForArtist(string w)
        {
            l = new listAPI();
            l.getArtList();
            foreach (artistClass item in l.artList)
            {
                if (item.ArtistName.ToLower() == w || item.ArtistName.ToLower().Contains(w))
                {
                    return true;
                }
            }
            return false;
        }
        //checks if the searched word is an album from the list or if an album name contains the search word
        public bool lookForAlbum(string w)
        {
            l = new listAPI();
            l.getAlbList();
            foreach (albumClass item in l.albList)
            {
                if (item.AlbumName.ToLower() == w || item.AlbumName.ToLower().Contains(w))
                {
                    return true;
                }
            }
            return false;
        }
        //checks if the searched word is a song from the list or if a song name contains the search word
        public bool LookForSong(string w)
        {
            l = new listAPI();
            l.getSonList();
            foreach (songClass item in l.sonList)
            {
                if (item.SongName.ToLower() == w || item.SongName.ToLower().Contains(w))
                {
                    return true;
                }
            }
            return false;
        }
        //creates list to be displayed in the results pages if the searched word is a song
        public void searchSong(string sWord)
        {
            l = new listAPI();
            l.getArtList();
            l.getAlbList();
            l.getSonList();
            foreach (songClass item in l.sonList)
            {
                if (item.SongName.ToLower() == sWord || item.SongName.ToLower().Contains(sWord))
                {
                    //gets the infomation of the album the song came from and the artist of the song.
                    l.getArtInfo(item.ArtistID);
                    s1 = l.a1;
                    l.getAlbInfo(item.AlbumID);
                    ab1 = l.ab1;
                    foreach (albumClass i in l.albList)
                    {
                        //gests the information of the album the song is from
                        if (i.AlbumID == item.AlbumID)
                        {
                            relatedAlbList.Add(i);
                        }
                        //creates a list of other albums with the same genre 
                        else if (i.AlbumGenres == item.SongGenre)
                        {
                            recommendedAlbList.Add(i);
                        }
                    }
                    break;
                }
            }
        }
        //creates list to be displayed in the results pages if the searched word is a album
        public void searchAlbum(string sWord)
        {
            l = new listAPI();
            l.getArtList();
            l.getAlbList();
            foreach (albumClass item in l.albList)
            {
                if (item.AlbumName.ToLower() == sWord || item.AlbumName.ToLower().Contains(sWord))
                {
                    l.getArtInfo(item.ArtistID);
                    s1 = l.a1;
                    foreach (albumClass i in l.albList)
                    {
                        //gests the information of the album itself 
                        if (i.AlbumName == item.AlbumName)
                        {
                            relatedAlbList.Add(i);
                        }
                        //creates a list of other albums with the same genre
                        else if (i.AlbumGenres == item.AlbumGenres)
                        {
                            recommendedAlbList.Add(i);
                        }
                    }
                    break;
                }
            }
        }
        //creates list to be displayed in the results pages if the searched word is a album
        public void searchArtist(string sWord)
        {
            l = new listAPI();
            l.getArtList();
            l.getAlbList();
            foreach (artistClass item in l.artList)
            {
                if (item.ArtistName.ToLower() == sWord || item.ArtistName.ToLower().Contains(sWord))
                {
                    s1 = new artistClass();
                    s1 = item;
                    foreach (albumClass i in l.albList)
                    {
                        //gests the information of the albums made by the same artist 
                        if (i.ArtistID == s1.ID)
                        {
                            relatedAlbList.Add(i);
                        }
                        //creates a list of other albums with the same genre
                        else if (i.AlbumGenres == s1.ArtistMainGenres)
                        {
                            recommendedAlbList.Add(i);
                        }
                    }
                    break;
                }
            }
        }
    }
}