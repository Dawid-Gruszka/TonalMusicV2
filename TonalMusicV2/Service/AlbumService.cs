using TonalMusicV2.Rest;
using TonalMusicV2.Models;

namespace TonalMusicV2.Service
{
    public class AlbumService(RestClient restClient) : IService<Album>
    {
        public async Task<List<Album>> GetAll() => await restClient.GetAlbums();

        public async Task<Album> GetById(int id) => await restClient.GetAlbumById(id);
    }
}
