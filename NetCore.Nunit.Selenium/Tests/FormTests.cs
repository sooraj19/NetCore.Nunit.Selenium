using NetCore.Nunit.Selenium.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace NetCore.Nunit.Selenium.Tests
{
    [TestFixture]
    public class FormTests
    {
        [Test]
        public void Verify_Message_Filled_In_Form_Displayed_AsExpected()
        {            
            var chromeOptions = new ChromeOptions();            
            chromeOptions.PlatformName = "windows";
            chromeOptions.AddArgument("--start-maximized");
            var driver = new RemoteWebDriver(new Uri("http://localhost:4445/wd/hub"), chromeOptions.ToCapabilities());

            var formPage = new MessageForm(driver);
            var testMessage = "Hello World..";
            formPage.SubmitMessage(testMessage);
            var actualMessage = formPage.GetOutputMessage();

            Assert.AreEqual(testMessage, actualMessage, "Actual Message on form page doesn't match expected message");

            //Navigate to the checkbox page
            formPage.GotoCheckBoxPage();

            var checkboxPage = new CheckboxPage(driver);
            checkboxPage.SelectAgeCheckbox();
            var expectedCheckboxMessage = "Success - Check box is checked";
            var actualCheckboxMessage = checkboxPage.GetOutputMessage();
            Assert.AreEqual(expectedCheckboxMessage, actualCheckboxMessage);

            driver?.Quit();
            Console.WriteLine("Driver Disposed Successfully..");
        }
    }
}
