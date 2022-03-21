using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Visualization;
using Aquality.Selenium.Core.Waitings;
using Aquality.Selenium.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using ElementFactory = Aquality.Selenium.Core.Elements.ElementFactory;

namespace TestProject1.Forms
{
    public class DownloadForm : Form
    {
        private readonly IConditionalWait _wait = AqualityServices.ConditionalWait;
        private readonly string _productName;
        private readonly string _osName;
        
        private static IButton Send =>
            ElementFactory.GetButton(By.XPath("//button[@data-at-selector='installerSendSelfBtn']"), "SendButton");

        private static IButton _productDownloadButton(string productName) => ElementFactory.GetButton(
            By.XPath(
                $"//*[@data-at-selector='downloadApplicationCard' and contains(.,'{productName}')]//button[@data-at-selector='appInfoSendToEmail']"),
            "ProductButton");

        private static IButton _osButton(string osName) => ElementFactory.GetButton(By.XPath(
            $"//*[contains(@Class,'js-osFilter') and contains(.,'{osName}')]"), "AcceptCaptcha");

        public DownloadForm(string productName, string osName) : base(By.ClassName("site-title"), "SiteTitle")
        {
            _productName = productName;
            _osName = osName;
        }

        private void ClickDownloadLink()
        {
            _osButton(_osName).Click();
            _productDownloadButton(_productName).Click();
        }

        private void SendMessage()
        {
            Send.Click();
        }

        private bool IsSendDisabled()
        {
            return Send.GetAttribute("disabled")!=null;
        }

        public void SendMail()
        {
            ClickDownloadLink();
            _wait.WaitFor(() => !IsSendDisabled());
            SendMessage();
        }
    }
}

    