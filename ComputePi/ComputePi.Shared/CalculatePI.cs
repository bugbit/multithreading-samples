using System.Diagnostics;

namespace ComputePi.Shared
{
    public static class CalculatePI
    {
        public const int num_steps = 100000000;

        public static (TimeSpan elapsed, T result) Time<T>(Func<T> work)
        {
            var sw = Stopwatch.StartNew();
            var result = work();

            return (sw.Elapsed, result);
        }

        public static double SerialPi()
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

        public static double ThreadPi(int nthreads)
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
}