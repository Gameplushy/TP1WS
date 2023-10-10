using System.Text.RegularExpressions;

namespace TP1WS
{
    /// <summary>
    /// Main class, called by the user. Currently, only CreateCalendar exists.
    /// </summary>
    public static class Calendar
    {
        /// <summary>
        /// Returns an ASCII art graphic of the selected month and year.
        /// </summary>
        /// <param name="monthAndYear">Must follow the format MM/YYYY. Year must be positive.</param>
        /// <returns>Either the calendar view or an error message if the input's format was wrong.</returns>
        public static string CreateCalendar(string monthAndYear)
        {
            string? errorMessage = ValidateMonthAndYear(monthAndYear);
            if (errorMessage != null)
                return errorMessage;
            int[] monthAndYearNumerals = monthAndYear.Split('/').Select(int.Parse).ToArray();
            Enum.TryParse<Month>(monthAndYearNumerals[0].ToString(), out Month givenMonth);
            return CalendarGraphics.GetTexViewOfCalendar(givenMonth, monthAndYearNumerals[1]);
        }

        /// <summary>
        /// Validates the format and validity of the month and year
        /// </summary>
        /// <param name="monthAndYear">User input</param>
        /// <returns>Error message or null</returns>
        private static string? ValidateMonthAndYear(string monthAndYear)
        {
            if(!Regex.IsMatch(monthAndYear,@"^\d{1,2}\/\d+$"))
                return "Date format is wrong.";
            string[] dateNumerals = monthAndYear.Split('/').ToArray();
            if (!Enum.TryParse<Month>(dateNumerals[0], out _))
                return "This is not a correct month.";
            if (!int.TryParse(dateNumerals[1], out _))
                return "This is not a correct year. It must land in the int range.";
            return null;
        }
    }
}