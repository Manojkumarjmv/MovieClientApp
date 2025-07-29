using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Client.Models;

public class Movie
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required] public string Name { get; set; } = string.Empty;
    [Required] public string Genre { get; set; } = string.Empty;
    [Required] public List<string> Actors { get; set; } = new();
    public string Description { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; } = DateTime.Now;
    public string PosterUrl { get; set; } = string.Empty;
}