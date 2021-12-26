using Xunit;

namespace LexiconCalculator.Tests
{
    public class CalculatorTests
    {
        // Test Addition
        [Theory]
        [InlineData(4, 5, 9)]
        [InlineData(1.25, 2.25, 3.50)]
        [InlineData(double.MaxValue, 5, double.MaxValue)]
        [InlineData(double.MinValue, 5, double.MinValue)]

        public void Addition_SumShouldBeReturned(double firstNum, double secondNum, double expected)
        {
            // Arrange

            // Act
            double actual = Calculator.Addition(firstNum, secondNum);

            // Assert
            Assert.Equal(expected, actual);
        }

        // Test Addition overloaded method with Array args
        [Theory]
        [InlineData(new object[] { new double[] { 10, 30, 30 }, 70 })]
        [InlineData(new object[] { new double[] { 0, 0, 1, 0, 0 }, 1 })]
        [InlineData(new object[] { new double[] { 50, 100, 200, 300, 1000 }, 1650 })]
        [InlineData(new object[] { new double[] { 50, 100, 200, 300, 1000, 0, 0, 1 }, 1651 })]
        [InlineData(new object[] { new double[] { 100, double.MaxValue }, double.MaxValue })]
        public void Addition_SumShouldBeReturnedFromArray(double[] inputArray, double expected)
        {
            // Arrange

            // Act
            double actual = Calculator.Addition(inputArray);

            // Assert
            Assert.Equal(expected, actual);
        }


        // Test Subtraction
        [Theory]
        [InlineData(4, 5, -1)]
        [InlineData(1.25, 1, 0.25)]
        [InlineData(-1, -1, 0)] // double negative change operator to positive (+) 
        [InlineData(double.MinValue, 5, double.MinValue)]
        [InlineData(double.MinValue, double.MinValue, 0)] // -max - -max = -max + max = 0
        public void Subtraction_DifferenceShouldBeReturned(double minuend, double subtrahend, double expected)
        {
            // Arrange          

            // Act
            double actual = Calculator.Subtraction(minuend, subtrahend);

            // Assert
            Assert.Equal(expected, actual);
        }

        // Test Subtraction overloaded method with Array args
        [Theory]
        [InlineData(new object[] { new double[] { 10, 5, 5 }, 0 })]
        [InlineData(new object[] { new double[] { 0, 5, 5, 5, 5 }, -20 })]
        [InlineData(new object[] { new double[] { 50, 100, 0, 0, 1 }, -51 })]
        [InlineData(new object[] { new double[] { 100, double.MaxValue }, double.MinValue })]
        public void Subtraction_DifferenceShouldBeReturnedFromArray(double[] inputArray, double expected)
        {
            // Arrange

            // Act
            double actual = Calculator.Subtraction(inputArray);

            // Assert
            Assert.Equal(expected, actual);
        }

        // Test Multiplication
        [Theory]
        [InlineData(4, 5, 20)]
        [InlineData(double.MaxValue, double.MaxValue, double.PositiveInfinity)]
        [InlineData(10, 10, 100)]
        public void Multiplication_ProductShouldBeReturned(double firstFactor, double secondFactor, double expected)
        {
            // Arrange

            // Act
            double actual = Calculator.Multiplication(firstFactor, secondFactor);

            // Assert
            Assert.Equal(expected, actual);
        }

        // Test Multiplication overloaded method with Array args
        [Theory]
        [InlineData(new object[] { new double[] { 10, 5, 5 }, 250 })]
        [InlineData(new object[] { new double[] { 100, double.MaxValue }, double.PositiveInfinity })]
        public void Multiplication_ProductShouldBeReturnedFromArray(double[] inputArray, double expected)
        {
            // Arrange

            // Act
            double actual = Calculator.Multiplication(inputArray);

            // Assert
            Assert.Equal(expected, actual);
        }

        // Test Division 
        [Theory]
        [InlineData(10, 5, 2)]
        [InlineData(double.MaxValue, double.MaxValue, 1)]
        public void Division_QuotientShouldBeReturned(double numerator, double denominator, double expected)
        {
            // Arrange

            // Act
            double actual = Calculator.Division(numerator, denominator);

            // Assert
            Assert.Equal(expected, actual);
        }

        // Test Division overloaded method with Array args
        [Theory]
        [InlineData(new object[] { new double[] { 10, 5, 2 }, 1 })]
        [InlineData(new object[] { new double[] { 100, 10, 2 }, 5 })]
        public void Division_QuotientShouldBeReturnedFromArray(double[] inputArray, double expected)
        {
            // Arrange

            // Act
            double actual = Calculator.Division(inputArray);

            // Assert
            Assert.Equal(expected, actual);
        }

        // Test Division by 0
        [Fact]
        public void Division_DivideByZero()
        {
            // Arrange
            double expected = 0; // Returns zero NOT infinity

            // Act
            double actual = Calculator.Division(10, 0);

            // Assert
            Assert.Equal(expected, actual);
        }

        // Test Division, divide array by 0
        [Fact]
        public void Division_DivideArrayByZero()
        {
            // Arrange
            double expected = 0; // Returns zero NOT infinity

            // Act
            double actual = Calculator.Division(new double[] { 10, 5, 0 });

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
