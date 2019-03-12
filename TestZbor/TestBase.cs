using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using System.Threading;
using NUnit.Framework;

namespace TestZbor
{
	[TestFixture]
	class TestTemp : BaseSelenium
	{
		[OneTimeSetUp]
		public void StartBrowser()
		{
			BaseUrl = new Uri("https://zbor.md");
		}

		[Test]
		public void StartTest()
		{
			webDriver.Navigate().GoToUrl("https://zbor.md");
			webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div/div[1]/div/div[1]/div/div/div[2]/label")).Click();
			var dest1 = webDriver.FindElement(By.Id("dest-1"));

			Wait(TimeSpan.FromSeconds(10), (webDriver) => webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div/div[1]/div/div[1]/div/div/div[2]/label")).Displayed);


		}

		[TearDown]
		public void CloseBrowser()
		{
			//driver.Close();
		}
	}

}
