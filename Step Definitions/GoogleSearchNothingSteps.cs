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
     public class GoogleSearchNothingSteps
     {
          IWebDriver driver;
        string itemName;
        public GoogleSearchNothingSteps() => driver = new FirefoxDriver();

         [Given(@"I have accessed https://www\.google\.co\.in")]
         public void GivenIHaveAccessedGoogleByEnteringHttpsWww_Google_Co_InInTheURLBox()
         {
            driver.Navigate().GoToUrl("https://www.google.co.in");
         }


         [Given(@"I didn't enter anything in the search bar")]
         public void GivenIDidntEnterAnythingInTheSearchBar()
         {
             //NOTHING
         }

         [When(@"I press the search button")]
         public void WhenIPressTheSearchButton()
         {  
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(d => d.FindElement(By.XPath("//*[@id='tsf']/div[2]/div[1]/div[3]/center/input[1]")));
            ((IJavaScriptExecutor) driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Actions action = new Actions(driver);
            action.MoveToElement(element);
            action.Click();
            action.Perform();
         }

         [Then(@"nothing occurs")]
         public void ThenNothingOccurs()
         {
            Assert.IsTrue(driver.Url.ToLower().Equals("https://www.google.co.in/"));
         }
     }
 }