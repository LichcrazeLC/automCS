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
    public class QuickViewFeatureSteps
    {
        IWebDriver driver;
        string itemName;
        public QuickViewFeatureSteps() => driver = new FirefoxDriver();

        [Given(@"I have navigated to mens or womens wear page")]
        public void GivenIHaveNavigatedToMensOrWomensWearPage()
        {
            driver.Navigate().GoToUrl("https://adoring-pasteur-3ae17d.netlify.app/mens.html");
            Assert.IsTrue(driver.Title.ToLower().Contains("elite shoppy")); 
        }

        [Given(@"I have hovered over one of the products displayed on the page")]
        public void GivenIHaveHoveredOverOneOfTheProductsDisplayedOnThePage()
        {
           //Doing a MouseHover  
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(d => d.FindElement(By.XPath("//div[@class='inner-men-cart-pro']")));
            ((IJavaScriptExecutor) driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);

            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }

        [When(@"I press the quick view button that pops up")]
        public void WhenIPressTheQuickViewButtonThatPopsUp()
        {
            //Clicking the SubMenu on MouseHover
            itemName = driver.FindElement(By.XPath("//div[@class='item-info-product ']/h4/a")).GetAttribute("text");  
            var menuelement = driver.FindElement(By.XPath("//a[@class='link-product-add-cart']"));
            menuelement.Click();
        }

        [Then(@"I should be redirected to that product's page")]
        public void ThenIShouldBeRedirectedToThatProductsPage()
        {   
            driver.Navigate().Refresh();
            var element = driver.FindElement(By.XPath("//div[@class='col-md-8 single-right-left simpleCart_shelfItem']/h3")).Text;
            Assert.IsTrue(element.ToLower().Equals(itemName.ToLower()));
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