using Microsoft.Playwright;
using AutomationExercise.NUnit.Utils;

namespace AutomationExercise.NUnit.Models;

public class AccountCreatedPage
{
    private readonly IPage _page;
    private readonly ILocator _continueButton;
    public readonly ILocator accountCreatedMessage;

    public AccountCreatedPage(IPage page)
    {
        _page = page;
        _continueButton = page.Locator("[data-qa='continue-button']");

        accountCreatedMessage = page.Locator("h2[data-qa='account-created'] b");
    }

    public async Task ClickContinue()
    {
        await _continueButton.ClickAsync();
    }
}