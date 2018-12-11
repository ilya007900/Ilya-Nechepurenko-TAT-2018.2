using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DEV_8
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                IWebDriver driver = new ChromeDriver(@"D:\drivers\chrome");
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                VKTester messagesGetter = new VKTester(driver, wait);
                foreach (string messsage in messagesGetter.GetUnreadMessages(Data.Login, Data.Password))
                {
                    Console.WriteLine(messsage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
