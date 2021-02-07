using Microsoft.VisualStudio.TestTools.UnitTesting;
using dog_race_assignment_Nw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dog_race_assignment_Nw.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void Form1Test()
        {
            GameClass game = new GameClass();
            int y = game.GenRandom();
            if (y > 10)
            {
                Assert.IsTrue(true);
            }
            else {
                Assert.IsTrue(false);
            }
        }
        [TestMethod()]
        public void Form2Test()
        {
            GameClass game = new GameClass();
            int y = game.updateAmount(1,1,100,20);
            if (y ==120)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }


    }
}