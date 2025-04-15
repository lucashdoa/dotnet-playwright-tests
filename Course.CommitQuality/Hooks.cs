using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Hooks : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("https://commitquality.com");
    }

    [Test]
    public async Task Assertions()
    {
        await Expect(Page).ToHaveTitleAsync(new Regex("CommitQuality"), new PageAssertionsToHaveTitleOptions { Timeout = 2000});

        var firstRowName = Page.GetByTestId("name").First;

        await Expect(firstRowName).ToHaveTextAsync("Product 2", new LocatorAssertionsToHaveTextOptions { Timeout = 2000});
    }

    [TearDown]
    public async Task TearDown()
    {
        
    }
}