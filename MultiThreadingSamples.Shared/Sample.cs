namespace MultiThreadingSamples.Shared;

public class Sample
{
    public const int IdComputePi = 1;

    public required int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required ESamplePlataform Plataform { get; set; }
    public string? JSFunction { get; set; }
}