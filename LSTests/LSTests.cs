using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LSTests
{
    public class Counter
    {
        private int maxCounter = 0;
        private int sequenceCounter1 = 0;
        private int sequenceCounter2 = 0;
        private int p;

        public Counter(int p) { this.p = p; }

        private bool Counting(int i) { return i == p; }

        private void Switch() { Switched = true; }

        private bool Switched { get; set; }
        private bool NotSwitched { get { return !Switched; } }

        private void SwapCounters()
        {
            maxCounter = Math.Max(maxCounter, sequenceCounter1);
            sequenceCounter1 = sequenceCounter2;
            sequenceCounter2 = 0;
        }

        public void Count(int i)
        {
            var counting = Counting(i);
            var notCounting = !counting;

            if (counting || notCounting && NotSwitched)
            {
                sequenceCounter1++;
            }

            if (counting && Switched || notCounting && Switched)
            {
                sequenceCounter2++;
            }

            if (notCounting && Switched)
            {
                SwapCounters();
            }

            if (notCounting && NotSwitched)
            {
                Switch();
            }
        }

        public int Check() { return Math.Max(maxCounter, (NotSwitched) ? sequenceCounter1 - 1 : sequenceCounter1); }
    }


    public class Ls
    {
        public static int Find(int[] sequence)
        {
            return sequence.Aggregate(
                Tuple.Create(new Counter(1), new Counter(0)),
                (t, i) =>
                {
                    t.Item1.Count(i); t.Item2.Count(i);
                    return t;
                },
                t => Math.Max(t.Item1.Check(), t.Item2.Check())
            );
        }
    }


    public class LTTests
    {
        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { 7, new[] { 1, 1, 1, 1, 1, 1, 1, 1 } };
            yield return new object[] { 8, new[] { 0, 1, 1, 1, 1, 1, 1, 1 } };
            yield return new object[] { 8, new[] { 1, 0, 1, 1, 1, 1, 1, 1 } };
            yield return new object[] { 8, new[] { 1, 1, 0, 1, 1, 1, 1, 1 } };
            yield return new object[] { 8, new[] { 1, 1, 1, 0, 1, 1, 1, 1 } };
            yield return new object[] { 8, new[] { 1, 1, 1, 1, 0, 1, 1, 1 } };
            yield return new object[] { 8, new[] { 1, 1, 1, 1, 1, 0, 1, 1 } };
            yield return new object[] { 8, new[] { 1, 1, 1, 1, 1, 1, 0, 1 } };
            yield return new object[] { 8, new[] { 1, 1, 1, 1, 1, 1, 1, 0 } };
            yield return new object[] { 7, new[] { 0, 0, 1, 1, 1, 1, 1, 1 } };
            yield return new object[] { 6, new[] { 1, 0, 0, 1, 1, 1, 1, 1 } };
            yield return new object[] { 5, new[] { 1, 1, 0, 0, 1, 1, 1, 1 } };
            yield return new object[] { 4, new[] { 1, 1, 1, 0, 0, 1, 1, 1 } };
            yield return new object[] { 5, new[] { 1, 1, 1, 1, 0, 0, 1, 1 } };
            yield return new object[] { 6, new[] { 1, 1, 1, 1, 1, 0, 0, 1 } };
            yield return new object[] { 7, new[] { 1, 1, 1, 1, 1, 1, 0, 0 } };
            yield return new object[] { 6, new[] { 0, 0, 0, 1, 1, 1, 1, 1 } };
            yield return new object[] { 5, new[] { 1, 0, 0, 0, 1, 1, 1, 1 } };
            yield return new object[] { 4, new[] { 1, 1, 0, 0, 0, 1, 1, 1 } };
            yield return new object[] { 4, new[] { 1, 1, 1, 0, 0, 0, 1, 1 } };
            yield return new object[] { 5, new[] { 1, 1, 1, 1, 0, 0, 0, 1 } };
            yield return new object[] { 6, new[] { 1, 1, 1, 1, 1, 0, 0, 0 } };
            yield return new object[] { 5, new[] { 0, 0, 0, 0, 1, 1, 1, 1 } };
            yield return new object[] { 5, new[] { 1, 0, 0, 0, 0, 1, 1, 1 } };
            yield return new object[] { 5, new[] { 1, 1, 0, 0, 0, 0, 1, 1 } };
            yield return new object[] { 5, new[] { 1, 1, 1, 0, 0, 0, 0, 1 } };
            yield return new object[] { 5, new[] { 1, 1, 1, 1, 0, 0, 0, 0 } };
            yield return new object[] { 7, new[] { 0, 1, 1, 1, 1, 1, 1, 0 } };
            yield return new object[] { 6, new[] { 1, 0, 1, 1, 1, 1, 0, 1 } };
            yield return new object[] { 5, new[] { 1, 1, 0, 1, 1, 0, 1, 1 } };
            yield return new object[] { 5, new[] { 0, 0, 1, 1, 1, 1, 0, 0 } };
            yield return new object[] { 3, new[] { 1, 0, 0, 1, 1, 0, 0, 1 } };
            yield return new object[] { 6, new[] { 0, 0, 1, 1, 1, 1, 0, 1 } };
            yield return new object[] { 5, new[] { 0, 1, 0, 1, 1, 0, 1, 1 } };
            yield return new object[] { 3, new[] { 1, 0, 1, 0, 1, 0, 1, 0 } };
            yield return new object[] { 3, new[] { 0, 1, 0, 1, 0, 1, 0, 1 } };
            yield return new object[] { 7, new[] { 0, 0, 0, 0, 0, 0, 0, 0 } };
            yield return new object[] { 6, new[] { 1, 0, 1, 1, 0, 1, 1, 1 } };
            yield return new object[] { 4, new[] { 1, 1, 0, 1, 0, 0 } };
            yield return new object[] { 5, new[] { 1, 1, 1, 1, 1, 1 } };
            yield return new object[] { 5, new[] { 0, 0, 0, 0, 0, 0 } };
            yield return new object[] { 4, new[] { 1, 1, 1, 0, 0, 0 } };
            yield return new object[] { 3, new[] { 1, 1, 0, 0, 1, 1 } };
            yield return new object[] { 3, new[] { 0, 0, 1, 1, 0, 0 } };
            yield return new object[] { 5, new[] { 1, 1, 0, 0, 0, 0 } };
            yield return new object[] { 5, new[] { 0, 0, 0, 0, 1, 1 } };
            yield return new object[] { 3, new[] { 1, 0, 1, 0, 1, 0 } };
            yield return new object[] { 3, new[] { 0, 1, 0, 1, 0, 1 } };
            yield return new object[] { 1, new[] { 1 } };
            yield return new object[] { 2, new[] { 0, 1 } };
            yield return new object[] { 1, new[] { 1, 1 } };
            yield return new object[] { 3, new[] { 1, 1, 0 } };
            yield return new object[] { 3, new[] { 0, 1, 1, 0 } };
            yield return new object[] { 2, new[] { 1, 1, 1 } };
            yield return new object[] { 10, new[] { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 } };
            yield return new object[] { 10, new[] { 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 } };
            //            yield return new object[] { };
        }

        [Theory]
        [MemberData("Data")]
        public void Check(int expected, int[] array)
        {
            Assert.Equal(expected, Ls.Find(array));

            var r = new Random();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(r.Next(0, 1));
            }

        }
    }
}
