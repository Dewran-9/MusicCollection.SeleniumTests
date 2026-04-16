using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class UITests
{
    [Fact]
    public void FrontPage_ShowsTable()
    {

        var driver = new ChromeDriver();


        driver.Navigate().GoToUrl("http://127.0.0.1:5500/index.html");


        var table = driver.FindElement(By.Id("recordsTable"));
        Assert.NotNull(table);

        driver.Quit();
    }

    [Fact]
    public void FrontPage_ShowsLoginForm()
    {
        var driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://127.0.0.1:5500/index.html");

        var loginButton = driver.FindElement(By.XPath("//button[text()='Log ind']"));
        Assert.NotNull(loginButton);

        driver.Quit();
    }

    [Fact]
    public void FrontPage_CanLogin()
    {
        var driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://127.0.0.1:5500/index.html");

        driver.FindElement(By.Id("username")).SendKeys("admin");
        driver.FindElement(By.Id("password")).SendKeys("1234");
        driver.FindElement(By.XPath("//button[text()='Log ind']")).Click();

        System.Threading.Thread.Sleep(1000);
        driver.SwitchTo().Alert().Accept();

        var loginCard = driver.FindElement(By.Id("loginCard"));
        Assert.Equal("none", loginCard.GetCssValue("display"));

        driver.Quit();
    }
}