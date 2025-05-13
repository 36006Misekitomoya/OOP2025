using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    public class Song {
        public string Title { get; set; }
        public string ArtistName { get; set; }
        public int Length { get; set; }

        public Song(string Title, string ArtistName, int Length) {
            this.Title = Title;
            this.ArtistName = ArtistName;
            this.Length = Length;
        }
    }
}
