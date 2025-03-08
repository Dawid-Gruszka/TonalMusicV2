using CommunityToolkit.Mvvm.ComponentModel;
using TonalMusicV2.Models;
using TonalMusicV2.Service;

namespace TonalMusicV2.PageModels
{
    [QueryProperty(nameof(AlbumId), "id")]
    public partial class AlbumPageModel : ObservableObject
    {

        private readonly AlbumService _albumService;

        public AlbumPageModel(AlbumService albumService)
        {
            _albumService = albumService;
        }

        [ObservableProperty]
        private int albumId;


        [ObservableProperty]
        private Album album;

        partial void OnAlbumIdChanged(int value)
        {
            _ = LoadAlbumAsync(value);
        }

        private async Task LoadAlbumAsync(int id)
        {
                var album = await _albumService.GetById(id);
                if (album != null)
                {
                    Album = album;
                }
        }
    }
}