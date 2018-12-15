using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_8
{
    class VKDialogPage
    {
        public const string UnreadMessagesXPath = "//h4[contains(@class,'unread_bar')]/following-sibling::div[1]//div[contains(@class,'text')]";

        public VKDialogPage(WebDriverWait wait)
        {
            Messages = wait.Until(x => x.FindElements(By.XPath(UnreadMessagesXPath)));
        }

        public IList<IWebElement> Messages { get; private set; }
    }
}
