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
     public class ClothingCategorySteps
     {
        IWebDriver driver;
        string itemName;
        IWebElement Wear;
        public ClothingCategorySteps() => driver = new FirefoxDriver();

         [Given(@"I have navigated to site home page")]
         public void GivenIHaveNavigatedToSiteHomePage()
         {
            driver.Navigate().GoToUrl("https://adoring-pasteur-3ae17d.netlify.app/index.html");
            Assert.IsTrue(driver.Title.ToLower().Contains("elite shoppy")); 
         }

         [Given(@"I have clicked on Mens wear or Womens wear")]
         public void GivenIHaveClickedOnMensWear()
         {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            this.Wear = wait.Until(d => d.FindElement(By.XPath("//li[@class='dropdown menu__item']")));
            Wear.Click();
         }

         [When(@"I press the clothing button on the pop-up window")]
         public void WhenIPressTheClothingButtonOnThePop_UpWindow()
         {
            var element = Wear.FindElement(By.XPath("//ul[@class='multi-column-dropdown']/li/a"));
            element.Click();
         }

         [Then(@"I should be now shown only products belonging to the clothes category")]
         public void ThenIShouldBeNowShownOnlyProductsBelongingToTheClothesCategory()
         {
            Assert.IsTrue(driver.Url.ToLower().Contains("clothing")); 
         }
     }
 }