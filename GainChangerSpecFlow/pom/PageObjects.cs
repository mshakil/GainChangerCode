using OpenQA.Selenium;

namespace GainChangerSpecFlow
{
    public class PageObjects
    {
        public By byUserNameTextBox = By.Id("username");
        public By byPasswordTextBox = By.Id("password");
        public By byLoginButton = By.Id("submit");

        //

        public By byWidgetContainer = By.XPath("//div[@class='elementor-widget-container']/h1");

        public By byFirstArticle = By.XPath("//article[1]/div/a");
        public By byReadTime = By.XPath("//span[contains(@class,'span-reading-time')]/..");

        public By byMetaTitle = By.XPath("//meta[@property='og:title']");
        public By byMetaDescription = By.XPath("//meta[@property='og:description']");

        public By byH1 = By.TagName("h1");
        public By byH2 = By.TagName("h2");
        public By byP = By.TagName("p");
    }
}
