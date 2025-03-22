using System.Configuration;

namespace EnglishApp.Domain;

public static class Shared
{
    public static bool IsFake = ConfigurationManager.AppSettings["IsFake"] == "1";

    public static int UserId;
}
