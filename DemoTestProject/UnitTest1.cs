using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace DemoTestProject
{
    [TestClass]
    public class MMT
    {
        public static IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-popup-blocking");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://www.makemytrip.com");
            driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void Cleanup()
        {
            //driver.Quit();
        }

        [TestMethod]
        public void A_SearchFlights()

        {
            try
            {
                driver.FindElement(By.Id("fromCity")).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(driver.FindElement(By.XPath("//input[@placeholder='From']"))));
                driver.FindElement(By.XPath("//input[@placeholder='From']")).SendKeys("Delhi");
                driver.FindElement(By.Id("toCity")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(driver.FindElement(By.XPath("//input[@placeholder='To']"))));
                driver.FindElement(By.XPath("//input[@placeholder='To']")).SendKeys("Mumbai");
            }
            catch
            {
                              
            }
        }



    }
}