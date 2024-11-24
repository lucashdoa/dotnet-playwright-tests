using Microsoft.Playwright;
using AutomationExercise.NUnit.Utils;

namespace AutomationExercise.NUnit.Models;

public class HomePage
{
    private readonly IPage _page;
    private readonly ILocator _signupLoginButton;
    private readonly ILocator _signupNameInput;
    private readonly ILocator _signupEmailInput;
    private readonly ILocator _signupButton;
    private readonly ILocator _genderMaleRadio;
    private readonly ILocator _genderFemaleRadio;
    private readonly ILocator _passwordInput;
    private readonly ILocator _birthDaySelect;
    private readonly ILocator _birthMonthSelect;
    private readonly ILocator _birthYearSelect;
    private readonly ILocator _newsletterSelect;
    private readonly ILocator _offersSelect;
    private readonly ILocator _firstNameInput;
    private readonly ILocator _lastNameInput;
    private readonly ILocator _addressInput;
    private readonly ILocator _countrySelect;
    private readonly ILocator _stateInput;
    private readonly ILocator _cityInput;
    private readonly ILocator _zipcodeInput;
    private readonly ILocator _mobileNumberInput;
    private readonly ILocator _createAccountButton;
    public readonly ILocator accountCreatedMessage;
    public ILocator continueButton;
    public readonly ILocator deleteAccountButton;


    public HomePage(IPage page)
    {
        _page = page;
        _signupLoginButton = page.Locator("a[href*=login]");
        _signupNameInput = page.Locator("[data-qa=signup-name]");
        _signupEmailInput = page.Locator("[data-qa=signup-email]");
        _signupButton = page.Locator("[data-qa=signup-button]");
        _genderMaleRadio = page.Locator("#id_gender1");
        _genderFemaleRadio = page.Locator("#id_gender2");
        _passwordInput = page.Locator("#password");
        _birthDaySelect = page.Locator("#days");
        _birthMonthSelect = page.Locator("[data-qa='months']");
        _birthYearSelect = page.Locator("#years");
        _newsletterSelect = page.Locator("#newsletter");
        _offersSelect = page.Locator("#optin");
        _firstNameInput = page.Locator("#first_name");
        _lastNameInput = page.Locator("#last_name");
        _addressInput = page.Locator("#address1");
        _countrySelect = page.Locator("#country");
        _stateInput = page.Locator("#state");
        _cityInput = page.Locator("#city");
        _zipcodeInput = page.Locator("#zipcode");
        _mobileNumberInput = page.Locator("#mobile_number");
        _createAccountButton = page.Locator("[data-qa='create-account']");
        accountCreatedMessage = page.Locator("[data-qa='create-account']");
        continueButton = page.Locator("[data-qa='continue-button']");
        deleteAccountButton = page.Locator("a[href*='delete_account']");
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

    public async Task EnterAccountInformation(
        bool isMale,
        string password,
        string birthDay,
        string birthMonth,
        string birthYear,
        bool isSubscribedNewsletter,
        bool isSubscribedSpecialOffers,
        Address address
    )
    {
        if (isMale)
        {
            await _genderMaleRadio.CheckAsync();
        }
        else
        {
            await _genderFemaleRadio.CheckAsync();
        }

        await _passwordInput.FillAsync(password);

        await _birthDaySelect.SelectOptionAsync(birthDay);
        await _birthMonthSelect.SelectOptionAsync(birthMonth);
        await _birthYearSelect.SelectOptionAsync(birthYear);

        if (isSubscribedNewsletter)
        {
            await _newsletterSelect.CheckAsync();
        }

        if (isSubscribedSpecialOffers)
        {
            await _offersSelect.CheckAsync();
        }

        await _firstNameInput.FillAsync(address.firstName);
        await _lastNameInput.FillAsync(address.lastName);
        await _addressInput.FillAsync(address.fullAddress);
        await _countrySelect.SelectOptionAsync(address.country);
        await _stateInput.FillAsync(address.state);
        await _cityInput.FillAsync(address.city);
        await _zipcodeInput.FillAsync(address.zipcode);
        await _mobileNumberInput.FillAsync(address.phone);

        await _createAccountButton.ClickAsync();
    }
}