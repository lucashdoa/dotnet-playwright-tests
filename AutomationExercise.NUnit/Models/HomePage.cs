using Microsoft.Playwright;

namespace AutomationExercise.NUnit.Models;

public class HomePage
{
    private readonly IPage _page;
    private readonly ILocator _signupLoginButton;
    private readonly ILocator _signupNameInput;
    private readonly ILocator _signupEmailInput;
    private readonly ILocator _signupButton;

    public HomePage(IPage page)
    {
        _page = page;
        _signupLoginButton = page.Locator("a[href*=login]");
        _signupNameInput = page.Locator("[data-qa=signup-name]");
        _signupEmailInput = page.Locator("[data-qa=signup-email]");
        _signupButton = page.Locator("[data-qa=signup-button]");
    }

    public async Task GoToAsync()
    {
        await _page.GotoAsync("https://automationexercise.com/");
    }

    public async Task SignupUserWithEmail(string user, string email)
    {
        await _signupLoginButton.ClickAsync();
        await _signupNameInput.FillAsync(user);
        await _signupEmailInput.FillAsync(email);
        await _signupButton.ClickAsync();
    }
}