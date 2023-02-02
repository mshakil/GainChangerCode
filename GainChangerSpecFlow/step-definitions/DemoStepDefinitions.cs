using System;
using TechTalk.SpecFlow;

namespace GainChangerSpecFlow
{
    [Binding]
    public class DemoStepDefinitions
    {
        [Given(@"I have enterned number")]
        public void GivenIHaveEnternedNumber()
        {
            Console.WriteLine("Login");
        }

        [When(@"I entered second number")]
        public void WhenIEnteredSecondNumber()
        {
            Console.WriteLine("Test1");
        }

        [Then(@"Result showed on screen")]
        public void ThenResultShowedOnScreen()
        {
            Console.WriteLine("Output");
        }
    }
}
