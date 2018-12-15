using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DEV_8
{
    /// <summary>
    /// This program outputs unread messages to console
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point of program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                IWebDriver driver = new ChromeDriver(@"D:\drivers\chrome");
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                VKTester VKTester = new VKTester(driver, wait);
                foreach (string messsage in VKTester.GetUnreadMessages(Data.Login, Data.Password))
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
