using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WebDriverSupport
{
    public partial class AppWebDriver
    {
        public IWebElement Element { get; set; }



        public AppWebDriver SetElementById(string id)
        {
            //WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 10));
            //Element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));

            Element = Driver.FindElement(By.Id(id));
            return this;
        }

        public AppWebDriver SetElementByLinkText(string text)
        {
            //WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 10));
            //Element = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(text)));

            Element = Driver.FindElement(By.LinkText(text));
            return this;
        }

        public AppWebDriver SetElementByXPath(string path)
        {
            //WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 10));
            //Element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(path)));

            Element = Driver.FindElement(By.XPath(path));
            return this;
        }

        public AppWebDriver SendKeyToElement(string text)
        {

            Actions builder = new Actions(Driver);
            builder.MoveToElement(Element).Perform();

            Element.SendKeys(text);

            return this;
        }

        public AppWebDriver SendKey(string text)
        {

            Actions builder = new Actions(Driver);
            builder.SendKeys(text).Perform();

            return this;
        }
        public AppWebDriver SendEnter()
        {

            Actions builder = new Actions(Driver);
            builder.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(1000);

            return this;
        }


        public AppWebDriver SendKeyWithIntervals(string text)
        {
            throw new NotImplementedException();

        }

        public AppWebDriver Click()
        {


            Actions builder = new Actions(Driver);
            builder.MoveToElement(Element).Perform();

            Element.Click();
            return this;
        }
    }
}
