using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicWebSite.backend
{
    class searchClass
    {
        public List<albumClass> relatedAlbList = new List<albumClass>();
        public List<albumClass> recommendedAlbList = new List<albumClass>();
        public artistClass s1 = new artistClass();
        public albumClass ab1 = new albumClass();
        listAPI l;

        public string cleanWord(string s)
        {
            s = s.ToLower();
            return s.Trim();
        }
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
                    l.getArtInfo(item.ArtistID);
                    s1 = l.a1;
                    l.getAlbInfo(item.AlbumID);
                    ab1 = l.ab1;
                    foreach (albumClass i in l.albList)
                    {
                        if (i.AlbumID == item.AlbumID)
                        {
                            relatedAlbList.Add(i);
                        }
                        else if (i.AlbumGenres == item.SongGenre)
                        {
                            recommendedAlbList.Add(i);
                        }
                    }
                    break;
                }
            }
        }
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
                        if (i.AlbumName == item.AlbumName)
                        {
                            relatedAlbList.Add(i);
                        }
                        else if (i.AlbumGenres == item.AlbumGenres)
                        {
                            recommendedAlbList.Add(i);
                        }
                    }
                    break;
                }
            }
        }
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
                        if (i.ArtistID == s1.ID)
                        {
                            relatedAlbList.Add(i);
                        }
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