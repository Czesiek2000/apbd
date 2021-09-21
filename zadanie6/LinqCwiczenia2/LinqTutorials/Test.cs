using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqTutorials.Models;

namespace LinqTutorials
{
    class Test
    {
        private static IEnumerable<Album> albums = new List<Album>()
        {
            new Album()
            {
                IdAlbum = 1,
                IdTrack = 1,
                Name = "Test 1",
                Author = "John doe"
            },
            new Album()
            {
                IdAlbum = 2,
                IdTrack = 2,
                Name = "Test 2",
                Author = "Jane doe"
            }
        };
        private static IEnumerable<Track> tracks = new List<Track>()
        {
            new Track()
            {
                IdTrack = 1,
                PublishDate = DateTime.Now,
                TrackName = "Test track"
            },
            
            new Track()
            {
                IdTrack = 2,
                PublishDate = DateTime.Now,
                TrackName = "Test track 2"
            },
        };
        static void Main(string[] args)
        {
            var result = (from a in albums join t in tracks on a.IdTrack equals t.IdTrack where a.IdTrack == 1 select new {a, t}).ToList();
        }
    }
}
