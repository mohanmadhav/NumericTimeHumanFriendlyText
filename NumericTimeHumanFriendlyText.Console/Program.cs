using System;
using NumericTimeHumanFriendlyText.Console.ApplicationEnum;
using NumericTimeHumanFriendlyText.Console.Interfaces;
using NumericTimeHumanFriendlyText.Console.Services;

namespace TimeHumanFriendlyText
{
    public class Program
    {
        public static INumericTimeHumanText numericTimeHumanText = new NumericTimeHumanTextService();
        public static void Main(string[] args)
        {
            int[] inputIntegers = new int[2];
            Console.WriteLine("Input hh:mm or exit.");
            string[] input = Console.ReadLine().Trim().Split(':');
            if (input[0].ToLower().Equals("exit"))
            {
                /// Exit method.
            }
            else if (input.Length == 2)
            {
                // Fills int array.
                inputIntegers[0] = Convert.ToInt32(input[0]);
                inputIntegers[1] = Convert.ToInt32(input[1]);
            }
            GenerateOutput(inputIntegers);
        }

        /// <summary>
        /// Generate the output as human text based on hh:mm
        /// </summary>
        /// <param name="input"></param>
        public static void GenerateOutput(int[] input)
        {
            var result = numericTimeHumanText.GenerateHumanFriendlyText(input);
            Console.WriteLine(result);
        }
    }
}
