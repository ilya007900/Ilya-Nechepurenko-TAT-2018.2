using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_8
{
    class VKLoginPage
    {
        public const string LoginFieldId = "index_email";
        public const string PasswordFieldId = "index_pass";
        public const string LoginButtonId = "index_login_button";

        public IWebElement LoginField { get; private set; }
        public IWebElement PasswordField { get; private set; }
        public IWebElement LoginButton { get; private set; }

        public WebDriverWait Wait { get; set; }

        public VKLoginPage(WebDriverWait wait)
        {
            LoginField = wait.Until(x => x.FindElement(By.Id(LoginFieldId)));
            PasswordField = wait.Until(x => x.FindElement(By.Id(PasswordFieldId)));
            LoginButton = wait.Until(x => x.FindElement(By.Id(LoginButtonId)));
            Wait = wait;
        }

        /// <summary>
        /// Logs in VK
        /// </summary>
        /// <param name="login">Login from page</param>
        /// <param name="password">Password from page</param>
        /// <returns>VKHomePage</returns>
        public VKHomePage LogIn(string login, string password)
        {
            LoginField.SendKeys(login);
            PasswordField.SendKeys(password);
            LoginButton.Click();
            return new VKHomePage(Wait);
        }
    }
}
