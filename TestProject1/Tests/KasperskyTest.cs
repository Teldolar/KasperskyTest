using System.Runtime.InteropServices;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Configurations;
using Aquality.Selenium.Core.Waitings;
using NUnit.Framework;
using TestProject1.Utils;

namespace TestProject1.Tests
{
    public class KasperskyTest : BaseTest
    {
        private ITimeoutConfiguration _timeoutConfiguration = AqualityServices.Get<ITimeoutConfiguration>();
        private readonly IConditionalWait _wait = AqualityServices.ConditionalWait;
        
        private MailUtil _mailUtil;
        private PageObjectUtil _pageObjectUtil;

        private static object[] GetTestCase()
        {
            AqualityServices.Logger.Debug("Get test cases");
            return ExcelUtil.GetAllRawsFromExcel("Task1.xls");
        }

        

        [Test, TestCaseSource(nameof(GetTestCase))]
        public void Test1(string email, string password, string osName, string productName)
        {
            _mailUtil = new MailUtil(email, password);
            _pageObjectUtil = new PageObjectUtil(productName, osName, email, password);
            _mailUtil.SetStartCountOfMessage();
            AqualityServices.Logger.Debug("Go to kaspersky login form");
            Driver.GoTo(JsonReader.GetValueByKey("Resources\\settings.json","url"));
            _wait.WaitFor(() => _pageObjectUtil.IsLoginFormDisplayed(),_timeoutConfiguration.PageLoad);
            _pageObjectUtil.LoginSite();
            _wait.WaitFor(() => _pageObjectUtil.IsMenuFormDisplayed(),_timeoutConfiguration.PageLoad);
            _pageObjectUtil.ClickDownloadButton();
            _wait.WaitFor(() => _pageObjectUtil.IsDownloadFormDisplayed(),_timeoutConfiguration.PageLoad);
            _wait.WaitFor(() => _mailUtil.HasMail(),_timeoutConfiguration.Command);
            Assert.IsTrue(_mailUtil.GetLink(_mailUtil.GetMessageText()).Contains("Download"),"Message hasn't download link");
        }
    }
}