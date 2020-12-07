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
     public class GoogleDidYouMeanSteps
     {
        IWebDriver driver;
        string itemName;
        string searchKeyword;
        public GoogleDidYouMeanSteps() => driver = new FirefoxDriver();

         [Given(@"I accessed https://www\.google\.com/ncr")]
         public void GivenIAccessedHttpsWww_Google_ComNcr()
         {
             driver.Navigate().GoToUrl("https://www.google.com/ncr");
         }

         [Given(@"I typed (.*) in the search bar")]
         public void GivenITypedAsDddInTheSearchBar(String searchString)
         {
            this.searchKeyword = searchString.ToLower();  
            var searchInputBox = driver.FindElement(By.XPath("//*[@id='tsf']/div[2]/div[1]/div[1]/div/div[2]/input"));  
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));  
            searchInputBox.SendKeys(searchKeyword);  
         }

         [When(@"I press search")]
         public void WhenIPressSearch()
         {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(d => d.FindElement(By.XPath("//*[@id='tsf']/div[2]/div[1]/div[2]/div[2]/div[2]/center/input[1]")));
            ((IJavaScriptExecutor) driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Actions action = new Actions(driver);
            action.MoveToElement(element);
            action.Click();
            action.Perform();
         }

         [Then(@"google proposes at least one Did You Mean option")]
         public void ThenGoogleProposesAtLeastOneDidYouMeanOption()
         {
            var didYouMeanSuggestion = driver.FindElement(By.XPath("//*[@id='Rlb3e']/div[2]/p/a"));
         }
     }
 }