using Day_10_Assignment1_CalculatorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CalculatorTests
{
    [TestClass]
    public sealed class Test1
    {
        //[TestMethod]
       // public void TestMethod1()
        
            private Calculator calculator;

        [TestInitialize]
        public void Setup()
        {
            calculator = new Calculator();
        }
        

        [TestMethod]
        public void Test_Add()
        {
            Assert.AreEqual(8, calculator.Add(5, 3));
        }

        [TestMethod]
        public void Test_Subtract()
        {
            Assert.AreEqual(2, calculator.Subtract(5, 3));
        }

        [TestMethod]
        public void Test_Multiply()
        {
            Assert.AreEqual(15, calculator.Multiply(5, 3));
        }

        [TestMethod]
        public void Test_Divide()
        {
            Assert.AreEqual(5, calculator.Divide(10, 2));
        }

        [TestMethod]
        // public void Test_Divide_By_Zero()
        // {
        //     Assert.ThrowsException<DivideByZeroException>(() => calculator.Divide(10, 0));
        //}
       // [ExpectedException(typeof(DivideByZeroException))]


        public void Test_Divide_By_Zero()
        {
            try
            {
                calculator.Divide(10, 0);
                Assert.Fail("Exception not thrown");
            }
            catch (DivideByZeroException)
            {
                Assert.IsTrue(true);
            }

            //Assert.ThrowsException<DivideByZeroException>(() => calculator.Divide(10, 0));
            // calculator.Divide(10, 0);
        }
    }
    }


