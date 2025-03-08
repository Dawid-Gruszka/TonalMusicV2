using CommunityToolkit.Mvvm.ComponentModel;
using TonalMusicV2.Models;
using TonalMusicV2.Service;

namespace TonalMusicV2.PageModels
{
    [QueryProperty(nameof(ArtistId), "id")]
    public partial class ArtistPageModel : ObservableObject
    {
        [ObservableProperty]
        private int artistId;

        partial void OnArtistIdChanged(int value)
        {
            _ = LoadArtistAsync(value);
        }

        [ObservableProperty]
        private Artist _artista;

        private readonly ArtistService _artistService;

        public ArtistPageModel(ArtistService artistService)
        {
            _artistService = artistService;
        }

        private async Task LoadArtistAsync(int id)
        {
            try
            {
                var artist = await _artistService.GetById(id);
                Artista = artist;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading artist: {ex.Message}");
            }
        }
    }
}