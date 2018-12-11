using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_8
{
    class VKMessagesPage
    {
        const string UnreadMessagesXPath = "//li[contains(@class,'nim-dialog_unread')]";

        public VKMessagesPage(WebDriverWait wait)
        {
            UnreadDialogs = wait.Until(x => x.FindElements(By.XPath(UnreadMessagesXPath)));
        }

        public IList<IWebElement> UnreadDialogs { get; private set; }
    }
}
