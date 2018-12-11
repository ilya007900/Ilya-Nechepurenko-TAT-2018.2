using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_8
{
    class VKLoginPage
    {
        const string LoginFieldId = "index_email";
        const string PasswordFieldId = "index_pass";
        const string LoginButtonId = "index_login_button";

        public IWebElement LoginField { get; private set; }
        public IWebElement PasswordField { get; private set; }
        public IWebElement LoginButton { get; private set; }

        public VKLoginPage(WebDriverWait wait)
        {
            LoginField = wait.Until(x => x.FindElement(By.Id(LoginFieldId)));
            PasswordField = wait.Until(x => x.FindElement(By.Id(PasswordFieldId)));
            LoginButton = wait.Until(x => x.FindElement(By.Id(LoginButtonId)));
        }

        public void LogIn(string login, string password)
        {
            LoginField.SendKeys(login);
            PasswordField.SendKeys(password);
            LoginButton.Click();
        }
    }
}
