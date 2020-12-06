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
    public class SearchFeatureSteps
    {
        IWebDriver driver;
        string searchKeyword;
        public SearchFeatureSteps() => driver = new FirefoxDriver();

        [Given(@"I have navigated to home page")]
        public void GivenIHaveNavigatedToHomePage()
        {
            driver.Navigate().GoToUrl("https://adoring-pasteur-3ae17d.netlify.app/index.html");
            Assert.IsTrue(driver.Title.ToLower().Contains("elite shoppy")); 
        }

         [Given(@"I have entered (.*) as a keyword I want to search for")]
         public void GivenIHaveEnteredAKeywordIWantToSearchFor(String searchString)
         {
            this.searchKeyword = searchString.ToLower();  
            var searchInputBox = driver.FindElement(By.XPath("//input[@type='search']"));  
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));  
            searchInputBox.SendKeys(searchKeyword);  
         }

         [When(@"I press the search button next to the search bar")]
         public void WhenIPressTheSearchButtonNextToTheSearchBar()
         {
            var searchSubmit = driver.FindElement(By.XPath("//input[@type='submit']"));
            searchSubmit.Click();
         }

         [Then(@"I should be redirected to a page with my search results")]
         public void ThenIShouldBeRedirectedToAPageWithMySearchResults()
         {
            Assert.IsTrue(driver.Url.ToLower().Contains(searchKeyword));  
            Assert.IsTrue(driver.Title.ToLower().Contains(searchKeyword)); 
         }

        public void Dispose()
        {
            if (driver != null)
            {
                driver.Dispose();
                driver = null;
            }
        }
    }
}