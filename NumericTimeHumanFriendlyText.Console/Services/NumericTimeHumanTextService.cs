using System;
using NumericTimeHumanFriendlyText.Console.ApplicationEnum;
using NumericTimeHumanFriendlyText.Console.Interfaces;

namespace NumericTimeHumanFriendlyText.Console.Services
{
    /// <summary>
    /// Service to Generate the Readable text from the given input time
    /// </summary>
    public class NumericTimeHumanTextService : INumericTimeHumanText
    {
        #region Global String Variables
        public string ampm = string.Empty;
        public string hourWord = string.Empty;
        public string minuteWord = string.Empty;
        public string[] hours = Enum.GetNames(typeof(Hours));
        public string[] tens = Enum.GetNames(typeof(Tens));
        public string[] mins = Enum.GetNames(typeof(MinuteTeens));
        public string resultHumanText = string.Empty;
        #endregion

        #region Public Methods
        /// <summary>
        /// Generate the Human Friendly Text with Numeric Time
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string GenerateHumanFriendlyText(int[] inputTime)
        {
            resultHumanText = Helper.HelperClass.GetValidInput(inputTime) ? GenerateTimeText(inputTime) : "Invalid Data";
            return resultHumanText;
        }
        /// <summary>
        /// Helper Method to get the human text with numeric time
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string GenerateTimeText(int[] input)
        {
            // handles am/pm situation
            string amPm = GenerateAmPm(input[0]);
            string output;
            // Continues with output generation.
            if (input[1] >= 30)
            {
                output = input[1] > 30 ? String.Format("It's {1} to {0} {2}", GenerateHoursString(input[0] + 1), GenerateMinutesString(input[1]), amPm)
                    : String.Format("It's {1} {0} {2}", GenerateHoursString(input[0]), GenerateMinutesString(input[1]), amPm);
            }
            else
            {
                output = input[1] != 0 ? String.Format("It's {1} past {0} {2}", GenerateHoursString(input[0]), GenerateMinutesString(input[1]), amPm)
                    : String.Format("It's {0} {1} {2}", GenerateHoursString(input[0]), GenerateMinutesString(input[1]), amPm);
            }

            return output;
        }

        /// <summary>
        /// Get the Meridiemas text by hour
        /// </summary>
        /// <param name="hour">hour</param>
        /// <returns></returns>
        public string GenerateAmPm(int hour)
        {
            return ampm = hour >= 12 ? AntePostMeridiem.PM.ToString() : AntePostMeridiem.AM.ToString();
        }
        /// <summary>
        /// Get the input hour as text
        /// </summary>
        /// <param name="hour">hour</param>
        /// <returns></returns>
        public string GenerateHoursString(int hour)
        {
            // handles pm clause
            if (hour >= 13)
            {
                hour -= 12;
            }
            switch (hour)
            {
                case 0: hourWord = Hours.Twelve.ToString().ToLower(); break;
                case 1: hourWord = Hours.One.ToString().ToLower(); break;
                case 2: hourWord = Hours.Two.ToString().ToLower(); break;
                case 3: hourWord = Hours.Three.ToString().ToLower(); break;
                case 4: hourWord = Hours.Four.ToString().ToLower(); break;
                case 5: hourWord = Hours.Five.ToString().ToLower(); break;
                case 6: hourWord = Hours.Six.ToString().ToLower(); break;
                case 7: hourWord = Hours.Seven.ToString().ToLower(); break;
                case 8: hourWord = Hours.Eight.ToString().ToLower(); break;
                case 9: hourWord = Hours.Nine.ToString().ToLower(); break;
                case 10: hourWord = Hours.Ten.ToString().ToLower(); break;
                case 11: hourWord = Hours.Eleven.ToString().ToLower(); break;
                case 12: hourWord = Hours.Twelve.ToString().ToLower(); break;
                default:
                    break;
            }
            return hourWord;
        }
        /// <summary>
        /// Get the input minute as text
        /// </summary>
        /// <param name="minute"></param>
        /// <returns></returns>
        public string GenerateMinutesString(int minute)
        {
            if (minute == 0)
            {
                minuteWord = "o'clock";
            }
            else if (minute < 10 || minute < 20)
            {
                minuteWord = NumberAsWord(minute);
            }

            else if (minute < 30)
            {
                minuteWord = "twenty " + NumberAsWord(minute - 20);
            }
            else if (minute == 30)
            {
                minuteWord = "Half past";
            }
            else
            {
                switch ((minute - 30) / 10)
                {
                    case > 1:
                        switch ((minute - 30) % 10)
                        {
                            case 0:
                                minuteWord = (mins[((60 - minute) % 10)]).ToLower();
                                break;
                            default:
                                minuteWord = (hours[((60 - minute) % 10)]).ToLower();
                                break;
                        }
                        break;
                    case > 0:
                        switch (minute)
                        {
                            case 40:
                                minuteWord = (tens[(60 - minute) % 10]).ToLower();
                                break;
                            default:
                                minuteWord = (mins[(60 - minute) % 10]).ToLower();
                                break;
                        }
                        break;
                    default:
                        minuteWord = (tens[(60 - minute) / 10 - 2] + hours[(60 - minute) % 10]).ToLower();
                        break;
                }
            }
            return minuteWord;
        }
        /// <summary>
        /// Get the numericas word 
        /// </summary>
        /// <param name="hourMinute"></param>
        /// <returns></returns>
        public string NumberAsWord(int hourMinute)
        {
            switch (hourMinute)
            {
                case 0: return string.Empty;
                case 1: return Minutes.One.ToString().ToLower();
                case 2: return Minutes.Two.ToString().ToLower();
                case 3: return Minutes.Three.ToString().ToLower();
                case 4: return Minutes.Four.ToString().ToLower();
                case 5: return Minutes.Five.ToString().ToLower();
                case 6: return Minutes.Six.ToString().ToLower();
                case 7: return Minutes.Seven.ToString().ToLower();
                case 8: return Minutes.Eight.ToString().ToLower();
                case 9: return Minutes.Nine.ToString().ToLower();
                case 10: return MinuteTeens.Ten.ToString().ToLower();
                case 11: return MinuteTeens.Eleven.ToString().ToLower();
                case 12: return MinuteTeens.Twelve.ToString().ToLower();
                case 13: return MinuteTeens.Thirteen.ToString().ToLower();
                case 14: return MinuteTeens.Fourteen.ToString().ToLower();
                case 15: return MinuteTeens.Fifteen.ToString().ToLower();
                case 16: return MinuteTeens.Sixteen.ToString().ToLower();
                case 17: return MinuteTeens.Seventeen.ToString().ToLower();
                case 18: return MinuteTeens.Eighteen.ToString().ToLower();
                case 19: return MinuteTeens.Nineteen.ToString().ToLower();
                default:
                    return "outofboundsnumberAsWord";
            }
        }
        #endregion

    }
}
