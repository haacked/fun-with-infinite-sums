using System;
using System.Collections.Generic;

namespace MathSeries
{
    public static class PartialSums
    {
        public static IEnumerable<SeriesTerm> Geometric(int n)
        {
            double sum = 0F;
            for (int i = 0; i < n; i++)
            {
                sum += 1.0F / Math.Pow(2, i);
                yield return new SeriesTerm(i, sum);
            }
        }

        public static IEnumerable<SeriesTerm> Euler(int n)
        {
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += 1.0 / Math.Pow(i, 2);
                yield return new SeriesTerm(i, sum);
            }
        }

        public static IEnumerable<SeriesTerm> Grandi(int n)
        {
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += Math.Pow(-1, i);
                yield return new SeriesTerm(i, sum);
            }
        }

        public static IEnumerable<SeriesTerm> GrandiCesaro(int n)
        {
            double sum = 0;
            double sumOfSums = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += Math.Pow(-1, i);
                sumOfSums += sum;
                yield return new SeriesTerm(i, sumOfSums / i);
            }
        }

        public static IEnumerable<SeriesTerm> Alternating(int n)
        {
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += (i % 2 == 0 ? -i : i);
                yield return new SeriesTerm(i, sum);
            }
        }

        public static IEnumerable<SeriesTerm> AlternatingCesaroPartial(int n)
        {
            double sum = 0;
            double sumOfSums = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += (i % 2 == 0 ? -i : i);
                sumOfSums += sum;
                var avg = sumOfSums / i;
                yield return new SeriesTerm(i, avg);
            }
        }
    }

    public struct SeriesTerm
    {
        private readonly double _index;
        private readonly double _value;

        public SeriesTerm(double index, double value)
        {
            _index = index;
            _value = value;
        }

        public double Index 
        {
            get { return _index; }
        }

        public double Value
        {
            get { return _value; }
        }
    }
}
