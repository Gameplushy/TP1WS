namespace TP1WS
{
    internal enum Month : byte
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

    internal static class MonthHelper
    {
        internal static int GetDaysInMonth(Month month, int year)
        {
            if (month == Month.February)
            {
                if (DateTime.IsLeapYear(year))
                    return 29;
                else
                    return 28;
            }

            if (new Month[] { Month.January, Month.March, Month.May, Month.July, Month.August, Month.October, Month.December }.Contains(month))
                return 31;
            else return 30;
        }
    }
}
