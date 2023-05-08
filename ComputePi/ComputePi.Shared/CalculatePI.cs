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

        //public async static Task< double> ThreadPi(int nthreads)
        //{
        //    Thread t;

        //    t.Join()
        //}
    }
}