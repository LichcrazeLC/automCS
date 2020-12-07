 using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Remote;

 namespace MyNamespace
 {
     [Binding]
     public class GooglePageAccessSteps
     {
        IWebDriver driver;
        string itemName;
        public GooglePageAccessSteps() => driver = new FirefoxDriver();


         [Given(@"I have accessed google by entering https://www\.google\.co\.in in the URL box")]
         public void GivenIHaveAccessedGoogleByEnteringHttpsWww_Google_Co_InInTheURLBox()
         {
            driver.Navigate().GoToUrl("https://www.google.co.in");
         }

         [Then(@"the google page should display properly")]
         public void ThenTheGooglePageShouldDisplayProperly()
         {
            Assert.IsTrue(driver.Title.ToLower().Contains("google")); 
         }
     }
 }