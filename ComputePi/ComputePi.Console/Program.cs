// See https://aka.ms/new-console-template for more information
using ComputePi.Shared;
using System.Threading;

var exit = false;

do
{
    var opMenu = Menu();

    switch (opMenu)
    {
        case "1":
            Time(CalculatePI.SerialPi);
            break;
        case "2":
            Time(() => CalculatePI.ThreadPi(4));
            break;
        case "0":
            exit = true;
            break;
    }
} while (!exit);

string Menu()
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. SerialPi");
    Console.WriteLine("2. ThreadPi");
    Console.WriteLine("0. Exit");

    return Console.ReadLine();
}

void Time<T>(Func<T> work)
{
    var r = CalculatePI.Time(work);

    Console.WriteLine(r.elapsed + ": " + r.result);
}