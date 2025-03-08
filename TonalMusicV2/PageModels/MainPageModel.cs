using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TonalMusic.Models;
using TonalMusicV2.Models;
using TonalMusicV2.Service;

namespace TonalMusicV2.PageModels
{
    public partial class MainPageModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Artist> _artist;

        [ObservableProperty]
        public ObservableCollection<Album> _album;

        [ObservableProperty]
        public ObservableCollection<Song> _songs;

        private readonly ArtistService _artistService;
        private readonly AlbumService _albumService;
        private readonly SongService _songService;

        public MainPageModel(ArtistService artistService, AlbumService albumService, SongService songService)
        {
            _artistService = artistService ?? throw new ArgumentNullException(nameof(artistService));
            _albumService = albumService;
            _songService = songService;
            LoadArtistsAsync();
            LoadAlbumAsync();
            LoadSongsAsync();
        }

        private async void LoadSongsAsync()
        {
            var songList = await _songService.GetAll();
            Songs = new ObservableCollection<Song>(songList);
        }

        private async void LoadArtistsAsync()
        {
            try
            {
                var artistList = await _artistService.GetAll();
                Artist = new ObservableCollection<Artist>(artistList);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al cargar las canciones: {ex.Message}");
            }
        }

        private async void LoadAlbumAsync()
        {
            var albumList = await _albumService.GetAll();
            Album = new ObservableCollection<Album>(albumList);
        }

        [RelayCommand]
        public async Task ClickArtist(Artist artist)
        {
            await NavigateToAsync($"///ArtistPage?id={artist.Id}");
        }

        [RelayCommand]
        public async Task ClickAlbum(Album album)
        {
            await NavigateToAsync($"///AlbumPage?id={album.Id}");
        }

        [RelayCommand]
        public async Task ClickSong(Song song)
        {
            await NavigateToAsync($"///SongPage?id={song.Id}");
        }

        private async Task NavigateToAsync(string url)
        {
            await Shell.Current.GoToAsync(url);
        }
    }
}
