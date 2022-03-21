using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TestProject1.Forms
{
    public class MenuForm : Form
    {
        private ILink Download =>
            ElementFactory.GetLink(Locator,
                Name);
        
        public MenuForm() : base(By.XPath("//*[contains(@class, 'downloads') and contains(@class,'navigation')]"), "DownloadLink")
        {
        }

        public void GoToDownload()
        {
            Download.Click();
        }
    }
}