using System.Collections.Generic;

namespace TanganTask.Interfaces
{
    interface IMailBox
    {
        //IMailBox(){} интерфейсы не могут иметь конструкторов
        void Connect(string login, string password, string server, int port, bool ssl);
        List<string> GetLastTenMessages();
    }
}