using System;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = 80000; // number of random numbers to generate
        double[] numbers = GenerateRandomDoubles(n);
        double[] squaresDirect = new double[n];
        double[] squaresMathPow = new double[n];
        double[] squareRootsMathSqrt = new double[n];
        Stopwatch timer = new Stopwatch();

        // Measure the time for direct multiplication
        timer.Start();
        SquareNumbersDirect(numbers, squaresDirect);
        timer.Stop();
        double directTime = timer.Elapsed.TotalMilliseconds;

        // Measure the time for using Math.Pow
        timer.Restart();
        SquareNumbersMathPow(numbers, squaresMathPow);
        timer.Stop();
        double mathPowTime = timer.Elapsed.TotalMilliseconds;

        // Measure the time for using Math.Sqrt
        timer.Restart();
        SquareRootsMathSqrt(numbers, squareRootsMathSqrt);
        timer.Stop();
        double sqrtTime = timer.Elapsed.TotalMilliseconds;

        Console.WriteLine("Direct Multiplication took " + directTime + " ms");
        Console.WriteLine("Math.Pow took " + mathPowTime + " ms");
        Console.WriteLine("Math.Sqrt took " + sqrtTime + " ms");

        if (directTime < mathPowTime && directTime < sqrtTime)
        {
            Console.WriteLine("Direct multiplication is faster.");
        }
        else if (mathPowTime < directTime && mathPowTime < sqrtTime)
        {
            Console.WriteLine("Math.Pow is faster.");
        }
        else
        {
            Console.WriteLine("Math.Sqrt is faster.");
        }
    }

    static double[] GenerateRandomDoubles(int count)
    {
        Random rand = new Random();
        double[] numbers = new double[count];
        for (int i = 0; i < count; ++i)
        {
            numbers[i] = 100.0 * rand.NextDouble();
        }
        return numbers;
    }

    static void SquareNumbersDirect(double[] nums, double[] squares)
    {
        for (int i = 0; i < nums.Length; ++i)
        {
            squares[i] = nums[i] * nums[i];
        }
    }

    static void SquareNumbersMathPow(double[] nums, double[] squares)
    {
        for (int i = 0; i < nums.Length; ++i)
        {
            squares[i] = Math.Pow(nums[i], 2);
        }
    }

    static void SquareRootsMathSqrt(double[] nums, double[] squares)
    {
        for (int i = 0; i < nums.Length; ++i)
        {
            squares[i] = Math.Sqrt(nums[i]);
        }
    }
}
