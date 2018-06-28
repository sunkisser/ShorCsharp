﻿using System;
using System.Numerics;

namespace ShorCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            PrimeSieve sieve = new PrimeSieve(Constants.MINFACT, Constants.MAXFACT);
            Random RNG = new Random();
            long fact1 = sieve.GetIthPrime( RNG.Next(1, sieve.primeCount) );
            long fact2 = sieve.GetIthPrime( RNG.Next(1, sieve.primeCount) );
            long r = fact1 * fact2;
            
            Console.WriteLine("fact1 = {0}", fact1);
            Console.WriteLine("fact2 = {0}", fact2);
            Console.WriteLine("r = {0}", r);

            long period = 1;
            BigInteger testroot = 0;

            while ( (period % 2 == 1) || (testroot == r-1) ) {

                long testradix = (long) (RNG.NextDouble() * r);
                Console.WriteLine("testradix = {0}", testradix);

                //period = ClassicalFindPeriod(58469529322, 75945260669);
                period = ClassicalFindPeriod(testradix, r);
                Console.WriteLine("period = {0}", period);
                testroot = BigInteger.ModPow(testradix, period / 2, r);
                Console.WriteLine("testroot = {0}", testroot);
                
                if (period % 2 == 1)
                {
                    Console.WriteLine("Result:  Period is odd ... Redo");
                }
                if (testroot == r-1)
                {
                    Console.WriteLine("Result:  radix^(period/2) mod R is congruent to r-1 ... Redo");
                }
                            
            }
           
            Console.WriteLine("Result:  Square Root Found.");

            long foundfact1 = (long) BigInteger.GreatestCommonDivisor(testroot - 1, r);
            long foundfact2 = (long) BigInteger.GreatestCommonDivisor(testroot + 1, r);

            Console.WriteLine(" {0} x {1} = {2}", foundfact1, foundfact2, r);
            Console.ReadKey();

        }

        static long ClassicalFindPeriod ( long radix, long modulus )
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
            Console.WriteLine("elapsed time = {0} seconds", watch.ElapsedMilliseconds / 1000);

            return period;
        }

    }

  
}
