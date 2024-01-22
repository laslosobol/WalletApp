namespace WalletApp.BLL.Utils;

public static class PointHelper
{
    private static DateTime GetSeasonStartDate(int year, string season)
    {
        switch (season)
        {
            case "Winter": return new DateTime(year, 12, 1);
            case "Spring": return new DateTime(year, 3, 1);
            case "Summer": return new DateTime(year, 6, 1);
            case "Fall": return new DateTime(year, 9, 1);
            default: throw new ArgumentException("Invalid season");
        }
    }

    private static string FindSeason(DateTime date)
    {
        int year = date.Year;
        if (date >= GetSeasonStartDate(year, "Winter")) return "Winter";
        if (date >= GetSeasonStartDate(year, "Fall")) return "Fall";
        if (date >= GetSeasonStartDate(year, "Summer")) return "Summer";
        if (date >= GetSeasonStartDate(year, "Spring")) return "Spring";
        return "Winter";
    }

    public static string CalculatePoints(DateTime registrationDate)
    {
        DateTime currentDate = DateTime.Today;
        string season = FindSeason(registrationDate);
        DateTime seasonStartDate = GetSeasonStartDate(registrationDate.Year, season);

        if ((registrationDate - seasonStartDate).Days >= 2) return "0";

        double pointsPrevious = 3;
        double pointsTwoDaysAgo = 2;
        double totalPoints = 0;

        for (int i = 2; i <= (currentDate - seasonStartDate).Days; i++)
        {
            double pointsToday = 0.6 * pointsPrevious + pointsTwoDaysAgo;
            totalPoints += Math.Round(pointsToday);
            pointsTwoDaysAgo = pointsPrevious;
            pointsPrevious = pointsToday;
        }

        if ((currentDate - seasonStartDate).Days >= 0) totalPoints += 2;
        if ((currentDate - seasonStartDate).Days >= 1) totalPoints += 3;

        if (totalPoints > 1000) return $"{Math.Round(totalPoints / 1000)}k";
        return totalPoints.ToString();
    }
}