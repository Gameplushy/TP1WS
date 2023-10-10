using System.Text.RegularExpressions;
using System.Text;

namespace TP1WS
{
    public static class Calendar
    {
        public static string CreateCalendar(string monthAndYear)
        {
            string? errorMessage = ValidateMonthAndYear(monthAndYear);
            if (errorMessage != null)
                return errorMessage;
            int[] monthAndYearNumerals = monthAndYear.Split('/').Select(int.Parse).ToArray();
            Enum.TryParse<Month>(monthAndYearNumerals[0].ToString(), out Month givenMonth);
            int[,] daysInSlots = GetListOfDays(givenMonth, monthAndYearNumerals[1]);
            return GetTexViewOfCalendar(givenMonth, monthAndYearNumerals[1], daysInSlots);
        }

        private static string GetTexViewOfCalendar(Month givenMonth, int v, int[,] daysInSlots)
        {
            StringBuilder calendar = new StringBuilder();
            calendar.AppendLine("┌────────────────────┐");
            calendar.AppendLine("│" + PadMiddle(givenMonth, v)+ "│");
            calendar.AppendLine("├──┬──┬──┬──┬──┬──┬──┤");
            calendar.AppendLine("│Su|Mo|Tu|We|Th|Fr|Sa│");
            PlaceDays(calendar,daysInSlots);
            calendar.AppendLine("└──┴──┴──┴──┴──┴──┴──┘");
            return calendar.ToString();
        }

        private static void PlaceDays(StringBuilder calendar, int[,] daysInSlots)
        {
            for(int row=0;row<6;row++)
            {
                calendar.AppendLine("├──┼──┼──┼──┼──┼──┼──┤");
                for(int day = 0; day < 7; day++)
                {
                    calendar.Append("│" + (daysInSlots[row, day] == 0 ? "--" : daysInSlots[row, day].ToString("D2")));
                }
                calendar.AppendLine("|");
            }
        }

        private static string PadMiddle(Month month, int year)
        {
            string baseString = month.ToString() + " " + year;
            if (baseString.Length >= 20) return baseString;
            decimal numberOfSpaces = (20 - baseString.Length) / 2;
            return new string(' ',(int)Math.Floor(numberOfSpaces)) + baseString + new string(' ',(int)Math.Ceiling(numberOfSpaces));
        }

        private static int[,] GetListOfDays(Month month, int year)
        {
            DateTime startDate = new DateTime(year, (int)month, 1);
            int[,] res = new int[6, 7];
            int daysInMonth = MonthHelper.GetDaysInMonth(month, year);
            int dayIndex = 0, weekIndex = 0;
            dayIndex = (int)startDate.DayOfWeek;
            for(int i=1;  i <= daysInMonth; i++)
            {
                res[weekIndex, dayIndex] = i;
                dayIndex++;
                if (dayIndex == 7)
                {
                    dayIndex = 0;
                    weekIndex++;
                }
            }
            return res;
        }

        private static string? ValidateMonthAndYear(string monthAndYear)
        {
            if(!Regex.IsMatch(monthAndYear,@"^\d{1,2}\/\d+$"))
                return "Date format is wrong.";
            Month? givenMonth = GetMonthFromNumber(monthAndYear);
            if (givenMonth == null)
                return "This is not a correct month.";
            return null;
        }

        private static Month? GetMonthFromNumber(string date)
        {
            int monthNumeral = date.Split('/').Select(int.Parse).First();
            Enum.TryParse<Month>(monthNumeral.ToString(), out Month givenMonth);
            return givenMonth;
        }
    }
}