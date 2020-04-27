using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using UserAction;

namespace WebDriverSupport
{
    public partial class AppWebDriver
    {
        private IWebDriver Driver { get; set; }
        private UserActions Actions { get; set; }

        private WebDriverWait Wait { get; set; }


        public AppWebDriver()
        {
            CreateChromeDriver();
            Actions = new UserActions();
        }

        public AppWebDriver CreateChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments(
                "--incognito",
                "disable-infobars",
                "--disable-extensions",
                "--profile-directory=Default",
                "--disable-plugins-discovery",
                "--start-maximized");

            Driver = new ChromeDriver(options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            Driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(200);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(300);

            Wait = new WebDriverWait(Driver, new TimeSpan(0,2,0));

            return  this;
        }

        public AppWebDriver NavigateTo(string url)
        {
            //WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 10));
            //Element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(path)));
            if(Driver.Url == url)
            {
                Driver.Navigate().Refresh();
            }
            else
            {
                Driver.Navigate().GoToUrl(url);
            }

            return this;
        }

        public AppWebDriver CloseDriver()
        {
            Driver.Close();
            Driver.Dispose();
            return this;
        }
    }
}
