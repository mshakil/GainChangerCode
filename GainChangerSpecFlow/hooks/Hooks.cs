using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium;

namespace GainChangerSpecFlow
{
    [Binding]
    public sealed class Hooks : DriverHelper
    {

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("start-maximized");
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
            //chromeOptions.AddArguments("--headless");

            new DriverManager().SetUpDriver(new ChromeConfig());
            Console.WriteLine("Setup");

            Driver = new ChromeDriver(chromeOptions);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario

            Driver.Close();
            Driver.Quit();
        }
    }
}