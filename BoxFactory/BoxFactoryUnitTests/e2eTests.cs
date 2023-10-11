using NUnit.Framework;
using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;

namespace BoxFactoryUnitTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]

public class e2eTests : PageTest
{
    [Test]
    public async Task MyTest()
    {
        await Page.GotoAsync("http://localhost:4200/boxes");

        await Page.GetByRole(AriaRole.Button, new() { Name = "View Orders" }).ClickAsync();

        await Page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();

        await Page.Locator("input[name=\"street\"]").ClickAsync();

        await Page.Locator("input[name=\"street\"]").FillAsync("1");

        await Page.Locator("input[name=\"number\"]").ClickAsync();

        await Page.Locator("input[name=\"number\"]").FillAsync("2");

        await Page.Locator("input[name=\"city\"]").ClickAsync();

        await Page.Locator("input[name=\"city\"]").FillAsync("3");

        await Page.Locator("input[name=\"zip\"]").ClickAsync();

        await Page.Locator("input[name=\"zip\"]").FillAsync("5000");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();

        await Page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();

        await Page.GetByRole(AriaRole.Button, new() { Name = "Cancel" }).ClickAsync();

        await Page.GetByRole(AriaRole.Button, new() { Name = "View Boxes" }).ClickAsync();

        await Page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();

        await Page.Locator("input[name=\"width\"]").ClickAsync();

        await Page.Locator("input[name=\"width\"]").FillAsync("1");

        await Page.Locator("input[name=\"height\"]").ClickAsync();

        await Page.Locator("input[name=\"height\"]").FillAsync("2");

        await Page.Locator("input[name=\"length\"]").ClickAsync();

        await Page.Locator("input[name=\"length\"]").FillAsync("3");

        await Page.Locator("input[name=\"weight\"]").ClickAsync();

        await Page.Locator("input[name=\"weight\"]").FillAsync("4");

        await Page.GetByRole(AriaRole.Combobox).SelectOptionAsync(new[] { "Blue" });

        await Page.Locator("input[name=\"price\"]").ClickAsync();

        await Page.Locator("input[name=\"price\"]").FillAsync("499");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();

        await Page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();

        await Page.GetByRole(AriaRole.Button, new() { Name = "Cancel" }).ClickAsync();

        await Page.GetByLabel("search text").ClickAsync();

        await Page.GetByLabel("search text").FillAsync("5000");

        await Page.GetByLabel("reset").ClickAsync();

    }
}