using System.Collections.Generic;

namespace TanganTask.MailManager.Interfaces
{
    interface IMailBox
    {
        //IMailBox(){} интерфейсы не могут иметь конструкторов
        void Connect(string login, string password, string server, int port, bool ssl);
        List<string> GetLastTenSubjects();
    }
}