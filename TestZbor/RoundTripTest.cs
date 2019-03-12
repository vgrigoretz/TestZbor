using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace TestZbor
{
	class RoundTripTest : Driver
	{

		[Test]
		public void StartRoundTripTest()
		{

			string origin = "Bucuresti";
			string destination = "Kiev";
			DateTime departDate = new DateTime(2019, 03, 23);
			DateTime arriveDate = new DateTime(2019, 04, 18);
			By roundTrip = By.CssSelector(".text-center.chsrcmode.radio-route-2");
			var zborPage = new VarClass(driver, wait);

			zborPage.SelectTrip(roundTrip);
			zborPage.SourceCity(origin);
			zborPage.DestCity(destination);
			zborPage.GoDate(departDate.ToString("yyyyMMdd"));
			zborPage.ReturnDate(arriveDate.ToString("yyyyMMdd"));
			zborPage.AddPersons(5);
			zborPage.Search();

			wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".list-inline.list-recomanded")));

			zborPage.sortCheapest();
			//zborPage.sortConvinient();

			var temp = driver.FindElements(By.XPath("//span[contains(text(),'EUR')]"));
			Assert.IsNotNull(temp);

			CloseDriver();
		}

	}

}
