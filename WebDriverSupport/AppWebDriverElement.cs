using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using UserAction;

namespace WebDriverSupport
{
    public partial class AppWebDriver
    {
        public IWebElement Element { get; set; }

        public AppWebDriver Sleep(int sec)
        {
            LogManager.GetCurrentClassLogger().Debug($"Sleep for : {sec} Secs");
            Thread.Sleep(sec * 1000);
            return this;
        }

        public AppWebDriver SetElementById(string id)
        {
            LogManager.GetCurrentClassLogger().Debug($"SetElementById : {id}");
            Element = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
            return this;
        }

        public AppWebDriver SetElementByCss(string css)
        {
            LogManager.GetCurrentClassLogger().Debug($"SetElementByCss : {css}");
            Element = Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(css)));
            return this;
        }

        public AppWebDriver SetElementByLinkText(string text)
        {
            LogManager.GetCurrentClassLogger().Debug($"SetElementByLinkText : {text}");
            Element = Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(text)));
            return this;
        }

        public AppWebDriver SetElementByXPath(string path)
        {
            LogManager.GetCurrentClassLogger().Debug($"SetElementByXPath  : {path}");
            Element = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(path)));
            return this;
        }

        public AppWebDriver SendKeyToElement(string text)
        {
            LogManager.GetCurrentClassLogger().Debug($"SendKeyToElement : {text}");
            Actions builder = new Actions(Driver);
            builder.MoveToElement(Element).Perform();

            Element.SendKeys(text);

            return this;
        }

        public AppWebDriver SendKey(string text)
        {
            LogManager.GetCurrentClassLogger().Debug($"SendKey : {text}");
            Actions builder = new Actions(Driver);
            builder.SendKeys(text).Perform();

            //Actions.UserKeyboard.TextEntry(text);

            return this;
        }

        public AppWebDriver SendEnter()
        {
            LogManager.GetCurrentClassLogger().Debug($"Enter click");
            Actions builder = new Actions(Driver);
            builder.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(1000);

            return this;
        }

        public AppWebDriver SendKeyDown()
        {
            LogManager.GetCurrentClassLogger().Debug($"Down arrow click");
            Actions builder = new Actions(Driver);
            builder.SendKeys(Keys.ArrowDown).Perform();
            Thread.Sleep(1000);

            return this;
        }



        public  AppWebDriver MouseCrossElement()
        {
            LogManager.GetCurrentClassLogger().Debug($"Fake mouse movement");

            var broserSize = Driver.Manage().Window.Size;

            var a = Element;
            var elementPoint = Element.Location;
            var elementMiddle = new Point(
                (elementPoint.X % broserSize.Width) + (Element.Size.Width / 2),
                (elementPoint.Y % broserSize.Height) + 120 + (Element.Size.Height / 2));
            var pointA = new Point(elementMiddle.X, elementMiddle.Y - 20);
            var pointB = new Point(elementMiddle.X, elementMiddle.Y + 20);
            var pointC = new Point(elementMiddle.X -20, elementMiddle.Y);
            var pointD = new Point(elementMiddle.X + 20, elementMiddle.Y);
            Actions.UserMouse.MoveMouseWithVisible(pointA);
            Actions.UserMouse.MoveMouseWithVisible(pointB);
            Actions.UserMouse.MoveMouseWithVisible(pointC);
            Actions.UserMouse.MoveMouseWithVisible(pointD);

            return this;
        }


        public AppWebDriver SendKeyWithIntervals(string text)
        {
            LogManager.GetCurrentClassLogger().Debug($"SendKeyWithIntervals : {text}");
            foreach (var item in text)
            {
                Thread.Sleep(100);
                Actions.UserKeyboard.TextEntry(item);
            }

            return this;
        }

        public AppWebDriver Click(bool needMousemove = false)
        {
            LogManager.GetCurrentClassLogger().Debug($"Click");
            if (needMousemove)
                MouseCrossElement();

            Actions builder = new Actions(Driver);
            builder.MoveToElement(Element).Build().Perform();

            Element.Click();
            return this;
        }

        public AppWebDriver ScrollTo()
        {
            LogManager.GetCurrentClassLogger().Debug($"ScrollTo");
            IJavaScriptExecutor je = (IJavaScriptExecutor)Driver;
            je.ExecuteScript("arguments[0].scrollIntoView(true);", Element);

            return this;
        }

        public bool ElementExsist(string Xpath)
        {
            LogManager.GetCurrentClassLogger().Debug($"ElementExsist : {Xpath}");

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            var result = Driver.FindElements(By.XPath(Xpath)).Count > 0;

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            return result;
        }


    }
}
