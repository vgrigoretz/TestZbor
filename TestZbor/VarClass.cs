using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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

		public void SelectTrip(By tripType)
		{
			driver.Navigate().GoToUrl("https://zbor.md");
			driver.FindElement(tripType).Click();
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

		public void GoDate(string goDate)
		{
			string goXPath = "//span[@data-value='" + goDate + "']";
			var date1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(goXPath)));
			date1.Click();
		}

		public void ReturnDate(string returnDate)
		{
			string returnXPath = "//span[@data-value='" + returnDate + "']";
			var date2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(returnXPath)));
			//driver.SwitchTo().ActiveElement(); - unselectable on "inactive" dates
			date2.Click();
		}

		public void AddPersons(int nrPersons)
		{
			var person = driver.FindElement(By.Id("persons-summary"));
			person.Click();

			for (int i = 1; i < nrPersons; i ++)
			{
				driver.FindElement(By.ClassName("person-add")).Click();
			}
		}

		public void Search()
		{
			var search = driver.FindElement(By.Id("search"));
			search.Click();
		}

		public void sortCheapest()
		{
			By cheapest = By.CssSelector(".btn.warning");
			wait.Until(ExpectedConditions.ElementToBeClickable(cheapest)).Click();
		}

		public void sortConvinient()
		{
			By recommended = By.Id("recommended");
			wait.Until(ExpectedConditions.ElementToBeClickable(recommended)).Click();
		}
	}
}
