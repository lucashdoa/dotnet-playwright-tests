using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ExampleTest : PageTest
{
    [Test]
    public async Task HasTitle()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
    }

    [Test]
    public async Task GetStartedLink()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Getting variables from runsettings
        var envVariable = Environment.GetEnvironmentVariable("SUBSCRIBE");
        var testParam = TestContext.Parameters["CommitQuality"];

        Assert.That(envVariable, Is.EqualTo("Example environment variable"));
        Assert.That(testParam, Is.EqualTo("Example test parameter"));


        // Click the get started link.
        await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();

        // Expects page to have a heading with the name of Installation.
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" })).ToBeVisibleAsync();
    }

    [Test]
    public async Task Assertions()
    {
        await Page.GotoAsync("https://commitquality.com");

        await Expect(Page).ToHaveTitleAsync(new Regex("CommitQuality"), new PageAssertionsToHaveTitleOptions { Timeout = 2000});

        var firstRowName = Page.GetByTestId("name").First;

        await Expect(firstRowName).ToHaveTextAsync("Product 2", new LocatorAssertionsToHaveTextOptions { Timeout = 2000});
    }
}