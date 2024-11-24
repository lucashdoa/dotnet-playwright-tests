using Microsoft.Playwright;
using AutomationExercise.NUnit.Utils;

namespace AutomationExercise.NUnit.Models;

public class HomePage
{
    private readonly IPage _page;
    private readonly ILocator _signupLoginButton;
    private readonly ILocator _deleteAccountButton;

    public HomePage(IPage page)
    {
        _page = page;
        _signupLoginButton = page.Locator("a[href*=login]");
        _deleteAccountButton = page.Locator("[href*='delete_account']");
    }

    public async Task GoToAsync()
    {
        await _page.GotoAsync("https://automationexercise.com/");
    }

    public async Task DeleteAccount()
    {
        await _deleteAccountButton.ClickAsync(new() { Timeout = 12000 });
    }
}