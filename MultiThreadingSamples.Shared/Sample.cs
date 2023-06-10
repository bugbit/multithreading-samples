namespace MultiThreadingSamples.Shared;

public class Sample
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required ESamplePlataform Plataform { get; set; }
    public string? JSFunction { get; set; }
}