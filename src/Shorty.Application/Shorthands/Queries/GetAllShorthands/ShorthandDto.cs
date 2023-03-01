namespace Shorty.Application.Shorthands.Queries.GetAllShorthands;

public class ShorthandDto
{
    public string? Id { get; set; }

    public string? Destination { get; set; }

    public DateTime DateAdded { get; set; } = DateTime.MinValue;

    public DateTime? ExpirationDate { get; set; }
}
