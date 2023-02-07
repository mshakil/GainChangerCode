using TechTalk.SpecFlow;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;


namespace GainChangerSpecFlow
{
    [Binding]

    public class GainChangerScrapingStepDef : DriverHelper
    {
        string jsonSerialize = string.Empty;

        PageObjects pageObjects = new PageObjects();

        [Given(@"Navigate to gainchanger login page")]
        public void GivenNavigateToGainchangerLoginPage()
        {
            Driver.Navigate().GoToUrl("https://cozy-fairy-5394bc.netlify.app/");
                        
        }

        [When(@"User entered user name ""([^""]*)""")]
        public void WhenUserEnteredUserName(string username)
        {
            IWebElement userNameElement = SeleniumExtensions.FindElementWithWait(Driver, pageObjects.byUserNameTextBox);
            userNameElement.SendKeys(username);
        }

        [When(@"User entered password ""([^""]*)""")]
        public void WhenUserEnteredPassword(string password)
        {
            IWebElement passwordElement = SeleniumExtensions.FindElementWithWait(Driver, pageObjects.byPasswordTextBox);
            passwordElement.SendKeys(password);
        }

        [When(@"Click on Login button")]
        public void WhenClickOnLoginButton()
        {
            IWebElement loginButton = SeleniumExtensions.FindElementWithWait(Driver, pageObjects.byLoginButton);
            loginButton.Click();
        }

        [Then(@"Gainchanger Website should be logged In")]
        public void ThenGainchangerWebsiteShouldBeLoggedIn()
        {
            bool isLoginSuccessfull = SeleniumExtensions.FindElementWithWait(Driver, pageObjects.byWidgetContainer).Displayed;
            Assert.IsTrue(isLoginSuccessfull, "Login to application is not successfull");
        }

        [When(@"User navigate to resouces page")]
        public void WhenUserNavigateToResoucesPage()
        {
            Driver.Navigate().GoToUrl("https://www.gainchanger.com/resources/");

            IWebElement headingTitle = SeleniumExtensions.FindElementWithWait(Driver, pageObjects.byWidgetContainer);
            Assert.AreEqual("GainChanger Resources", headingTitle.Text, "Resources page heading title is not same as expected.");
        }

        [When(@"Click on first blog")]
        public void WhenClickOnFirstBlog()
        {

            IWebElement article = Driver.FindElement(pageObjects.byFirstArticle);
            SeleniumExtensions.ScrollToElement(Driver, article);
            article.Click();


            string readTime = Driver.FindElement(pageObjects.byReadTime).Text;
            Assert.IsTrue(readTime.Contains("minute read"));
        }

        [Then(@"Scrape all the required tags")]
        public void ThenScrapeAllTheRequiredTags()
        {
            string title = Driver.FindElement(pageObjects.byMetaTitle).GetAttribute("content");
            string desc = Driver.FindElement(pageObjects.byMetaDescription).GetAttribute("content");
            string h1 = Driver.FindElement(pageObjects.byH1).Text;

            IList<string> h2 = Driver.FindElements(pageObjects.byH2).Select(x => x.Text).ToList();
            IList<string> para = Driver.FindElements(pageObjects.byP).Select(x => x.Text).ToList();

            var jsonString = new JsonObjects()
            {
                metaTitle = title,
                metaDescription = desc,
                headingOneTag = h1,
                headingTwoTags = new List<HeadingTwoTag> { new HeadingTwoTag { heading2Value = JsonConvert.SerializeObject(h2) } },
                paragraphTags = new List<ParagraphTag> { new ParagraphTag { paragraphValue = JsonConvert.SerializeObject(para) } }
            };

            jsonSerialize = JsonConvert.SerializeObject(jsonString);
        }

        [Then(@"Save tags on JSON")]
        public void ThenSaveTagsOnJSON()
        {
            WriteJsonFile.WriteToFile(jsonSerialize);
        }
    }
}
