using System;
using System.Configuration;
using TanganTask.MailManager.Interfaces;

namespace TanganTask.MailManager.Config
{
    public class ConfigService : IConfigService
    {
        private static ConfigService _service;
        private ConfigService() { }
        public static ConfigService Singleton()
        {
            if (_service == null)
            {
                _service = new ConfigService();
                return _service;
            }
            return _service;
        }
        public string Pop3Server
        {
            get
            {
                AppSettingsReader reader = new AppSettingsReader();
                return reader.GetValue("Pop3Server", typeof(string)).ToString();
            }
        }

        public int Pop3Port
        {
            get
            {
                AppSettingsReader reader = new AppSettingsReader();
                var stringSetting = (int)reader.GetValue("Pop3Port", typeof(int));
                return stringSetting;
            }
        }

        public bool Pop3SSL
        {
            get
            {
                AppSettingsReader reader = new AppSettingsReader();
                try
                {
                    return Convert.ToBoolean(reader.GetValue("Pop3SSL", typeof (string)));
                }
                catch (Exception)
                {
                    Console.WriteLine("Unvalid SSL");
                    return false;
                }
            }
        }
        public string ImapServer
        {
            get
            {
                AppSettingsReader reader = new AppSettingsReader();
                var value = reader.GetValue("ImapServer", typeof (string)).ToString();
                return value;
            }
        }

        public int ImapPort
        {
            get
            {
                AppSettingsReader reader = new AppSettingsReader();
                var stringSetting = (int) reader.GetValue("ImapPort", typeof(int));
                return stringSetting;
            }
        }

        public bool ImapSSL
        {
            get
            {
                AppSettingsReader reader = new AppSettingsReader();
                try
                {
                    return Convert.ToBoolean(reader.GetValue("ImapSSL", typeof(string)));
                }
                catch (Exception)
                {
                    Console.WriteLine("Unvalid SSL");
                    return false;
                }
            }
        }

        public string SmtpServer
        {
            get
            {
                AppSettingsReader reader = new AppSettingsReader();
                var value = reader.GetValue("SmtpServer", typeof(string)).ToString();
                return value;
            }
        }

        public int SmtpPort
        {
            get
            {
                AppSettingsReader reader = new AppSettingsReader();
                var stringSetting = (int)reader.GetValue("SmtpPort", typeof(int));
                return stringSetting;
            }
        }

        public bool SmtpSSL
        {
            get
            {
                AppSettingsReader reader = new AppSettingsReader();
                try
                {
                    return Convert.ToBoolean(reader.GetValue("SmtpSSL", typeof(string)));
                }
                catch (Exception)
                {
                    Console.WriteLine("Unvalid SSL");
                    return false;
                }
            }
        }
    }
}