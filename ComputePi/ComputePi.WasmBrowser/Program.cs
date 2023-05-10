using System;
using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using System.Threading;

[assembly: SupportedOSPlatform("browser")]

Console.WriteLine("Hello, Browser!");

new Thread(SecondThread).Start();
Console.WriteLine($"Hello, Browser from the main thread {Thread.CurrentThread.ManagedThreadId}");

static void SecondThread()
{
    Console.WriteLine($"Hello from Thread {Thread.CurrentThread.ManagedThreadId}");
    for (int i = 0; i < 5; ++i)
    {
        Console.WriteLine($"Ping {i}");
        Thread.Sleep(100);
    }
}

MyClass.Print("Ready!!");

public class ThreadPiState
{
    public int Ini { get; init; }
    public int End { get; init; }
    public double Step { get; init; }
    public double Sum { get; set; }
}

public partial class MyClass
{
    public const int num_steps = 100000000;

    [JSExport]
    internal static void SerialPi()
    {
        var text = Time(_SerialPi);

        Print(text);
    }

    [JSExport]
    internal static void ThreadPi()
    {
        var text = Time(() => _ThreadPi(4));

        Print(text);
    }

    [JSImport("window.location.href", "main.js")]
    internal static partial string GetHRef();
    [JSImport("window.print", "main.js")]
    internal static partial void Print(string s);

    static internal string Time<T>(Func<T> work)
    {
        var sw = Stopwatch.StartNew();
        var result = work();
        //var r = Time(work);

        //return r.elapsed + ": " + r.result;
        return sw.Elapsed + ": " + result;
    }

    public static double _SerialPi()
    {
        double sum = 0.0;
        double step = 1.0 / (double)num_steps;

        for (int i = 0; i < num_steps; i++)
        {
            double x = (i + 0.5) * step;

            sum = sum + 4.0 / (1.0 + x * x);
        }

        return step * sum;
    }

    public static double _ThreadPi(int nthreads)
    {
        var parts = new ThreadPiState[nthreads];
        var threads = new Thread[nthreads];
        var ini = 0;
        var div = int.DivRem(num_steps, nthreads);
        var step = 1.0 / (double)num_steps;

        for (var i = 0; i < threads.Length; i++)
        {
            var end = ini + div.Quotient + div.Remainder - 1;
            var part = new ThreadPiState
            {
                Ini = ini,
                End = end,
                Step = step
            };
            var thread = new Thread(state =>
            {
                var tState = (ThreadPiState)state!;
                var sum = 0.0;

                for (int i = tState.Ini; i <= tState.End; i++)
                {
                    double x = (i + 0.5) * tState.Step;

                    sum = sum + 4.0 / (1.0 + x * x);
                }

                tState.Sum = sum;
            });

            ini = end + 1;
            div.Remainder = 0;
            parts[i] = part;
            threads[i] = thread;
            thread.Start(part);
        }

        var sum = 0.0;

        for (var i = 0; i < threads.Length; i++)
        {
            var thread = threads[i];
            var part = parts[i];

            thread.Join();
            sum += part.Sum;
        }

        return step * sum;
    }
}


