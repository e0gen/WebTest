using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WebTest.Controllers;

namespace WebTest.Tests
{
    public class Tests
    {
        [TestCase(0, new int[] { 0, 1, 2})]
        [TestCase(3, new int[] { 0, 1, 2, 3 })]
        [TestCase(3, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(10, new int[] { 0, 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(21, new int[] { 1, 3, 5, 7, 9, 11 })]
        [TestCase(21, new int[] { 1, -3, 5, 7, 9, -11 })]
        public void TestFirstTask(int expResult, int[] input)
        {
            // Arrange
            var sut = new TestController();
            // Act
            var res = sut.SumEverySecondNonOddDigit(input).Value;
            // Assert
            Assert.AreEqual(expResult, res);
        }

        [TestCase(2468, 1234, 1234)]
        [TestCase(7013, 12, 7001)]
        [TestCase(19998, 9999, 9999)]
        public void TestSecondTask(int expResult, int first, int second)
        {
            // Arrange
            var sut = new TestController();
            // Act
            var res = sut.SumDigitalLinkedLists(new[] { first, second }).Value;
            // Assert
            Assert.AreEqual(expResult, res);
        }


        [TestCase(true, "WatTaw")]
        [TestCase(true, "palindromordnilap")]
        [TestCase(true, "p")]
        [TestCase(true, "12344321")]
        [TestCase(true, "515")]
        [TestCase(false, "nope")]
        [TestCase(false, "1234")]
        public void TestThirdTask(bool expResult, string value)
        {
            // Arrange
            var sut = new TestController();
            // Act
            var res = sut.IsStringPalindrom(value).Value;
            // Assert
            Assert.AreEqual(expResult, res);
        }

        [TestCase(new int[] { 4, 3, 2, 1 }, 1234)]
        public void DigitalLinkedListCorrectInitializationFromInt32(int[] array, int input)
        {
            // Arrange
            var expResult = new DigitalLinkedList(array);
            // Act
            var result = new DigitalLinkedList(input);
            // Assert
            Assert.AreEqual(expResult, result);
        }

        [TestCase(1234, new int[] { 4, 3, 2, 1 })]
        public void DigitalLinkedListToInt32(int expResult, int[] array)
        {
            // Arrange
            var input = new DigitalLinkedList(array);
            // Act
            var res = input.ToInt32();
            // Assert
            Assert.AreEqual(expResult, res);
        }
    }
}