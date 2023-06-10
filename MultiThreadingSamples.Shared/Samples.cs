namespace MultiThreadingSamples.Shared;

public static class Samples
{
    public static readonly Sample[] Instance = new[]
    {
        new Sample{ Id=Sample.IdComputePi,Name="ComputePi", Plataform=ESamplePlataform.Console|ESamplePlataform.Wasm,JSFunction="OnClickComputePi"  }
    };
}
