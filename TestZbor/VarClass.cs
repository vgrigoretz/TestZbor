using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestZbor
{
	public class VarClass
	{
		private IWebDriver driver;
		private WebDriverWait wait;

		public VarClass(IWebDriver driver, WebDriverWait wait)
		{
			this.driver = driver;
			this.wait = wait;
		}

		public void SourceCity(string city)
		{
			By City = By.Id("dest-1");
			var sourceCity = driver.FindElement(City);
			sourceCity.Clear();
			sourceCity.SendKeys(city);
			wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("ui-menu-item")));
			sourceCity.SendKeys(Keys.ArrowDown);
			sourceCity.SendKeys(Keys.Enter);
		}

		public void DestCity(string city)
		{
			By City = By.Id("dest-2");
			var destCity = driver.FindElement(City);
			destCity.Clear();
			destCity.SendKeys(city);
			wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ui-id-2")));
			destCity.SendKeys(Keys.ArrowDown);
			destCity.SendKeys(Keys.Enter);
		}

		public void GoDate(string date)
		{
			string myXPath = "//span[@data-value='" + date + "']";
			wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(myXPath))).Click();
		}

		public void ReturnDate(string returnDate)
		{
			driver.FindElement(By.Id("dt2")).Click();
			string myXPath = "//span[@data-value='" + returnDate + "']";
			wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(myXPath))).Click();
		}
	}
}
