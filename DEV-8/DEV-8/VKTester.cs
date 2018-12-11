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
        private const string url = "https://vk.com";

        /// <summary>
        /// Redirects to dialogs
        /// </summary>
        private void GoToDialogs()
        {
            VKHomePage VKHomePage = new VKHomePage(Wait);
            VKHomePage.Messages.Click();
        }

        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }

        public VKTester(IWebDriver driver, WebDriverWait wait)
        {
            Driver = driver;
            Wait = wait;
        }

        /// <summary>
        /// Logs in VK
        /// </summary>
        /// <param name="login">Login from page</param>
        /// <param name="password">Password from page</param>
        public void LogIn(string login, string password)
        {
            Driver.Navigate().GoToUrl(url);
            VKLoginPage VKLoginPage = new VKLoginPage(Wait);
            VKLoginPage.LogIn(login, password);
        }

        /// <summary>
        /// Gets unread messages
        /// </summary>
        /// <param name="login">Login from page</param>
        /// <param name="password">Password from page</param>
        /// <returns>Unread messages</returns>
        public List<string> GetUnreadMessages(string login, string password)
        {
            LogIn(login, password);
            GoToDialogs();
            VKMessagesPage VKMessagesPage = new VKMessagesPage(Wait);
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
