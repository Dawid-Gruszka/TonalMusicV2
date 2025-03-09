namespace TonalMusicV2.Models
{
    public class Artist
    {
        public string Name { get; set; }
        public string Mbid { get; set; }
        public string ArtistBackground { get; set; }
        public string ArtistLogo { get; set; }
        public string ArtistThumbnail { get; set; }
        public string ArtistBanner { get; set; }
        public int Id { get; set; }

        public Album[] Albums { get; set; }
    }
}
