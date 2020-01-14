using System;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Calc_Sum_4_and_5_results_9()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(4, 5);

            //Assert
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void Calc_Sum_0_and_0_results_0()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Calc_Sum_MAX_and_1_results_throws()
        {
            //Arrange
            var calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));


        }

        [TestMethod]
        public void Calc_IsWeekend()
        {
            var calc = new Calc();

            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 1, 13);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 1, 14);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 1, 15);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 1, 16);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 1, 17);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 1, 18);
                Assert.IsTrue(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 1, 19);
                Assert.IsTrue(calc.IsWeekend());
            }
        }
    }
}
