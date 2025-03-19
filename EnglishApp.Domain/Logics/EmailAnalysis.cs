using System.Globalization;
using System.Text.RegularExpressions;

namespace EnglishApp.Domain.Logics;

public static class EmailAnalysis
{
    public static bool IsValid(string email)
    {
        if (String.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        try
        {
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
        catch (ArgumentException)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    private static string DomainMapper(Match match)
    {
        IdnMapping idn = new();

        string domainName = idn.GetAscii(match.Groups[2].Value);

        return match.Groups[1].Value + domainName;
    }
}
