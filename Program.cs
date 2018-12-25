using System;
using System.Numerics;

namespace ShorCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeSieve sieve = new PrimeSieve(Constants.MINFACT, Constants.MAXFACT);

            Random RNG = new Random();
            long fact1 = sieve.GetIthPrime(RNG.Next(1, sieve.primeCount));
            long fact2 = sieve.GetIthPrime(RNG.Next(1, sieve.primeCount));
            long r = fact1 * fact2;
            Console.WriteLine("fact1 = {0}  fact2 = {1}  r = {2}", fact1, fact2, r);

            long period = 1;
            BigInteger testroot = 0;
            while ( period % 2 == 1 || testroot == r - 1) 
            {
                long testradix = (long)(RNG.NextDouble() * r);
                period = ClassicalFindPeriod(testradix, r);
                testroot = BigInteger.ModPow(testradix, period / 2, r);
            }

            long foundfact1 = (long)BigInteger.GreatestCommonDivisor(testroot - 1, r);
            long foundfact2 = (long)BigInteger.GreatestCommonDivisor(testroot + 1, r);
            Console.WriteLine("Factoring complete: {0} x {1} = {2}", foundfact1, foundfact2, r);
            Console.ReadKey();
        }

        static long ClassicalFindPeriod(long radix, long modulus)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            long period = 1;
            Decimal t = radix;
            while (t != 1)
            {
                t *= radix;
                t %= modulus;
                period++;
            }
            watch.Stop();
            Console.WriteLine("Elapsed Time = {0} seconds", watch.ElapsedMilliseconds / 1000);

            return period;
        }
    }
}
