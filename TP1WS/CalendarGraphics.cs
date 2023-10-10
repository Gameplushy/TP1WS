using System.Text;

namespace TP1WS
{
    internal class CalendarGraphics
    {
        /// <summary>
        /// Creates the graphic calendar of the chosen month and year
        /// </summary>
        internal static string GetTexViewOfCalendar(Month month, int year)
        {
            int[,] daysInSlots = GetListOfDays(month, year);
            StringBuilder calendar = new StringBuilder();
            calendar.AppendLine("┌────────────────────┐");
            calendar.AppendLine("│" + PadMiddle(month, year) + "│");
            calendar.AppendLine("├──┬──┬──┬──┬──┬──┬──┤");
            calendar.AppendLine("│Su|Mo|Tu|We|Th|Fr|Sa│");
            PlaceDays(calendar, daysInSlots);
            calendar.AppendLine("└──┴──┴──┴──┴──┴──┴──┘");
            return calendar.ToString();
        }

        /// <summary>
        /// Creates the days part of the calendar
        /// </summary>
        /// <param name="calendar">The StringBuilder already used for creating the calendar</param>
        /// <param name="daysInSlots">A 2D array with the day numbers in the corresponding weeks and days</param>
        private static void PlaceDays(StringBuilder calendar, int[,] daysInSlots)
        {
            for (int row = 0; row < 6; row++)
            {
                calendar.AppendLine("├──┼──┼──┼──┼──┼──┼──┤");
                for (int day = 0; day < 7; day++)
                {
                    calendar.Append("│" + (daysInSlots[row, day] == 0 ? "--" : daysInSlots[row, day].ToString("D2")));
                }
                calendar.AppendLine("|");
            }
        }

        /// <summary>
        /// Centers the header of the calendar (Month + Year)
        /// </summary>
        private static string PadMiddle(Month month, int year)
        {
            string baseString = month.ToString() + " " + year;
            if (baseString.Length >= 20) return baseString; //Max width is 22 characters. Taking the borders, the header has a space of 20 chars max. If more, whoops!
            decimal numberOfSpaces = (20 - baseString.Length) / 2m;
            return new string(' ', (int)Math.Floor(numberOfSpaces)) + baseString + new string(' ', (int)Math.Ceiling(numberOfSpaces));
        }

        /// <summary>
        /// Places the days of the month in a 2D array, in a way that the columns represent the days and the rows the weeks.
        /// </summary>
        private static int[,] GetListOfDays(Month month, int year)
        {
            DateTime startDate = new DateTime(year, (int)month, 1);
            int[,] res = new int[6, 7]; //There can be a maximum of 6 weeks in a month
            int daysInMonth = MonthHelper.GetDaysInMonth(month, year);
            int dayIndex = 0, weekIndex = 0;
            dayIndex = (int)startDate.DayOfWeek;
            for (int i = 1; i <= daysInMonth; i++)
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
    }
}
