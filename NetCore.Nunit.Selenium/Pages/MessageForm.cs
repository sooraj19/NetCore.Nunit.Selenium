using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace NetCore.Nunit.Selenium.Pages
{
    public class MessageForm
    {
        private RemoteWebDriver _driver;

        public MessageForm(RemoteWebDriver driver) => _driver = driver;

        private IWebElement MessageTextBox => _driver.FindElementById("user-message");
        private IWebElement FormSubmitButton => _driver.FindElementByXPath("//button[.='Show Message']");
        private IWebElement OutputLabel => _driver.FindElementById("display");

        public void SubmitMessage(string message)
        {
            _driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-first-form-demo.html");
            MessageTextBox.SendKeys(message); //Enter the message in text box            
            FormSubmitButton.Click();            
        }

        public void GotoCheckBoxPage()
        {
            _driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-checkbox-demo.html");
        }

        public string GetOutputMessage()
        {
            return OutputLabel.GetAttribute("innerHTML");
        }
    }
}
