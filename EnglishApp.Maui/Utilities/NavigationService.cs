using EnglishApp.Domain.Interfaces;

namespace EnglishApp.Maui.Utilities;

public sealed class NavigationService : INavigationService
{
    public Task NavigateToAsync(string route, Dictionary<string, object>? parameter = null, bool isRoot = false)
    {
        if (parameter is null)
        {
            return isRoot ? Shell.Current.GoToAsync(route) : Shell.Current.GoToAsync($"//{route}");
        }

        return isRoot ? Shell.Current.GoToAsync(route, parameter) : Shell.Current.GoToAsync($"//{route}", parameter);
    }
}
