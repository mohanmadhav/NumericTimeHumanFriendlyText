namespace NumericTimeHumanFriendlyText.Console.Interfaces
{
    /// <summary>
    /// Contract for generating readble text from the numeric time
    /// </summary>
    public interface INumericTimeHumanText
    {
        string GenerateHumanFriendlyText(int[] input);
        string GenerateAmPm(int hour);
        string GenerateHoursString(int hour);
        string GenerateMinutesString(int minute);
        string NumberAsWord(int hourMinute);
    }
}
