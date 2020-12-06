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
     public class AccessoriesCategorySteps
     {
        IWebDriver driver;
        string itemName;
        IWebElement Wear;
        public AccessoriesCategorySteps() => driver = new FirefoxDriver();

         [Given(@"I have navigated to site index page")]
         public void GivenIHaveNavigatedToSiteIndexPage()
         {
            driver.Navigate().GoToUrl("https://adoring-pasteur-3ae17d.netlify.app/index.html");
            Assert.IsTrue(driver.Title.ToLower().Contains("elite shoppy")); 
         }

         [Given(@"I have clicked on Mens wear")]
         public void GivenIHaveClickedOnMensWear()
         {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            this.Wear = wait.Until(d => d.FindElement(By.XPath("//li[@class='dropdown menu__item']")));
            Wear.Click();
         }

         [When(@"I press the accessories button on the pop-up window")]
         public void WhenIPressTheAccessoriesButtonOnThePop_UpWindow()
         {
            var element = Wear.FindElement(By.XPath("//div[@class='col-sm-3 multi-gd-img'][2]/ul/li/a"));
            element.Click();
         }

         [Then(@"I should be now shown only products belonging to the accessories category")]
         public void ThenIShouldBeNowShownOnlyProductsBelongingToTheClothesCategory()
         {
            Assert.IsTrue(driver.Url.ToLower().Contains("accessories"));
         }
     }
 }