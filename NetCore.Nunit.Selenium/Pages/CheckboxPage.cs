using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace NetCore.Nunit.Selenium.Pages
{
    public class CheckboxPage
    {
        private RemoteWebDriver _driver;

        private IWebElement AgeSelectionCheckBox => _driver.FindElementById("isAgeSelected");
        private IWebElement MessageLabel => _driver.FindElementById("txtAge");

        public CheckboxPage(RemoteWebDriver driver)
        {
            _driver = driver;
        }

        public void SelectAgeCheckbox()
        {
            AgeSelectionCheckBox.Click();
        }

        public string GetOutputMessage()
        {
            return MessageLabel.GetAttribute("innerHTML");
        }
    }
}
