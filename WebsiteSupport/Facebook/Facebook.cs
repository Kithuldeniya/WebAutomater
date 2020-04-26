using System;
using System.Collections.Generic;
using System.Text;
using WebDriverSupport;

namespace WebsiteSupport.Facebook
{
    public class Facebook
    {
        public AppWebDriver AppWebDriver { get; set; }
        public Facebook()
        {
            AppWebDriver = new AppWebDriver();
        }

        public void Login()
        {
            AppWebDriver
                .NavigateTo("https://www.facebook.com")
                .SetElementById("email").SendKeyToElement("rajitha.kithuldeniya@gmail.com")
                .SetElementById("pass").SendKeyToElement("Ruk@9071")
                .SetElementById("loginbutton").Click();
        }

        public void Logout()
        {
            AppWebDriver
                .NavigateTo("https://www.facebook.com")
                .SetElementById("logoutMenu").Click()
                .SetElementByLinkText("Log Out").Click();

            AppWebDriver.CloseDriver();
        }

        public void PostComment(string postLink, string comment)
        {
            var comments = new List<string>() { comment };
            PostComment(postLink, comments, 1);
        }

        public void PostComment(string postLink, string comment, int itarate)
        {
            var comments = new List<string>() { comment };
            PostComment(postLink, comments, itarate);
        }

        public void PostComment(string postLink, List<string> comments, int itarate)
        {
            AppWebDriver
                .NavigateTo(postLink)
                .SetElementByXPath(@"//*[contains(text(), 'Write a comment...')]")
                .Click();
            for (int i = 0; i < itarate; i++)
            {
                foreach (string comment in comments)
                {
                    PostComment(comment);
                }
            }

        }

        private void PostComment(string comment)
        {
            AppWebDriver
                .SendKey(comment)
                .SendEnter();
        }





    }
}
