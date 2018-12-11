using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_8
{
    /// <summary>
    /// Provides methods to manipulation with VK pages
    /// </summary>
    class VKTester
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
        public const string Url = "https://vk.com";

        public VKTester(IWebDriver driver, WebDriverWait wait)
        {
            Driver = driver;
            Wait = wait;
        }

        /// <summary>
        /// Gets unread messages
        /// </summary>
        /// <param name="login">Login from page</param>
        /// <param name="password">Password from page</param>
        /// <returns>Unread messages</returns>
        public List<string> GetUnreadMessages(string login, string password)
        {
            Driver.Navigate().GoToUrl(Url);
            VKLoginPage VKLoginPage = new VKLoginPage(Wait);
            VKHomePage VKHomePage = VKLoginPage.LogIn(login, password); 
            VKMessagesPage VKMessagesPage = VKHomePage.MessagesClick();
            List<string> messages = new List<string>();
            foreach (var dialog in VKMessagesPage.UnreadDialogs)
            {
                dialog.Click();
                VKDialogPage VKDialogPage = new VKDialogPage(Wait);
                foreach (var message in VKDialogPage.Messages)
                {
                    messages.Add(message.Text);
                }
                Driver.Navigate().Back();
            }
            Driver.Quit();
            return messages;
        }
    }
}
