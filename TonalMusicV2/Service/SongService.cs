using TonalMusic.Models;
using TonalMusicV2.Rest;

namespace TonalMusicV2.Service
{
    public class SongService(RestClient restClient) : IService<Song>
    {
        public async Task<List<Song>> GetAll() => await restClient.GetSongs();

        public async Task<Song> GetById(int id) => await restClient.GetSongById(id);
    }
}
