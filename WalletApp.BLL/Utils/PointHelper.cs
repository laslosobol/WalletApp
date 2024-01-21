namespace WalletApp.BLL.Utils;

public static class PointHelper
{
    public static string CalculateTotalPoints(DateTime registrationDate)
    {
        DateTime currentDate = DateTime.Today;
        int totalPoints = 0;
        
        DateTime seasonStart = GetSeasonStartDate(registrationDate);
        if (registrationDate != seasonStart)
        {
            registrationDate = GetNextSeasonStartDate(registrationDate);
        }

        while (registrationDate < currentDate)
        {
            DateTime seasonEnd = GetSeasonEndDate(registrationDate);
            DateTime endOfPeriod = seasonEnd < currentDate ? seasonEnd : currentDate;

            totalPoints += CalculatePointsForSeason(registrationDate, endOfPeriod);
            registrationDate = GetNextSeasonStartDate(seasonEnd.AddDays(1));
        }

        return FormatPoints(totalPoints);
    }
    private static DateTime GetSeasonStartDate(DateTime date)
    {
        int year = date.Year;
        if (date.Month < 3 || (date.Month == 3 && date.Day < 1)) return new DateTime(year - 1, 12, 1);
        if (date.Month < 6 || (date.Month == 6 && date.Day < 1)) return new DateTime(year, 3, 1);
        if (date.Month < 9 || (date.Month == 9 && date.Day < 1)) return new DateTime(year, 6, 1);
        return new DateTime(year, 9, 1);
    }
    private static int CalculatePointsForSeason(DateTime start, DateTime end)
    {
        int days = (end - start).Days + 1;
        int points = 0;

        if (days == 1) return 2;
        if (days == 2) return 5;

        int prevPoints = 3;
        int prevPrevPoints = 2;
        points = 5;
        for (int i = 3; i <= days; i++)
        {
            int currentPoints = prevPoints + (int)(0.6 * prevPrevPoints);
            prevPrevPoints = prevPoints;
            prevPoints = currentPoints;
            points += currentPoints;
        }

        return points;
    }

    private static DateTime GetNextSeasonStartDate(DateTime date)
    {
        int year = date.Year;
        if (date.Month < 3 || (date.Month == 3 && date.Day < 1)) return new DateTime(year, 3, 1);
        if (date.Month < 6 || (date.Month == 6 && date.Day < 1)) return new DateTime(year, 6, 1);
        if (date.Month < 9 || (date.Month == 9 && date.Day < 1)) return new DateTime(year, 9, 1);
        if (date.Month < 12 || (date.Month == 12 && date.Day < 1)) return new DateTime(year + 1, 3, 1);
        return new DateTime(year + 1, 3, 1);
    }

    private static DateTime GetSeasonEndDate(DateTime date)
    {
        int year = date.Year;
        if (date.Month <= 5) return new DateTime(year, 5, 31);
        if (date.Month <= 8) return new DateTime(year, 8, 31);
        if (date.Month <= 11) return new DateTime(year, 11, 30);
        return new DateTime(year, 2, DateTime.IsLeapYear(year) ? 29 : 28);
    }

    private static string FormatPoints(int points)
    {
        if (points < 1000) return points.ToString();
        return (points / 1000) + "K";
    }
}