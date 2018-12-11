using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_8
{
    class VKHomePage
    {
        const string MessagesId = "l_msg";

        public VKHomePage(WebDriverWait wait)
        {
            Messages = wait.Until(x => x.FindElement(By.Id(MessagesId)));
        }

        public IWebElement Messages { get; private set; }
    }
}
