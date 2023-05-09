using System.Diagnostics;

namespace ComputePi.Shared
{
    public static class CalculatePI
    {
        const int num_steps = 100000000;

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
            var parts = CalcThreadPiParts(0, num_steps, 4).Select(part => new ThreadPiState
            {
                Ini = part.ini,
                End = part.end,
                Step = part.step
            }).ToArray();
            var threads = new Thread[nthreads];

            for (var i = 0; i < threads.Length; i++)
            {
                var part = parts[i];
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

            return sum;
        }

        private static (int ini, int end, double step)[] CalcThreadPiParts(int i, int nsteps, int nparts)
        {
            var step = 1.0 / (double)nsteps;
            var parts = new List<(int ini, int end, double step)>();
            var stack = new Stack<(int ini, int end, double step)>();

            stack.Push((i, nsteps, step));

            while (stack.Count > 0)
            {
                var p = stack.Pop();

                if (nparts - 1 > stack.Count && nparts >= 2)
                {
                    var _nsteps = (p.end - p.ini + 1);
                    var middle = _nsteps / 2;

                    stack.Push((p.ini, p.ini + middle - 1, step));
                    stack.Push((p.ini + middle, p.end, step));
                }
                else
                {
                    parts.Add(p);
                    nparts--;
                }
            }

            return parts.ToArray();
        }
    }
}