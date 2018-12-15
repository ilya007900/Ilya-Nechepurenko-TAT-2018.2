using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_8
{
    class VKHomePage
    {
        public const string MessagesId = "l_msg";

        public VKHomePage(WebDriverWait wait)
        {
            Messages = wait.Until(x => x.FindElement(By.Id(MessagesId)));
            Wait = wait;
        }

        public IWebElement Messages { get; private set; }

        public WebDriverWait Wait { get; set; }

        /// <summary>
        /// Clicks on Messages
        /// </summary>
        /// <returns>VKMessagesPage</returns>
        public VKMessagesPage MessagesClick()
        {
            Messages.Click();
            return new VKMessagesPage(Wait);
        }
    }
}
