namespace TonalMusic.Models
{
    public class Song
    {
            public string Title { get; set; }
            public string? Publisher { get; set; }
            public int? Year { get; set; }
            public int? TrackNum { get; set; }
            public string File { get; set; }
            public int? AlbumId { get; set; }
            public int? GenreId { get; set; }
            public int Id { get; set; }
    }
}
