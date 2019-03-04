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
	public class Test
	{
		IWebDriver driver;
		WebDriverWait wait;

		[SetUp]
		public void StartBrowser()
		{
			driver = new FirefoxDriver();
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
		}

		[Test]
		public void StartTest()
		{
			driver.Navigate().GoToUrl("https://zbor.md");
			driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div/div[1]/div/div[1]/div/div/div[2]/label")).Click();
			var dest1 = driver.FindElement(By.Id("dest-1"));
			dest1.Clear();
			dest1.SendKeys("Bucu");
			wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("ui-menu-item")));
			dest1.SendKeys(Keys.ArrowDown);
			dest1.SendKeys(Keys.Enter);

			var dest2 = driver.FindElement(By.Id("dest-2"));
			dest2.Clear();
			dest2.SendKeys("Kiev");
			wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ui-id-2")));
			dest2.SendKeys(Keys.ArrowDown);
			dest2.SendKeys(Keys.Enter);

			var date1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[1]/div[2]/div/div[2]/div/div[2]/div[3]/div[1]/div[3]/div[4]/span[6]")));
			date1.Click();

			var date2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[1]/div[2]/div/div[2]/div/div[2]/div[3]/div[2]/div[3]/div[1]/span[4]")));
			date2.Click();

			var person = driver.FindElement(By.Id("persons-summary"));
			person.Click();
			driver.FindElement(By.ClassName("person-add")).Click();

			var search = driver.FindElement(By.Id("search"));
			search.Click();

			wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div[1]/div[2]/div/div[2]/div/div/div[2]/div/div[2]/ul")));

			var sort = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div/div[2]/div/div/div[3]/div[1]/div[1]/div/label[1]"));
			sort.Click();

			//var temp = driver.FindElements(By.PartialLinkText("EUR"));
			//Console.WriteLine(temp.ToString());
		}

		[TearDown]
		public void CloseBrowser()
		{
			//driver.Close();
		}
	}

}
