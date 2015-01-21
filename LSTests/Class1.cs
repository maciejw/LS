using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LSTests
{




    public class Ls
    {


        public static int Find(int[] sequence)
        {

            int max = 0;
            int seq1 = 0;
            int seq2 = 0;
            bool switchAvailable = true;
            bool count1 = true;
            bool count2 = false;

            foreach (var i in sequence)
            {


                if (i == 1)
                {
                    seq1++;
                } 
                if (i == 1 && count2)
                {
                    seq2++;
                }
                if (i == 0 && !switchAvailable)
                {
                    max = seq1;
                    seq2++;
                    seq1 = seq2;
                    seq2 = 0;
                }
                if (i == 0 && switchAvailable)
                {
                    seq1++;
                    switchAvailable = false;
                    count2 = true;

                }
               

            }
            return Math.Max(max, seq1);
        }
    }


    public class Class1
    {
        [Fact]
        public void MyTestMethod()
        {
            Assert.Equal(6, Ls.Find(new[] { 1, 0, 1, 1, 0, 1, 1, 1 }));

            Assert.Equal(8, Ls.Find(new[] { 1, 0, 1, 1, 1, 1, 1, 1 }));
            Assert.Equal(4, Ls.Find(new[] { 1, 0, 0, 0, 0, 1, 1, 1 }));
            //Assert.Equal(8, Ls.Find(new[] { 1, 1, 1, 1, 1, 1, 1, 1 }));        
        }
    }
}
