using System;

namespace TanganTask.DAL.Interfaces
{
    interface IDataAccessLayer
    {
        string LastCheck();
        void Check(DateTime date);
    }
}
