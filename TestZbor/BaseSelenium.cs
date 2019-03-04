using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;

namespace TestZbor
{
	public class BaseSelenium
	{
		protected Uri BaseUrl { get; set; }
		protected IWebDriver webDriver;

		[OneTimeSetUp]
		public void Init()
		{
			webDriver = GetFirefox();
		}

		private IWebDriver GetFirefox()
		{
			return new FirefoxDriver();
		}
		private IWebDriver GetHeadlessChrome()
		{
			var fireofxOptions = new FirefoxOptions();
			fireofxOptions.AddArguments(new List<string>() {
				"--silent-launch",
				"--no-startup-window",
				"no-sandbox",
				"headless"});

			var firefoxDriverService = FirefoxDriverService.CreateDefaultService();
			firefoxDriverService.HideCommandPromptWindow = true;    // This is to hidden the console.
			var driver = new FirefoxDriver(firefoxDriverService, fireofxOptions);
			return driver;
		}

		[OneTimeTearDown]
		public void CleanUp()
		{
			if (webDriver != null)
				webDriver.Dispose();
		}

		protected void BrowserWindowMaximize()
		{
			webDriver.Manage().Window.Maximize();
		}

		protected void Wait(TimeSpan waitTime, Func<IWebDriver, bool> condition)
		{
			var webDriverWait = new WebDriverWait(webDriver, waitTime);
			webDriverWait.Until(condition);
		}

		protected TimeSpan DefaultMaxPageLoadWaitTime = TimeSpan.FromSeconds(10);
		protected void WaitPageLoad(TimeSpan? waitTime = null)
		{
			var webDriverWait = new WebDriverWait(webDriver, waitTime ?? DefaultMaxPageLoadWaitTime);
			webDriverWait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
		}
	}
}
