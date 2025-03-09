using CommunityToolkit.Mvvm.ComponentModel;
using TonalMusic.Models;
using TonalMusicV2.Service;

namespace TonalMusicV2.PageModels
{
    [QueryProperty(nameof(SongId), "id")]
    public partial class SongPageModel : ObservableObject
    {
        private readonly SongService _songService;

        private int lastId = -1;

        [ObservableProperty]
        private int _songId;

        [ObservableProperty]
        private Song _songs;

        partial void OnSongIdChanged(int value)
        {
            if (lastId == -1 || value != lastId)
            {
                _ = LoadSongAsync(value);
                lastId = value;
            }
            
        }

        public SongPageModel(SongService songService)
        {
            _songService = songService;
            LoadSongAsync(SongId);
        }

        private async Task LoadSongAsync(int id)
        {
            try
            {
                var cancion = await _songService.GetById(id);
                Songs = cancion;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading artist: {ex.Message}");
            }
        }
    }
}

