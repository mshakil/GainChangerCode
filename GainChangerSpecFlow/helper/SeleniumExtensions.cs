using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace GainChangerSpecFlow
{
    public static class SeleniumExtensions
    {
        public static IWebElement FindElementWithFluentWait(IWebDriver driver, By selector)
        {
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
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
    }
}
