using AutomationExercise.NUnit.Models;
using AutomationExercise.NUnit.Utils;
using Microsoft.Playwright;

namespace AutomationExercise.NUnit;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    private HomePage homePage;
    private SignupPage signupPage;
    private AccountCreatedPage accountCreatedPage;

    [SetUp]
    public async Task BeforeAll()
    {
        IPage page = await Browser.NewPageAsync();
        homePage = new HomePage(page);
        signupPage = new SignupPage(page);
        accountCreatedPage = new AccountCreatedPage(page);
    }

    [Test, TestCaseSource(typeof(UserDataSource))]
    public async Task RegisterUser(
        string name,
        string email,
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
        await homePage.GoToAsync();
        await signupPage.SignupUserWithEmail(name, email);
        await signupPage.EnterAccountInformation(
            isMale,
            password,
            birthDay,
            birthMonth,
            birthYear,
            isSubscribedNewsletter,
            isSubscribedSpecialOffers,
            address
        );

        await Expect(accountCreatedPage.accountCreatedMessage).ToHaveTextAsync("Account Created!");

        await accountCreatedPage.ClickContinue();
        await homePage.DeleteAccount();
    }
}
