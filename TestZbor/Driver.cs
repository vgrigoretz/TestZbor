using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace TestZbor
{
	public class Driver
	{
		public IWebDriver driver;
		public WebDriverWait wait;

		[SetUp]
		public void StartBrowser()
		{
			driver = new FirefoxDriver();
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
		}

		[TearDown]
		public void CloseDriver()
		{
			driver.Quit();
		}
	}
}
