using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Remote;

namespace Lab5
{
    [TestFixture]
	class RedditFunc						
    {
        IWebDriver driver;

        [SetUp]
        public void TestSetup()
        {
            driver = new FirefoxDriver();
        }

        [Test]
		public void TestHeader()
        {
            driver.Navigate().GoToUrl("https://www.reddit.com");
            driver.FindElement(By.Name("q")).SendKeys("Computer"+ Keys.Return);
            bool exists = driver.FindElement(By.XPath("//header[1]")) != null;
            Assert.IsTrue(exists);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
}