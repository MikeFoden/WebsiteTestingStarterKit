using System;
using System.Diagnostics;
using System.IO;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;

namespace Tests
{
    #region Selenium Test Fixture

    public class SeleniumFixture : IDisposable
    {
        public readonly FirefoxDriver driver;
        private readonly Process server;

        public SeleniumFixture()
        {
            server = Process.Start(new ProcessStartInfo
            {
                FileName = "dnx",
                Arguments = "web",
                WorkingDirectory = Path.Combine(Directory.GetCurrentDirectory(), "..", "Web")
            });
            driver = new FirefoxDriver();
        }

        public void Dispose()
        {
            server.Kill();
            driver.Dispose();
        }
    }

    [CollectionDefinition("Selenium Collection")]
    public class SeleniumCollection : ICollectionFixture<SeleniumFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

    #endregion

    [Collection("Selenium Collection")]
    public class TestBase
    {
        public SeleniumFixture fixture;
        public IWebDriver driver;

        /// <summary>
        /// Determines whether the element is present on a page.
        /// </summary>
        /// <param name="by">The parameters to the element</param>
        /// <returns>True if the element is found, false if the element is not found.</returns>
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException e)
            {
                // Element wasn't found, return false
                return false;
            }
        }

        /// <summary>
        /// Instructs the driver to navigate to the specified URL.
        /// </summary>
        /// <param name="url">A website url (starting with http or https)</param>
        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
