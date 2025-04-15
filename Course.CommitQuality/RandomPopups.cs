using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class RandomPopups : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("https://commitquality.com/practice-random-popup");
    }

    [Test]
    public async Task Assertions()
    {
        // Setup handler in case overlay appears
        await Page.AddLocatorHandlerAsync(Page.GetByText("Random Popup"), 
        async() =>
        {
            await Page.GetByText("Close").ClickAsync();
        });


        await Task.Delay(6000);
        await Page.GetByTestId("accordion-1").ClickAsync(new () {Timeout = 2000});
    }

    [TearDown]
    public async Task TearDown()
    {
        
    }
}