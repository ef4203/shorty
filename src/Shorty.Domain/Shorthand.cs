namespace Shorty.Domain;

using System.ComponentModel.DataAnnotations;

public class Shorthand
{
#pragma warning disable CA1056
    [Key]
    public string? Url { get; set; }
#pragma warning restore CA1056

    public string? Destination { get; set; }

    public DateTime? DateAdded { get; set; }
}
