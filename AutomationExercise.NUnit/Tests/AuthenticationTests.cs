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
    public async Task RegisterUser(User user)
    {
        await homePage.GoToAsync();
        await signupPage.SignupUserWithEmail(user.name, user.email);
        await signupPage.EnterAccountInformation(user);

        await Expect(accountCreatedPage.accountCreatedMessage).ToHaveTextAsync("Account Created!");

        await accountCreatedPage.ClickContinue();
        await homePage.DeleteAccount();
    }
}
