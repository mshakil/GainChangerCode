using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace GainChangerSpecFlow
{
    [Binding]
    public class GainChangerScrapingStepDef
    {
        IWebDriver driver;
        const string UserName = "gainchanger";
        const string Password = "justdoit";

        [Given(@"Navigate to gainchanger login page")]
        public void GivenNavigateToGainchangerLoginPage()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cozy-fairy-5394bc.netlify.app/");
            Thread.Sleep(2000);
        }

        [When(@"User entered user name ""([^""]*)""")]
        public void WhenUserEnteredUserName(string username)
        {
            driver.FindElement(By.Id("username")).SendKeys(UserName);
            Thread.Sleep(1000);
        }

        [When(@"User entered password ""([^""]*)""")]
        public void WhenUserEnteredPassword(string password)
        {
            driver.FindElement(By.Id("password")).SendKeys(Password);
            Thread.Sleep(1000);
        }

        [When(@"Click on Login button")]
        public void WhenClickOnLoginButton()
        {
            driver.FindElement(By.Id("submit")).Click();
            Thread.Sleep(1000);
        }

        [Then(@"Gainchanger Website should be logged In")]
        public void ThenGainchangerWebsiteShouldBeLoggedIn()
        {
            bool page = driver.FindElement(By.ClassName("elementor-widget-container")).Displayed;
            Assert.IsTrue(page);
        }

        [When(@"User navigate to resouces page")]
        public void WhenUserNavigateToResoucesPage()
        {
            driver.Navigate().GoToUrl("https://www.gainchanger.com/resources/");
            Thread.Sleep(3000);
        }

        [When(@"Click on first blog")]
        public void WhenClickOnFirstBlog()
        {
            driver.FindElement(By.XPath("//article[1]/div/a")).Click();
            string readTime = driver.FindElement(By.XPath("//span[contains(@class,'span-reading-time')]/..")).Text;
            Assert.IsTrue(readTime.Contains("minute read"));
        }

        [Then(@"Scrape all the required tags")]
        public void ThenScrapeAllTheRequiredTags()
        {
            string title=driver.FindElement(By.XPath("//meta[@property='og:title']")).GetAttribute("content");

            string desc = driver.FindElement(By.XPath("//meta[@property='og:description']")).GetAttribute("content");

            IList<IWebElement> h1 = driver.FindElements(By.TagName("h1")).ToList();

            IList<IWebElement> h2 = driver.FindElements(By.TagName("h2")).ToList();

            IList<IWebElement> para = driver.FindElements(By.TagName("p")).ToList();

        }

        [Then(@"Save tags on JSON")]
        public void ThenSaveTagsOnJSON()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
