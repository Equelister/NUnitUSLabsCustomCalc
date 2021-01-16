using NUnit.Framework;
using PTUIACalc;
using System;

namespace PTUIATestsNUnit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalcEmptyString()
        {
            string input = "";
            double output = Calculator.sum(input);
            Assert.AreEqual(0, output);
        }
        
        [Test]
        public void CalcNullString()
        {
            string input = null;
            var ex = Assert.Throws<NullReferenceException>(() => Calculator.sum(input));
            Assert.AreEqual("Null parameter", ex.Message);
        }

        [Test]
        public void CalcOneParamInString()
        {
            string input = "1";
            double output = Calculator.sum(input);
            Assert.AreEqual(1, output);
        }

        [Test]
        public void CalcTwoParamsInString()
        {
            string input = "1,2";
            double output = Calculator.sum(input);
            Assert.AreEqual(3, output);
        }

        [Test]
        public void CalcTenParamsInString()
        {
            string input = "1,2,3,4,5,6,7,8,9,10";
            double output = Calculator.sum(input);
            Assert.AreEqual(55, output);
        }

        [Test]
        public void CalcNewLineParamsInString()
        {
            string input = "1,2\n9,10";
            double output = Calculator.sum(input);
            Assert.AreEqual(22, output);
        }

        [Test]
        public void CalcCustomSeparator()
        {
            string input = "//[;]\n1;2\n9;10";
            double output = Calculator.sum(input);
            Assert.AreEqual(22, output);
        }

        [Test]
        public void CalcMinusAsSeparator()
        {
            string input = "//[-]\n1-2\n9-10";
            double output = Calculator.sum(input);
            Assert.AreEqual(22, output);
        }

        [Test]
        public void CalcNegativeDigits()
        {
            string input = "//[;]\n1;-2\n9;-10";
            var ex = Assert.Throws<ArgumentException>(() => Calculator.sum(input));
            Assert.AreEqual("Parameter cannot be negative: -2, -1.", ex.Message);
        }

        [Test]
        public void CalcCheckCeilLvl1000_0 ()
        {
            string input = "15,2,200000";
            double output = Calculator.sum(input);
            Assert.AreEqual(17, output);
        }

        [Test]
        public void CalcCheckCeilLvl1000_1()
        {
            string input = "15,2,1000";
            double output = Calculator.sum(input);
            Assert.AreEqual(1017, output);
        }

        [Test]
        public void CalcCheckCeilLvl1000_2()
        {
            string input = "15,2,1001";
            double output = Calculator.sum(input);
            Assert.AreEqual(17, output);
        }

        [Test]
        public void CalcMultipleSeparators_0()
        {
            string input = "//[*][;][BB][B2Q][321][XXX]\n1*2;3";
            double output = Calculator.sum(input);
            Assert.AreEqual(6, output);
        }
    }
}