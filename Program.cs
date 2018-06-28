using System;
using System.Numerics;

namespace ShorCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var watch = System.Diagnostics.Stopwatch.StartNew();

            PrimeSieve sieve = new PrimeSieve(Constants.MINFACT, Constants.MAXFACT);
            Random RNG = new Random();
            long fact1 = sieve.GetIthPrime( RNG.Next(1, sieve.primeCount) );
            long fact2 = sieve.GetIthPrime( RNG.Next(1, sieve.primeCount) );
            long R = fact1 * fact2;

            watch.Stop();
            Console.WriteLine("time in ms = {0}", watch.ElapsedMilliseconds);
            Console.WriteLine("fact1 = {0}", fact1);
            Console.WriteLine("fact2 = {0}", fact2);
            Console.WriteLine("R = {0}", R);
            Console.ReadKey();

        }
    }

  
}
