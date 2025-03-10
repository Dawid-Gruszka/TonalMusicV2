using System.Text.Json.Serialization;

namespace TonalMusicV2.Models
{
    public class Artist
    {
        public string Name { get; set; }
        public string Mbid { get; set; }
        public string ArtistBackground { get; set; }

        [JsonPropertyName("artist_logo")]
        public string ArtistLogo { get; set; }

        [JsonPropertyName("artist_thumbnail")]
        public string ArtistThumbnail { get; set; }

        [JsonPropertyName("artist_banner")]
        public string ArtistBanner { get; set; }
        public int Id { get; set; }

        public Album[] Albums { get; set; }
    }
}
