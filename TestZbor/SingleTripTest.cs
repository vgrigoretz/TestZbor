using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace TestZbor
{
	class SingleTripTest : Driver
	{

		[Test]
		public void StartSingleTripTest()
		{

			string origin = "Chisinau";
			string destination = "Bucuresti";
			DateTime departDate = new DateTime(2019, 03, 23);
			By singleTrip = By.CssSelector(".text-center.chsrcmode.radio-route-1");
			var zborPage = new VarClass(driver, wait);

			zborPage.SelectTrip(singleTrip);
			zborPage.SourceCity(origin);
			zborPage.DestCity(destination);
			zborPage.GoDate(departDate.ToString("yyyyMMdd"));
			zborPage.AddPersons(3);
			zborPage.Search();

			wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".list-inline.list-recomanded")));

			//zborPage.sortCheapest();
			zborPage.sortConvinient();

			var temp = driver.FindElements(By.XPath("//span[contains(text(),'EUR')]"));
			Assert.IsNotNull(temp);

			CloseDriver();
		}

	}

}
