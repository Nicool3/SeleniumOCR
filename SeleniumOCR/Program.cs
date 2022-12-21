using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumOCR
{
    class Program
    {
        static void Main(string[] args)
        {
            ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true; // 关闭cmd窗口

            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = @"D:\Program Files\Google\Chrome\Application\chrome.exe";
            options.DebuggerAddress = "127.0.0.1:9527";
            //options.AddArguments("--disk-cache-dir=./cache");
            //options.AddArguments("--no-sandbox");
            WebDriver driver = new ChromeDriver(driverService, options);
            driver.Navigate().GoToUrl("https://pearocr.com/#/");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement element = wait.Until((d) =>
            {
                try
                {
                    return driver.FindElement(By.Id("addImage"));
                }
                catch (Exception ex)
                {
                    return null;
                }
            });

            //element.Click();
        }
    }
}
