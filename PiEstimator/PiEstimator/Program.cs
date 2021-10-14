using System;

namespace PiEstimator
{
    class Program
    {
        static void Main(string[] args)
        {
            long n;
            
            Console.WriteLine("Pi Estimator");
            Console.WriteLine("================================================");

            n = GetNumber("Enter number of iterations (n): ");

            double pi = EstimatePi(n);
            double diff = Math.Abs(pi - Math.PI);

            Console.WriteLine();
            Console.WriteLine($"Pi (estimate): {pi}, Pi (system): {Math.PI}, Difference: {diff}");
        }

        static double EstimatePi(long n)
        {
            Random rand = new Random(System.Environment.TickCount);
            double pi = 0.0;
            double hits = 0.0; // Hits is the number of points that are within the circle

            for (int i = 0; i < n; i++)
            {
                Point point = new Point() // Initialize a new point
                {
                    x = rand.NextDouble(),
                    y = rand.NextDouble()
                };

                if (Math.Pow(point.x, 2) + Math.Pow(point.y, 2) <= 1) hits++;
                // If the point is within the circle, increase hits
            }

            pi = 4 * (hits / n); // Complete the mathematical equation to solve for pi

            return pi;
        }

        static long GetNumber(string prompt)
        {
            long output;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (Int64.TryParse(input, out output))
                {
                    return output;
                }
            }
        }
    }

    class Point
    {
        public double x { get; set; }
        public double y { get; set; }
    }
}