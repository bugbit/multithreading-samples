// See https://aka.ms/new-console-template for more information
using ComputePi.Shared;

Time(CalculatePI.SerialPi);

void Time<T>(Func<T> work)
{
    var r = CalculatePI.Time(work);

    Console.WriteLine(r.elapsed + ": " + r.result);
}