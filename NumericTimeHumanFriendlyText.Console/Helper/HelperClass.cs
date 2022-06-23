using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericTimeHumanFriendlyText.Console.Helper
{
    /// <summary>
    /// Helper Class to validate input data
    /// </summary>
    public static class HelperClass
    {
        /// <summary>
        /// Validate the input hour and mm
        /// </summary>
        /// <returns></returns>
        public static bool GetValidInput(int[] inputTime)
        {
            bool inputInvalid = false;
            int[] inputIntegers = new int[2];
            if (inputTime.Length == 2)
            {
                // Fills int array.
                inputIntegers[0] = Convert.ToInt32(inputTime[0]);
                inputIntegers[1] = Convert.ToInt32(inputTime[1]);
                // If input numbers are valid, while loop exits.
                inputInvalid = ValidateInput(inputIntegers);
                return inputInvalid;
            }
            return inputInvalid;
        }

        /// <summary>
        /// Validates if given integers are hh:mm.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ValidateInput(int[] input)
        {
            return (input[0] >= 0 && input[0] <= 23 && input[1] >= 0 && input[1] <= 59);
        }
    }
}
