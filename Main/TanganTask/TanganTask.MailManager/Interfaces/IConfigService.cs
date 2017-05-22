namespace TanganTask.MailManager.Interfaces
{
    interface IConfigService
    {
        string Pop3Server { get; }
        int Pop3Port { get; }
        bool Pop3SSL { get; }
        string ImapServer { get; }
        int ImapPort { get; }
        bool ImapSSL { get; }
    }
}