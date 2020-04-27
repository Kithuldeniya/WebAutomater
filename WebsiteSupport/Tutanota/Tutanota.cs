using System;
using System.Collections.Generic;
using System.Text;
using WebDriverSupport;

namespace WebsiteSupport.Tutanota
{
    

    public class Tutanota
    {
        public AppWebDriver AppWebDriver { get; set; }

        public Tutanota()
        {
            AppWebDriver = new AppWebDriver();
        }

        public void SignUp()
        {
            AppWebDriver
                .NavigateTo("https://mail.tutanota.com/signup")
                .SetElementByXPath(@"//*[contains(text(), 'Free')]/..//button").Click()
                .SetElementByCss(@".primary > .text-ellipsis").Click()
                .SetElementByXPath(@"//small[contains(text(), 'Please enter mail address.')]").Click()
                .SendKey("MyEmail")
                .SetElementByXPath(@"//div[contains(text(), 'Please enter a new password.')]").Click()
                .SendKey("Mypass")
                .SetElementByXPath(@"//div[contains(text(), 'Please confirm your password.')]").Click()
                .SendKey("Mypass")
                .SetElementByXPath(@"//div[contains(text(), 'I have read and')]").Click()
                .SetElementByXPath(@"//div[contains(text(), 'I am at least 16')]").Click()
                .SetElementByXPath(@"//button[@title='Next']").Click()
                .SetElementByXPath(@"//div[contains(text(), 'Ok')]//..").Click()
                .SetElementByCss(@".text-field:nth-child(2) .input").Click().SendKey("Mypass")
                .SetElementByXPath(@"//div[contains(text(), 'Log in')]//..").Click();
        }
    }
}
