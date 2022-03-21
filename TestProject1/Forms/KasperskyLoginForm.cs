using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TestProject1.Forms
{
    public class KasperskyLoginForm : Form
    {
        private ITextBox EmailInput => ElementFactory.GetTextBox(By.XPath("//input[@name='email']"), "EmailInput");
        private ITextBox PasswordInput => ElementFactory.GetTextBox(By.XPath("//input[@name='password']"), "PasswordInput");
        private IButton LoginButton => ElementFactory.GetButton(By.XPath("//button[@type='submit']"), "LoginButton");
        private IButton CookiesAcceptButton => ElementFactory.GetButton(By.XPath("//*[@id='CybotCookiebotDialogBodyLevelButtonAccept']"),"CookiesAcceptButton");
        
        public KasperskyLoginForm() : base(By.XPath("//button[@type='submit']"), "loginButton")
        {
        }

        public void Login(string email,string password)
        {
            CookiesAcceptButton.Click();
            EmailInput.ClearAndType(email);
            PasswordInput.ClearAndType(password,true);
            LoginButton.Click();
        }
    }
}