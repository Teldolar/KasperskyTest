using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Waitings;
using TestProject1.Forms;

namespace TestProject1.Utils
{
    public class PageObjectUtil
    {
        private readonly KasperskyLoginForm _kasperskyLoginForm = new();
        private readonly DownloadForm _downloadForm;
        private readonly MenuForm _menuForm = new();
        private readonly string _login;
        private readonly string _password;
        
        public PageObjectUtil(string productName,string osName,string login,string password)
        {
            _login = login;
            _password = password;
            _downloadForm = new DownloadForm(productName,osName);
        }

        public void LoginSite()
        {
            AqualityServices.Logger.Debug("Go to menu form");
            _kasperskyLoginForm.Login(_login,_password);
        }

        public void ClickDownloadButton()
        {
            AqualityServices.Logger.Debug("Go to download form");
            _menuForm.GoToDownload();
            _downloadForm.SendMail();
        }
        
        public bool IsLoginFormDisplayed()
        {
            AqualityServices.Logger.Debug("Check that login form is displayed");
            return _kasperskyLoginForm.State.IsDisplayed;
        }
        
        public bool IsMenuFormDisplayed()
        {
            AqualityServices.Logger.Debug("Check that menu is displayed");
            return _menuForm.State.IsDisplayed;
        }
        
        public bool IsDownloadFormDisplayed()
        {
            AqualityServices.Logger.Debug("Check that download form is displayed");
            return _downloadForm.State.IsDisplayed;
        }
    }
    
    
}