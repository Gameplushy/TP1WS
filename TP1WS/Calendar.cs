using System.Text.RegularExpressions;

namespace TP1WS
{
    /// <summary>
    /// Main class, called by the user. Also contains validation and filtering methods.
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
        /// Returns an ASCII art graphic of the selected month and year, while highlighting special events occuring this month.
        /// </summary>
        /// <param name="monthAndYear">Must follow the format MM/YYYY. Year must be positive.</param>
        /// <param name="specialDates">List of dates that follow the format DD/MM/YYYY. Year must be positive.</param>
        /// <returns>Either the calendar view or an error message if the input's format was wrong.</returns>
        public static string CreateCalendarWithSpecialDates(string monthAndYear, List<string> specialDates)
        {
            string? errorMessage = ValidateMonthAndYear(monthAndYear);
            if (errorMessage != null)
                return errorMessage;
            errorMessage = ValidateSpecialDates(specialDates);
            if (errorMessage != null)
                return errorMessage;
            int[] monthAndYearNumerals = monthAndYear.Split('/').Select(int.Parse).ToArray();
            int[] events = GetImportantDates(specialDates, monthAndYearNumerals);
            Enum.TryParse<Month>(monthAndYearNumerals[0].ToString(), out Month givenMonth);
            return CalendarGraphics.GetTexViewOfCalendarWithSpecialDays(givenMonth, monthAndYearNumerals[1], events);
        }

        /// <summary>
        /// Filters out the special dates so that only the ones in the relevant month are kept.
        /// </summary>
        /// <param name="specialDates">List of special dates</param>
        /// <param name="monthAndYearNumerals">Int array [month,year]</param>
        /// <returns>Array of the days of relevant events</returns>
        private static int[] GetImportantDates(List<string> specialDates, int[] monthAndYearNumerals)
        {
            List<DateTime> dates = specialDates.Select(DateTime.Parse).ToList();
            return dates.Where(d => d.Month == monthAndYearNumerals[0] && d.Year == monthAndYearNumerals[1]).Select(d=> d.Day).ToArray();
        }

        /// <summary>
        /// Validates the format and validity of the special dates
        /// </summary>
        /// <param name="specialDates">User input</param>
        /// <returns>Error message or null</returns>
        private static string? ValidateSpecialDates(List<string> specialDates)
        {
            foreach(string specialDate in specialDates)
            {
                if (!Regex.IsMatch(specialDate, @"^\d{1,2}\/\d{1,2}\/\d+$"))
                    return specialDate + " : Date format is wrong.";
                string[] dateNumerals = specialDate.Split('/').ToArray();
                if (!int.TryParse(dateNumerals[2], out _))
                    return specialDate + " : This is not a correct year. It must land in the int range.";
                if (!DateTime.TryParse(specialDate, out _))
                    return specialDate + "Date is incorrect.";
            }
            return null;
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