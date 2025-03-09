using System.Net.Http.Json;
using System.Text.Json;
using TonalMusic.Models;
using TonalMusicV2.Models;

namespace TonalMusicV2.Rest
{
    public class RestClient
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        readonly String URI = "http://192.168.1.147:8080";

        public List<Album> Albums { get; set; }
        public List<Artist> Artists { get; set; }

        public RestClient()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                WriteIndented = true
            };
        }

        public async Task<Album> GetAlbumById(int albumId) => await _client.GetFromJsonAsync<Album>($"{URI}/albums/{albumId}");

        public async Task<List<Album>> GetAlbums() => await _client.GetFromJsonAsync<List<Album>>($"{URI}/albums");

        public async Task<Artist> GetArtistById(int artistId) => await _client.GetFromJsonAsync<Artist>($"{URI}/artists/{artistId}");

        public async Task<List<Artist>> GetArtists() => await _client.GetFromJsonAsync<List<Artist>>($"{URI}/artists");

        public async Task<List<Song>> GetSongs() => await _client.GetFromJsonAsync<List<Song>>($"{URI}/songs");

        public async Task<Song> GetSongById(int songId) => await _client.GetFromJsonAsync<Song>($"{URI}/songs/{songId}");
    }

}
