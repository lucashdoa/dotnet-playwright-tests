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
    public async Task RegisterUser(string name, string email)
    {
        await homePage.GoToAsync();
        await homePage.SignupUserWithEmail(name, email);
    }
}
