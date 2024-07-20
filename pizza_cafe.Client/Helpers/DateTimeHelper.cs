namespace pizza_cafe.Client.Helpers;

public class DateTimeHelper
{
    public static string GetCurrentDateTime()
    {
        return DateTime.Now.ToString("dd.MM.yyyy_HH:mm");
    }
}