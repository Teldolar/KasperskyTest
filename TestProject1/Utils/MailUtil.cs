using System;
using Aquality.Selenium.Browsers;
using MailKit.Net.Pop3;
using MimeKit.Text;

namespace TestProject1.Utils
{
    public class MailUtil
    {
        private int _startCountOfMessages;
        private readonly string _login;
        private readonly string _password;
        
        public MailUtil(string login, string password)
        {
            _login = login;
            _password = password;
        }
        
        public string GetMessageText()
        {
            AqualityServices.Logger.Debug("Getting message from email");
            return GetConnection().GetMessage(GetConnection().GetMessageCount()-1).GetTextBody(TextFormat.Text);
        }
        
        public void SetStartCountOfMessage()
        {
            AqualityServices.Logger.Debug("Get start count of message");
            _startCountOfMessages = GetConnection().Count;
        }
        
        public bool HasMail()
        {
            AqualityServices.Logger.Debug("Check mail for download link");
            return GetConnection().Count!=_startCountOfMessages;
        }
         
        private Pop3Client GetConnection()
        {
            var client = new Pop3Client();
            client.Connect("pop.gmail.com", 995, true);
            client.Authenticate(_login,_password);
            return client;
        }

        public string GetLink(string message)
        {
            AqualityServices.Logger.Debug("Getting download link in message");
            var open = message.IndexOf("(", StringComparison.Ordinal);
            var close = message.IndexOf(")", StringComparison.Ordinal);
            var s = message[..close];
            var substring = s[(open+1)..];
            return substring;
        }
    }
}