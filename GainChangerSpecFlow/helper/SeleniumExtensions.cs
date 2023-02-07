using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace GainChangerSpecFlow
{
    public static class SeleniumExtensions
    {
        const int FINDELEMENT_TIME_OUT = 30;
        public static IWebElement FindElementWithFluentWait(IWebDriver driver, By selector)
        {
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(FINDELEMENT_TIME_OUT))
            {
                PollingInterval = TimeSpan.FromSeconds(5)
            };
            driverWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            IWebElement element = driverWait.Until(drv => drv.FindElement(selector));

            return element;
        }

        public static void ScrollToElement(IWebDriver driver, IWebElement element)
        {
            WheelInputDevice.ScrollOrigin origin = new WheelInputDevice.ScrollOrigin
            {
                Element = element
            };
            new Actions(driver).ScrollFromOrigin(origin, 0, 200).Perform();
        }

        public static IWebElement FindElementWithWait(IWebDriver driver, By selector)
        {
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(FINDELEMENT_TIME_OUT));
            IWebElement firstResult = driverWait.Until(e => e.FindElement(selector));

            return firstResult;
        }
    }
}
