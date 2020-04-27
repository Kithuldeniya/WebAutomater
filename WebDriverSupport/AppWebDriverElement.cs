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



        public AppWebDriver SetElementById(string id)
        {

            Element = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
            return this;
        }

        public AppWebDriver SetElementByCss(string css)
        {

            Element = Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(css)));
            return this;
        }

        public AppWebDriver SetElementByLinkText(string text)
        {

            Element = Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(text)));
            return this;
        }

        public AppWebDriver SetElementByXPath(string path)
        {

            Element = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(path)));
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

            //Actions.UserKeyboard.TextEntry(text);

            return this;
        }
        public AppWebDriver SendEnter()
        {

            Actions builder = new Actions(Driver);
            builder.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(1000);

            return this;
        }

        private AppWebDriver MouseCrossElement()
        {
            var a = Element;
            var elementPoint = Element.Location;
            var elementMiddle = new Point(elementPoint.X + (Element.Size.Width / 2), elementPoint.Y + 120 + (Element.Size.Height / 2));
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
            throw new NotImplementedException();

        }

        public AppWebDriver Click()
        {

            MouseCrossElement();

            Actions builder = new Actions(Driver);
            builder.MoveToElement(Element).Build().Perform();

            Element.Click();
            return this;
        }
    }
}
