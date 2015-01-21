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
        private int max = 0;
        private int seq1 = 0;
        private int seq2 = 0;
        private bool switchAvailable = true;
        private bool count1 = true;
        private bool count2 = false;
        private int p;
        private int nonP;

        public Counter(int p, int nonP)
        {
            this.p = p;
            this.nonP = nonP;
        }

        public void Count(int i)
        {

            if (i == p)
            {
                seq1++;
            }
            if (i == p && count2)
            {
                seq2++;
            }
            if (i == nonP && !switchAvailable)
            {
                max = seq1;
                seq2++;
                seq1 = seq2;
                seq2 = 0;
            }
            if (i == nonP && switchAvailable)
            {
                seq1++;
                switchAvailable = false;
                count2 = true;

            }
        }

        public int Check()
        {
            int i = seq1;
            if (switchAvailable)
            {
                i--;
            }

            return Math.Max(max, i);
        }
    }


    public class Ls
    {


        public static int Find(int[] sequence)
        {

            var oneCounter = new Counter(1, 0);
            var zeroCounter = new Counter(0, 1);

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
            Assert.Equal(7, Ls.Find(new[] { 0, 0, 0, 0, 0, 0, 0, 0 }));

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

            Assert.Equal(7, Ls.Find(new[] { 0, 0, 0, 1, 1, 1, 1, 1 }));
            Assert.Equal(6, Ls.Find(new[] { 1, 0, 0, 0, 1, 1, 1, 1 }));
            Assert.Equal(5, Ls.Find(new[] { 1, 1, 0, 0, 0, 1, 1, 1 }));
            Assert.Equal(4, Ls.Find(new[] { 1, 1, 1, 0, 0, 0, 1, 1 }));
            Assert.Equal(5, Ls.Find(new[] { 1, 1, 1, 1, 0, 0, 0, 1 }));
            Assert.Equal(6, Ls.Find(new[] { 1, 1, 1, 1, 1, 0, 0, 0 }));

            Assert.Equal(7, Ls.Find(new[] { 0, 0, 0, 0, 1, 1, 1, 1 }));
            Assert.Equal(6, Ls.Find(new[] { 1, 0, 0, 0, 0, 1, 1, 1 }));
            Assert.Equal(5, Ls.Find(new[] { 1, 1, 0, 0, 0, 0, 1, 1 }));
            Assert.Equal(4, Ls.Find(new[] { 1, 1, 1, 0, 0, 0, 0, 1 }));
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

         
            //Assert.Equal(8, Ls.Find(new[] { 1, 0, 0, 1, 1, 1, 1, 1 }));
            //Assert.Equal(6, Ls.Find(new[] { 1, 0, 1, 1, 0, 1, 1, 1 }));
            //Assert.Equal(5, Ls.Find(new[] { 1, 0, 0, 0, 0, 1, 1, 1 }));
            //Assert.Equal(5, Ls.Find(new[] { 0, 1, 1, 1, 1, 0, 0, 0 }));
        }
    }
}
