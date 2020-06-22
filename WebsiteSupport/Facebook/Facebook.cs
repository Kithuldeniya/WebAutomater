using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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
            LogManager.GetCurrentClassLogger().Debug("Login to facebook");
            AppWebDriver
                .NavigateTo("https://www.facebook.com")
                .SetElementById("email").SendKeyToElement("rajitha.kithuldeniya@gmail.com")
                .SetElementById("pass").SendKeyToElement("Ruk@9071")
                .SetElementById("loginbutton").Click();
        }

        public void Logout()
        {
            LogManager.GetCurrentClassLogger().Debug("Login out from facebook");
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
            LogManager.GetCurrentClassLogger().Debug($"Facebook comment -> itarate : {itarate} ; Post link : {postLink}");

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
            LogManager.GetCurrentClassLogger().Debug($"Facebook comment : {comment}");
            AppWebDriver
                .SendKey(comment)
                .SendEnter();
        }

        public void SharePost(string postLink, List<string> groups)
        {
            LogManager.GetCurrentClassLogger().Debug($"Facebook share -> Post link : {postLink}");

            AppWebDriver
                .NavigateTo(postLink)
                .Sleep(2);

            //dom load share button
            AppWebDriver.SetElementByXPath(@"//a[@title='Send this to friends or post it on your Timeline.']")
                .ScrollTo()
                .Sleep(2);


            foreach (var group in groups)
            {
                LogManager.GetCurrentClassLogger().Debug($"Facebook share -> starting share to group : {group}");

                try
                {
                    AppWebDriver
                        .SetElementByXPath(@"//a[@title='Send this to friends or post it on your Timeline.']")
                        .MouseCrossElement()
                        .Sleep(2)
                        //click share button
                        .SetElementByXPath(@"//a[@title='Send this to friends or post it on your Timeline.']")
                        .Click()
                        //Share in a group click
                        .SetElementByXPath(@"//li/a/span/span[text() = 'Share in a group']")
                        .Click()
                        //select input
                        .SetElementByXPath(@"//label/input[@placeholder='Group name']")
                        .Click()
                        .Sleep(1)
                        //type and select group
                        .SendKeyWithIntervals(group)
                        .Sleep(2);

                    AppWebDriver
                        .SendKeyDown()
                        .SendEnter()
                        .Sleep(1);


                    if (!AppWebDriver.ElementExsist(@"//label/input[@placeholder='Group name']/../../../img"))
                    {
                        LogManager.GetCurrentClassLogger().Error($"****** Cant Find the group ({group}) in the drop dwown");

                        AppWebDriver.SetElementByXPath(@"//button[text()='Cancel']")
                       .Click();

                        continue;
                    }

                    //post
                    AppWebDriver.SetElementByXPath(@"//div[@class='clearfix']//button[text() = 'Post']")
                        .Click()
                        .Sleep(2);


                    //if cant post
                    if (AppWebDriver.ElementExsist(@"//a[text()='Close']"))
                    {
                        LogManager.GetCurrentClassLogger().Error($"****** Cant share to the group : {group}");
                        AppWebDriver
                            .SetElementByXPath(@"//a[text()='Close']")
                            .Click();
                    }

                    LogManager.GetCurrentClassLogger().Debug($"Group : {group}, Share Success");
                }
                catch (Exception e)
                {
                    LogManager.GetCurrentClassLogger().Error($"****** Something went worong for group : {group}");
                    LogManager.GetCurrentClassLogger().Error(e);

                    AppWebDriver
                        .NavigateTo(postLink)
                        .Sleep(2);

                    //dom load share button
                    AppWebDriver.SetElementByXPath(@"//a[@title='Send this to friends or post it on your Timeline.']")
                        .ScrollTo()
                        .Sleep(2);

                }

            }

            LogManager.GetCurrentClassLogger().Debug("Shrare compleate.");
        }
    }
}
