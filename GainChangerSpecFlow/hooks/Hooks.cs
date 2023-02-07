using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace GainChangerSpecFlow
{
    [Binding]
    public sealed class Hooks : DriverHelper
    {

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("start-maximized", "no-sandbox");
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;


            new DriverManager().SetUpDriver(new ChromeConfig());
            Console.WriteLine("Setup");

            Driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), chromeOptions, TimeSpan.FromSeconds(60));
            Driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(30));
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