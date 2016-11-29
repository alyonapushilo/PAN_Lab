using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PAN_1;

namespace Test
{
    public class Class1
    {
        [Test]
        public void SumTest_01()
        {
            Calc result = new PAN_1.Calc();
            Assert.AreEqual(4, result.Sum(2, 2));
        }

        [Test]
        public void SumTest_02()
        {
            Calc result = new PAN_1.Calc();
            Assert.AreEqual(7, result.Sum(7, 0));
        }

        [Test]
        public void SumTest_03()
        {
            Calc result = new PAN_1.Calc();
            Assert.AreEqual(1, result.Sum(3, -2));
        }

        [Test]
        public void MinTest_01()
        {
            Calc result = new PAN_1.Calc();
            Assert.AreEqual(0, result.Min(2, 2));
        }

        [Test]
        public void MinTest_02()
        {
            Calc result = new PAN_1.Calc();
            Assert.AreEqual(7, result.Min(7, 0));
        }

        [Test]
        public void MinTest_03()
        {
            Calc result = new PAN_1.Calc();
            Assert.AreEqual(5, result.Min(3, -2));
        }

        [Test]
        public void MulTest_01()
        {
            Calc result = new PAN_1.Calc();
            Assert.AreEqual(4, result.Mul(2, 2));
        }

        [Test]
        public void MulTest_02()
        {
            Calc result = new PAN_1.Calc();
            Assert.AreEqual(0, result.Mul(7, 0));
        }

        [Test]
        public void MulTest_03()
        {
            Calc result = new PAN_1.Calc();
            Assert.AreEqual(-6, result.Mul(3, -2));
        }

        [Test]
        public void DivTest_01()
        {
            Calc result = new PAN_1.Calc();
            Assert.AreEqual(1, result.Div(2, 2));
        }

        [Test]
        public void DivTest_02()
        {
            Calc result = new PAN_1.Calc();
            Assert.AreEqual(7, result.Div(7, 1));
        }

        [Test]
        public void DivTest_03()
        {
            Calc result = new PAN_1.Calc();
            Assert.AreEqual(-3, result.Min(6, -2));
        }

    }
}

