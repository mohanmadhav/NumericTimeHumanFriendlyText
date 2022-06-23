using NumericTimeHumanFriendlyText.Console.Interfaces;
using System;
using Xunit;
using NumericTimeHumanFriendlyText.Console.Services;

namespace NumericTimeHumanFriendlyText.UnitTests
{
    public class HumanFriendlyTextTest
    {
        private readonly INumericTimeHumanText _humanText;

        public HumanFriendlyTextTest()
        {
            this._humanText = new NumericTimeHumanTextService();
        }
        /// <summary>
        /// Returns Exact Hour time
        /// </summary>
        [Fact]
        public void GenerateHumanFriendlyText_WithOutMinutes_ReturnsClock()
        {
            //Assert
            int[] inputIntegers = new int[2];
            string inputTime = "01:00";
            string[] splitTime = inputTime.Split(':');
            inputIntegers[0] = Convert.ToInt32(splitTime[0]);
            inputIntegers[1] = Convert.ToInt32(splitTime[1]);
            string expectedResult = "It's one o'clock AM";
            //Act
            var result = this._humanText.GenerateHumanFriendlyText(inputIntegers);

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(expectedResult, result);
        }
        /// <summary>
        /// Returns Half Past time
        /// </summary>
        [Fact]
        public void GenerateHumanFriendlyText_With30Minutes_ReturnsHalfPast()
        {
            //Assert
            int[] inputIntegers = new int[2];
            string inputTime = "14:30";
            string[] splitTime = inputTime.Split(':');
            inputIntegers[0] = Convert.ToInt32(splitTime[0]);
            inputIntegers[1] = Convert.ToInt32(splitTime[1]);
            string expectedResult = "It's Half past two PM";
            //Act
            var result = this._humanText.GenerateHumanFriendlyText(inputIntegers);

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(expectedResult, result);
        }
        /// <summary>
        /// Returns Past time(below 30 mins) for the given
        /// </summary>
        [Fact]
        public void GenerateHumanFriendlyText_WithBelow30Minutes_ReturnsCurrentPastTime()
        {
            //Assert
            int[] inputIntegers = new int[2];
            string inputTime = "03:10";
            string[] splitTime = inputTime.Split(':');
            inputIntegers[0] = Convert.ToInt32(splitTime[0]);
            inputIntegers[1] = Convert.ToInt32(splitTime[1]);
            string expectedResult = "It's ten past three AM";
            //Act
            var result = this._humanText.GenerateHumanFriendlyText(inputIntegers);

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(expectedResult, result);
        }

        /// <summary>
        /// Returns to near hour if minutes more than 30
        /// </summary>
        [Fact]
        public void GenerateHumanFriendlyText_With35Minutes_ReturnsToNearHour()
        {
            //Assert
            int[] inputIntegers = new int[2];
            string inputTime = "13:35";
            string[] splitTime = inputTime.Split(':');
            inputIntegers[0] = Convert.ToInt32(splitTime[0]);
            inputIntegers[1] = Convert.ToInt32(splitTime[1]);
            string expectedResult = "It's twentyfive to two PM";
            //Act
            var result = this._humanText.GenerateHumanFriendlyText(inputIntegers);

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(expectedResult, result);
        }
        /// <summary>
        /// Returns Invalid Data
        /// </summary>
        [Fact]
        public void GenerateHumanFriendlyText_WithInvalidInputTime_ReturnsInvalidDate()
        {
            //Assert
            int[] inputIntegers = new int[2];
            string inputTime = "24:61";
            string[] splitTime = inputTime.Split(':');
            inputIntegers[0] = Convert.ToInt32(splitTime[0]);
            inputIntegers[1] = Convert.ToInt32(splitTime[1]);
            string expectedResult = "Invalid Data";
            //Act
            var result = this._humanText.GenerateHumanFriendlyText(inputIntegers);

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(expectedResult, result);
        }
    }
}
