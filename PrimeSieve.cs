using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShorCsharp
{
    class PrimeSieve
    {
        private bool[] isPrime;
        public int primeCount;

        public PrimeSieve(long minprime, long maxprime)
        {
            isPrime = new bool[maxprime];
            this.PerformSieve();
            this.SetAllSmallPrimesAsFalse(minprime);
            primeCount = isPrime.Count(c => c == true);
        }

        public long GetIthPrime(long index) {

            long ithPrime = 0;

            for (long j = 0; j < index; j++)
            {
                while (!isPrime[++ithPrime])
                {
                }
            }

            return ithPrime;
        }
        
        private void PerformSieve()
        {
            this.InitializeArrayToAllTrue();
            isPrime[0] = false;  //Zero is not prime
            isPrime[1] = false;  //One is not prime
            for (long i = 2; i < Math.Sqrt(isPrime.Length); i++)
            {
                if (isPrime[i])
                {
                    this.SetAllMultiplesAsFalse(i);
                }
            }
        }

        private void InitializeArrayToAllTrue()
        {
            for (long i = 0; i < isPrime.Length; i++)
            {
                isPrime[i] = true;
            }
        }

        private void SetAllMultiplesAsFalse(long prime)
        {
            for (long i = 2 * prime; i < isPrime.Length; i += prime)
            {
                isPrime[i] = false;
            }
        }

        private void SetAllSmallPrimesAsFalse(long minprime)
        {
            for (long i = 0; i < minprime; i++)
            {
                isPrime[i] = false;
            }
        }
    }

}
