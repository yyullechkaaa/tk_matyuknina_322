
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGradeCalculation_Excellent()
        {
            int totalScore = 85;
            string expected = "5 (отлично)";

            string actual = CalculateGrade(totalScore);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGradeCalculation_Good()
        {
            int totalScore = 55;
            string expected = "4 (хорошо)";

            string actual = CalculateGrade(totalScore);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGradeCalculation_Satisfactory()
        {
            int totalScore = 25;
            string expected = "3 (удовлетворительно)";

            string actual = CalculateGrade(totalScore);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGradeCalculation_Unsatisfactory()
        {
            int totalScore = 10;
            string expected = "2 (неудовлетворительно)";

            string actual = CalculateGrade(totalScore);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGradeBoundaries_70Points()
        {
            Assert.AreEqual("5 (отлично)", CalculateGrade(70));
        }

        [TestMethod]
        public void TestGradeBoundaries_40Points()
        {
            Assert.AreEqual("4 (хорошо)", CalculateGrade(40));
        }

        [TestMethod]
        public void TestGradeBoundaries_20Points()
        {
            Assert.AreEqual("3 (удовлетворительно)", CalculateGrade(20));
        }

        [TestMethod]
        public void TestGradeBoundaries_0Points()
        {
            Assert.AreEqual("2 (неудовлетворительно)", CalculateGrade(0));
        }

        private string CalculateGrade(int totalScore)
        {
            if (totalScore >= 70) return "5 (отлично)";
            if (totalScore >= 40) return "4 (хорошо)";
            if (totalScore >= 20) return "3 (удовлетворительно)";
            return "2 (неудовлетворительно)";
        }

        [TestMethod]
        public void TestInputValidation_ValidNumber()
        {
            Assert.IsTrue(IsValidScore("10", 10));
        }

        [TestMethod]
        public void TestInputValidation_InvalidNumber()
        {
            Assert.IsFalse(IsValidScore("abc", 10));
        }

        [TestMethod]
        public void TestInputValidation_OutOfRange()
        {
            Assert.IsFalse(IsValidScore("15", 10));
        }

        private bool IsValidScore(string input, int maxScore)
        {
            if (!int.TryParse(input, out int score))
                return false;

            return score >= 0 && score <= maxScore;
        }
    }
}
