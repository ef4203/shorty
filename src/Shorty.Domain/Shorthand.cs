namespace Shorty.Domain;

using System.ComponentModel.DataAnnotations;

public class Shorthand
{
    [Key] public string? Url { get; set; }

    public string? Destination { get; set; }

    public DateTime? DateAdded { get; set; }
}
