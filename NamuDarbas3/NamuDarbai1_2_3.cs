using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamuDarbas3
{
    internal class NamuDarbai1_2_3
    {
        private static IWebDriver driver;

        [OneTimeSetUp]
        public static void OneTimeSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Manage().Window.Maximize();
            driver.Url = "https://demoqa.com/checkbox";
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }

        [Test]
        public static void NamuDarbas3_1()
        {
            IWebElement expandAllButton = driver.FindElement(By.CssSelector("#tree-node > div > button.rct-option.rct-option-expand-all"));
            expandAllButton.Click();

            IWebElement commandBox = driver.FindElement(By.XPath("//body/div[@id='app']/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/ol[1]/li[1]/ol[1]/li[1]/ol[1]/li[2]/span[1]/label[1]/span[1]/*[1]"));
            commandBox.Click();

            string actualResult = driver.FindElement(By.XPath("//span[@class='text-success']")).Text;
            string expectedResult = "commands";
            Assert.AreEqual(expectedResult, actualResult, "Tekstas neatitinka");
        }

        [Test]
        public static void NamuDarbas3_2()
        {

            driver.Navigate().Refresh();

            IWebElement expandAllButton = driver.FindElement(By.CssSelector("#tree-node > div > button.rct-option.rct-option-expand-all"));
            expandAllButton.Click();

            IWebElement desktop = driver.FindElement(By.XPath("//body/div[@id='app']/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/ol[1]/li[1]/ol[1]/li[1]/span[1]/label[1]/span[1]/*[1]"));
            desktop.Click();

            IWebElement downloads = driver.FindElement(By.XPath("//body/div[@id='app']/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/ol[1]/li[1]/ol[1]/li[3]/span[1]/label[1]/span[1]/*[1]"));
            downloads.Click();

            string actualResult = driver.FindElement(By.Id("result")).Text;
            string expectedResult = "You have selected :\r\ndesktop\r\nnotes\r\ncommands\r\ndownloads\r\nwordFile\r\nexcelFile";
            Assert.AreEqual(expectedResult, actualResult, "Tekstas neatitinka");
        }

        [Test]
        public static void NamuDarbas3_3()
        {
            driver.Navigate().Refresh();

            IWebElement expandAllButton = driver.FindElement(By.CssSelector("#tree-node > div > button.rct-option.rct-option-expand-all"));
            expandAllButton.Click();

            IWebElement notes = driver.FindElement(By.XPath("//body/div[@id='app']/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/ol[1]/li[1]/ol[1]/li[1]/ol[1]/li[1]/span[1]/label[1]/span[1]/*[1]"));
            notes.Click();

            IWebElement general = driver.FindElement(By.XPath("//body/div[@id='app']/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/ol[1]/li[1]/ol[1]/li[2]/ol[1]/li[2]/ol[1]/li[4]/span[1]/label[1]/span[1]/*[1]"));
            general.Click();

            string actualResult = driver.FindElement(By.Id("result")).Text;
            Console.WriteLine(actualResult);
            string expectedResult = "You have selected :\r\nnotes\r\ngeneral";
            Assert.AreEqual(expectedResult, actualResult, "Tekstas neatitinka");
        }
    }
}
