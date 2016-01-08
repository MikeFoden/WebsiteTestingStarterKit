using System;
using Xunit;
using OpenQA.Selenium;

namespace Tests
{
    public class TestExample : TestBase, IDisposable
    {
        /// <summary>
        /// Initialise the class with the shared fixture from the base
        /// </summary>
        /// <param name="fixture"></param>
         public TestExample(SeleniumFixture fixture)
        {
            this.fixture = fixture;
            this.driver = fixture.driver;
        }

        /// <summary>
        /// Dispose anything that has been created in the loading of the Test Class.
        /// </summary>
        public void Dispose()
        {
        }

        [Fact]
        public void DriverWorks()
        {
            Assert.True(driver != null);
            NavigateToUrl("http://www.google.com");
            Assert.False(string.IsNullOrEmpty(driver.Title));
            Assert.Equal("Google", driver.Title);
            Assert.True(IsElementPresent(By.Id("hplogo")));
        }

        [Fact(Skip ="This test is just an example of a failing test.")]
        public void FailingTest()
        {
            Assert.True(driver != null, "Driver is not available.");
            NavigateToUrl("http://www.facebook.com");
            Assert.False(string.IsNullOrEmpty(driver.Title), "Title is missing");
            Assert.True(IsElementPresent(By.Id("hplogo")), "Logo does not exist.");
        }

        [Fact]
        public void FactTestExample()
        {
            NavigateToUrl("http://localhost:5000");
            Assert.Equal("Home Page - Web", driver.Title);
            Assert.True(IsElementPresent(By.Id("pageTitle")));
            Assert.Equal("Hello World.", driver.FindElement(By.Id("pageTitle")).Text);
        }

        [Theory]
        [InlineData("http://localhost:5000")]
        public void TheoryTestExample(string url)
        {
            NavigateToUrl(url);
            Assert.Equal("Home Page - Web", driver.Title);
            Assert.True(IsElementPresent(By.Id("pageTitle")));
            Assert.Equal("Hello World.", driver.FindElement(By.Id("pageTitle")).Text);
        }
    }
}