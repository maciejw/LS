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
        private bool switched = false;
        private int p;

        public Counter(int p)
        {
            this.p = p;
        }

        public void Count(int i)
        {

            var counted = i == p;
            var notCounted = !counted;
            var notSwitched = !switched;

            if (counted || notCounted)
            {
                sequenceCounter1++;
                if (switched) sequenceCounter2++;                    
            }
            else
            {
                if (!switched)
                {
                    sequenceCounter1++;
                    Switch();
                }
                else
                {
                    sequenceCounter2++;
                    SwapCounters();
                }
            }
        }

        private void SwapCounters()
        {
            maxCounter = Math.Max(maxCounter, sequenceCounter1);
            sequenceCounter1 = sequenceCounter2;
            sequenceCounter2 = 0;
        }

        private void Switch()
        {
            switched = true;
        }

        public int Check()
        {
            int seq = sequenceCounter1;
            if (!switched)
            {
                seq--;
            }

            return Math.Max(maxCounter, seq);
        }
    }


    public class Ls
    {


        public static int Find(int[] sequence)
        {
            var oneCounter = new Counter(1);
            var zeroCounter = new Counter(0);

            foreach (var i in sequence)
            {
                oneCounter.Count(i);
                zeroCounter.Count(i);
            }
            return Math.Max(oneCounter.Check(), zeroCounter.Check());
        }
    }


    public class Class1
    {
        [Fact]
        public void MyTestMethod()
        {
            Assert.Equal(7, Ls.Find(new[] { 1, 1, 1, 1, 1, 1, 1, 1 }));

            Assert.Equal(8, Ls.Find(new[] { 0, 1, 1, 1, 1, 1, 1, 1 }));
            Assert.Equal(8, Ls.Find(new[] { 1, 0, 1, 1, 1, 1, 1, 1 }));
            Assert.Equal(8, Ls.Find(new[] { 1, 1, 0, 1, 1, 1, 1, 1 }));
            Assert.Equal(8, Ls.Find(new[] { 1, 1, 1, 0, 1, 1, 1, 1 }));
            Assert.Equal(8, Ls.Find(new[] { 1, 1, 1, 1, 0, 1, 1, 1 }));
            Assert.Equal(8, Ls.Find(new[] { 1, 1, 1, 1, 1, 0, 1, 1 }));
            Assert.Equal(8, Ls.Find(new[] { 1, 1, 1, 1, 1, 1, 0, 1 }));
            Assert.Equal(8, Ls.Find(new[] { 1, 1, 1, 1, 1, 1, 1, 0 }));

            Assert.Equal(7, Ls.Find(new[] { 0, 0, 1, 1, 1, 1, 1, 1 }));
            Assert.Equal(6, Ls.Find(new[] { 1, 0, 0, 1, 1, 1, 1, 1 }));
            Assert.Equal(5, Ls.Find(new[] { 1, 1, 0, 0, 1, 1, 1, 1 }));
            Assert.Equal(4, Ls.Find(new[] { 1, 1, 1, 0, 0, 1, 1, 1 }));
            Assert.Equal(5, Ls.Find(new[] { 1, 1, 1, 1, 0, 0, 1, 1 }));
            Assert.Equal(6, Ls.Find(new[] { 1, 1, 1, 1, 1, 0, 0, 1 }));
            Assert.Equal(7, Ls.Find(new[] { 1, 1, 1, 1, 1, 1, 0, 0 }));

            Assert.Equal(6, Ls.Find(new[] { 0, 0, 0, 1, 1, 1, 1, 1 }));
            Assert.Equal(5, Ls.Find(new[] { 1, 0, 0, 0, 1, 1, 1, 1 }));
            Assert.Equal(4, Ls.Find(new[] { 1, 1, 0, 0, 0, 1, 1, 1 }));
            Assert.Equal(4, Ls.Find(new[] { 1, 1, 1, 0, 0, 0, 1, 1 }));
            Assert.Equal(5, Ls.Find(new[] { 1, 1, 1, 1, 0, 0, 0, 1 }));
            Assert.Equal(6, Ls.Find(new[] { 1, 1, 1, 1, 1, 0, 0, 0 }));

            Assert.Equal(5, Ls.Find(new[] { 0, 0, 0, 0, 1, 1, 1, 1 }));
            Assert.Equal(5, Ls.Find(new[] { 1, 0, 0, 0, 0, 1, 1, 1 }));
            Assert.Equal(5, Ls.Find(new[] { 1, 1, 0, 0, 0, 0, 1, 1 }));
            Assert.Equal(5, Ls.Find(new[] { 1, 1, 1, 0, 0, 0, 0, 1 }));
            Assert.Equal(5, Ls.Find(new[] { 1, 1, 1, 1, 0, 0, 0, 0 }));

            Assert.Equal(7, Ls.Find(new[] { 0, 1, 1, 1, 1, 1, 1, 0 }));
            Assert.Equal(6, Ls.Find(new[] { 1, 0, 1, 1, 1, 1, 0, 1 }));
            Assert.Equal(5, Ls.Find(new[] { 1, 1, 0, 1, 1, 0, 1, 1 }));

            Assert.Equal(5, Ls.Find(new[] { 0, 0, 1, 1, 1, 1, 0, 0 }));
            Assert.Equal(3, Ls.Find(new[] { 1, 0, 0, 1, 1, 0, 0, 1 }));


            Assert.Equal(6, Ls.Find(new[] { 0, 0, 1, 1, 1, 1, 0, 1 }));
            Assert.Equal(5, Ls.Find(new[] { 0, 1, 0, 1, 1, 0, 1, 1 }));

            Assert.Equal(3, Ls.Find(new[] { 1, 0, 1, 0, 1, 0, 1, 0 }));
            Assert.Equal(3, Ls.Find(new[] { 0, 1, 0, 1, 0, 1, 0, 1 }));

            Assert.Equal(7, Ls.Find(new[] { 0, 0, 0, 0, 0, 0, 0, 0 }));

            Assert.Equal(6, Ls.Find(new[] { 1, 0, 0, 1, 1, 1, 1, 1 }));
            Assert.Equal(6, Ls.Find(new[] { 1, 0, 1, 1, 0, 1, 1, 1 }));

            Assert.Equal(4, Ls.Find(new[] { 1, 1, 0, 1, 0, 0 }));
            Assert.Equal(5, Ls.Find(new[] { 1, 1, 1, 1, 1, 1 }));
            Assert.Equal(5, Ls.Find(new[] { 0, 0, 0, 0, 0, 0 }));
            Assert.Equal(4, Ls.Find(new[] { 1, 1, 1, 0, 0, 0 }));
            Assert.Equal(3, Ls.Find(new[] { 1, 1, 0, 0, 1, 1 }));
            Assert.Equal(3, Ls.Find(new[] { 0, 0, 1, 1, 0, 0 }));
            Assert.Equal(5, Ls.Find(new[] { 1, 1, 0, 0, 0, 0 }));
            Assert.Equal(5, Ls.Find(new[] { 0, 0, 0, 0, 1, 1 }));
            Assert.Equal(3, Ls.Find(new[] { 1, 0, 1, 0, 1, 0 }));
            Assert.Equal(3, Ls.Find(new[] { 0, 1, 0, 1, 0, 1 }));
            Assert.Equal(1, Ls.Find(new[] { 1 }));
            Assert.Equal(2, Ls.Find(new[] { 0, 1 }));
            Assert.Equal(1, Ls.Find(new[] { 1, 1 }));
            Assert.Equal(3, Ls.Find(new[] { 1, 1, 0 }));
            Assert.Equal(3, Ls.Find(new[] { 0, 1, 1, 0 }));
            Assert.Equal(2, Ls.Find(new[] { 1, 1, 1 }));
            Assert.Equal(10, Ls.Find(new[] { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 }));
            Assert.Equal(10, Ls.Find(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 }));



        }
    }
}
