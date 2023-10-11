using System;
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
            calendar.AppendLine("│" + PadMiddle(month, year, 20) + "│");
            calendar.AppendLine("├──┬──┬──┬──┬──┬──┬──┤");
            calendar.AppendLine("│Su│Mo│Tu│We│Th│Fr│Sa│");
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
                calendar.AppendLine("│");
            }
        }

        /// <summary>
        /// Creates the graphic calendar of the chosen month and year, while highlighting special events
        /// </summary>
        internal static string GetTexViewOfCalendarWithSpecialDays(Month month, int year, int[] events)
        {
            int[,] daysInSlots = GetListOfDays(month, year);
            StringBuilder calendar = new StringBuilder();
            calendar.AppendLine("┌──────────────────────────────────┐");
            calendar.AppendLine("│" + PadMiddle(month, year, 34) + "│");
            calendar.AppendLine("├────┬────┬────┬────┬────┬────┬────┤");
            calendar.AppendLine("│ Su │ Mo │ Tu │ We │ Th │ Fr │ Sa │");
            PlaceDaysWithEvents(calendar, daysInSlots, events);
            calendar.AppendLine("└────┴────┴────┴────┴────┴────┴────┘");
            return calendar.ToString();
        }

        /// <summary>
        /// Creates the days part of the calendar with events
        /// </summary>
        /// <param name="calendar">The StringBuilder already used for creating the calendar</param>
        /// <param name="daysInSlots">A 2D array with the day numbers in the corresponding weeks and days</param>
        /// <param name="events">The day numbers with events</param>
        private static void PlaceDaysWithEvents(StringBuilder calendar, int[,] daysInSlots, int[] events)
        {
            for (int row = 0; row < 6; row++)
            {
                calendar.AppendLine("├────┼────┼────┼────┼────┼────┼────┤");
                for (int day = 0; day < 7; day++)
                {
                    string numberDisplay;
                    if (daysInSlots[row, day] == 0) 
                        numberDisplay = " -- ";
                    else
                    {
                        if (events.Contains(daysInSlots[row, day]))
                            numberDisplay = "!" + daysInSlots[row,day]+"!";
                        else
                            numberDisplay = " "+daysInSlots[row,day].ToString("D2")+" ";
                    }
                    calendar.Append("│" + numberDisplay);
                }
                calendar.AppendLine("│");
            }
        }

        /// <summary>
        /// Centers the header of the calendar (Month + Year)
        /// </summary>
        private static string PadMiddle(Month month, int year,int size)
        {
            string baseString = month.ToString() + " " + year;
            if (baseString.Length >= size) return baseString;
            decimal numberOfSpaces = (size - baseString.Length) / 2m;
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
