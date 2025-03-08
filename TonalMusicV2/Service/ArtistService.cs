using TonalMusicV2.Models;
using TonalMusicV2.Rest;
using TonalMusicV2.Service;

namespace TonalMusicV2.Service
{
    public class ArtistService(RestClient restClient) : IService<Artist>
    {
        public async Task<List<Artist>> GetAll() => await restClient.GetArtists();

        public async Task<Artist> GetById(int id) => await restClient.GetArtistById(id);
    }
}
