using AutomationExercise.NUnit.Models;
using AutomationExercise.NUnit.Utils;

namespace AutomationExercise.NUnit;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    private HomePage homePage;

    [SetUp]
    public async Task BeforeAll()
    {
        homePage = new HomePage(await Browser.NewPageAsync());
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
        await homePage.SignupUserWithEmail(name, email);
        await homePage.EnterAccountInformation(
            isMale,
            password,
            birthDay,
            birthMonth,
            birthYear,
            isSubscribedNewsletter,
            isSubscribedSpecialOffers,
            address
        );

        await homePage.continueButton.ClickAsync();

        await homePage.deleteAccountButton.ClickAsync(new() { Timeout = 12000 });
    }
}
