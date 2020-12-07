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
     public class GoogleSearchResultNumberSteps
     {
        IWebDriver driver;
        string itemName;
        string searchKeyword;
        public GoogleSearchResultNumberSteps() => driver = new FirefoxDriver();

         [Given(@"I accessed the google home page https://www\.google\.com/ncr")]
         public void GivenIAccessedTheGoogleHomePageHttpsWww_Google_ComNcr()
         {
             driver.Navigate().GoToUrl("https://www.google.com/ncr");
         }

         [Given(@"I searched for (.*) in the search bar")]
         public void GivenISearchedForAnythingInTheSearchBar(string searchString)
         {
            this.searchKeyword = searchString.ToLower();  
            var searchInputBox = driver.FindElement(By.XPath("//*[@id='tsf']/div[2]/div[1]/div[1]/div/div[2]/input"));  
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));  
            searchInputBox.SendKeys(searchKeyword);  
         }

         [When(@"I search")]
         public void WhenISearch()
         {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(d => d.FindElement(By.XPath("//*[@id='tsf']/div[2]/div[1]/div[2]/div[2]/div[2]/center/input[1]")));
            ((IJavaScriptExecutor) driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Actions action = new Actions(driver);
            action.MoveToElement(element);
            action.Click();
            action.Perform();
         }

         [Then(@"google returns the right result number")]
         public void ThenGoogleReturnsTheRightResultNumber()
         {
            //ASSERT ELEMENT NUMBER IS RIGHT??
         }
     }
 }