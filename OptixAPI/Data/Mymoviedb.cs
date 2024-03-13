
namespace OptixAPI.Data;

public partial class Mymoviedb
{
    public DateOnly? ReleaseDate { get; set; }

    public string? Title { get; set; }

    public string? Overview { get; set; }

    public double? Popularity { get; set; }

    public short? VoteCount { get; set; }

    public double? VoteAverage { get; set; }

    public string? OriginalLanguage { get; set; }

    public string? Genre { get; set; }

    public string? PosterUrl { get; set; }

    public int Id { get; set; }
}
