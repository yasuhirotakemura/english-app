namespace EnglishApp.Domain.Interfaces;

public interface INavigationService
{
    Task NavigateToAsync(string route, Dictionary<string, object>? parameter = null, bool isRoot = false);
}
