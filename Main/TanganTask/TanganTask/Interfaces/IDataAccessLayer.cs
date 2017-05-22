using System;

namespace TanganTask.Interfaces
{
    interface IDataAccessLayer
    {
        void LastCheck();
        void Check(DateTime date);
    }
}
